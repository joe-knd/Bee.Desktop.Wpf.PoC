using AutoMapper;
using Bee.Data.Abstractions;
using Bee.Data.Abstractions.Extensions;
using Bee.Data.Service;
using Bee.Data.Service.Models;
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
    public partial class ScrollViewModel : BaseViewModel
    {
        [RelayCommand]
        public Task UserList()
        {
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

    }
}
