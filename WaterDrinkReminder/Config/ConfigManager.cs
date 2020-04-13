using System;
using System.Collections.Generic;
using System.Text;

namespace WaterDrinkReminder.Config
{
    public class ConfigManager : IConfigManager
    {
        private const string FileName = "config.xml";


        public Config LoadOrCreate()
        {
            Config result;

            var fileExists = FileHelper.FileExists(FileName);
            if (fileExists == false)
            {
                var newConfiguration = new Config()
                {
                    NotificationIntervalMinutes = 10
                };
                FileHelper.Save(newConfiguration, FileName);
                result = newConfiguration;
            }
            else
            {
                result = FileHelper.Load<Config>(FileName);
            }

            return result;
        }

        public void Save(Config config)
        {
            FileHelper.Save(config, FileName);
        }
    }
}
