using System;

namespace Web_Donation.Models
{
    public class BlockData
    {
        public string name_sender {  get; set; }
        public string sender { get; set; }
        public long account_number { get; set; }
        public int amount { get; set; }
        public DateTime transaction_date { get; set; }
        public string transactionDes { get; set; }
    }
}
