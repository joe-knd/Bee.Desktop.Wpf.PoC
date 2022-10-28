using Bee.Desktop.Wpf.PoC.Models;
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

namespace Bee.Desktop.Wpf.PoC.Messenger
{
    public partial class ServerViewModel : BaseViewModel
    {
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Printer IP address is required")]
        [RegularExpression("^(?:[0-9]{1,3}\\.){3}[0-9]{1,3}$", ErrorMessage = "IP Address is not well formed")]
        private string? ipAddress = string.Empty;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Printer Port address is required")]
        [Range(1, 99999, ErrorMessage = "Invalid range")]
        private string? port = string.Empty;

        public ServerViewModel()
        {
            ValidateAllProperties();
        }

        [RelayCommand(CanExecute = nameof(CanSave))]
        public Task Save()
        {
            MessageBox.Show("Authorized");

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

        public bool CanSave()
        {
            return !HasErrors;
        }
    }
}
