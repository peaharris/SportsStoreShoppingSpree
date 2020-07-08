using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabSportsStore.Models.ViewModels
{
    public class ProductListViewModel //this is what your sending to your index
    {
        public IQueryable<Product> Products         { get; set; }
        public PagingInfo          PagingInfo       { get; set; }
        public IQueryable<string>  AllCategories    { get; set; }
        public string              CurrentCategory  { get; set; }
    }
}
