using CommunityToolkit.Mvvm.Messaging;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Unity;

namespace Bee.Desktop.Wpf.PoC
{
    public  class UnityServiceLocator : IServiceLocator
    {
        private Page authorize;
        private Page serverData;

        public UnityServiceLocator(IUnityContainer unityContainer)
        {
            //CreateMain();
            //CreateFrontend();
            //CreateBackend();
            //CreateStartUp();
            //CreateOperative();
            //CreateLogin();
            //CreateConfiguration();
            //CreateOutOfOrder();
            CreateAutorize();
            CreateServerData();


            // Set Startup Page...
            //ServiceLocator.Current.GetInstance<INavigationService>().NavigateTo(new Uri(StartUpViewPath, UriKind.Relative));

            //Messenger.Default.Register<MoveToViewMessage>(this, message =>
            //{
            //    switch (message.StateInfo.StateType)
            //    {
            //        case StateType.StartUpState:

            //            ServiceLocator.Current.GetInstance<INavigationService>().NavigateTo(new Uri(StartUpViewPath, UriKind.Relative));
            //            break;
            //        case StateType.LoginState:
            //            ServiceLocator.Current.GetInstance<INavigationService>().NavigateTo(new Uri(LoginViewPath, UriKind.Relative));
            //            break;
            //        case StateType.OperativeState:
            //            ServiceLocator.Current.GetInstance<INavigationService>().NavigateTo(new Uri(OperativeViewPath, UriKind.Relative));
            //            break;
            //        case StateType.ConfigurationState:
            //            ServiceLocator.Current.GetInstance<INavigationService>().NavigateTo(new Uri(ConfigurationViewPath, UriKind.Relative));
            //            break;
            //        case StateType.ClosedState:
            //        case StateType.OutOfOrderState:
            //            ServiceLocator.Current.GetInstance<INavigationService>().NavigateTo(new Uri(OutOfOrderViewPath, UriKind.Relative));
            //            break;
            //        default:
            //            ServiceLocator.Current.GetInstance<INavigationService>().NavigateTo(new Uri(StartUpViewPath, UriKind.Relative));
            //            break;
            //    }
            //});
        }

        private void CreateServerData()
        {
            serverData = new ServerData();
        }

        private void CreateAutorize()
        {
            //throw new NotImplementedException();
            authorize = new Authorize();
        }

        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TService> GetAllInstances<TService>()
        {
            throw new NotImplementedException();
        }

        public object GetInstance(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public object GetInstance(Type serviceType, string key)
        {
            throw new NotImplementedException();
        }

        public TService GetInstance<TService>()
        {
            throw new NotImplementedException();
        }

        public TService GetInstance<TService>(string key)
        {
            throw new NotImplementedException();
        }

        public object? GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
}