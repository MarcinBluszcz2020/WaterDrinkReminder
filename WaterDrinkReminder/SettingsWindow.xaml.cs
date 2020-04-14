using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WaterDrinkReminder.RemindNotifications;
using WaterDrinkReminder.Config;


namespace WaterDrinkReminder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private IConfigManager _configurationManager;
        private INotificationManager _notificationManager;
        private SettingsWindowViewModel _viewModel;

        public SettingsWindow(IConfigManager configurationManager, INotificationManager notificationManager)
        {
            InitializeComponent();
            _configurationManager = configurationManager;
            _notificationManager = notificationManager;
            var configuration = configurationManager.LoadOrCreate();

            _viewModel = new SettingsWindowViewModel(configuration);
            this.DataContext = _viewModel;
            this.Closing += SettingsWindow_Closing;
        }

        private void SettingsWindow_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var currentConfiguration = _viewModel.GetConfiguration();
            _configurationManager.Save(currentConfiguration);
            _notificationManager.Update(currentConfiguration);
            this.Hide();
        }

    }
}
