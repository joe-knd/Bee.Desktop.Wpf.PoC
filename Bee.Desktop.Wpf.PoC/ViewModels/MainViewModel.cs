using Bee.Desktop.Wpf.PoC.Messenger;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Threading.Tasks;

namespace Bee.Desktop.Wpf.PoC.Messenger
{
    public partial class MainViewModel : BaseViewModel
    {
        [ObservableProperty]
        private BaseViewModel? currentViewModel;

        private bool canNavigateNext;
        private bool canNavigatePrevious;
        private BaseViewModel? NextViewModel;
        private BaseViewModel? PreviousViewModel;

        public NavigationReceiver Receiver { get; } = new NavigationReceiver();

        public MainViewModel()
        {
            CurrentViewModel = new AuthorizeViewModel();
            
            // Register a message in some module
            WeakReferenceMessenger.Default.Register<NavigationChangedMessage>(this, (r, m) =>
            {
                canNavigateNext = m.Value.NextCommand != null && m.Value.NextCommand.CanExecute;
                canNavigatePrevious = m.Value.PreviousCommand != null && m.Value.PreviousCommand.CanExecute;

                //Next
                switch (m.Value.NextCommand?.ViewModelName)
                {
                    case "ServerViewModel":
                        NextViewModel = new ServerViewModel();
                        break;
                    default:
                        NextViewModel = null;
                        break;
                }

                //Previous
                switch (m.Value.PreviousCommand?.ViewModelName)
                {
                    case "AuthorizeViewModel":
                        PreviousViewModel = new AuthorizeViewModel();
                        break;
                    default:
                        PreviousViewModel = null;
                        break;
                }

                NavigateNextCommand.NotifyCanExecuteChanged();
                NavigatePreviousCommand.NotifyCanExecuteChanged();
            });

            this.ValidateAllProperties();
        }


        [RelayCommand(CanExecute = nameof(CanNavigateNext))]
        public void NavigateNext()
        {
            CurrentViewModel = NextViewModel;
        }

        public bool CanNavigateNext()
        {
            return canNavigateNext;
        }

        [RelayCommand(CanExecute = nameof(CanNavigatePrevious))]
        public void NavigatePrevious()
        {
            CurrentViewModel = PreviousViewModel;
        }

        public bool CanNavigatePrevious()
        {
            return canNavigatePrevious;
        }
    }
}
