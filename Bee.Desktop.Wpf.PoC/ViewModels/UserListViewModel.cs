using Bee.Desktop.Wpf.PoC.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
    public partial class UserListViewModel : BaseViewModel
    {
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        public ObservableCollection<UserModel>? users;

        public UserListViewModel()
        {
            Users = new ObservableCollection<UserModel>
            { 
                new UserModel { EmailAddress = "joe.k.nd@oultook.com", Name = "Gabe Valencia", IsSelected = false},
                new UserModel { EmailAddress = "joe-k.nd@oultook.com", Name = "Jose Valencia", IsSelected = false},
                new UserModel { EmailAddress = "ingjrz@gmail.com", Name = "Javier Rivera", IsSelected = false},
                new UserModel { EmailAddress = "mxsmax@gmail.com", Name = "Gabriel", IsSelected = false},
                new UserModel { EmailAddress = "IsFake@Address.com", Name = "Fake Account", IsSelected = false},
            };

            SaveCommand.NotifyCanExecuteChanged();
            ValidateAllProperties();
        }

        partial void OnUsersChanging(ObservableCollection<UserModel>? value)
        {
            MessageBox.Show("entre");
        }

        [RelayCommand(CanExecute = nameof(CanSave))]
        public void Save()
        {
            var usersCount = Users?.Select(x => x.IsSelected == true).Count();
            MessageBox.Show($"Saved: {usersCount} user(s) selected");
        }

        public bool CanSave()
        {
            var isValid = Users.Any(x => x.IsSelected == true);

            return isValid;
        }
    }
}
