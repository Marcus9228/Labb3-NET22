using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Labb3_NET22.DataModels
{
    public static class JsonHelperClass
    {
        public static List<string> Category { get; set; } = new List<string>();
        
        private static List<Quiz> _listOfQuiz = new List<Quiz>();
        public static List<Quiz> ListOfQuiz 
        {
            get { return _listOfQuiz; }
            set { _listOfQuiz = value; }
        }
        public static string filepath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Labb3-NET22\\savedQuizes.json";
        public static Quiz SelectedQuiz;
        public static Question SelectedQuestion;


        public static async Task ReadFiles()
        {
            if (!File.Exists(filepath))
                return;

            var json = await File.ReadAllTextAsync(filepath);
            List<Quiz> deserialized = JsonConvert.DeserializeObject<List<Quiz>>(json);
            ListOfQuiz = deserialized ?? new List<Quiz>();
            ListOfQuiz.Remove(SetupDefaultQuiz());
            ListOfQuiz.Add(SetupDefaultQuiz());
        }

        public static async Task WriteFiles()
        {
            if (!File.Exists(filepath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filepath));
            }

            string json = JsonConvert.SerializeObject(ListOfQuiz);
            await File.WriteAllTextAsync(filepath, json);
            await ReadFiles();
        }

        public static void SetupCategory()
        {
            Category.Clear();
            Category.Add("History");
            Category.Add("Sports");
            Category.Add("Science");
            Category.Add("Movies");
            Category.Add("Music");
            Category.Add("Geography");
            Category.Add("Politics");
            Category.Add("Other");
        }

        public static Quiz SetupDefaultQuiz()
        {
            Quiz quiz = new Quiz("Default Quiz (Not editable)");
            List<string> answers1 = new List<string> { "Oxygen", "Carbon Dioxide", "Nitrogen", "Argon" };
            Question question1 = new Question("What is the most abundant gas in the Earth's atmosphere?", 2, answers1);
            quiz.Questions.Add(question1);

            List<string> answers2 = new List<string> { "Amazon River", "Nile River", "Yangtze River", "Mississippi River" };
            Question question2 = new Question("What is the longest river in the world?", 1, answers2);
            quiz.Questions.Add(question2);

            List<string> answers3 = new List<string> { "Thomas Jefferson", "Abraham Lincoln", "George Washington", "John Adams" };
            Question question3 = new Question("Who was the first President of the United States?", 2, answers3);
            quiz.Questions.Add(question3);

            List<string> answers4 = new List<string> { "Aldous Huxley", "George Orwell", "Ray Bradbury", "J.R.R. Tolkien" };
            Question question4 = new Question("Who wrote '1984'?", 1, answers4);
            quiz.Questions.Add(question4);

            List<string> answers5 = new List<string> { "Brazil", "China", "United Kingdom", "Russia" };
            Question question5 = new Question("Which country hosted the 2016 Summer Olympics?", 0, answers5);
            quiz.Questions.Add(question5);

            List<string> answers6 = new List<string> { "Star Trek", "Avatar", "Star Wars", "The Matrix" };
            Question question6 = new Question("Which movie features the quote, 'May the Force be with you'?", 2, answers6);
            quiz.Questions.Add(question6);

            List<string> answers7 = new List<string> { "London", "Liverpool", "Manchester", "Birmingham" };
            Question question7 = new Question("The Beatles were originally formed in which city?", 1, answers7);
            quiz.Questions.Add(question7);

            List<string> answers8 = new List<string> { "Vincent van Gogh", "Pablo Picasso", "Leonardo da Vinci", "Michelangelo" };
            Question question8 = new Question("The Mona Lisa was painted by which artist?", 2, answers8);
            quiz.Questions.Add(question8);

            List<string> answers9 = new List<string> { "HyperText Transfer Protocol", "Hyperlink Tracking Technology Protocol", "Highspeed Transfer Text Protocol", "HyperText Translation Protocol" };
            Question question9 = new Question("What does 'HTTP' stand for in website addresses?", 0, answers9);
            quiz.Questions.Add(question9);

            List<string> answers10 = new List<string> { "Sydney", "Melbourne", "Canberra", "Perth" };
            Question question10 = new Question("What is the capital of Australia?", 2, answers10);
            quiz.Questions.Add(question10);

            List<string> answers11 = new List<string> { "Grapefruit", "Orange", "Lemon", "Lime" };
            Question question11 = new Question("Which fruit is known to be the primary ingredient in traditional Italian limoncello?", 2, answers11);
            quiz.Questions.Add(question11);

            List<string> answers12 = new List<string> { "Aphrodite", "Hera", "Athena", "Artemis" };
            Question question12 = new Question("In Greek mythology, who is the goddess of wisdom?", 2, answers12);
            quiz.Questions.Add(question12);

            List<string> answers13 = new List<string> { "Casa", "Hogar", "Maison", "Haus" };
            Question question13 = new Question("What is the Spanish word for 'house'?", 0, answers13);
            quiz.Questions.Add(question13);

            List<string> answers14 = new List<string> { "Jupiter", "Mars", "Venus", "Saturn" };
            Question question14 = new Question("Which planet is known as the 'Red Planet'?", 1, answers14);
            quiz.Questions.Add(question14);

            List<string> answers15 = new List<string> { "Nucleus", "Endoplasmic reticulum", "Mitochondria", "Golgi apparatus" };
            Question question15 = new Question("What is the powerhouse of the cell?", 2, answers15);
            quiz.Questions.Add(question15);

            List<string> answers16 = new List<string> { "Batman", "Spider-Man", "Deadpool", "Wolverine" };
            Question question16 = new Question("Which character is known as the 'Merc with a Mouth'?", 2, answers16);
            quiz.Questions.Add(question16);

            List<string> answers17 = new List<string> { "Theresa May", "Margaret Thatcher", "Indira Gandhi", "Angela Merkel" };
            Question question17 = new Question("Who was the first female Prime Minister of the United Kingdom?", 1, answers17);
            quiz.Questions.Add(question17);

            List<string> answers18 = new List<string> { "Weight", "Density", "Mass", "Volume" };
            Question question18 = new Question("What is the term for the amount of matter in an object?", 2, answers18);
            quiz.Questions.Add(question18);

            List<string> answers19 = new List<string> { "Steven Spielberg", "Martin Scorsese", "Ridley Scott", "Quentin Tarantino" };
            Question question19 = new Question("Who directed the movie 'Schindler's List'?", 0, answers19);
            quiz.Questions.Add(question19);

            List<string> answers20 = new List<string> { "3.14", "3.15", "3.16", "3.17" };
            Question question20 = new Question("What is the value of pi to two decimal places?", 0, answers20);
            quiz.Questions.Add(question20);

            List<string> answers21 = new List<string> { "African Lion", "Great White Shark", "Saltwater Crocodile", "Hippopotamus" };
            Question question21 = new Question("Which mammal is known to have the most powerful bite in the world?", 2, answers21);
            quiz.Questions.Add(question21);

            List<string> answers22 = new List<string> { "Alps", "Andes", "Himalayas", "Rockies" };
            Question question22 = new Question("Mount Everest is located in which mountain range?", 2, answers22);
            quiz.Questions.Add(question22);

            List<string> answers23 = new List<string> { "Pomme", "Poire", "Pêche", "Prune" };
            Question question23 = new Question("What is the French word for 'apple'?", 0, answers23);
            quiz.Questions.Add(question23);

            List<string> answers24 = new List<string> { "Buzz Aldrin", "Yuri Gagarin", "Neil Armstrong", "John Glenn" };
            Question question24 = new Question("Who was the first person to walk on the moon?", 2, answers24);
            quiz.Questions.Add(question24);

            List<string> answers25 = new List<string> { "Charlotte Brontë", "Jane Austen", "Emily Brontë", "Mary Shelley" };
            Question question25 = new Question("Who is the author of 'Pride and Prejudice'?", 1, answers25);
            quiz.Questions.Add(question25);

            List<string> answers26 = new List<string> { "Volleyball", "Basketball", "Tennis", "Baseball" };
            Question question26 = new Question("In which sport would you perform a 'slam dunk'?", 1, answers26);
            quiz.Questions.Add(question26);

            List<string> answers27 = new List<string> { "Guitar", "Violin", "Piano", "Harp" };
            Question question27 = new Question("Which musical instrument has keys, pedals, and strings?", 2, answers27);
            quiz.Questions.Add(question27);

            List<string> answers28 = new List<string> { "Tomato", "Onion", "Avocado", "Lime" };
            Question question28 = new Question("What is the main ingredient in guacamole?", 2, answers28);
            quiz.Questions.Add(question28);

            List<string> answers29 = new List<string> { "Central Processing Unit", "Computer Processing Unit", "Central Performance Unit", "Computer Performance Unit" };
            Question question29 = new Question("What does the acronym 'CPU' stand for?", 0, answers29);
            quiz.Questions.Add(question29);

            List<string> answers30 = new List<string> { "Respiration", "Photosynthesis", "Transpiration", "Fermentation" };
            Question question30 = new Question("What is the process called by which plants make their food?", 1, answers30);
            quiz.Questions.Add(question30);

            return quiz;
        }
    }
}

