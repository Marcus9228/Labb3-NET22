using Labb3_NET22.DataModels;
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
using Newtonsoft.Json;

namespace Labb3_NET22
{
    

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ReadFiles();
        }

        private async void ReadFiles()
        {
            await JsonHelperClass.ReadFiles();
        }
        private async void WriteFiles()
        {
            await JsonHelperClass.WriteFiles();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.ShowDialog();
        }

        private void SetupGameButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow gameWindow = new GameWindow();
            JsonHelperClass.SetupCategory();
            gameWindow.ShowDialog();
        }
    }
}
