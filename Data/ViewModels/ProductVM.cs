using ProductsManagement.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace ProductsManagement.Data.ViewModels
{
    public class ProductVM
    {
        private string[] ProductTypes = { "Property", "Vehicle", "Land", "Apartment" };

        [Required(ErrorMessage = "A Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "A Type is required")]
        [RegularExpression("Property|Vehicle|Land|Apartment",
            ErrorMessage = "Product Type must match with one of the following values Property|Vehicle|Land|Apartment")]
        public string Type { get; set; }

        [Required(ErrorMessage = "A Product Value is required")]
        [Range(0, 9999999, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public double Value { get; set; }

        [Required(ErrorMessage = "The BoughtDate is required")]
        public DateTime BoughtDate { get; set; }

        [Required(ErrorMessage = "A Product State is required")]
        [RegularExpression("Active|Inactive",
            ErrorMessage = "Product State must match with one of the following values Active|Inactive")]
        public string State { get; set; }

        public int TypeAsInt
        {
            get => Array.IndexOf(ProductTypes, Type);
        }

        public bool StateAsBool
        {
            get => State == "Active";
        }

        public static explicit operator Product(ProductVM product)
        {
            return new Product()
            {
                Description = product.Description,
                Type = product.TypeAsInt,
                Value = product.Value,
                BoughtDate = product.BoughtDate,
                State = product.StateAsBool,
            };
        }
    }
}
