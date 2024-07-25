using System.ComponentModel.DataAnnotations;

namespace JuanBackendApp.Models
{
    public class Setting : BaseEntity
    {
        [Required]
        public string Key { get; set; }
        [MaxLength(3000)]
        public string Value { get; set; }
    }
}

