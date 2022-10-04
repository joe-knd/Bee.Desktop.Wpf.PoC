using CommunityToolkit.Mvvm.Input;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Windows;

namespace Bee.Desktop.Wpf.PoC.ViewModels
{
    public class AuthorizeViewModel : BaseViewModel
    {
        private string? emailAddress = string.Empty;
        public IAsyncRelayCommand AuthorizeCommand { get; }
        public UserSenderViewModel SenderViewModel { get; } = new UserSenderViewModel();


        public AuthorizeViewModel()
        {
            AuthorizeCommand = new AsyncRelayCommand(Authorize, () => AuthorizeCanExecute());
            //ShowServerCommand = new AsyncRelayCommand(SetEmail, () => ShowServerCanExecute());
            this.ValidateAllProperties();
        }

        public async Task SetEmail()
        {

        }

        //public bool ShowServerCanExecute()
        //{
            
        //    return !AuthorizeCanExecute();
        //}

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
                //ShowServerCommand.NotifyCanExecuteChanged();
            }
        }
        public async Task Authorize()
        {
            EmailAddress = "joe@doe.com";        
        }

        public bool AuthorizeCanExecute()
        {
            SenderViewModel.SendUserMessage();
            return HasErrors;
        }
    }
}
