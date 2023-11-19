using System.Collections.Generic;
using Web_Donation.Models;

namespace Web_Donation.Models
{
    public class FilteredBlockViewModel
    {
        public string Product_ID { get; set; }
        public List<BlockDetailsViewModel> FilteredBlocks { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
