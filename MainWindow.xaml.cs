using System;
using System.Collections.Generic;
using System.IO;
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

namespace ExamTemperatureMonitoring
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                // Open document
                string pathName = dlg.FileName;
                using (StreamReader file = new StreamReader(pathName))
                {

                    string temp = file.ReadLine();
                    tbStartTime.Text = temp;
                    temp = file.ReadLine();
                    tbData.Text = temp;

                }

            }
        }

        private void btnReport_Copy_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Document";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";

            Nullable<bool> result = dlg.ShowDialog();
    
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
            }
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbTempMin.Text != null || tbTempMin.Text != "" || tbTimeMax.Text != null || tbTimeMax.Text != "")
                {
                    Violation report = new Violation(tbFishName.Text, Convert.ToInt32(tbTempMax.Text), Convert.ToInt32(tbTimeMax.Text),
                                                     Convert.ToInt32(tbTempMin.Text), Convert.ToInt32(tbTimeMin.Text),
                                                     tbData.Text, tbStartTime.Text);
                    string result = report.Pursing();
                    tbResult.Text = result;
                }
                else 
                {
                    Violation report = new Violation(tbFishName.Text, Convert.ToInt32(tbTempMax.Text), Convert.ToInt32(tbTimeMax.Text),
                                                     tbData.Text, tbStartTime.Text);
                    string result = report.Pursing();
                    tbResult.Text = result;
                }
            }
            catch 
            {
                string messageBoxText = "Остались пустые поля либо введены некорректные данные";
                string caption = "Ошибка";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;

                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
        }
    }
}
