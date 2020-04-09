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
using WaterDrinkReminder.Interfaces;


namespace WaterDrinkReminder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IConfigurationManager _configurationManager;
        private INotificationManager _notificationManager;
        private MainWindowViewModel _viewModel;

        public MainWindow(IConfigurationManager configurationManager, INotificationManager notificationManager)
        {
            InitializeComponent();
            _configurationManager = configurationManager;
            _notificationManager = notificationManager;
            var configuration = configurationManager.LoadOrCreate();
            
            _viewModel = new MainWindowViewModel(configuration);
            this.DataContext = _viewModel;

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
            this.Close();
        }

 
    }
}
