using Labb3_NET22.DataModels;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace Labb3_NET22
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public GameWindow()
        {
            InitializeComponent();
            SelectedQuizComboBox.ItemsSource = JsonHelperClass.ListOfQuiz;
            CategoryStackpanel.ItemsSource = null;
            CategoryStackpanel.ItemsSource = JsonHelperClass.Category;
        }

        private void SelectedQuizComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CategoryStackpanel.IsEnabled = SelectedQuizComboBox.SelectedItem == null;
        }

        private void StartGameButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedQuizComboBox.SelectedItem != null)
            {
                foreach (Quiz quiz in JsonHelperClass.ListOfQuiz)
                {
                    if (quiz.Equals(SelectedQuizComboBox.SelectedItem))
                    {
                        JsonHelperClass.SelectedQuiz = quiz;
                    }
                }
            } else
            {
                Quiz generatedQuiz = new Quiz("generatedQuiz");

                List<string> checkedCategories = new List<string>();

                foreach (var item in CategoryStackpanel.Items)
                {
                    var contentPresenter = CategoryStackpanel.ItemContainerGenerator.ContainerFromItem(item) as ContentPresenter;

                    CheckBox checkbox = GetChildOfType<CheckBox>(contentPresenter);

                    if (checkbox != null && checkbox.IsChecked == true)
                    {
                        checkedCategories.Add(checkbox.Content.ToString());
                    }
                }
                foreach (Quiz quiz in JsonHelperClass.ListOfQuiz)
                {
                    foreach (Question question in quiz.Questions)
                    {
                        if (checkedCategories.Contains(question.Category))
                        generatedQuiz.Questions.Add(question);
                    }
                }
                JsonHelperClass.SelectedQuiz = generatedQuiz;
            }
            QuizGenerator.SetUpQuiz();
            QuizWindow quizWindow = new QuizWindow();
            quizWindow.ShowDialog();
        }

        public static T GetChildOfType<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) return null;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);
                var result = (child as T) ?? GetChildOfType<T>(child);
                if (result != null) return result;
            }
            return null;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClearSelectedQuizButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedQuizComboBox.SelectedItem = null;
            CategoryStackpanel.IsEnabled = true;
        }

        private void ClearCategoriesButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in CategoryStackpanel.Items)
            {
                var contentPresenter = CategoryStackpanel.ItemContainerGenerator.ContainerFromItem(item) as ContentPresenter;

                CheckBox checkbox = GetChildOfType<CheckBox>(contentPresenter);

                if (checkbox != null)
                {
                    checkbox.IsChecked = false;
                }
            }
        }
    }
}
