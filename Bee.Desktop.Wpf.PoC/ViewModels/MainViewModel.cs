using Bee.Desktop.Wpf.PoC.Messenger;
using Bee.Desktop.Wpf.PoC.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ControlzEx.Theming;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Bee.Desktop.Wpf.PoC.Messenger
{
    public partial class MainViewModel : BaseViewModel
    {
        [ObservableProperty]
        private BaseViewModel? currentViewModel;

        [ObservableProperty]
        private ThemeColor? selectedTheme;

        [ObservableProperty]
        private List<ThemeColor>? themes;

        //private bool canNavigateNext;
        //private bool canNavigatePrevious;
        //private BaseViewModel NextViewModel;
        //private BaseViewModel? PreviousViewModel;
        //public NavigationReceiver Receiver { get; } = new NavigationReceiver();
        public MainViewModel()
        {
            Themes ??= new List<ThemeColor>
                {
                    new ThemeColor{ Name = "Light.Blue"},
                    new ThemeColor{ Name = "Light.Red"},
                    new ThemeColor{ Name = "Light.Crimson"},
                    new ThemeColor{ Name = "Light.Teal"},
                    new ThemeColor{ Name = "Light.Steel"},
                    new ThemeColor{ Name = "Light.Brown"},
                    new ThemeColor{ Name = "Dark.Blue"},
                    new ThemeColor{ Name = "Dark.Red"},
                    new ThemeColor{ Name = "Dark.Crimson"},
                    new ThemeColor{ Name = "Dark.Teal"},
                    new ThemeColor{ Name = "Dark.Steel"},
                    new ThemeColor{ Name = "Dark.Brown"},
                };
            
            CurrentViewModel = new AuthorizeViewModel();
            
            // Register a message in some module
            WeakReferenceMessenger.Default.Register<NavigationChangedMessage>(this, (r, m) =>
            {
                canNavigateNext = m.Value.NextCommand != null && m.Value.NextCommand.CanExecute;
                // canNavigatePrevious = m.Value.PreviousCommand != null && m.Value.PreviousCommand.CanExecute;

                ////Next
                //switch (m.Value.NextCommand?.ViewModelName)
                //{
                //    case "ServerViewModel":
                //        NextViewModel = new ServerViewModel();
                //        break;
                //    case "UserListViewModel":
                //        NextViewModel = new UserListViewModel();
                //        break;
                //    default:
                //        NextViewModel = null;
                //        break;
                //}

                ////Previous
                //switch (m.Value.PreviousCommand?.ViewModelName)
                //{
                //    case "AuthorizeViewModel":
                //        PreviousViewModel = new AuthorizeViewModel();
                //        break;
                //    default:
                //        PreviousViewModel = null;
                //        break;
                //}
                var viewModelsList = App.Current.ServiceProvider.GetServices(typeof(BaseViewModel));
                NextViewModel = (BaseViewModel)viewModelsList.FirstOrDefault(vm => vm.GetType().Equals(m.Value.NextCommand.ViewModel), typeof(AuthorizeViewModel));

                NavigateNextCommand.NotifyCanExecuteChanged();
                NavigateNext();

                NavigateNextCommand.NotifyCanExecuteChanged();
                //NavigatePreviousCommand.NotifyCanExecuteChanged();
            });

            ValidateAllProperties();
        }

        public override void NavigateNext()
        {
            CurrentViewModel = NextViewModel;
        }

        //public ThemeColor SelectedTheme
        //{
        //    get => selectedTheme;
        //    set
        //    {
        //        ThemeManager.Current.ChangeTheme(App.Current, value.Name);
        //        SetProperty(ref selectedTheme, value);
        //    }
        //}

        partial void OnSelectedThemeChanged(ThemeColor? value)
        {
            if (value != null)
            {
                ThemeManager.Current.ChangeTheme(App.Current, value.Name?? "Light.Blue");
            }
        }


        //[RelayCommand(CanExecute = nameof(CanNavigateNext))]
        //public void NavigateNext()
        //{
        //    CurrentViewModel = NextViewModel;
        //}

        //public bool CanNavigateNext()
        //{
        //    return canNavigateNext;
        //}

        //[RelayCommand(CanExecute = nameof(CanNavigatePrevious))]
        //public void NavigatePrevious()
        //{
        //    CurrentViewModel = PreviousViewModel;
        //}

        //public bool CanNavigatePrevious()
        //{
        //    return canNavigatePrevious;
        //}

        [RelayCommand(CanExecute = nameof(CanHome))]
        public Task Home()
        {
            NavigationSenderProvider.SendNavigationChangeMessage(new NavigationModel
            {
                NextCommand = new NavigationCommandModel
                {
                    CanExecute = true,
                    IsHidden = false,
                    ViewModel = typeof(AuthorizeViewModel)
                }
            });

            return Task.CompletedTask;
        }

        public bool CanHome()
        {
            return true;
        }
    }
}
