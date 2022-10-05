using Bee.Desktop.Wpf.PoC.Models;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Bee.Desktop.Wpf.PoC.ViewModels
{
    public class AuthorizeViewModel : BaseViewModel
    {
        private string? emailAddress = string.Empty;
        public IAsyncRelayCommand AuthorizeCommand { get; }
        public NavigationSenderViewModel SenderViewModel { get; } = new NavigationSenderViewModel();


        public AuthorizeViewModel()
        {
            AuthorizeCommand = new AsyncRelayCommand(Authorize, () => AuthorizeCanExecute());
            this.ValidateAllProperties();
        }

        public async Task SetEmail()
        {
        }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "The Email adress is not well formed")]
        public string? EmailAddress
        {
            get => emailAddress;
            set
            {
                SetProperty(ref emailAddress, value);
                ValidateProperty(emailAddress);
                AuthorizeCommand.NotifyCanExecuteChanged();
            }
        }

        public async Task Authorize()
        {
            EmailAddress = "joe@doe.com";
            SenderViewModel.SendUserMessage(new NavigationModel(true, "server"));
        }

        public bool AuthorizeCanExecute()
        {
            return HasErrors;
        }
    }
}
