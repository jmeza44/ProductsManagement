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

        public List<ProductWithIdVM> GetAllProducts()
        {
            var products = _context.Products.Select(p => (ProductWithIdVM)p);
            return products.ToList();
        }

        public ProductWithIdVM GetProductById(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            return (ProductWithIdVM)product;
        }

        public List<ProductWithIdVM> GetProductsByDescription(string description)
        {
            var products = _context.Products.Where(p => p.Description.ToLower().Contains(description.ToLower()))
                .Select(p => (ProductWithIdVM)p)
                .ToList();

            return products;
        }

        public ProductWithIdVM AddProduct(ProductVM product)
        {
            var _product = (Product)product;
            var _productAdded = _context.Add(_product);
            _context.SaveChanges();
            return (ProductWithIdVM)_productAdded.Entity;
        }

        public ProductWithIdVM UpdateProduct(int id, ProductVM product)
        {
            var _product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (_product != null)
            {
                _product.Description = product.Description;
                _product.Type = product.TypeAsInt;
                _product.Value = product.Value;
                _product.BoughtDate = product.BoughtDate;
                _product.State = product.StateAsBool;
                _context.SaveChanges();
            }
            return (ProductWithIdVM)_product;
        }

        public ProductWithIdVM DeleteProduct(int id)
        {
            var _product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (_product != null)
            {
                _context.Products.Remove(_product);
                _context.SaveChanges();
            }
            return (ProductWithIdVM)_product;
        }
    }
}
