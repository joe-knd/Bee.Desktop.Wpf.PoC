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
    public class ServerViewModel : BaseViewModel
    {
        private string? ipAddress = string.Empty;
        private string? port = string.Empty;
        public IAsyncRelayCommand SaveCommand { get; }

        public ServerViewModel()
        {
            SaveCommand = new AsyncRelayCommand(Save, () => SaveCanExecute());
            ValidateAllProperties();
        }

        [Required(ErrorMessage ="Printer IP address is required")]
        [RegularExpression ("^(?:[0-9]{1,3}\\.){3}[0-9]{1,3}$", ErrorMessage ="IP Address is not well formed")]
        public string? IpAddress
        {
            get => ipAddress;
            set
            {
                SetProperty(ref ipAddress, value);
                ValidateProperty(ipAddress);
                SaveCommand.NotifyCanExecuteChanged();
            }
        }

        [Required(ErrorMessage = "Printer Port address is required")]
        [Range(1,99999, ErrorMessage = "Invalid range")]
        public string? Port
        {
            get => port;
            set
            {
                SetProperty(ref port, value);
                ValidateProperty(port);
                SaveCommand.NotifyCanExecuteChanged();
            }
        }

        public async Task Save()
        {
            var r = new Random();
            var password = Guid.NewGuid().ToString().Replace("-", "").Substring(r.Next(0, 9), r.Next(10, 15));
            MessageBox.Show(password);
        }

        public bool SaveCanExecute()
        {
            return !HasErrors;
        }
    }
}
