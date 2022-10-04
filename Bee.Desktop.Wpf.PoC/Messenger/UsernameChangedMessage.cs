using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Bee.Desktop.Wpf.PoC.Messenger
{
    // A sample message with a username value
    public sealed class UsernameChangedMessage : ValueChangedMessage<string>
    {
        public UsernameChangedMessage(string value) : base(value)
        {
        }
    }
}
