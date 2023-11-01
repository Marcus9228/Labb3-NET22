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
        public static Quiz SetupDefaultQuiz()
        {
            Quiz quiz = new Quiz("Default Quiz (Not editable)");

            List<string> answers1 = new List<string> { "Nitrogen", "Oxygen", "Carbon Dioxide", "Argon" };
            Question question1 = new Question("What is the most abundant gas in the Earth's atmosphere?", 0, answers1);
            quiz.Questions.Add(question1);

            List<string> answers2 = new List<string> { "Nile River", "Amazon River", "Yangtze River", "Mississippi River" };
            Question question2 = new Question("What is the longest river in the world?", 0, answers2);
            quiz.Questions.Add(question2);

            List<string> answers3 = new List<string> { "George Washington", "Thomas Jefferson", "Abraham Lincoln", "John Adams" };
            Question question3 = new Question("Who was the first President of the United States?", 0, answers3);
            quiz.Questions.Add(question3);

            List<string> answers4 = new List<string> { "George Orwell", "Aldous Huxley", "Ray Bradbury", "J.R.R. Tolkien" };
            Question question4 = new Question("Who wrote '1984'?", 0, answers4);
            quiz.Questions.Add(question4);

            List<string> answers5 = new List<string> { "Brazil", "China", "United Kingdom", "Russia" };
            Question question5 = new Question("Which country hosted the 2016 Summer Olympics?", 0, answers5);
            quiz.Questions.Add(question5);

            List<string> answers6 = new List<string> { "Star Wars", "Star Trek", "Avatar", "The Matrix" };
            Question question6 = new Question("Which movie features the quote, 'May the Force be with you'?", 0, answers6);
            quiz.Questions.Add(question6);

            List<string> answers7 = new List<string> { "Liverpool", "London", "Manchester", "Birmingham" };
            Question question7 = new Question("The Beatles were originally formed in which city?", 0, answers7);
            quiz.Questions.Add(question7);

            List<string> answers8 = new List<string> { "Leonardo da Vinci", "Vincent van Gogh", "Pablo Picasso", "Michelangelo" };
            Question question8 = new Question("The Mona Lisa was painted by which artist?", 0, answers8);
            quiz.Questions.Add(question8);

            List<string> answers9 = new List<string> { "HyperText Transfer Protocol", "Hyperlink Tracking Technology Protocol", "Highspeed Transfer Text Protocol", "HyperText Translation Protocol" };
            Question question9 = new Question("What does 'HTTP' stand for in website addresses?", 0, answers9);
            quiz.Questions.Add(question9);

            List<string> answers10 = new List<string> { "Canberra", "Sydney", "Melbourne", "Perth" };
            Question question10 = new Question("What is the capital of Australia?", 0, answers10);
            quiz.Questions.Add(question10);

            List<string> answers11 = new List<string> { "Lemon", "Grapefruit", "Orange", "Lime" };
            Question question11 = new Question("Which fruit is known to be the primary ingredient in traditional Italian limoncello?", 0, answers11);
            quiz.Questions.Add(question11);

            List<string> answers12 = new List<string> { "Athena", "Aphrodite", "Hera", "Artemis" };
            Question question12 = new Question("In Greek mythology, who is the goddess of wisdom?", 0, answers12);
            quiz.Questions.Add(question12);

            List<string> answers13 = new List<string> { "Casa", "Hogar", "Maison", "Haus" };
            Question question13 = new Question("What is the Spanish word for 'house'?", 0, answers13);
            quiz.Questions.Add(question13);

            List<string> answers14 = new List<string> { "Mars", "Jupiter", "Venus", "Saturn" };
            Question question14 = new Question("Which planet is known as the 'Red Planet'?", 0, answers14);
            quiz.Questions.Add(question14);

            List<string> answers15 = new List<string> { "Mitochondria", "Nucleus", "Endoplasmic reticulum", "Golgi apparatus" };
            Question question15 = new Question("What is the powerhouse of the cell?", 0, answers15);
            quiz.Questions.Add(question15);

            List<string> answers16 = new List<string> { "Deadpool", "Batman", "Spider-Man", "Wolverine" };
            Question question16 = new Question("Which character is known as the 'Merc with a Mouth'?", 0, answers16);
            quiz.Questions.Add(question16);

            List<string> answers17 = new List<string> { "Margaret Thatcher", "Theresa May", "Indira Gandhi", "Angela Merkel" };
            Question question17 = new Question("Who was the first female Prime Minister of the United Kingdom?", 0, answers17);
            quiz.Questions.Add(question17);

            List<string> answers18 = new List<string> { "Mass", "Weight", "Density", "Volume" };
            Question question18 = new Question("What is the term for the amount of matter in an object?", 0, answers18);
            quiz.Questions.Add(question18);

            List<string> answers19 = new List<string> { "Steven Spielberg", "Martin Scorsese", "Ridley Scott", "Quentin Tarantino" };
            Question question19 = new Question("Who directed the movie 'Schindler's List'?", 0, answers19);
            quiz.Questions.Add(question19);

            List<string> answers20 = new List<string> { "3.14", "3.15", "3.16", "3.17" };
            Question question20 = new Question("What is the value of pi to two decimal places?", 0, answers20);
            quiz.Questions.Add(question20);

            List<string> answers21 = new List<string> { "Saltwater Crocodile", "African Lion", "Great White Shark", "Hippopotamus" };
            Question question21 = new Question("Which mammal is known to have the most powerful bite in the world?", 0, answers21);
            quiz.Questions.Add(question21);

            List<string> answers22 = new List<string> { "Himalayas", "Alps", "Andes", "Rockies" };
            Question question22 = new Question("Mount Everest is located in which mountain range?", 0, answers22);
            quiz.Questions.Add(question22);

            List<string> answers23 = new List<string> { "Pomme", "Poire", "Pêche", "Prune" };
            Question question23 = new Question("What is the French word for 'apple'?", 0, answers23);
            quiz.Questions.Add(question23);

            List<string> answers24 = new List<string> { "Neil Armstrong", "Buzz Aldrin", "Yuri Gagarin", "John Glenn" };
            Question question24 = new Question("Who was the first person to walk on the moon?", 0, answers24);
            quiz.Questions.Add(question24);

            List<string> answers25 = new List<string> { "Jane Austen", "Charlotte Brontë", "Emily Brontë", "Mary Shelley" };
            Question question25 = new Question("Who is the author of 'Pride and Prejudice'?", 0, answers25);
            quiz.Questions.Add(question25);

            List<string> answers26 = new List<string> { "Basketball", "Volleyball", "Tennis", "Baseball" };
            Question question26 = new Question("In which sport would you perform a 'slam dunk'?", 0, answers26);
            quiz.Questions.Add(question26);

            List<string> answers27 = new List<string> { "Piano", "Guitar", "Violin", "Harp" };
            Question question27 = new Question("Which musical instrument has keys, pedals, and strings?", 0, answers27);
            quiz.Questions.Add(question27);

            List<string> answers28 = new List<string> { "Avocado", "Tomato", "Onion", "Lime" };
            Question question28 = new Question("What is the main ingredient in guacamole?", 0, answers28);
            quiz.Questions.Add(question28);

            List<string> answers29 = new List<string> { "Central Processing Unit", "Computer Processing Unit", "Central Performance Unit", "Computer Performance Unit" };
            Question question29 = new Question("What does the acronym 'CPU' stand for?", 0, answers29);
            quiz.Questions.Add(question29);

            List<string> answers30 = new List<string> { "Photosynthesis", "Respiration", "Transpiration", "Fermentation" };
            Question question30 = new Question("What is the process called by which plants make their food?", 0, answers30);
            quiz.Questions.Add(question30);


            return quiz;
        }
    }
}
