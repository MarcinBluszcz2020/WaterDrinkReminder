using System;
using System.Collections.Generic;
using System.Text;

namespace WaterDrinkReminder.Config
{
    [Serializable]
    public class Config
    {
        public int NotificationIntervalMinutes { get; set; }
        public bool UseBlinking { get; set; }
    }
}
