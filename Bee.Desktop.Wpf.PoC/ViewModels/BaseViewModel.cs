using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bee.Desktop.Wpf.PoC.Messenger
{
    public abstract class BaseViewModel : ObservableValidator
    {
        protected NavigationSender NavigationSenderProvider { get; } = new NavigationSender();
    }
}
