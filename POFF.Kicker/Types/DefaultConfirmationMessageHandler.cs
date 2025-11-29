using POFF.Kicker.Interfaces;

namespace POFF.Kicker.Types;


internal class DefaultConfirmationMessageHandler : IConfirmationMessage
{

    private DefaultConfirmationMessageHandler()
    {
        // 
    }

    public static IConfirmationMessage Empty = new DefaultConfirmationMessageHandler();

    public bool Confirm(string message)
    {
        return true;
    }

}