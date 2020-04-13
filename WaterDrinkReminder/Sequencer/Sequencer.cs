using System;
using System.Threading;


namespace WaterDrinkReminder.Sequencer
{
    public class Sequencer : ISequencer
    {
        private readonly Timer _timer;
        private readonly Action _action;
        private TimeSpan _interval;

        private DateTime _nextExecutionTimestamp;

        public event EventHandler NextExecutionTimestampChanged;

        public DateTime NextExecutionTimestamp
        {
            get
            {
                return _nextExecutionTimestamp;
            }
            private set
            {
                _nextExecutionTimestamp = value;
                NextExecutionTimestampChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public Sequencer(TimeSpan interval, Action action)
        {
            _action = action;
            _timer = new Timer(TimerElapsed);
            SetInterval(interval);
        }

        public void SetInterval(TimeSpan interval)
        {
            _interval = interval;
            NextExecutionTimestamp = DateTime.Now;
            _timer.Change(TimeSpan.Zero, interval);
        }

        private void TimerElapsed(object state)
        {
            NextExecutionTimestamp = DateTime.Now.Add(_interval);
            _action.Invoke();
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}
