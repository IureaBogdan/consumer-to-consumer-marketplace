using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.Offer
{
    public class AccountOfferEditViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Title must contain only letters.")]
        [StringLength(40, ErrorMessage = "Must be short then 40 chars")]
        public string Title { get; set; }


        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Location is required.")]
        [StringLength(40, ErrorMessage = "Must be short then 150 chars")]
        public string Location { get; set; }


        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, 100000, ErrorMessage = "Must be between 0.01 and 100.000")]
        public Nullable<float> Price { get; set; }


        [Required(ErrorMessage = "Category is required.")]
        [StringLength(40, ErrorMessage = "Must be short then 40 chars")]
        public string Category { get; set; }


        [Required(ErrorMessage = "Subcategory is required.")]
        [StringLength(40, ErrorMessage = "Must be short then 40 chars")]
        public string Subcategory { get; set; }
        public Dictionary<Guid, string> ImageDataDictionary { get; set; }
    }
}
