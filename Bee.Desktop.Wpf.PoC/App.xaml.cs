using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using Unity.Lifetime;

namespace Bee.Desktop.Wpf.PoC
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private static IUnityContainer _ambientContainer;
        public static IServiceLocator AmbientLocator { get; private set; }



        private void Application_Startup(object sender, System.Windows.StartupEventArgs e)
        {

            _ambientContainer = new UnityContainer();

            _ambientContainer.RegisterType<INavigationService, NavigationService>(new ContainerControlledLifetimeManager());

            AmbientLocator = new UnityServiceLocator(_ambientContainer);
            ServiceLocator.SetLocatorProvider(() => AmbientLocator);
        }
    }
}
