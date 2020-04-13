using System;
using System.Threading;


namespace WaterDrinkReminder.Sequencer
{
    public class Sequencer : ISequencer
    {
        private readonly Timer _timer;
        private readonly Action _action;

        public Sequencer(TimeSpan interval, Action action)
        {
            _action = action;
            _timer = new Timer(TimerElapsed);
            SetInterval(interval);
        }

        public void SetInterval(TimeSpan interval)
        {
            _timer.Change(TimeSpan.Zero, interval);
        }

        private void TimerElapsed(object state)
        {
            _action.Invoke();
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}
