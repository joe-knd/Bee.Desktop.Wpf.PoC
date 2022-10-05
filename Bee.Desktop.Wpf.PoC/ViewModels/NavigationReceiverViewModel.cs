using Bee.Desktop.Wpf.PoC.Messenger;
using Bee.Desktop.Wpf.PoC.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace Bee.Desktop.Wpf.PoC.ViewModels
{
    // Simple viewmodel for a module receiving a username message
    public partial class NavigationReceiverViewModel : ObservableRecipient
    {
        [ObservableProperty]
        private NavigationModel navigationNext;

        [ObservableProperty]
        private NavigationModel navigationPrevious;

        protected override void OnActivated()
        {
            Messenger.Register<NavigationReceiverViewModel, NavigationChangedMessage>(this, (r, m) => r.NavigationNext = m.Value);
        }


    }

}
