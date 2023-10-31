using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
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
using System.Windows.Shapes;
using Labb3_NET22.DataModels;
using Microsoft.Win32;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace Labb3_NET22
{
    /// <summary>
    /// Interaction logic for CreateQuizWindow.xaml
    /// </summary>
    public partial class CreateQuizWindow : Window
    {

        public List<string> category = new List<string>();
        public CreateQuizWindow()
        {
            InitializeComponent();

            foreach (Quiz quiz in JsonHelperClass.ListOfQuiz)
            {
                if (quiz.Title == JsonHelperClass.SelectedQuiz.Title)
                {
                    NameOfQuizTextBlock.Text = ("Name of quiz: " + quiz.Title);
                }
            }

            QuestionCategoryComboBox.ItemsSource = category;
            foreach (Quiz quiz in JsonHelperClass.ListOfQuiz)
            {
                if (JsonHelperClass.SelectedQuiz.Title == quiz.Title)
                {
                    EditQuestionComboBox.ItemsSource = quiz.Questions;
                    break;
                }
            }
            UploadImgHint.Text = "Select a question or save as new question before uploading new image";

            UploadImgButton.IsEnabled = false;

            LoadDefaultImage();


        }
        private async void SaveQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> answers = new List<string>
            {
                new TextRange(Answer1TextBox.Document.ContentStart, Answer1TextBox.Document.ContentEnd).Text,
                new TextRange(Answer2TextBox.Document.ContentStart, Answer2TextBox.Document.ContentEnd).Text,
                new TextRange(Answer3TextBox.Document.ContentStart, Answer3TextBox.Document.ContentEnd).Text,
                new TextRange(Answer4TextBox.Document.ContentStart, Answer4TextBox.Document.ContentEnd).Text
            };

            string statement = new TextRange(QuestionInputTextBox.Document.ContentStart, QuestionInputTextBox.Document.ContentEnd).Text;

            Question question = new Question(statement, 0, answers);
            question.Category = QuestionCategoryComboBox.Text;
            foreach (Quiz quiz in JsonHelperClass.ListOfQuiz)
            {
                if (quiz.Title == JsonHelperClass.SelectedQuiz.Title)
                {
                    quiz.Questions.Add(question);
                    break;
                }
            }

            await JsonHelperClass.WriteFiles();

            ClearFields();
            QuestionCategoryComboBox.SelectedItem = null;
            LoadDefaultImage();

            MessageBox.Show("The question was saved to the quiz");
            foreach (Quiz quiz in JsonHelperClass.ListOfQuiz)
            {
                if (JsonHelperClass.SelectedQuiz.Title == quiz.Title)
                {
                    EditQuestionComboBox.ItemsSource = quiz.Questions;
                    break;
                }
            }
            UploadImgHint.Text = "Select a question or save as new question before uploading new image";
            UploadImgButton.IsEnabled = false;
        }

        private async void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            if (EditQuestionComboBox.SelectedItem != null)
            {
                JsonHelperClass.SelectedQuestion.Statement = new TextRange(QuestionInputTextBox.Document.ContentStart, QuestionInputTextBox.Document.ContentEnd).Text;
                JsonHelperClass.SelectedQuestion.Answers[0] = new TextRange(Answer1TextBox.Document.ContentStart, Answer1TextBox.Document.ContentEnd).Text;
                JsonHelperClass.SelectedQuestion.Answers[1] = new TextRange(Answer2TextBox.Document.ContentStart, Answer2TextBox.Document.ContentEnd).Text;
                JsonHelperClass.SelectedQuestion.Answers[2] = new TextRange(Answer3TextBox.Document.ContentStart, Answer3TextBox.Document.ContentEnd).Text;
                JsonHelperClass.SelectedQuestion.Answers[3] = new TextRange(Answer4TextBox.Document.ContentStart, Answer4TextBox.Document.ContentEnd).Text;
                if (QuestionCategoryComboBox.SelectedItem != null)
                {
                    JsonHelperClass.SelectedQuestion.Category = (string)QuestionCategoryComboBox.SelectedItem;
                }
                ClearFields();
                LoadDefaultImage();

                QuestionCategoryComboBox.SelectedItem = null;
                EditQuestionComboBox.SelectedIndex = -1;
                await JsonHelperClass.WriteFiles();
                UploadImgHint.Text = "Select a question or save as new question before uploading new image";
                UploadImgButton.IsEnabled = false;

                MessageBox.Show("Question was updated");
                foreach (Quiz quiz in JsonHelperClass.ListOfQuiz)
                {
                    if (JsonHelperClass.SelectedQuiz.Title == quiz.Title)
                    {
                        EditQuestionComboBox.ItemsSource = quiz.Questions;
                        break;
                    }
                }
            }
        }

        private async void EditQuestionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearFields();
            JsonHelperClass.SelectedQuestion = (Question)EditQuestionComboBox.SelectedItem;
            if (EditQuestionComboBox.SelectedItem != null)
            {
                QuestionInputTextBox.AppendText(JsonHelperClass.SelectedQuestion.Statement);
                Answer1TextBox.AppendText(JsonHelperClass.SelectedQuestion.Answers[0]);
                Answer2TextBox.AppendText(JsonHelperClass.SelectedQuestion.Answers[1]);
                Answer3TextBox.AppendText(JsonHelperClass.SelectedQuestion.Answers[2]);
                Answer4TextBox.AppendText(JsonHelperClass.SelectedQuestion.Answers[3]);
                CreateQuizImage.Source = JsonHelperClass.SelectedQuestion.ImageSource;
                    UploadImgButton.IsEnabled = true;

                if (EditQuestionComboBox.SelectedItem != null)
                {
                    UploadImgHint.Text = "";
                    UploadImgButton.IsEnabled = true;

                    QuestionCategoryComboBox.SelectedItem = JsonHelperClass.SelectedQuestion.Category;
                    CreateQuizImage.Source = await JsonHelperClass.SelectedQuestion.LoadImageAsync();
                }
            }
        }

        private async void DeleteQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            Question question = (Question)EditQuestionComboBox.SelectedItem;
            foreach (Quiz quiz in JsonHelperClass.ListOfQuiz)
            {
                if (quiz.Title == JsonHelperClass.SelectedQuiz.Title)
                {
                    quiz.Questions.Remove(question);
                    break;
                }
            }
            LoadDefaultImage();

            await JsonHelperClass.WriteFiles();
            MessageBox.Show("Selected question was deleted");
            foreach (Quiz quiz in JsonHelperClass.ListOfQuiz)
            {
                if (JsonHelperClass.SelectedQuiz.Title == quiz.Title)
                {
                    EditQuestionComboBox.ItemsSource = quiz.Questions;
                    break;
                }
            }
            UploadImgHint.Text = "Select a question or save as new question before uploading new image";
            UploadImgButton.IsEnabled = false;
        }

        private void LoadDefaultImage()
        {
            string path = @"..\..\Images\DefaultImage.jpg";
            Uri imageUri = new Uri(path, UriKind.Relative);
            CreateQuizImage.Source = new BitmapImage(imageUri);
        }

        private async void ChangeNameButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Quiz quiz in JsonHelperClass.ListOfQuiz)
            {
                if (quiz.Title == JsonHelperClass.SelectedQuiz.Title)
                {
                    quiz.Title = RenameQuizTexBox.Text;
                    NameOfQuizTextBlock.Text = ("Name of quiz: " + quiz.Title);
                    break;
                }
            }
            await JsonHelperClass.WriteFiles();

        }

        private void UploadImgButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    BitmapImage image = new BitmapImage(new Uri(openFileDialog.FileName));
                    CreateQuizImage.Source = image;
                    byte[] imageData = File.ReadAllBytes(openFileDialog.FileName);
                    string base64Image = Convert.ToBase64String(imageData);
                    JsonHelperClass.SelectedQuestion.ImageData = base64Image;
                } catch
                {

                }
            }
        }
        private void ClearFields()
        {
            QuestionInputTextBox.Document.Blocks.Clear();
            Answer1TextBox.Document.Blocks.Clear();
            Answer2TextBox.Document.Blocks.Clear();
            Answer3TextBox.Document.Blocks.Clear();
            Answer4TextBox.Document.Blocks.Clear();
        }
    }
}
