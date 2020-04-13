using WaterDrinkReminder.Config;
using WaterDrinkReminder.Sequencer;

namespace WaterDrinkReminder.RemindNotifications
{
    public interface INotificationManager
    {
        void Update(Config.Config config);
        void Stop();

        ISequencer Sequencer { get; }
    }
}
