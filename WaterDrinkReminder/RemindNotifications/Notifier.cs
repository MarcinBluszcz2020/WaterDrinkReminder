using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Media;
using Notifications.Wpf;


namespace WaterDrinkReminder.RemindNotifications
{
    public class Notifier : INotifier
    {
        private Notifications.Wpf.NotificationManager _manager;

        private Notification _notification;

        public Notifier(Config.Config config)
        {
            _manager = new Notifications.Wpf.NotificationManager();

            Color? backColor = Config.Config.Parse(config.BackgroundColorString);
            Color? fontColor = Config.Config.Parse(config.FontColorString);

            if (backColor.HasValue == false)
            {
                backColor = Colors.Orange;
            }

            if (fontColor.HasValue == false)
            {
                fontColor = Colors.White;
            }

            _notification = new Notification(backColor.Value, fontColor.Value);
        }

        public void ShowNotification(TimeSpan timeToAutoClose)
        {
            _notification.Close();
            _manager.Show(_notification, expirationTime: timeToAutoClose);
        }

        public void Dispose()
        {
            _notification.Dispose();
        }


        public void Update(Config.Config config)
        {
            Color? backColor = Config.Config.Parse(config.BackgroundColorString);
            Color? fontColor = Config.Config.Parse(config.FontColorString);

            if (backColor.HasValue == false)
            {
                backColor = Colors.Orange;
            }

            if (fontColor.HasValue == false)
            {
                fontColor = Colors.White;
            }

            _notification.Update(backColor.Value, fontColor.Value);
        }
    }
}
