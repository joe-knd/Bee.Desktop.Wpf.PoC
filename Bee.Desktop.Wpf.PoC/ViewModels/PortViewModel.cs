using CommunityToolkit.Mvvm.Input;
using System;
using System.ComponentModel.DataAnnotations;

namespace Bee.Desktop.Wpf.PoC.ViewModels
{
    public class PortViewModel : MyObservableValidator
    {
        private int? portNumber = null;

        public IAsyncRelayCommand AuthorizeCommand { get; }

        public PortViewModel()
        {
            AuthorizeCommand = new AsyncRelayCommand(Authorize, () => AuthorizeCanExecute());
            this.ValidateAllProperties();
        }

        [Required]
        [Range(0, 9999)]
        [EmailAddress]
        public int? PortNumber
        {
            get => portNumber;
            set
            {
                SetProperty(ref portNumber, value);
                ValidateProperty(portNumber);
                AuthorizeCommand.NotifyCanExecuteChanged();
            }
        }
    }
}
