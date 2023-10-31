using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3_NET22.DataModels
{
    public static class QuizGenerator
    {
        public static List<Question> randomQuestions;

        public static void SetUpQuiz()
        {
            randomQuestions = new List<Question>();

            randomQuestions.Clear();

            foreach (Question question in JsonHelperClass.SelectedQuiz.Questions)
            {
                randomQuestions.Add(new Question(question));
            }

            Shuffle(randomQuestions);

            foreach (Question question in randomQuestions)
            {
                string originalFirstAnswer = question.Answers[0];
                Shuffle(question.Answers);
                question.CorrectAnswer = question.Answers.IndexOf(originalFirstAnswer);
            }
        }


        private static void Shuffle<T>(List<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
