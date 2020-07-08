using System.ComponentModel.DataAnnotations;

namespace LabSportsStore.Models
{   // [Table("Product")] this is naming your table
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
//JSON : JavaScript Object Notation