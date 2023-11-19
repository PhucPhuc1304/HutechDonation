using System.Collections.Generic;

namespace Web_Donation.Models
{
	public class DetailsPageViewModel
	{
		public List<Product> Products { get; set; }
        public List<Product> Products2 { get; set; }

        public List<Details> Details { get; set; }
		public List<FilteredBlockViewModel> FilteredBlockViewModelList { get; set; }
    }
}
