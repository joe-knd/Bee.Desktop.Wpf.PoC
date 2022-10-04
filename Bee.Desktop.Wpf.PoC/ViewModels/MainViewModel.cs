using Bee.Desktop.Wpf.PoC.Settings;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bee.Desktop.Wpf.PoC.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel currentViewModel;
        private IRelayCommand showServerView;
       public MainViewModel()
        {
            CurrentViewModel = new AuthorizeViewModel();
        }

        public IRelayCommand ShowServerView
        {
            get
            {
                if (showServerView == null) 
                {
                    showServerView = new RelayCommand(ShowServer);
                }

                return showServerView;
            }
        }
        public BaseViewModel CurrentViewModel 
        {
            get => currentViewModel;
            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }

        public void ShowServer()
        {
            CurrentViewModel = new ServerViewModel();
        }
    }
}
