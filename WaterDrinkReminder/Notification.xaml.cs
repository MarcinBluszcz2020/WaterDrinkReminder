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

namespace WaterDrinkReminder
{
    /// <summary>
    /// Interaction logic for Notification.xaml
    /// </summary>
    public partial class Notification : UserControl
    {
        Timer _toggleColorTimer;

        public Notification()
        {
            InitializeComponent();
            _toggleColorTimer = new Timer();
            _toggleColorTimer.Interval = 600;
            _toggleColorTimer.Elapsed += _toggleColorTimer_Elapsed;
            _toggleColorTimer.Start();
        }

        private void _toggleColorTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(ToggleColors);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _toggleColorTimer.Elapsed -= _toggleColorTimer_Elapsed;
            _toggleColorTimer.Dispose();
            var parent = this.Parent as Notifications.Wpf.Controls.Notification;

            parent.Close();
        }

        private void ToggleColors()
        {
            if (this.DrinkWaterBtn.Background != Brushes.Orange)
            {
                this.DrinkWaterBtn.Background = Brushes.Orange;
                this.DrinkWaterBtn.Foreground = Brushes.White;
            }
            else
            {
                this.DrinkWaterBtn.Background = Brushes.White;
                this.DrinkWaterBtn.Foreground = Brushes.Orange;
            }
        }
    }
}
