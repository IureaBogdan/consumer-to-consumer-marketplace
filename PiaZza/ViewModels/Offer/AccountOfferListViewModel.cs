using System;
namespace ViewModels.Offer
{
    public class AccountOfferListViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public string ImageLink { get; set; }
    }
}
