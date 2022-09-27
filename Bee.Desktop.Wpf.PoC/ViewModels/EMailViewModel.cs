using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bee.Desktop.Wpf.PoC.ViewModels
{
    public class EMailViewModel : ObservableValidator
    {
        private string? emailAddress = string.Empty;
        public IAsyncRelayCommand AuthorizeCommand { get; }

        public EMailViewModel()
        {
            AuthorizeCommand = new AsyncRelayCommand(Authorize, () => AuthorizeCanExecute());
            this.ValidateAllProperties();
        }

        [Required]
        [EmailAddress]
        public string? EmailAddress
        {
            get => emailAddress;
            set
            {
                SetProperty(ref emailAddress, value);
                this.ValidateAllProperties();
                AuthorizeCommand.NotifyCanExecuteChanged();
            }
        }
        public async Task Authorize()
        {
            MessageBox.Show("Authorized");
        }

        public bool AuthorizeCanExecute()
        {
            return !this.HasErrors;
        }
    }
}
