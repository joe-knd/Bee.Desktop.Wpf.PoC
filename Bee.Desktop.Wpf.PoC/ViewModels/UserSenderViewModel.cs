using Bee.Desktop.Wpf.PoC.Messenger;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace Bee.Desktop.Wpf.PoC.ViewModels
{
    // Simple viewmodel for a module sending a username message
    public class UserSenderViewModel : ObservableRecipient
    {
        private string username = "Bob";

        public string Username
        {
            get => username;
            private set => SetProperty(ref username, value);
        }

        public void SendUserMessage()
        {
            Username = Username == "Bob" ? "Alice" : "Bob";

            Messenger.Send(new UsernameChangedMessage(Username));
        }
    }

}
