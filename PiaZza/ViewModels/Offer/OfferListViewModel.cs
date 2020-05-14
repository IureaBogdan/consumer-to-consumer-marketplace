using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Offer
{
    public class OfferListViewModel
    {
        public Guid Id { get; set; }
        public Guid AcountId{ get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public  Nullable<float> Price { get; set; }
        public string ImageLink { get; set; }
    }
}
