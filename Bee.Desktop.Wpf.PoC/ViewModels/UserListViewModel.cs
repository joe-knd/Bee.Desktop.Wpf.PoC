using AutoMapper;
using Bee.Data.Abstractions;
using Bee.Data.Abstractions.Extensions;
using Bee.Data.Service;
using Bee.Data.Service.Models;
using Bee.Desktop.Wpf.PoC.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
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
        private const string DialogIdentifier = "RootDialogManager";

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        public ObservableCollection<UserModel>? users;

        private readonly IService<User>? _userService;
        private readonly IMapper? _mapper;

        public UserListViewModel()
        {
            _userService = App.Current.ServiceProvider?.GetService(typeof(IService<User>)) as IService<User>;
            _mapper = App.Current.ServiceProvider?.GetService(typeof(IMapper)) as IMapper;

            FillUserList();
        }

        private void FillUserList()
        {
            if (_userService != null)
            {
                //userService?.Insert(new User { Name = "Jose Valencia", Email = "joe.k.nd@outlook.com", EmailConfirmed = "joe.k.nd@outlook.com", Password = string.Empty, PasswordConfirmed = string.Empty });
                //userService?.Insert(new User { Name = "Gabe Valencia", Email = "joe-k.nd@outlook.com", EmailConfirmed = "joe-k.nd@outlook.com", Password = string.Empty, PasswordConfirmed = string.Empty });
                //userService?.Insert(new User { Name = "Javier Rivera", Email = "ingjrz@gmail.com", EmailConfirmed = "ingjrz@gmail.com", Password = string.Empty, PasswordConfirmed = string.Empty });
                //userService?.Insert(new User { Name = "Gabriel", Email = "mxsmax@gmail.com", EmailConfirmed = "mxsmax@gmail.com", Password = string.Empty, PasswordConfirmed = string.Empty });
                //userService?.Insert(new User { Name = "Fake Account", Email = "isfake@outlook.com", EmailConfirmed = "isfake@gmail.com", Password = string.Empty, PasswordConfirmed = string.Empty });

                //Users = _userService.FindAll().Select(x => new UserModel { EmailAddress = x.Email, Name = x.Name, IsSelected = false }).ToList().ToObservableCollection();
                var usrs = _userService.FindAll().ToList();

                if (usrs.Count() != 0)
                {
                    Users = _mapper?.Map<List<UserModel>>(usrs).ToObservableCollection();
                }
            }
            //else
            //{
            //    userService?.Insert(new User { Name = "Jose Valencia", Email = "joe.k.nd@outlook.com", EmailConfirmed = "joe.k.nd@outlook.com", Password = string.Empty, PasswordConfirmed = string.Empty });
            //}
            //Users = new ObservableCollection<UserModel>
            //{ 
            //    new UserModel { EmailAddress = "joe.k.nd@oultook.com", Name = "Gabe Valencia", IsSelected = false},
            //    new UserModel { EmailAddress = "joe-k.nd@oultook.com", Name = "Jose Valencia", IsSelected = false},
            //    new UserModel { EmailAddress = "ingjrz@gmail.com", Name = "Javier Rivera", IsSelected = false},
            //    new UserModel { EmailAddress = "mxsmax@gmail.com", Name = "Gabriel", IsSelected = false},
            //    new UserModel { EmailAddress = "IsFake@Address.com", Name = "Fake Account", IsSelected = false},
            //};

            SaveCommand.NotifyCanExecuteChanged();
            ValidateAllProperties();
        }

        [RelayCommand]
        public void UserSelected()
        {
            SaveCommand.NotifyCanExecuteChanged();
        }

        [RelayCommand(CanExecute = nameof(CanSave))]
        public void Save()
        {
            var users = Users?.Where(x => x.IsSelected == true).ToList();
            MessageBox.Show($"Saved: {users?.Count()} user(s) selected");
        }

        public bool CanSave()
        {
            return Users?.Any(x => x.IsSelected == true)?? false;

        }

        [RelayCommand]
        public async Task AddUser()
        {
            var addUserViewModel = App.Current.ServiceProvider?.GetRequiredService<AddUserViewModel>();
            if (addUserViewModel == null)
            {
                MessageBox.Show("Error adding new user", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            object dialogResult = await MaterialDesignThemes.Wpf.DialogHost.Show(addUserViewModel, DialogIdentifier);
            if (dialogResult is bool boolResult && boolResult)
            {
                _userService?.Insert(new User
                {
                    EmailAddress = addUserViewModel.EmailAddress,
                    EmailConfirmed = addUserViewModel.EmailAddress,
                    Name = addUserViewModel.Name,
                    Password = string.Empty,
                    PasswordConfirmed = string.Empty
                });

                FillUserList();
            }
            
        }
    }
}
