using JuanBackendApp.Models;

namespace JuanBackendApp.Interfaces
{
    public interface ILayoutService
    {
        IDictionary<string, string> GetSettings();
    }
}