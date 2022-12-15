using ProductsManagement.Data.Models;
using ProductsManagement.Data.ViewModels;

namespace ProductsManagement.Data.Services
{
    public class ProductsService : IProductsService
    {
        private readonly AppDbContext _context;

        public ProductsService(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<Product> GetAllProducts()
        {
            var products = _context.Products.ToList();
            return products;
        }

        public Product GetProductByCode(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            return product;
        }

        public List<Product> GetProductsByDescription(string description)
        {
            var products = _context.Products.Where(p => p.Description.ToLower().Contains(description.ToLower()))
                .ToList();
            return products;
        }

        public Product AddProduct(ProductVM product)
        {
            Product _product = new Product()
            {
                Description = product.Description,
                Type = product.Type,
                Value = product.Value,
                BoughtDate = product.BoughtDate,
                State = product.State,
            };
            var _productAdded = _context.Add(_product);
            _context.SaveChanges();
            return _productAdded.Entity;
        }

        public Product UpdateProduct(int id, ProductVM product)
        {
            var _product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (_product != null)
            {
                _product.Description = product.Description;
                _product.Type = product.Type;
                _product.Value = product.Value;
                _product.BoughtDate = product.BoughtDate;
                _product.State = product.State;
                _context.SaveChanges();
            }
            return _product;
        }
    }
}
