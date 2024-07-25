namespace JuanBackendApp.Models
{
    public class Color : BaseEntity
    {
        public string ColorName { get; set; }
        public List<ProductColor> ProductColors { get; set; }
    }
}
