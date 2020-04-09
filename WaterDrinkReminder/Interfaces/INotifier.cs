using System;
using System.Collections.Generic;
using System.Text;

namespace WaterDrinkReminder.Interfaces
{
    public interface INotifier
    {
        void ShowNotification(TimeSpan timeToAutoClose);
    }
}
