using AutoMapper;
using Bee.Data.Abstractions;
using Bee.Data.Abstractions.Extensions;
using Bee.Data.Service;
using Bee.Data.Service.Models;
using Bee.Desktop.Wpf.PoC.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bee.Desktop.Wpf.PoC.Messenger
{
    public partial class AddUserViewModel : ObservableValidator
    {
        private const string DialogIdentifier = "RootDialogManager";

        [Required]
        [EmailAddress]
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveUserCommand))]
        [NotifyDataErrorInfo]
        private string? emailAddress;

        [Required]
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveUserCommand))]
        [NotifyDataErrorInfo]
        private string? name;

        public AddUserViewModel()
        {
            ValidateAllProperties();
        }

        [RelayCommand(CanExecute = nameof(CanSaveUser))]
        public void SaveUser()
        {
            var dialog = DialogHost.GetDialogSession(DialogIdentifier);
            dialog?.Close(true);
        }

        public bool CanSaveUser()
        {
            return !HasErrors;
        }
    }
}
