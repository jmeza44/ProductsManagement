namespace ProductsManagement.Data.ViewModels
{
    public class ProductVM
    {
        public ProductVM(string description, string type, double value, DateTime boughtDate, string state)
        {
            Description = description;
            Type = type;
            Value = value;
            BoughtDate = boughtDate;
            State = state;
        }

        public string Description { get; set; }
        public string Type { get; set; }
        public double Value { get; set; }
        public DateTime BoughtDate { get; set; }
        public string State { get; set; }
    }
}
