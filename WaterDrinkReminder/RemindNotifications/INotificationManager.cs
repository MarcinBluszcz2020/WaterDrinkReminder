using WaterDrinkReminder.Config;

namespace WaterDrinkReminder.RemindNotifications
{
    public interface INotificationManager
    {
        void Update(Config.Config config);
        void Stop();
    }
}
