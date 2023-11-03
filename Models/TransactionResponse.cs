using System;

namespace Web_Donation.Models
{
	public class TransactionResponse
	{
		public string _id { get; set; }
		public string sender { get; set; }
		public string id_account { get; set; }
		public string account_number { get; set; }
		public string transaction_type { get; set; }
		public decimal amount { get; set; }
		public DateTime transaction_date { get; set; }
		public string transaction_des { get; set; }
		public int __v { get; set; }
	}
}
