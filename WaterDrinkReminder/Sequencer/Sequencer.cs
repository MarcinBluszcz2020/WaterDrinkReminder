using System;
using System.Collections.Generic;
using System.Text;
using WaterDrinkReminder.Interfaces;
using System.Threading;


namespace WaterDrinkReminder.Sequencer
{
    public class Sequencer : ISequencer
    {
        Timer _timer;
        Action _action;
        TimeSpan _interval;

        public Sequencer(TimeSpan interval, Action action)
        {
            _action = action;
            _timer = new Timer(TimerElapsed);
            _timer.Change(TimeSpan.Zero, interval);
            _interval = interval;
        }

        public void SetInterval(TimeSpan interval)
        {
            _interval = interval;
            Start();
        }

        public void Start()
        {
            _timer.Change(TimeSpan.Zero, _interval);
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }


        private void TimerElapsed(object state)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(_action);
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}
