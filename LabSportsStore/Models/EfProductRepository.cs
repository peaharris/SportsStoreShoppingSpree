using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Linq;

namespace LabSportsStore.Models
{
    public class EfProductRepository : IProductRepository
    {
        // F i e l d s  &  P r o p e r t i e s

        private AppDbContext context;

        // C o n s t r u c t o r s

        public EfProductRepository (AppDbContext context) //context talks to the database, use context to get db info
        {
            this.context = context; 
        }

        // M e t h o d s   - C R U D

        // C r e a t e 
        public Product Create(Product product)
        {
            try
            {
                context.Products.Add(product);
                context.SaveChanges(); //This is like the GO command SQL;
                return product;
            }
            catch (Exception e)
            { //a bad thing happened
                return null;
            }
        }

        // R e a d 

        public IQueryable<Product> GetAllProducts()  //returns an IQueryable
        {
            return context.Products.OrderBy(p => p.Name); //LINQ
            //orders by name
            //generates the select on Products and returns it as an array of products
        }
        public IQueryable<string> GetAllCategories()
        {
            IQueryable<string> categories = context.Products
                                                   .Select(p => p.Category)
                                                   .Distinct()
                                                   .OrderBy(c => c);
            return categories;
        }
        public Product GetProductById(int productId)
        {
            Product theProduct = //language integrated query
            context.Products //line up with the periods
                   .Where(p => p.ProductId == productId) // LINQ using a WHERE clause
                   .FirstOrDefault(); // give me the first thing out of the list, if nothing give default value
            return theProduct;
        }
        public IQueryable<Product> GetProductsByCategory(string category)
        {
            return GetAllProducts() //this is call LInQ (Language Integrated Query)
                    .Where(p => p.Category == category)
                    .OrderBy(p => p.ProductId);
        }

        public IQueryable<Product> GetProductsByKeyword(string keyword)
        {
            return context.Products.Where(p => p.Name.Contains(keyword));
        }

        // U p d a t e
        public Product UpdateProduct(Product prod) //this is what someone passes me
        {
            //1. Go find (read) this product from the database
            Product productFromDb = context.Products //This will return an IQueryable
                .FirstOrDefault(p => p.ProductId == prod.ProductId); //gets one product out of the database   

            //2. Modify the database copy of the product
            if (productFromDb != null)
            {
                productFromDb.Category = prod.Category;
                productFromDb.Description = prod.Description;
                productFromDb.Name = prod.Name;
                productFromDb.Price = prod.Price;
                //productFromDb.ProductId = prod.ProductId; this is already specified in step 1.


            //3. Dear Database: Please update you copy of this product
                context.SaveChanges();
            }
            return productFromDb;
        }

        // D e l e t e
        public bool DeleteProduct(int id)
        {
            Product productToDelete =
                context.Products.FirstOrDefault(p => p.ProductId == id); //combined where & first/default together
            if (productToDelete == null)
            {
                return false;
            }
            context.Products.Remove(productToDelete);
            context.SaveChanges(); //saving changes
            return true;
        }
    }
}
