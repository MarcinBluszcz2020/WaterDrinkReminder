using System;
using System.Collections.Generic;
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
using Notifications.Wpf;


namespace WaterDrinkReminder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NotifyExecuter _notifyExecuter;
        NotifyProvider _notifyProvider;
        private MainWindowViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            var configuration = LoadOrCreateConfiguration();
            _viewModel = new MainWindowViewModel();
            this.DataContext = _viewModel;
            _notifyProvider = new NotifyProvider();
            _notifyExecuter = new NotifyExecuter(configuration, _notifyProvider);
        }


        private void Save()
        {
            //save to file
            _notifyExecuter.Dispose();
            _notifyExecuter = new NotifyExecuter(null, _notifyProvider);
        }

        private Configuration LoadOrCreateConfiguration()
        {
            Configuration result;

            var fileName = "config.xml";
            var fileExists = FileHelper.FileExists(fileName);
            if (fileExists == false)
            {
                var newConfiguration = new Configuration()
                {
                    NotificationIntervalMinutes = 10
                };
                FileHelper.Save(newConfiguration, fileName);
                result = newConfiguration;
            }
            else
            {
                result = FileHelper.Load<Configuration>(fileName);
            }

            return result;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
