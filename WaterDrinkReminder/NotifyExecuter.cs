using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace WaterDrinkReminder
{
    public class NotifyExecuter : IDisposable
    {
        Configuration _configuration;
        Timer _timer;
        NotifyProvider _notifyProvider;

        public NotifyExecuter(Configuration configuration, NotifyProvider notifyProvider)
        {
            _configuration = configuration;
            _notifyProvider = notifyProvider;

            _timer = new Timer(TimerElapsed);
            _timer.Change(TimeSpan.Zero, TimeSpan.FromMinutes(configuration.NotificationIntervalMinutes));
        }

        public void Dispose()
        {
            _timer.Dispose();
        }

        private void TimerElapsed(object state)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(_notifyProvider.ShowNotification);
        }
    }
}
