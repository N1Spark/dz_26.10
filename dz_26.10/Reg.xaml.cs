using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace dz_26._10
{
    /// <summary>
    /// Interaction logic for Reg.xaml
    /// </summary>
    public partial class Reg : Window
    {
        public static RoutedCommand RegCommand = new RoutedCommand();
        public static RoutedCommand CancCommand = new RoutedCommand();
        public Reg()
        {
            InitializeComponent();
            CommandBinding binding;
            binding = new CommandBinding(RegCommand, RegisterButton_Executed, CanExecuteRegisterCommand);
            CommandBindings.Add(binding);
            binding = new CommandBinding(CancCommand, Cancle_Command, CanExecuteCancle_Command);
            CommandBindings.Add(binding);
        }
        private void RegisterButton_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string userData = LoginTxtBlock.Text;
            MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (mainWindow != null)
            {
                mainWindow.SetUserData(userData);
                this.Close();
            }
        }
        private void CanExecuteRegisterCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Cancle_Command(object sender, ExecutedRoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

            if (mainWindow != null)
            {
                this.Close();
            }
        }
        private void CanExecuteCancle_Command(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}

