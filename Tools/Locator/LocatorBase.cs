using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Locator
{
    public abstract class LocatorBase
    {
        private readonly IServiceProvider _serviceProvider;

        protected LocatorBase()
        {
            IServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        protected IServiceProvider ServiceProvider
        {
            get
            {
                return _serviceProvider;
            }
        }

        protected abstract void ConfigureServices(IServiceCollection services);

        public TService? GetServices<TService>()
        {
            return _serviceProvider.GetService<TService>();
        }
    }
}
