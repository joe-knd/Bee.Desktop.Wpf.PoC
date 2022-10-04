using Bee.Desktop.Wpf.PoC.Messenger;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace Bee.Desktop.Wpf.PoC.ViewModels
{
    // Simple viewmodel for a module receiving a username message
    public class UserReceiverViewModel : ObservableRecipient
    {
        private string username = "";

        public string Username
        {
            get => username;
            private set => SetProperty(ref username, value);
        }

        protected override void OnActivated()
        {
            Messenger.Register<UserReceiverViewModel, UsernameChangedMessage>(this, (r, m) => r.Username = m.Value);
        }


    }

}
