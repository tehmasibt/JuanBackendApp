using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JuanBackendApp.Models
{
    public class Product : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DisCountPrice { get; set; }
        public bool IsNewProduct { get; set; }
        public string Image { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal EcoTax { get; set; }
        public int Count { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<ProductColor> ProductColors { get; set; }
        public List<ProductSize> ProductSizes { get; set; }
    } 
}
