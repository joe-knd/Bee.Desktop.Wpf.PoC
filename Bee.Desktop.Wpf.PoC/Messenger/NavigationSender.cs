using Bee.Desktop.Wpf.PoC.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace Bee.Desktop.Wpf.PoC.Messenger
{
    // Simple viewmodel for a module sending a username message
    public partial class NavigationSender : ObservableRecipient
    {
        public void SendNavigationChangeMessage(NavigationModel navigationModel)
        {
            Messenger.Send(new NavigationChangedMessage(navigationModel));
        }
    }

}
