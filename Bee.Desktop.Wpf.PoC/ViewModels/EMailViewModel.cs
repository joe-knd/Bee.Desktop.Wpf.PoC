using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bee.Desktop.Wpf.PoC.ViewModels
{
    public class EMailViewModel : ObservableValidator
    {
        private string emailAddress = string.Empty;
        private bool canExecuteAuthorize = false;
        public IAsyncRelayCommand AuthorizeCommand { get; }

        public EMailViewModel()
        {
            AuthorizeCommand = new AsyncRelayCommand(Authorize, () => AuthorizeCanExecute());
        }

        public string EmailAddress
        {
            get => emailAddress;
            set
            {
                SetProperty(ref emailAddress, value);
                canExecuteAuthorize = value.Length > 0;
                AuthorizeCommand.NotifyCanExecuteChanged();
            }
        }
        public async Task Authorize()
        {
            MessageBox.Show("Authorized");
        }

        public bool AuthorizeCanExecute()
        {
            return canExecuteAuthorize;
        }
    }
}
