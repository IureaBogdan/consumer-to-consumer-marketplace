using System;
using System.Collections.Generic;

namespace ViewModels.Offer
{
    public class OfferDetailsViewModel
    {

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public Nullable<float> Price { get; set; }
        public DateTime Date { get; set; }
        public string SellerName { get; set; }
        public string SellerPhoneNumber { get; set; }
        public string SellerEmail { get; set; }
        public List<string> Images { get; set; }
        //public virtual ICollection<OfferImage> OfferImages { get; set; }
    }
}
