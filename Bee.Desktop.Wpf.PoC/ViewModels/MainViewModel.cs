using Bee.Desktop.Wpf.PoC.Messenger;
using Bee.Desktop.Wpf.PoC.Models;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Threading.Tasks;

namespace Bee.Desktop.Wpf.PoC.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel currentViewModel;
        private bool showServer = false;
        private IAsyncRelayCommand showServerCommand;
        public UserReceiverViewModel ReceiverViewModel { get; } = new UserReceiverViewModel();

        public MainViewModel()
        {            
            CurrentViewModel = new AuthorizeViewModel();
            //ReceiverViewModel.PropertyChanged += ReceiverViewModel_PropertyChanged;

            // Register a message in some module
            WeakReferenceMessenger.Default.Register<UsernameChangedMessage>(this, (r, m) =>
            {
                showServer = !string.IsNullOrEmpty(((AuthorizeViewModel)CurrentViewModel).EmailAddress);
                ShowServerView.NotifyCanExecuteChanged();
            });

            this.ValidateAllProperties();
        }

        private void ReceiverViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            showServerCommand.NotifyCanExecuteChanged();
        }

        public IAsyncRelayCommand ShowServerView //IRelayCommand ShowServerView
        {
            get
            {
                if (showServerCommand == null)
                {
                    //showServerCommand = new AsyncRelayCommand(ShowServer);
                    showServerCommand = new AsyncRelayCommand(ShowServer, () => ShowServerCanExecute());
                }

                return showServerCommand;
            }
        }

        private bool ShowServerCanExecute()
        {
            return showServer;
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
