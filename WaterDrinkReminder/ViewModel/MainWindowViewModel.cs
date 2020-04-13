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

        public MainWindowViewModel(Config.Config config)
        {
            NotificationIntervalMinutes = config.NotificationIntervalMinutes;
        }


        public Config.Config GetConfiguration()
        {
            var result = new Config.Config();
            result.NotificationIntervalMinutes = NotificationIntervalMinutes;
            return result;
        }
    }
}