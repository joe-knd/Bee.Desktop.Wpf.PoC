using Bee.Desktop.Wpf.PoC.Models;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace Bee.Desktop.Wpf.PoC.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel currentViewModel;
        private IAsyncRelayCommand showServerCommand;

        public MainViewModel()
        {            
            CurrentViewModel = new AuthorizeViewModel();
            this.ValidateAllProperties();
        }                

        public IAsyncRelayCommand ShowServerView //IRelayCommand ShowServerView
        {
            get
            {
                if (showServerCommand == null)
                {
                    showServerCommand = new AsyncRelayCommand(ShowServer);
                    //showServerCommand = new AsyncRelayCommand(ShowServer, () => ShowServerCanExecute());
                }

                return showServerCommand;
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
        
        public async Task ShowServer()
        {
            CurrentViewModel = new ServerViewModel();
            showServerCommand.NotifyCanExecuteChanged();
        }
    }
}
