using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Donation.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http;
using System.Text;
using Web_Donation.Areas.Admin.Models;
using Microsoft.CodeAnalysis;

namespace Web_Donation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        // GET: /Admin/Home/Index
        private readonly IMongoCollection<Account> _accountCollection;
        private readonly IMongoCollection<ProjectModel> _projectCollection;
        private readonly IMongoCollection<Details> _detailsCollection;

        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(DbContext context, IHttpClientFactory httpClientFactory)
        {
            _accountCollection = context.GetAccountCollection();
            _projectCollection = context.GetProductCollection();
            _detailsCollection = context.GetDetailsCollection();
            _httpClientFactory = httpClientFactory;

        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult AddProduct()
        {
            return View();
        }
        public IActionResult AddAccount()
        {
            return View();
        }

        public IActionResult Details()
        {
            List<Details> details = _detailsCollection.Find(_id=>true).ToList();

            return View(details);
        }
        public IActionResult AddDetails()
        {
            List<ProjectModel> products = _projectCollection.Find(product => true).ToList();

            return View(products);
        }
        public IActionResult Product()
        {
            List<ProjectModel> products = _projectCollection.Find(product => true).ToList();
            return View(products);
        }
        public IActionResult Account()
        {
            List<Account> accounts = _accountCollection.Find(_id => true).ToList();
            return View(accounts);
        }


        public async Task<IActionResult> Index()
        {
            var httpClient = _httpClientFactory.CreateClient();
            string apiUrl = "https://u5wsu9qncf.execute-api.ap-south-1.amazonaws.com/viewBlock";
            httpClient.DefaultRequestHeaders.Add("x-api-key", "hutech_hackathon@123456");
            httpClient.DefaultRequestHeaders.Add("access-token", "phucphuctest123");
            // Check if the user is logged in
            if (HttpContext.Session.GetString("UserId") == null)
            {
                // If not logged in, redirect to the login page
                return RedirectToAction("Login");
            }

            var blocksResponse = await httpClient.GetAsync(apiUrl);
            Console.WriteLine(blocksResponse.ToString());
            if (blocksResponse.IsSuccessStatusCode)
            {
                var blocksContent = await blocksResponse.Content.ReadAsStringAsync();
                var blocks = JsonConvert.DeserializeObject<List<Block>>(blocksContent);

                var blockDetailsList = new List<BlockDetailsViewModel>();

                foreach (var block in blocks)
                {
                    var data = JsonConvert.DeserializeObject<BlockData>(block.Data);
                    var blockDetails = new BlockDetailsViewModel
                    {
                        Index = block.Index,
                        NameSender = data.name_sender,
                        Timestamp = block.Timestamp,
                        Sender = data.sender,
                        AccountNumber = data.account_number,
                        Amount = data.amount,
                        TransactionDate = data.transaction_date,
                        TransactionDescription = data.transactionDes,
                        PreviousHash = block.PreviousHash,
                        Hash = block.Hash
                    };
                    blockDetailsList.Add(blockDetails);
                }
                List<ProjectModel> products = _projectCollection.Find(product => true).ToList();

                var filteredBlockViewModelList = new List<FilteredBlockViewModel>();
                foreach (var product in products)
                {
                    var filteredBlocks = blockDetailsList.FindAll(b =>
                        b.TransactionDescription != null &&
                        b.TransactionDescription.Contains(product.Producid)
                    );

                    // Tính tổng Amount của filteredBlocks
                    decimal totalAmount = filteredBlocks.Sum(block => block.Amount);

                    var filteredBlockViewModel = new FilteredBlockViewModel
                    {
                        Product_ID = product.Producid,
                        FilteredBlocks = filteredBlocks,
                        TotalAmount = totalAmount // Thêm thuộc tính TotalAmount vào FilteredBlockViewModel
                    };

                    filteredBlockViewModelList.Add(filteredBlockViewModel);
                }

                return View(filteredBlockViewModelList);

            }

            // Handle the case where the API request fails
            return View("Error");
        }

        // GET: /Admin/Home/Login
       
 
      
        [HttpPost]
        public async Task<IActionResult> AddDetails(IFormCollection form, IFormFile Image1, IFormFile Image2, IFormFile Image3)
        {
            try
            {
                // Lấy dữ liệu từ form
                var IDProduct = form["IDProduct"];
                var timeBegin = form["time_begin"];
                var status = form["status"];
                var infoProduct = form["info_Product"];
                var infoDetails = form["info_Details"];
                var typeDonation = form["type_donation"];

                // Lưu ảnh vào thư mục root
                var imagePath1Task = SaveImageToRoot(Image1);
                var imagePath2Task = SaveImageToRoot(Image2);
                var imagePath3Task = SaveImageToRoot(Image3);
                
                var Details_ = new Details
                                {
                                    IDProduct = IDProduct,
                                    TimeBegin = DateTime.Parse(timeBegin),
                                    Status = status,
                                    InfoProduct = infoProduct,
                                    InfoDetails = infoDetails,
                                    TypeDonation = typeDonation,
                                    Image1 = imagePath1Task,
                                    Image2 = imagePath2Task,
                                    Image3 = imagePath3Task
                                };

                await _detailsCollection.InsertOneAsync(Details_);



                return RedirectToAction("Details"); // Chuyển hướng sau khi thêm dữ liệu thành công
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Xử lý lỗi nếu có
                ModelState.AddModelError("", "Lỗi khi thêm dữ liệu: " + ex.Message);
                return View(); // Chuyển hướng sau khi thêm dữ liệu thành công
            }
        }



        private string SaveImageToRoot(IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                try
                {
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img");

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    // Generate a unique filename
                    var uniqueFileName = GetUniqueFileName(uploadsFolder, imageFile.FileName);

                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.CopyTo(fileStream);
                    }

                    return "/img/" + uniqueFileName; // Return the saved path for database storage
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error while saving the image: {ex.Message}");
                    return string.Empty; // Return an empty string on error
                }
            }

            return string.Empty; // Return an empty string if no image is uploaded
        }

        private string GetUniqueFileName(string folderPath, string fileName)
        {
            var filePath = Path.Combine(folderPath, fileName);

            if (!System.IO.File.Exists(filePath))
            {
                return fileName;
            }

            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
            var fileExtension = Path.GetExtension(fileName);
            var counter = 1;

            while (System.IO.File.Exists(filePath))
            {
                var newFileName = $"{fileNameWithoutExtension}_{counter}{fileExtension}";
                filePath = Path.Combine(folderPath, newFileName);
                counter++;
            }

            return Path.GetFileName(filePath);
        }
        public async Task<IActionResult> EditDetails(IFormCollection form, IFormFile editImage1, IFormFile editImage2, IFormFile editImage3)
        {
            try
            {
                var id = form["editProductId"].FirstOrDefault();
                var status = form["editStatus"].FirstOrDefault();
                var timeBegin = form["editTimeBegin"].FirstOrDefault();
                var infoProduct = form["editInfoProduct"].FirstOrDefault();
                var infoDetails = form["editInfoDetails"].FirstOrDefault();
                var typeDonation = form["editTypeDonation"].FirstOrDefault();

                // Check for null or empty strings and handle accordingly

                var existingDetails = await _detailsCollection
                    .Find(p => p.IDProduct == id)
                    .FirstOrDefaultAsync();

                if (existingDetails != null)
                {
                    // Update existing details with form values
                    existingDetails.Status = status;
                    existingDetails.TimeBegin = DateTime.Parse(timeBegin);
                    existingDetails.InfoProduct = infoProduct;
                    existingDetails.InfoDetails = infoDetails;
                    existingDetails.TypeDonation = typeDonation;

                    // Save and assign image paths
                    existingDetails.Image1 =  SaveImageToRoot(editImage1);
                    existingDetails.Image2 =  SaveImageToRoot(editImage2);
                    existingDetails.Image3 =  SaveImageToRoot(editImage3);

                    var filter = Builders<Details>.Filter.Where(p => p.IDProduct == id);
                    await _detailsCollection.ReplaceOneAsync(filter, existingDetails).ConfigureAwait(false);

                    return RedirectToAction("Details");
                }
                else
                {
                    // Handle case where existing details were not found
                    return NotFound("Details not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500); // Return a server error status code
            }
        }


        [HttpPost]
        public async Task<IActionResult> EditProduct(IFormCollection form, IFormFile imageFile)
        {
            var _idEdit = form["editId"].FirstOrDefault();
            var _idProduct = form["editProducId"].FirstOrDefault();
            var _Name = form["editName"].FirstOrDefault();
            var _Description = form["editDescription"].FirstOrDefault();
            var _Target = form["Target"].FirstOrDefault();
            // Validate the form data
            if (string.IsNullOrEmpty(_idEdit) || string.IsNullOrEmpty(_idProduct))
            {
                return BadRequest("Invalid data provided for updating the product.");
            }

            // Retrieve the existing product from the database based on the editId
            var existingProduct = await _projectCollection
                .Find(p => p.Producid == _idProduct)
                .FirstOrDefaultAsync();

            if (existingProduct == null)
            {
                return NotFound("Product not found.");
            }

            // Update the properties of the existing product
            existingProduct.Name = _Name;
            existingProduct.Description = _Description;
            existingProduct.Target = decimal.Parse(_Target);
            if (imageFile != null && imageFile.Length > 0)
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", imageFile.FileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                // Update existingProduct with the path to the saved image
                existingProduct.Images = "/img/" + imageFile.FileName;

                // Save the changes back to the database
            }
            else
            {
                // Handle the case where no image is provided
                // This might involve removing the existing image if necessary

                // For example, you might want to clear the existing image path in this case:
                existingProduct.Images = null;

                // Save the changes back to the database
            }
            // Save the changes back to the database
            var filter = Builders<ProjectModel>.Filter.Where(p => p.Producid == _idProduct);
            await _projectCollection.ReplaceOneAsync(filter, existingProduct).ConfigureAwait(false);


            return RedirectToAction("Product");
        }



        public async Task<IActionResult> EditAccount(IFormCollection form)
        {
            var _id = form["editAccountId"].FirstOrDefault();
            var _editUser = form["editUser"].FirstOrDefault();
            var _editPwd = form["editPwd"].FirstOrDefault();
            var _editRoles = form["editRoles"].FirstOrDefault();

            // Validate the form data
            if (string.IsNullOrEmpty(_id) || string.IsNullOrEmpty(_id))
            {
                return BadRequest("Invalid data provided for updating the product.");
            }

            // Retrieve the existing product from the database based on the editId
            var existingAccount = await _accountCollection
                .Find(p => p._id == _id)
                .FirstOrDefaultAsync();

            if (existingAccount == null)
            {
                return NotFound("Product not found.");
            }

            // Update the properties of the existing product
            existingAccount.user = _editUser;
            existingAccount.pwd = _editPwd;
            existingAccount.roles = _editRoles;


            var filter = Builders<Account>.Filter.Where(p => p._id == _id);
            await _accountCollection.ReplaceOneAsync(filter, existingAccount).ConfigureAwait(false);


            return RedirectToAction("Account");
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(IFormCollection form, IFormFile imageFile)
        {
            // Bạn có thể sử dụng IFormCollection để truy xuất dữ liệu từ form
            var productId = form["ProductId"];
            var name = form["Name"];
            var description = form["Description"];
            var _Target = form["Target"];

            var project = new ProjectModel
            {
                Producid = productId,
                Name = name,
                Description = description,
                Target = decimal.Parse(_Target),
                // Các trường khác của project
            };
            if (ModelState.IsValid)
            {
                // Lưu hình ảnh vào thư mục wwwroot/img
                if (imageFile != null && imageFile.Length > 0)
                {
                    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", imageFile.FileName);

                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    project.Images = "/img/" + imageFile.FileName;
                }
                // Insert thông tin dự án vào MongoDB
                await _projectCollection.InsertOneAsync(project);

                return RedirectToAction("AddProduct");
            }

            // Nếu thông tin không hợp lệ, quay lại trang AddProduct với thông báo lỗi
            return View(project);
        }
        [HttpPost]
        public async Task<IActionResult> AddAccount(IFormCollection form)
        {
            // Bạn có thể sử dụng IFormCollection để truy xuất dữ liệu từ form
            var user = form["Username"];
            var pwd = form["Password"];
            var role = form["Role"];

            var account = new Account
            {
                user = user,
                pwd = pwd,
                roles = role,
                // Các trường khác của project
            };
            if (ModelState.IsValid)
            {
                // Lưu hình ảnh vào thư mục wwwroot/img

                // Insert thông tin dự án vào MongoDB
                await _accountCollection.InsertOneAsync(account);

                return RedirectToAction("Account");
            }

            // Nếu thông tin không hợp lệ, quay lại trang AddProduct với thông báo lỗi
            return View(account);
        }


        // POST: /Admin/Home/Login
        [HttpPost]
        public IActionResult Login(IFormCollection form)
        {
            // Retrieve username and password from the form collection
            string username = form["username"];
            string password = form["password"];

            // Query the MongoDB collection for an account with the given username and password
            List<Account> accounts = _accountCollection.Find(account => account.user == username && account.pwd == password).ToList();
            Console.WriteLine(accounts.ToString());
            if (accounts.Count == 1)
            {
                // If a matching account is found, set the UserId in the session
                HttpContext.Session.SetString("UserId", accounts[0]._id);
                HttpContext.Session.SetString("Username", accounts[0].user);
                HttpContext.Session.SetString("Role", accounts[0].roles);

                return RedirectToAction("Index");
            }
            else
            {
                // If no matching account is found, display an error message
                ModelState.AddModelError(string.Empty, "Invalid username or password");
                return View();
            }
        }
        [HttpGet]
        public IActionResult Logout()
        {
            // Xóa thông tin phiên đăng nhập
            HttpContext.Session.Remove("UserId");
            HttpContext.Session.Remove("Username");
            HttpContext.Session.Remove("Role");

            // Chuyển hướng đến trang đăng nhập hoặc trang chính
            return RedirectToAction("Login");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(IFormCollection form)
        {
            var _idDel = form["itemIdToDelete"].FirstOrDefault();
            if (string.IsNullOrEmpty(_idDel))
            {
                return BadRequest("Invalid product ID provided for deletion.");
            }
            else
            {
                var filter = Builders<ProjectModel>.Filter.Where(p => p.Id == _idDel);
                await _projectCollection.DeleteOneAsync(filter);
                return RedirectToAction("Product");
            }

        }

        [HttpPost]
        public async Task<IActionResult> DeleteAccount(IFormCollection form)
        {
            var _idDel = form["itemIdToDelete"].FirstOrDefault();
            if (string.IsNullOrEmpty(_idDel))
            {
                return BadRequest("Invalid product ID provided for deletion.");
            }
            else
            {
                var filter = Builders<Account>.Filter.Where(p => p._id == _idDel);
                await _accountCollection.DeleteOneAsync(filter);
                return RedirectToAction("Account");
            }




        }
        [HttpPost]
        public async Task<IActionResult> DeleteDetails(IFormCollection form)
        {
            var _idDel = form["itemIdToDelete"].FirstOrDefault();
            if (string.IsNullOrEmpty(_idDel))
            {
                return BadRequest("Invalid product ID provided for deletion.");
            }
            else
            {
                var filter = Builders<Details>.Filter.Where(p => p.Id == _idDel);
                await _detailsCollection.DeleteOneAsync(filter);
                return RedirectToAction("Details");
            }

        }


    }
}
