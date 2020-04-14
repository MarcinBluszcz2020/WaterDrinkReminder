using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace WaterDrinkReminder.Config
{
    [Serializable]
    public class Config
    {
        public int NotificationIntervalMinutes { get; set; }
        public string FontColorString { get; set; }
        public string BackgroundColorString { get; set; }

        public static Color? Parse(string colorString)
        {
            return ColorConverter.ConvertFromString(colorString) as Color?;
        }
    }
}
