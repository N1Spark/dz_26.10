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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace dz_26._10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static private string UserData = "";
        public MainWindow()
        {
            InitializeComponent();
            CommandBinding binding;
            binding = new CommandBinding(ApplicationCommands.New);
            binding.Executed += NewCommand_Executed;
            binding.CanExecute += CommnadBinding_CanExecute;
            CommandBindings.Add(binding);

            binding = new CommandBinding(ApplicationCommands.Open);
            binding.Executed += LoadCommand_Executed;
            binding.CanExecute += LoadCommand_CanExecute;
            CommandBindings.Add(binding);

            binding = new CommandBinding(ApplicationCommands.Save);
            binding.Executed += SaveCommand_Executed;
            binding.CanExecute += SaveCommand_CanExecute;
            CommandBindings.Add(binding);

            binding = new CommandBinding(ApplicationCommands.Cut);
            binding.CanExecute += CutCommand_CanExecute;
            CommandBindings.Add(binding);

            binding = new CommandBinding(ApplicationCommands.Copy);
            binding.CanExecute += CopyCommand_CanExecute;
            CommandBindings.Add(binding);

            binding = new CommandBinding(ApplicationCommands.Paste);
            binding.CanExecute += PasteCommand_CanExecute;
            CommandBindings.Add(binding);

            OpenRegistrationWindow();
        }

        private void OpenRegistrationWindow()
        {
            Reg registrationWindow = new Reg();
            registrationWindow.ShowDialog();
        }

        public void SetUserData(string userData)
        {
            UserData = userData;
        }
        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Testblock.Text = "";
        }

        private void CommnadBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (UserData == "trial" || UserData == "pro")
            {
                e.CanExecute = true;
            }
            else
                e.CanExecute = false;
            e.Handled = false;
        }

        private void LoadCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Text Files|*.txt|All Files|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    string fileContent = File.ReadAllText(filePath);
                    Testblock.Text = fileContent;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while loading the file: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void LoadCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (UserData == "trial" || UserData == "pro")
            {
                e.CanExecute = true;
            }
            else
                e.CanExecute = false;
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = "Text Files|*.txt|All Files|*.*";

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    string textToSave = Testblock.Text;

                    File.WriteAllText(filePath, textToSave);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while saving the file: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (UserData == "trial" || UserData == "pro")
            {
                e.CanExecute = true;
            }
            else
                e.CanExecute = false;
        }
        private void CutCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (UserData == "pro")
            {
                e.CanExecute = true;
            }
            else
                e.CanExecute = false;
        }
        private void CopyCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (UserData == "pro")
            {
                e.CanExecute = true;
            }
            else
                e.CanExecute = false;
            e.Handled = false;
        }
        private void PasteCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (UserData == "pro")
            {
                e.CanExecute = true;
            }
            else
                e.CanExecute = false;
            e.Handled = false;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenRegistrationWindow();
        }
    }
}
