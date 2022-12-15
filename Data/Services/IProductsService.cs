using ProductsManagement.Data.Models;
using ProductsManagement.Data.ViewModels;

namespace ProductsManagement.Data.Services
{
    public interface IProductsService
    {
        Product AddProduct(ProductVM product);
        List<Product> GetAllProducts();
        Product GetProductByCode(int id);
        List<Product> GetProductsByDescription(string description);
        Product UpdateProduct(int id, ProductVM product);
    }
}