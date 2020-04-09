using GalaSoft.MvvmLight;
using System.ComponentModel;
using WaterDrinkReminder.Config;

namespace WaterDrinkReminder
{
    public class MainWindowViewModel : ViewModelBase
    {

        public int _notificationIntervalMinutes;

        public int NotificationIntervalMinutes
        {
            get { return _notificationIntervalMinutes; }
            set
            {
                _notificationIntervalMinutes = value;
                RaisePropertyChanged();
            }
        }

        public MainWindowViewModel(Configuration configuration)
        {
            NotificationIntervalMinutes = configuration.NotificationIntervalMinutes;
        }


        public Configuration GetConfiguration()
        {
            var result = new Configuration();
            result.NotificationIntervalMinutes = NotificationIntervalMinutes;
            return result;
        }
    }
}