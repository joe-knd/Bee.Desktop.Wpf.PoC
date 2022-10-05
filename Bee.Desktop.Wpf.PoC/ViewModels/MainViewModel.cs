using Bee.Desktop.Wpf.PoC.Messenger;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Threading.Tasks;

namespace Bee.Desktop.Wpf.PoC.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel currentViewModel;
        private bool showServer = false;
        private IAsyncRelayCommand showServerCommand;
        public NavigationReceiverViewModel ReceiverViewModel { get; } = new NavigationReceiverViewModel();

        public MainViewModel()
        {
            CurrentViewModel = new AuthorizeViewModel();

            // Register a message in some module
            WeakReferenceMessenger.Default.Register<NavigationChangedMessage>(this, (r, m) =>
            {
                //switch(m.Value.ViewModelName):
                switch (m.Value.ViewModelName)
                {
                    case "server":
                        showServer = m.Value.CanExecute;
                        break;
                    default:
                        showServer = true;
                        break;
                }

                ShowServerView.NotifyCanExecuteChanged();
            });

            this.ValidateAllProperties();
        }

        private void ReceiverViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            showServerCommand.NotifyCanExecuteChanged();
        }

        public IAsyncRelayCommand ShowServerView
        {
            get
            {
                if (showServerCommand == null)
                {                    
                    showServerCommand = new AsyncRelayCommand(ShowServer, () => showServer);
                }

                return showServerCommand;
            }
        }

        //private bool ShowServerCanExecute()
        //{
        //    return showServer;
        //}

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
        }
    }
}
