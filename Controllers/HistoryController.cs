using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Web_Donation.Models;
using Newtonsoft.Json;
namespace Web_Donation.Controllers
{

    public class HistoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HistoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var httpClient = _httpClientFactory.CreateClient();

            // Set the API URL
            string apiUrl = "https://f47tz8mt0a.execute-api.ap-south-1.amazonaws.com/viewBlock";

            // Set request headers
            httpClient.DefaultRequestHeaders.Add("x-api-key", "hutech_hackathon@123456");
            httpClient.DefaultRequestHeaders.Add("access-token", "phucphuctest123");

            try
            {
                // Send a GET request to the API endpoint
                var response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var blocks = JsonConvert.DeserializeObject<List<Block>>(content);

                    var blockDetailsList = new List<BlockDetailsViewModel>();

                    foreach (var block in blocks)
                    {
                        var data = JsonConvert.DeserializeObject<BlockData>(block.Data);
                        var blockDetails = new BlockDetailsViewModel
                        {
                            Index = block.Index,
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

                    return View(blockDetailsList);
                }
                else
                {
                    return View("Error");
                }
            }
            catch (HttpRequestException ex)
            {
                return View("Error");
            }
        }
    }
}
