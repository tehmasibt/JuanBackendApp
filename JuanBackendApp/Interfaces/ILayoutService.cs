using JuanBackendApp.ViewModel;

namespace JuanBackendApp.Interfaces
{
    public interface ILayoutService
    {
        IDictionary<string, string> GetSettings();
        IEnumerable<BasketVM> GetBasket();
    }
}