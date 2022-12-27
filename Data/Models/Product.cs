namespace ProductsManagement.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public double Value { get; set; }
        public DateTime BoughtDate { get; set; }
        public bool State { get; set; }
    }
}
