using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Text;

namespace Web_Donation.Controllers
{
    public class PaymentController : Controller
    {
        private readonly HttpClient _httpClient_Payment, _httpClient_Blockchain, _httpClient_Email;
        private string _email;
        private string _donorName;
        private string _amount;
        private string _type;

        public PaymentController()
        {
            _httpClient_Payment = new HttpClient();
            _httpClient_Payment.BaseAddress = new Uri("https://autj7dthme.execute-api.ap-south-1.amazonaws.com"); // Replace with your API base URL
            _httpClient_Payment.DefaultRequestHeaders.Add("access-token", "phucphuctest123");
            _httpClient_Payment.DefaultRequestHeaders.Add("x-api-key", "hutech_hackathon@123456");

            _httpClient_Blockchain = new HttpClient();
            _httpClient_Blockchain.BaseAddress = new Uri("https://u5wsu9qncf.execute-api.ap-south-1.amazonaws.com"); // Replace with your API base URL
            _httpClient_Blockchain.DefaultRequestHeaders.Add("access-token", "phucphuctest123");
            _httpClient_Blockchain.DefaultRequestHeaders.Add("x-api-key", "hutech_hackathon@123456");

            _httpClient_Email = new HttpClient();
            _httpClient_Email.BaseAddress = new Uri("https://4c1yte32ic.execute-api.ap-south-1.amazonaws.com");
            _httpClient_Email.DefaultRequestHeaders.Add("access-token", "phucphuctest123");
            _httpClient_Email.DefaultRequestHeaders.Add("x-api-key", "hutech_hackathon@123456");
        }

        public int GenerateRandom9DigitNumber()
        {
            Random random = new Random();
            int randomNumber = random.Next(100000000, 999999999);
            return randomNumber;
        }

        static string RemoveDiacritics(string text)
        {
            string normalizedString = text.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalizedString)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        [HttpPost]
        public IActionResult ProcessPayment(IFormCollection form)
        {
            // Retrieve form data
            _type = form["type"];
            string fname = form["fname"];
            string fname_ = RemoveDiacritics(fname);

            _email = form["email"];
            _amount = form["amount"];
            _donorName = fname; // Assign donorName to the _donorName variable
            string message = form["message"];
            string paymentDes = fname_ + " ung ho du an " + _type + " chung tay giup do nguoi ngheo";

            ViewBag.Type = _type;
            ViewBag.Name = fname_;
            ViewBag.Email = _email;
            ViewBag.Amount = _amount;
            ViewBag.Message = message;
            ViewBag.PaymentDes = paymentDes;
            return View("ProcessPayment");
        }

        [HttpPost]
        public async Task<IActionResult> PaymentSuccess(IFormCollection form)
        {
            try
            {
                string bankName = form["bankName"];
                string emai= form["email"];
                string type= form["type"];
                string accountNumber = form["accountNumber"];
                string beneficiary = form["beneficiary"];
                string donorName = form["donorName"];
                string amount = form["amount"];
                string amountWithoutCommas = amount.Replace(",", "");
                string paymentDescription = form["paymentDescription"];
                int accountNumberSender = GenerateRandom9DigitNumber();

                var requestData = new
                {
                    sender = accountNumberSender,
                    receiver = "0555777999",
                    transaction_type = "receive",
                    amount = amountWithoutCommas,
                    transaction_des = paymentDescription
                };
                var jsonContent = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

                var response = await _httpClient_Payment.PostAsync("/createTrans", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<JObject>(responseContent);

                    var sender = responseObject["transaction"]["sender"].Value<string>();
                    var idAccount = responseObject["transaction"]["id_account"].Value<string>();
                    var transactionType = responseObject["transaction"]["transaction_type"].Value<string>();
                    var amount_ = responseObject["transaction"]["amount"].Value<decimal>();
                    var transactionDate = responseObject["transaction"]["transaction_date"].Value<DateTime>();
                    var transactionDes = responseObject["transaction"]["transaction_des"].Value<string>();
                    var _id = responseObject["transaction"]["_id"].Value<string>();
                    var __v = responseObject["transaction"]["__v"].Value<int>();

                    var requestData_BlockChain = new
                    {
                        data = new
                        {
                            name_Sender = donorName,
                            sender = sender,
                            account_number = 0555777999,
                            amount = amount_,
                            transaction_date = transactionDate,
                            transactionDes = transactionDes,
                        }
                    };

                    var jsonContent_BlockChain = new StringContent(JsonConvert.SerializeObject(requestData_BlockChain), Encoding.UTF8, "application/json");
                    var response_Blockchain = await _httpClient_Blockchain.PostAsync("/addblock", jsonContent_BlockChain);

                    var requestData_Email = new
                    {
                        email = emai,
                        name = donorName,
                        amount = amount, // Số tiền theo đơn vị của API Email
                        type = type,
                    };

                    Console.WriteLine(requestData_Email.ToString());
                    var jsonContent_Email = new StringContent(JsonConvert.SerializeObject(requestData_Email), Encoding.UTF8, "application/json");
                    var response_Email = await _httpClient_Email.PostAsync("/dev/send-email", jsonContent_Email);

                    if (response_Blockchain.IsSuccessStatusCode)
                    {
                        ViewBag.DonorName = donorName;
                        ViewBag.Amount = amount;
                        return View("PaymentSuccess");
                    }
                    else
                    {
                        return View("Error");
                    }
                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
    }
}
