using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bee.Desktop.Wpf.PoC.ViewModels
{
    public class ServerViewModel : ObservableValidator
    {
        private string? ipAddress = string.Empty;
        private int? port = 0;
        public IAsyncRelayCommand AuthorizeCommand { get; }

        public ServerViewModel()
        {
            AuthorizeCommand = new AsyncRelayCommand(Authorize, () => AuthorizeCanExecute());
            this.ValidateAllProperties();
        }

        [Required(ErrorMessage ="Printer IP address is required")]
        [RegularExpression ("^(?:[0-9]{1,3}\\.){3}[0-9]{1,3}$")]
        public string? IpAddress
        {
            get => ipAddress;
            set
            {
                SetProperty(ref ipAddress, value);
                ValidateProperty(ipAddress);
                AuthorizeCommand.NotifyCanExecuteChanged();
            }
        }

        [Required(ErrorMessage = "Printer Port address is required")]
        [Range(1,99999)]
        public int? Port
        {
            get => port;
            set
            {
                SetProperty(ref port, value);
                ValidateProperty(port);
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
