using System;
using System.Collections.Generic;
using System.Text;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using System.Windows;
using Notifications.Wpf;
using ToastNotifications.Messages;

namespace WaterDrinkReminder
{
    public class NotifyProvider
    {
        private NotificationManager _manager;

        public NotifyProvider()
        {
            _manager = new NotificationManager();
        }

        public void ShowNotification()
        {
            _manager.Show(new Notification(), expirationTime: TimeSpan.FromMinutes(120));
        }
    }
}
