using Microsoft.Extensions.DependencyInjection;
using RPTSobj.ApplicationServices.GetMetroLineListUseCase;
using RPTSobj.ApplicationServices.Ports.Cache;
using RPTSobj.ApplicationServices.Repositories;
using RPTSobj.DesktopClient.InfrastructureServices.ViewModels;
using RPTSobj.DomainObjects;
using RPTSobj.DomainObjects.Ports;
using RPTSobj.InfrastructureServices.Cache;
using RPTSobj.InfrastructureServices.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RPTSobj.DesktopClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDomainObjectsCache<rptsobj>, DomainObjectsMemoryCache<rptsobj>>();
            services.AddSingleton<NetworkRPTSobjRepository>(
                x => new NetworkRPTSobjRepository("localhost", 80, useTls: false, x.GetRequiredService<IDomainObjectsCache<rptsobj>>())
            );
            services.AddSingleton<CachedReadOnlyRPTSobjRepository>(
                x => new CachedReadOnlyRPTSobjRepository(
                    x.GetRequiredService<NetworkRPTSobjRepository>(), 
                    x.GetRequiredService<IDomainObjectsCache<rptsobj>>()
                )
            );
            services.AddSingleton<IReadOnlyRPTSobjRepository>(x => x.GetRequiredService<CachedReadOnlyRPTSobjRepository>());
            services.AddSingleton<IGetRPTSobjListUseCase, GetRPTSobjListUseCase>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs args)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
