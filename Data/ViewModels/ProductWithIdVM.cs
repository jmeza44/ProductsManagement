using ProductsManagement.Data.Models;

namespace ProductsManagement.Data.ViewModels
{
    public class ProductWithIdVM
    {
        private static string[] ProductTypes = { "Property", "Vehicle", "Land", "Apartment" };

        public int Id { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public double Value { get; set; }
        public DateTime BoughtDate { get; set; }
        public string State { get; set; }

        public static explicit operator ProductWithIdVM(Product product)
        {
            return new ProductWithIdVM()
            {
                Id = product.Id,
                Description = product.Description,
                Type = ProductTypes.ElementAtOrDefault(product.Type),
                Value = product.Value,
                BoughtDate = product.BoughtDate,
                State = product.State ? "Active" : "Inactive",
            };
        }
    }
}
