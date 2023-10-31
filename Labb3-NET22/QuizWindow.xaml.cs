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
using System.Windows.Shapes;

namespace Labb3_NET22
{
    /// <summary>
    /// Interaction logic for QuizWindow.xaml
    /// </summary>
    public partial class QuizWindow : Window
    {
        double correctAnswers = 0;
        double wrongAnswers = 0;
        int indexOfQuestion = 0;
        int questionNow = 0;

        public QuizWindow()
        {
            InitializeComponent();

            SetQuestion();

            ScoreTextBlock.Text = $"score: {CalculateScore()}%";
        }

        private async void LoadImage()
        {
            try
            {
                QuestionImage.Source = await QuizGenerator.randomQuestions[indexOfQuestion].LoadImageAsync();
            } catch { }
        }

        private void SetQuestion()
        {
            if (indexOfQuestion >= QuizGenerator.randomQuestions.Count)
            {
                MessageBox.Show($"Quiz completed! Your score is {CalculateScore()}%");
                Answer1Button.IsEnabled = false;
                Answer2Button.IsEnabled = false;
                Answer3Button.IsEnabled = false;
                Answer4Button.IsEnabled = false;
                return;
            }

            QuestionStatementTextBlock.Text = QuizGenerator.randomQuestions[indexOfQuestion].Statement;
            Answer1ButtonTextBlock.Text = QuizGenerator.randomQuestions[indexOfQuestion].Answers[0].ToString();
            Answer2ButtonTextBlock.Text = QuizGenerator.randomQuestions[indexOfQuestion].Answers[1].ToString();
            Answer3ButtonTextBlock.Text = QuizGenerator.randomQuestions[indexOfQuestion].Answers[2].ToString();
            Answer4ButtonTextBlock.Text = QuizGenerator.randomQuestions[indexOfQuestion].Answers[3].ToString();

            LoadImage();
            indexOfQuestion++;
            questionNow++;

            RemainingQuestionsTextBlock.Text = $"Question: {questionNow}/{QuizGenerator.randomQuestions.Count}";
        }

        private double CalculateScore()
        {
            double totalAnswers = correctAnswers + wrongAnswers;
            if (totalAnswers == 0)
                return 0;

            double score = correctAnswers / totalAnswers;
            score = Math.Round(score * 100, 0);
            return score;
        }

        private void Answer1Button_Click(object sender, RoutedEventArgs e)
        {
            CheckAnswer(0);
            ScoreTextBlock.Text = $"score: {CalculateScore()}%";
            SetQuestion();
        }

        private void Answer2Button_Click(object sender, RoutedEventArgs e)
        {
            CheckAnswer(1);
            ScoreTextBlock.Text = $"score: {CalculateScore()}%";
            SetQuestion();
        }

        private void Answer3Button_Click(object sender, RoutedEventArgs e)
        {
            CheckAnswer(2);
            ScoreTextBlock.Text = $"score: {CalculateScore()}%";
            SetQuestion();
        }

        private void Answer4Button_Click(object sender, RoutedEventArgs e)
        {
            CheckAnswer(3);
            ScoreTextBlock.Text = $"score: {CalculateScore()}%";
            SetQuestion();
        }

        private void CheckAnswer(int selectedIndex)
        {
            if (QuizGenerator.randomQuestions[indexOfQuestion - 1].CorrectAnswer == selectedIndex)
            {
                correctAnswers++;
            }
            else
            {
                wrongAnswers++;
            }
        }
    }
}
