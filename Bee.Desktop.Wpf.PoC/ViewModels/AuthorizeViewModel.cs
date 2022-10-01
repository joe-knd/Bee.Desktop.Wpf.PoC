using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Bee.Desktop.Wpf.PoC.ViewModels
{
    public class AuthorizeViewModel : BaseViewModel
    {
        private string? emailAddress = string.Empty;
        public IAsyncRelayCommand AuthorizeCommand { get; }

        public AuthorizeViewModel()
        {
            AuthorizeCommand = new AsyncRelayCommand(Authorize, () => AuthorizeCanExecute());
            this.ValidateAllProperties();
        }

        [Required(ErrorMessage ="Email address is required")]
        [EmailAddress(ErrorMessage ="The Email adress is not well formed")]
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
            
            MessageBox.Show("Authorized");
        }

        public bool AuthorizeCanExecute()
        {
            return !HasErrors;
        }
    }
}
