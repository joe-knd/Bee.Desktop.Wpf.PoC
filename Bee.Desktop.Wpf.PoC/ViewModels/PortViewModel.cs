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
