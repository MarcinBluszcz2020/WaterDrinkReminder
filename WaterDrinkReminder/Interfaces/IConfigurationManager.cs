using System;
using System.Collections.Generic;
using System.Text;
using WaterDrinkReminder.Config;

namespace WaterDrinkReminder.Interfaces
{
    public interface IConfigurationManager
    {
        Configuration LoadOrCreate();
        void Save(Configuration configuration);
    }
}
