using System;
using System.Collections.Generic;
using System.Text;
using WaterDrinkReminder.Config;
using WaterDrinkReminder.Sequencer;

namespace WaterDrinkReminder.RemindNotifications
{
    public class NotificationManager : INotificationManager
    {
        private Config.Config _config;
        private ISequencer _sequencer;
        private INotifier _notifier;

        public ISequencer Sequencer
        {
            get { return _sequencer; }
        }

        public NotificationManager(Config.Config config)
        {
            _config = config;
            _notifier = new Notifier(config);

            var interval = TimeSpan.FromMinutes(config.NotificationIntervalMinutes);
            _sequencer = new Sequencer.Sequencer(interval, () => _notifier.ShowNotification(interval));
        }

        public void Update(Config.Config config)
        {
            _config = config;
            var interval = TimeSpan.FromMinutes(config.NotificationIntervalMinutes);
            _sequencer.SetInterval(interval);
            _notifier.Update(config);
        }

        public void Stop()
        {
            _sequencer.Dispose();
            _notifier.Dispose();
        }
    }
}
