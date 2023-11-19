using System;

namespace Web_Donation.Models
{
    public class BlockDetailsViewModel
    {
        public int Index { get; set; }
        public string NameSender { get; set; }
        public DateTime Timestamp { get; set; }
        public string Sender { get; set; }
        public long AccountNumber { get; set; }
        public int Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionDescription { get; set; }
        public string PreviousHash { get; set; }
        public string Hash { get; set; }
        public decimal TotalAmount { get; set; }



    }
}
