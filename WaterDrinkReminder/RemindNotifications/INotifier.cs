using System;
using System.Collections.Generic;
using System.Text;

namespace WaterDrinkReminder.RemindNotifications
{
    public interface INotifier : IDisposable
    {
        void ShowNotification(TimeSpan timeToAutoClose);
    }
}
