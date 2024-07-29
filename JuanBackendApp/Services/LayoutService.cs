using JuanBackendApp.App_Data;
using JuanBackendApp.Interfaces;

namespace JuanBackendApp.LayoutServices
{
    public class LayoutService : ILayoutService
    {
        private readonly JuanAppDbContext _juanAppDbContext;

        public LayoutService(JuanAppDbContext juanAppDbContext)
        {
            _juanAppDbContext = juanAppDbContext;
        }
        public IDictionary<string, string> GetSettings()
        {
            return _juanAppDbContext.Settings
               .Where(s => !s.IsDeleted)
               .ToDictionary(s => s.Key, s => s.Value);
        }
    }
}
