using System;
using System.Linq;

namespace LabSportsStore.Models
{
    public interface IProductRepository //create interface for product repository
    {
        // C r e a t e 
        public Product Create(Product product);

        // R e a d
        public IQueryable<Product> GetAllProducts(); //Declaration (no code) vs. Definition (defining code)
        Product GetProductById(int productId);
        IQueryable<Product> GetProductsByKeyword(string keyword);
        IQueryable<Product> GetProductsByCategory(string category);
        IQueryable<string> GetAllCategories();


        // U p d a t e
        public Product UpdateProduct(Product p);

        // D e l e t e
        public bool DeleteProduct(int id);

    }
}
