using System;
using System.Collections.Generic;
using System.Text;

namespace WaterDrinkReminder.Config
{
    public interface IConfigManager
    {
        Config LoadOrCreate();
        void Save(Config config);
    }
}
