using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Labb3_NET22.DataModels
{
    public static class JsonHelperClass
    {
        public static List<string> Category = new List<string>
        {
            "Art",
            "Astronomy",
            "Biology",
            "Cinema",
            "Comics",
            "Computing",
            "Cuisine",
            "Geography",
            "History",
            "Language",
            "Literature",
            "Mathematics",
            "Movies",
            "Music",
            "Mythology",
            "Other",
            "Physics",
            "Politics",
            "Science",
            "Space Exploration",
            "Sports",
            "Technology",
            "Zoology"
        };
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
            ListOfQuiz.Remove(QuizGenerator.SetupDefaultQuiz());
            if (!ListOfQuiz.Contains(QuizGenerator.SetupDefaultQuiz()))
            {
                ListOfQuiz.Add(QuizGenerator.SetupDefaultQuiz());
            }
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
    }
}

