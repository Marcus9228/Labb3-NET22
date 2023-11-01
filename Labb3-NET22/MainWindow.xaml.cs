using Labb3_NET22.DataModels;
using System.Windows;


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
            //JsonHelperClass.SetupCategory();
            gameWindow.ShowDialog();
        }

        private void ExitGameButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
