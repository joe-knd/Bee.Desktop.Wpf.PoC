using Bee.Desktop.Wpf.PoC.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Bee.Desktop.Wpf.PoC.Messenger
{
    public partial class AuthorizeViewModel : BaseViewModel
    {
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AuthorizeCommand))]
        [NotifyCanExecuteChangedFor(nameof(ShowServerCommand))]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "The Email address is not well formed")]
        private string? emailAddress = string.Empty;

        public AuthorizeViewModel()
        {
            ValidateAllProperties();
        }

        [RelayCommand(CanExecute = nameof(CanAuthorize))]
        public void Authorize()
        {
            EmailAddress = "joe@doe.com";

            //NavigationSenderProvider.SendNavigationChangeMessage(new NavigationModel
            //{
            //    NextCommand = new NavigationCommandModel
            //    {
            //        CanExecute = CanShowServer(),
            //        IsHidden = false,
            //        ViewModelName = nameof(UserListViewModel) //nameof(ServerViewModel)
            //    }
            //    //,
            //    //PreviousCommand = new NavigationCommandModel
            //    //{
            //    //    CanExecute = true,
            //    //    IsHidden = false,
            //    //    ViewModelName = nameof(AuthorizeViewModel)
            //    //}
            //});

        }

        public bool CanAuthorize()
        {
            return HasErrors;
        }

        [RelayCommand(CanExecute = nameof(CanShowServer))]
        public Task ShowServer()
        {
            NavigationSenderProvider.SendNavigationChangeMessage(new NavigationModel
            {
                NextCommand = new NavigationCommandModel
                {
                    CanExecute = true,
                    IsHidden = false,
                    ViewModel = typeof(UserListViewModel)
                }
            });

            return Task.CompletedTask;
        }

        public bool CanShowServer()
        {
            return !CanAuthorize();
        }

        public bool CanAddServer()
        {
            return true;
        }
    }
}
