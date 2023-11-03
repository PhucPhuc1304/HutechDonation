using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Web_Donation.Models;

namespace Web_Donation.Controllers
{
	public class PaymentController : Controller
	{
		private readonly HttpClient _httpClient_Payment, _httpClient_Blockchain;

		public PaymentController()
		{
			_httpClient_Payment = new HttpClient();
			_httpClient_Payment.BaseAddress = new Uri("https://gpfc0jtozk.execute-api.ap-south-1.amazonaws.com"); // Replace with your API base URL
			_httpClient_Payment.DefaultRequestHeaders.Add("access-token", "phucphuctest123");
			_httpClient_Payment.DefaultRequestHeaders.Add("x-api-key", "hutech_hackathon@123456");
			_httpClient_Blockchain = new HttpClient();
			_httpClient_Blockchain.BaseAddress = new Uri("https://f47tz8mt0a.execute-api.ap-south-1.amazonaws.com/"); // Replace with your API base URL
			_httpClient_Blockchain.DefaultRequestHeaders.Add("access-token", "phucphuctest123");
			_httpClient_Blockchain.DefaultRequestHeaders.Add("x-api-key", "hutech_hackathon@123456");
		}

		public int GenerateRandom9DigitNumber()
		{
			Random random = new Random();
			int randomNumber = random.Next(100000000, 999999999);
			return randomNumber;
		}

		[HttpPost]
		public IActionResult ProcessPayment(IFormCollection form)
		{
			// Retrieve form data
			string type = form["type"];
			string fname = form["fname"];
			string email = form["email"];
			string amount = form["amount"];
			string message = form["message"];
			string paymentDes = fname +" ung ho du an " + type + " chung tay giup do nguoi ngheo";

			ViewBag.Type = type;
			ViewBag.Name = fname;
			ViewBag.Email = email;
			ViewBag.Amount = amount;
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
				string accountNumber = form["accountNumber"];
				string beneficiary = form["beneficiary"];
				string donorName = form["donorName"];
				string amount = form["amount"];
				string paymentDescription = form["paymentDescription"];
				int accountNumberSender = GenerateRandom9DigitNumber();

				var requestData = new
				{
					sender = accountNumberSender,
					receiver = "0555777999",
					transaction_type = "receive",
					amount = amount,
					transaction_des = paymentDescription
				};
				var jsonContent = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

			
				var response = await _httpClient_Payment.PostAsync("/createTrans", jsonContent);

				if (response.IsSuccessStatusCode)
				{
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<JObject>(responseContent);
                    // Lấy từng giá trị cụ thể từ 'transaction'
                    var sender = responseObject["transaction"]["sender"].Value<string>();
                    var idAccount = responseObject["transaction"]["id_account"].Value<string>();
                    var transactionType = responseObject["transaction"]["transaction_type"].Value<string>();
                    var amount_= responseObject["transaction"]["amount"].Value<decimal>();
                    var transactionDate = responseObject["transaction"]["transaction_date"].Value<DateTime>();
                    var transactionDes = responseObject["transaction"]["transaction_des"].Value<string>();
                    var _id = responseObject["transaction"]["_id"].Value<string>();
                    var __v = responseObject["transaction"]["__v"].Value<int>();
                    var requestData_BlockChain = new
                    {
                        data = new
                        {
                            sender = sender,
                            account_number = 0555777999,
                            amount = amount_,
                            transaction_date = transactionDate,
							transactionDes = transactionDes,
                        }
                    };

					var jsonContent_blockChain = new StringContent(JsonConvert.SerializeObject(requestData_BlockChain), Encoding.UTF8, "application/json");
                    var response_Blockchain = await _httpClient_Blockchain.PostAsync("/addblock", jsonContent_blockChain);

                    if (response_Blockchain.IsSuccessStatusCode)
					{
						return View("PaymentSuccess");
					}
					else
					{
						return View("Error");
					}

					// In các giá trị ra console hoặc làm việc với chúng theo nhu cầu

				}
				else
				{
					return View("Error");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				return View("Error");
			}
		}
	}
}
