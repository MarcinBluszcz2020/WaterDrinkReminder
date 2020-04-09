using System;
using System.Collections.Generic;
using System.Text;
using WaterDrinkReminder.Config;

namespace WaterDrinkReminder.Interfaces
{
    public interface INotificationManager
    {
        void Update(Configuration configuration);
        void Stop();
    }
}
