namespace ProductsManagement.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public double Value { get; set; }
        public DateTime BoughtDate { get; set; }
        public string State { get; set; }
    }
}
