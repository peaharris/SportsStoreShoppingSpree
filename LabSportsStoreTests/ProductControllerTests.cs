using LabSportsStore.Controllers;
using LabSportsStore.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Linq;
using Xunit;

namespace LabSportsStoreTests
{
    public class ProductControllerTests
    {
        [Fact]
        public void CanPaginate()
        {
            Mock<IProductRepository> mock =  //manually creating a repository
                new Mock<IProductRepository>();
            mock.Setup(m => m.GetAllProducts())
                .Returns((new Product[]
                {
             new Product { ProductId = 1, Name = "P1" },
             new Product { ProductId = 2, Name = "P2" },
             new Product { ProductId = 3, Name = "P3" },
             new Product { ProductId = 4, Name = "P4" },
             new Product { ProductId = 5, Name = "P5" }
                }).AsQueryable<Product>());

            ProductController controller =  //manually creating a controller
               new ProductController(mock.Object);
            controller.PageSize = 3; //changing the page size to 3

            IQueryable<Product> result =  
               (controller.Index(2) as ViewResult)   //calling the index method, asking for page 2
               .ViewData.Model as IQueryable<Product>; //go to the data model change to an IQueryable
            Product[] productArray = result.ToArray(); //changed data to an array
            Assert.Equal(2, productArray.Length);  //test 1 expect the 2nd page to be 2 long
            Assert.Equal(4, productArray[0].ProductId);  //test 2 look at product array 0, expecting id to be 4
            Assert.Equal("P5", productArray[1].Name);  //test 3 look at index 1 expect name to be P5

        }
    }
}
