using System.ComponentModel.DataAnnotations;

namespace JuanBackendApp.Models
{
    public class Size : BaseEntity
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public List<ProductSize> ProductSizes { get; set; }
    }
}
