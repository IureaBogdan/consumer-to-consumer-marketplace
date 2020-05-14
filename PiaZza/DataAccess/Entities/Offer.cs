using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Offer
    {

        #region Properties
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public Nullable<float> Price { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        #endregion

        #region Constructors
        public Offer()
        {
            OfferImages = new List<OfferImage>();
        }
        #endregion

        #region Foreign Keys
        public Guid AccountId { get; set; }
        #endregion

        #region [ Navigation Properties ]
        public virtual Account Account { get; set; }
        public virtual ICollection<OfferImage> OfferImages { get; set; }
        #endregion
    }
}
