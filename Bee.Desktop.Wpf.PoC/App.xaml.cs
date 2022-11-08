using Bee.Data.Abstractions;
using Bee.Data.LiteDb;
using Bee.Data.Service;
using Bee.Data.Service.Models;
using Bee.Desktop.Wpf.PoC.Messenger;
using Bee.Desktop.Wpf.PoC.Settings;
using Bee.Desktop.Wpf.PoC.Views;
using LiteDB;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows;

namespace Bee.Desktop.Wpf.PoC
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public new static App Current => (App)Application.Current;

        public IServiceProvider? ServiceProvider { get; private set; }

        public IConfiguration? Configuration { get; private set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
             .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration?.GetSection(nameof(AppSettings)));
            services.Configure<LiteDbOptions>(Configuration?.GetSection(nameof(LiteDbOptions)));

            services.AddSingleton<IRepository<ILiteRepository>, LiteDbRepository>();
            services.AddSingleton<IService<User>, Service<User>>();

            services.AddSingleton<BaseViewModel, AuthorizeViewModel>();
            services.AddSingleton<BaseViewModel, ServerViewModel>();
            services.AddSingleton<BaseViewModel, UserListViewModel>();
            services.AddTransient(typeof(MainWindow));
        }
    }
}
