using Bee.Desktop.Wpf.PoC.Models;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Bee.Desktop.Wpf.PoC.Messenger
{
    // A sample message with a username value
    public sealed class NavigationChangedMessage : ValueChangedMessage<NavigationModel>
    {
        public NavigationChangedMessage(NavigationModel value) : base(value)
        {

        }
    }
}
