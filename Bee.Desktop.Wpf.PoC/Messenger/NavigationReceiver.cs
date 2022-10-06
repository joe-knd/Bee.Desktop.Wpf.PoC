using Bee.Desktop.Wpf.PoC.Messenger;
using Bee.Desktop.Wpf.PoC.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace Bee.Desktop.Wpf.PoC.Messenger
{
    // Simple viewmodel for a module receiving a username message
    public partial class NavigationReceiver : ObservableRecipient
    {
        [ObservableProperty]
        private NavigationModel? navigationModel;

        protected override void OnActivated()
        {
            Messenger.Register<NavigationReceiver, NavigationChangedMessage>(this, (r, m) => r.NavigationModel = m.Value);
        }


    }

}
