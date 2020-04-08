using GalaSoft.MvvmLight;
using System.ComponentModel;

namespace WaterDrinkReminder
{
    public class MainWindowViewModel : ViewModelBase
    {

        public int _delay;

        public int Delay
        {
            get { return _delay; }
            set { _delay = value; 
                RaisePropertyChanged();
            }
        }
    }
}