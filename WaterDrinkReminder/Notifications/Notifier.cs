using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Windows;
using Notifications.Wpf;
using WaterDrinkReminder.Interfaces;

namespace WaterDrinkReminder
{
    public class Notifier:INotifier
    {
        private Notifications.Wpf.NotificationManager _manager;

        private Notification _notification;

        public Notifier()
        {
            _manager = new Notifications.Wpf.NotificationManager();

            _notification = new Notification();
        }

        public void ShowNotification(TimeSpan timeToAutoClose)
        {
            _notification.Close();
            _manager.Show(_notification, expirationTime: timeToAutoClose);
        }


    }
}
