using POFF.KickerModel.Interfaces;

namespace POFF.KickerModel.Types;


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