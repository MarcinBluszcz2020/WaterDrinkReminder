using System;
using System.Collections.Generic;
using System.Text;

namespace WaterDrinkReminder
{
    [Serializable]
    public class Configuration
    {
        public int NotificationIntervalMinutes { get; set; }
        public bool UseBlinking { get; set; }
    }
}
