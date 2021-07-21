using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DTSBox_WPF.Common
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        // boiler-plate
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}