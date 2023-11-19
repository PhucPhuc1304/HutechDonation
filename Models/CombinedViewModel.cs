using PagedList;
using System.Collections.Generic;
using Web_Donation.Models;

namespace Web_Donation.Models
{
    public class CombinedViewModel
    {
        public IPagedList<BlockDetailsViewModel> PagedBlockDetailsList { get; set; }
        public List<FilteredBlockViewModel> FilteredBlockViewModelList { get; set; }
    }
}
