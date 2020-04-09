using System;
using System.Collections.Generic;
using System.Text;

namespace WaterDrinkReminder.Interfaces
{
    public interface ISequencer : IDisposable
    {
        void SetInterval(TimeSpan interval);
        void Stop();
        void Start();
    }
}
