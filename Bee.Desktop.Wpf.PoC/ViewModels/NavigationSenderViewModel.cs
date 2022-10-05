using Bee.Desktop.Wpf.PoC.Messenger;
using Bee.Desktop.Wpf.PoC.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace Bee.Desktop.Wpf.PoC.ViewModels
{
    // Simple viewmodel for a module sending a username message
    public partial class NavigationSenderViewModel : ObservableRecipient
    {
        public void SendUserMessage(NavigationModel navigationModel)
        {
            Messenger.Send(new NavigationChangedMessage(navigationModel));
        }
    }

}
