using System;
using System.Collections.Generic;
using System.Text;

namespace WaterDrinkReminder.Sequencer
{
    public interface ISequencer : IDisposable
    {
        void SetInterval(TimeSpan interval);
    }
}
