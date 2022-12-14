using ProductsManagement.Data.Models;
using ProductsManagement.Data.ViewModels;

namespace ProductsManagement.Data.Services
{
    public class ProductsService
    {
        private AppDbContext _context;

        public ProductsService(AppDbContext context)
        {
            _context = context;
        }

        public List<ProductVM> GetAllProducts()
        {
            var _products = _context.Products.ToList();
            var products = new List<ProductVM>();
            foreach (var _product in _products)
            {
                products.Add(new ProductVM()
                {
                    Code = _product.Code,
                    Description = _product.Description,
                    Type = _product.Type,
                    Value = _product.Value,
                    BoughtDate = _product.BoughtDate,
                    State = _product.State,
                });
            }
            return products;
        }

        public ProductVM GetProductByCode(string code)
        {
            var _product = _context.Products.FirstOrDefault(x => x.Code == code);
            if (_product == null)
            {
                return null;
            }
            return new ProductVM()
            {
                Code = _product.Code,
                Description = _product.Description,
                Type = _product.Type,
                Value = _product.Value,
                BoughtDate = _product.BoughtDate,
                State = _product.State,
            };
        }

        public List<ProductVM> GetProductsByDescription(string description)
        {
            var _products = _context.Products.Where(p => p.Description.ToLower().Contains(description.ToLower()))
                .ToList();
            var products = new List<ProductVM>();
            foreach (var _product in _products)
            {
                products.Add(new ProductVM()
                {
                    Code = _product.Code,
                    Description = _product.Description,
                    Type = _product.Type,
                    Value = _product.Value,
                    BoughtDate = _product.BoughtDate,
                    State = _product.State,
                });
            }
            return products;
        }

        public void AddProduct(ProductVM product)
        {
            Product _product = new Product()
            {
                Code = product.Code,
                Description = product.Description,
                Type = product.Type,
                Value = product.Value,
                BoughtDate = product.BoughtDate,
                State = product.State,
            };
            _context.Add(_product);
            _context.SaveChanges();
        }

        public void UpdateProduct(ProductVM product)
        {
            Product _product = _context.Products.FirstOrDefault(p => p.Code == product.Code);
            if (_product != null)
            {
                _product.Description= product.Description;
                _product.Type= product.Type;
                _product.Value= product.Value;
                _product.BoughtDate = product.BoughtDate;
                _product.State= product.State;
                _context.SaveChanges();
            }
        }
    }
}
