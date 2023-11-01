using Labb3_NET22.DataModels;
using System;
using System.IO;
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
using Newtonsoft.Json;

namespace Labb3_NET22
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
            ReadFiles();
            SelectQuizComboBox.ItemsSource = JsonHelperClass.ListOfQuiz;
        }
        private async void ReadFiles()
        {
            await JsonHelperClass.ReadFiles();
        }

        private async void NewQuiz()
        {
            Quiz quiz = new Quiz(NameOfQuizTextBox.Text);
            JsonHelperClass.SelectedQuiz = quiz;
            JsonHelperClass.ListOfQuiz.Add(quiz);
            await JsonHelperClass.WriteFiles();
            await JsonHelperClass.ReadFiles();
            CreateQuizWindow createQuizWindow = new CreateQuizWindow();
            SelectQuizComboBox.ItemsSource = JsonHelperClass.ListOfQuiz;
            NameOfQuizTextBox.Clear();
            createQuizWindow.ShowDialog();
        }

        private void CreateQuizzButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (NameOfQuizTextBox.Text.Length >= 3)
            {
                if (JsonHelperClass.ListOfQuiz.Count == 0)
                {
                    NewQuiz();
                    return;
                }
                bool flag = true;
                foreach (Quiz quiz in JsonHelperClass.ListOfQuiz)
                {
                    if (quiz.Title.ToLower() == NameOfQuizTextBox.Text.ToLower())
                    {
                        flag = false;
                        MessageBox.Show("Name of quiz is already used, please enter a unique name");
                        break;
                    }
                }
                if (flag)
                {
                    NewQuiz();
                }
            } else
            {
                MessageBox.Show("Name must be atleast 3 characters");
            }
        }

        private async void EditQuizzButton_Click(object sender, RoutedEventArgs e)
        {
            await JsonHelperClass.ReadFiles();
            if (SelectQuizComboBox.SelectedItem != null)
            {
                foreach (Quiz quiz in JsonHelperClass.ListOfQuiz)
                {
                    if (quiz.Equals(SelectQuizComboBox.SelectedItem))
                    {
                        JsonHelperClass.SelectedQuiz = quiz;
                        break;
                    }
                }
                CreateQuizWindow createQuizWindow = new CreateQuizWindow();
                createQuizWindow.ShowDialog();
            }
        }

        private async void DeleteQuizzButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Quiz quiz in JsonHelperClass.ListOfQuiz)
            {
                if (quiz.Equals(SelectQuizComboBox.SelectedItem))
                {
                    JsonHelperClass.ListOfQuiz.Remove(quiz);
                    MessageBox.Show(quiz.Title + " was removed");
                    break;
                }
            }
            await JsonHelperClass.WriteFiles();
            SelectQuizComboBox.ItemsSource = JsonHelperClass.ListOfQuiz;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
