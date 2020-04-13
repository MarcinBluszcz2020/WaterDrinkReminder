using Hardcodet.Wpf.TaskbarNotification;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WaterDrinkReminder
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private TaskbarIcon _notifyIcon;
        private RemindNotifications.NotificationManager _notificationManager;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var configurationManager = new WaterDrinkReminder.Config.ConfigManager();
            var configuration = configurationManager.LoadOrCreate();
            _notificationManager = new WaterDrinkReminder.RemindNotifications.NotificationManager(configuration);

            var settingsWindow = new SettingsWindow(configurationManager, _notificationManager);

            _notifyIcon = (TaskbarIcon)FindResource("NotifyIcon");
            _notifyIcon.DataContext = new NotifyIconViewModel(settingsWindow, _notificationManager.Sequencer);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _notificationManager.Stop();
            _notifyIcon.Dispose(); //the icon would clean up automatically, but this is cleaner
            base.OnExit(e);
        }

    }
}
