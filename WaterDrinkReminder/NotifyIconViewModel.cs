using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using WaterDrinkReminder.Sequencer;

namespace WaterDrinkReminder
{
    /// <summary>
    /// Provides bindable properties and commands for the NotifyIcon. In this sample, the
    /// view model is assigned to the NotifyIcon in XAML. Alternatively, the startup routing
    /// in App.xaml.cs could have created this view model, and assigned it to the NotifyIcon.
    /// </summary>
    public class NotifyIconViewModel:INotifyPropertyChanged
    {
        private SettingsWindow _settingsWindow;
        private ISequencer _sequencer;

        public NotifyIconViewModel(SettingsWindow settingsWindow, ISequencer sequencer)
        {
            _settingsWindow = settingsWindow;
            _sequencer = sequencer;
            sequencer.NextExecutionTimestampChanged += Sequencer_NextExecutionTimestampChanged;
            var nextExecutionTimestamp = _sequencer.NextExecutionTimestamp.ToShortTimeString();
            ToolTipText =
                $"Water drink reminder{System.Environment.NewLine}Next execution time: {nextExecutionTimestamp}";
        }

        private void Sequencer_NextExecutionTimestampChanged(object sender, EventArgs e)
        {
            var nextExecutionTimestamp = _sequencer.NextExecutionTimestamp.ToShortTimeString();
            ToolTipText =
                $"Water drink reminder{System.Environment.NewLine}Next execution time: {nextExecutionTimestamp}";
        }

        private string _toolTipText;

        public event PropertyChangedEventHandler PropertyChanged;

        public string ToolTipText
        {
            get
            {
                return _toolTipText;
            }
            set
            {
                _toolTipText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ToolTipText"));
            }
        }

        /// <summary>
        /// Shows a window, if none is already open.
        /// </summary>
        public ICommand ShowWindowCommand
        {
            get
            {
                return new DelegateCommand
                {
                    CanExecuteFunc = () => true,
                    CommandAction = () =>
                    {
                        Application.Current.MainWindow = _settingsWindow;
                        Application.Current.MainWindow.Show();
                        Application.Current.MainWindow.WindowState = WindowState.Normal;
                    }
                };
            }
        }


        /// <summary>
        /// Shuts down the application.
        /// </summary>
        public ICommand ExitApplicationCommand
        {
            get
            {
                return new DelegateCommand
                {
                    CommandAction = () => Application.Current.Shutdown()

                };
            }
        }
    }


    /// <summary>
    /// Simplistic delegate command for the demo.
    /// </summary>
    public class DelegateCommand : ICommand
    {
        public Action CommandAction { get; set; }
        public Func<bool> CanExecuteFunc { get; set; }

        public void Execute(object parameter)
        {
            CommandAction();
        }

        public bool CanExecute(object parameter)
        {
            return CanExecuteFunc == null || CanExecuteFunc();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
