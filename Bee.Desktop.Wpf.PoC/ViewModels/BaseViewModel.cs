using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bee.Desktop.Wpf.PoC.Messenger
{
    public abstract partial class BaseViewModel : ObservableValidator
    {
        protected bool canNavigateNext;
        protected BaseViewModel? NextViewModel;

        protected NavigationSender NavigationSenderProvider { get; } = new();
        public bool CanNavigateNext()
        {
            return canNavigateNext;
        }

        [RelayCommand(CanExecute = nameof(CanNavigateNext))]
        public virtual void NavigateNext()
        {
            
        }
    }
}
