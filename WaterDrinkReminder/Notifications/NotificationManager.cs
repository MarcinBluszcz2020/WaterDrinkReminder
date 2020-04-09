using System;
using System.Collections.Generic;
using System.Text;
using WaterDrinkReminder.Config;
using WaterDrinkReminder.Interfaces;

namespace WaterDrinkReminder
{
    public class NotificationManager : INotificationManager
    {
        private Configuration _configuration;
        private ISequencer _sequencer;
        private INotifier _notifier;

        public NotificationManager(Configuration configuration)
        {
            _configuration = configuration;
            _notifier = new Notifier();

            var interval = TimeSpan.FromMinutes(configuration.NotificationIntervalMinutes);
            _sequencer = new Sequencer.Sequencer(interval, () => _notifier.ShowNotification(interval));
        }

        public void Update(Configuration configuration)
        {
            _configuration = configuration;
            var interval = TimeSpan.FromMinutes(configuration.NotificationIntervalMinutes);
            _sequencer.SetInterval(interval);
        }

        public void Stop()
        {
            _sequencer.Dispose();
        }
    }
}
