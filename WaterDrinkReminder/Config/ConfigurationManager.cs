using System;
using System.Collections.Generic;
using System.Text;
using WaterDrinkReminder.Interfaces;

namespace WaterDrinkReminder.Config
{
    public class ConfigurationManager : IConfigurationManager
    {
        private const string FileName = "config.xml";


        public Configuration LoadOrCreate()
        {
            Configuration result;

            var fileExists = FileHelper.FileExists(FileName);
            if (fileExists == false)
            {
                var newConfiguration = new Configuration()
                {
                    NotificationIntervalMinutes = 10
                };
                FileHelper.Save(newConfiguration, FileName);
                result = newConfiguration;
            }
            else
            {
                result = FileHelper.Load<Configuration>(FileName);
            }

            return result;
        }

        public void Save(Configuration configuration)
        {
            FileHelper.Save(configuration, FileName);
        }
    }
}
