using ProductsManagement.Data.Models;
using ProductsManagement.Data.ViewModels;

namespace ProductsManagement.Data.Services
{
    public interface IProductsService
    {
        ProductWithIdVM AddProduct(ProductVM product);
        List<ProductWithIdVM> GetAllProducts();
        ProductWithIdVM GetProductById(int id);
        List<ProductWithIdVM> GetProductsByDescription(string description);
        ProductWithIdVM UpdateProduct(int id, ProductVM product);
        ProductWithIdVM DeleteProduct(int id);
    }
}