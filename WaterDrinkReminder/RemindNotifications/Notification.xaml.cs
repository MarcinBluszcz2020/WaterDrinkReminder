using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WaterDrinkReminder.RemindNotifications
{
    /// <summary>
    /// Interaction logic for Notification.xaml
    /// </summary>
    public partial class Notification : UserControl, IDisposable
    {
        Timer _toggleColorTimer;

        Brush _backColor;
        Brush _fontColor;

        public Notification(Color backgroundColor, Color fontColor)
        {
            InitializeComponent();
            _toggleColorTimer = new Timer();
            _toggleColorTimer.Interval = 600;
            _toggleColorTimer.Elapsed += _toggleColorTimer_Elapsed;
            _toggleColorTimer.Start();

            _backColor = new SolidColorBrush(backgroundColor);
            _fontColor = new SolidColorBrush(fontColor);
        }


        private void _toggleColorTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(ToggleColors);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ToggleColors()
        {
            if (this.DrinkWaterBtn.Background != _backColor)
            {
                this.DrinkWaterBtn.Background = _backColor;
                this.DrinkWaterBtn.Foreground = _fontColor;
            }
            else
            {
                this.DrinkWaterBtn.Background = _fontColor;
                this.DrinkWaterBtn.Foreground = _backColor;
            }
        }

        public void Close()
        {
            var parent = this.Parent as Notifications.Wpf.Controls.Notification;

            if (parent != null)
            {
                Dispatcher.Invoke(parent.Close);
            }
        }

        public void Dispose()
        {
            _toggleColorTimer.Elapsed -= _toggleColorTimer_Elapsed;
            _toggleColorTimer.Dispose();
        }

        public void Update(Color backgroundColor, Color fontColor)
        {
            _backColor = new SolidColorBrush(backgroundColor);
            _fontColor = new SolidColorBrush(fontColor);
        }
    }
}
