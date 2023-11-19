using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json;

using System.Net.Http;
using System.Threading.Tasks;
using Web_Donation.Models;

namespace Web_Donation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Details> _detailsCollection;
		private readonly IHttpClientFactory _httpClientFactory;

		public HomeController(MongoDBContext context, IHttpClientFactory httpClientFactory)
        {
            _productCollection = context.GetProductCollection();
            _detailsCollection = context.GetDetailsCollection();
			_httpClientFactory = httpClientFactory;

		}

		public async Task<IActionResult> Index()
        {
            var httpClient = _httpClientFactory.CreateClient();
            string apiUrl = "https://u5wsu9qncf.execute-api.ap-south-1.amazonaws.com/viewBlock";
            httpClient.DefaultRequestHeaders.Add("x-api-key", "hutech_hackathon@123456");
            httpClient.DefaultRequestHeaders.Add("access-token", "phucphuctest123");
            var blocksResponse = await httpClient.GetAsync(apiUrl);
            var blockDetailsList = new List<BlockDetailsViewModel>();
            if (blocksResponse.IsSuccessStatusCode)
            {
                var blocksContent = await blocksResponse.Content.ReadAsStringAsync();
                var blocks = JsonConvert.DeserializeObject<List<Block>>(blocksContent);


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
            }
            List<Product> products_ = _productCollection.Find(product => true).ToList();
            List<Product> products = _productCollection.Find(p => true).ToList();
            List<Details> details = _detailsCollection.Find(p => true).ToList();

            var filteredBlockViewModelList = new List<FilteredBlockViewModel>();
            foreach (var product in products)
            {
                var filteredBlocks = blockDetailsList.FindAll(b =>
                    b.TransactionDescription != null &&
                    b.TransactionDescription.Contains(product.Producid)
                );

                // Tính tổng Amount của filteredBlocks
                decimal totalAmount = filteredBlocks.Sum(block => block.Amount);
                Console.WriteLine(totalAmount);
                var filteredBlockViewModel = new FilteredBlockViewModel
                {
                    Product_ID = product.Producid,
                    FilteredBlocks = filteredBlocks,
                    TotalAmount = totalAmount // Thêm thuộc tính TotalAmount vào FilteredBlockViewModel
                };
                filteredBlockViewModelList.Add(filteredBlockViewModel); // Add to the list

            }
            var detailsPageViewModel = new DetailsPageViewModel
            {
                Products2 = products_,
                Products = products,
                Details = details,
                FilteredBlockViewModelList = filteredBlockViewModelList
                // Các thuộc tính khác nếu có
            };

            return View(detailsPageViewModel); // Trả về view với thông tin chi tiết
        }
        [HttpGet("Details/{id}")]
		public async Task<IActionResult> Details(string id)
        {

			var httpClient = _httpClientFactory.CreateClient();
			string apiUrl = "https://u5wsu9qncf.execute-api.ap-south-1.amazonaws.com/viewBlock";
			httpClient.DefaultRequestHeaders.Add("x-api-key", "hutech_hackathon@123456");
			httpClient.DefaultRequestHeaders.Add("access-token", "phucphuctest123");
			var blocksResponse = await httpClient.GetAsync(apiUrl);
			var blockDetailsList = new List<BlockDetailsViewModel>();
			if (blocksResponse.IsSuccessStatusCode)
			{
				var blocksContent = await blocksResponse.Content.ReadAsStringAsync();
				var blocks = JsonConvert.DeserializeObject<List<Block>>(blocksContent);


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
			}
            List<Product> products_ = _productCollection.Find(product => true).ToList();
            List<Product> products = _productCollection.Find(p => p.Producid == id).ToList();
			List<Details> details = _detailsCollection.Find(p => p.IDProduct == id).ToList();

			var filteredBlockViewModelList = new List<FilteredBlockViewModel>();
			foreach (var product in products)
			{
				var filteredBlocks = blockDetailsList.FindAll(b =>
					b.TransactionDescription != null &&
					b.TransactionDescription.Contains(id.ToString())
				);

				// Tính tổng Amount của filteredBlocks
				decimal totalAmount = filteredBlocks.Sum(block => block.Amount);
				Console.WriteLine(totalAmount);
				var filteredBlockViewModel = new FilteredBlockViewModel
				{
					Product_ID = product.Producid,
					FilteredBlocks = filteredBlocks,
					TotalAmount = totalAmount // Thêm thuộc tính TotalAmount vào FilteredBlockViewModel
				};
                filteredBlockViewModelList.Add(filteredBlockViewModel); // Add to the list

            }
            var detailsPageViewModel = new DetailsPageViewModel
			{
                Products2 = products_,
                Products = products,
				Details = details,
				FilteredBlockViewModelList = filteredBlockViewModelList
				// Các thuộc tính khác nếu có
			};

			return View(detailsPageViewModel); // Trả về view với thông tin chi tiết
        }
    }

}
