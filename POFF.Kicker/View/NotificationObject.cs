using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace POFF.Kicker.View;

public class NotificationObject : INotifyPropertyChanged
{

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}