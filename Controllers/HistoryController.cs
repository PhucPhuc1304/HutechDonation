using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Newtonsoft.Json;
using PagedList;
using Web_Donation.Areas.Admin.Models;
using Web_Donation.Models;

namespace Web_Donation.Controllers
{
    public class HistoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMongoCollection<Product> _productCollection;


        public HistoryController(MongoDBContext context, IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _productCollection = context.GetProductCollection();

        }

        public async Task<IActionResult> Index(int? page)
        {
            var httpClient = _httpClientFactory.CreateClient();

            // Set the API URL
            string apiUrl = "https://u5wsu9qncf.execute-api.ap-south-1.amazonaws.com/viewBlock";
            string balanceApiUrl = "https://autj7dthme.execute-api.ap-south-1.amazonaws.com/balance"; // Đường dẫn đến API balance

            // Set request headers
            httpClient.DefaultRequestHeaders.Add("x-api-key", "hutech_hackathon@123456");
            httpClient.DefaultRequestHeaders.Add("access-token", "phucphuctest123");

            try
            {
                // Send a POST request to the balance API
                var accountNumber = "0555777999"; // Thay bằng số tài khoản bạn muốn truy vấn
                var balanceRequest = new { account_number = accountNumber };
                var balanceRequestJson = JsonConvert.SerializeObject(balanceRequest);
                var content = new StringContent(balanceRequestJson, Encoding.UTF8, "application/json");

                var balanceResponse = await httpClient.PostAsync(balanceApiUrl, content);

                if (balanceResponse.IsSuccessStatusCode)
                {
                    var balanceContent = await balanceResponse.Content.ReadAsStringAsync();
                    var balanceData = JsonConvert.DeserializeAnonymousType(balanceContent, new { balance = 0 });

                    var blocksResponse = await httpClient.GetAsync(apiUrl);

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

                        List<Product> products = _productCollection.Find(product => true).ToList();

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
                        int pageSize = 10; // Số mục trên mỗi trang
                        int pageNumber = page ?? 1;
                        var pagedBlockDetailsList = blockDetailsList.ToPagedList(pageNumber, pageSize);
                        var combinedViewModel = new CombinedViewModel
                        {
                            PagedBlockDetailsList = pagedBlockDetailsList,
                            FilteredBlockViewModelList = filteredBlockViewModelList
                        };


                        // Process paging
                       

                        // Add balance data to the model
                        ViewBag.Balance = balanceData.balance;

                        return View(combinedViewModel);
                    }
                }
                return View("Error");
            }
            catch (HttpRequestException ex)
            {
                return View("Error");
            }
        }
    }
}
