using GalaSoft.MvvmLight;
using System.ComponentModel;
using WaterDrinkReminder.Config;
using System.Windows.Media;

namespace WaterDrinkReminder
{
    public class SettingsWindowViewModel : ViewModelBase
    {

        private int _notificationIntervalMinutes;
        private Color? _fontColor;
        private Color? _backgroundColor;

        public int NotificationIntervalMinutes
        {
            get { return _notificationIntervalMinutes; }
            set
            {
                _notificationIntervalMinutes = value;
                RaisePropertyChanged();
            }
        }


        public Color? FontColor
        {
            get { return _fontColor; }
            set
            {
                _fontColor = value;
                RaisePropertyChanged();
            }
        }

        public Color? BackgroundColor
        {
            get { return _backgroundColor; }
            set
            {
                _backgroundColor = value;
                RaisePropertyChanged();
            }
        }

        public SettingsWindowViewModel(Config.Config config)
        {
            NotificationIntervalMinutes = config.NotificationIntervalMinutes;
            FontColor = Config.Config.Parse(config.FontColorString);
            BackgroundColor = Config.Config.Parse(config.BackgroundColorString);
        }

        public Config.Config GetConfiguration()
        {
            var result = new Config.Config();
            result.NotificationIntervalMinutes = NotificationIntervalMinutes;
            result.BackgroundColorString = BackgroundColor.Value.ToString();
            result.FontColorString = FontColor.Value.ToString();
            return result;
        }
    }
}