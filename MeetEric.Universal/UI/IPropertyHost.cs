using System.ComponentModel;

namespace MeetEric.UI
{
    public interface IPropertyHost : INotifyPropertyChanged
    {
        void InvokePropertyChanged(string propertyName);
    }
}