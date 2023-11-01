using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;

namespace Labb3_NET22.DataModels;

public class Question : NotifyPropertyChangedHandler
{
    private string _statement;
    public string Statement
    {
        get { return _statement; }
        set { _statement = value; NotifyPropertyChanged(nameof(Statement)); }
    }

    private int _correctAnswer;
    public int CorrectAnswer
    {
        get { return _correctAnswer; }
        set { _correctAnswer = value; NotifyPropertyChanged(nameof(CorrectAnswer)); }
    }

    private List<string> _answers;
    public List<string> Answers
    {
        get { return _answers; }
        set
        {
            _answers = value;
            foreach (var answer in _answers)
            {
                NotifyPropertyChanged(nameof(Answers));
            }
        }
    }

    private string _category;
    public string Category
    {
        get { return _category; }
        set { _category = value; NotifyPropertyChanged(nameof(Category)); }
    }

    private string _imageData;

    public string ImageData
    {
        get { return _imageData; }
        set
        {
            _imageData = value;
            NotifyPropertyChanged(nameof(ImageData));
            NotifyPropertyChanged(nameof(ImageSource));
        }
    }

    [Newtonsoft.Json.JsonConstructor]
    public Question(string statement, int correctAnswer, List<string> answers)
    {
        Statement = statement;
        CorrectAnswer = correctAnswer;
        Answers = answers;
    }

    public Question(Question question)
    {
        Statement = question.Statement;
        CorrectAnswer = question.CorrectAnswer;
        Answers = new List<string>(question.Answers);
        ImageData = question.ImageData;
        Category = question.Category;
    }

    [Newtonsoft.Json.JsonIgnore]
    public BitmapImage ImageSource
    {
        get
        {
            if (string.IsNullOrEmpty(_imageData))
            {
                return GetDefaultImage();
            }

            byte[] bytes = Convert.FromBase64String(_imageData);
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = stream;
                image.EndInit();
                return image;
            }
        }
    }

    public async Task<BitmapImage> LoadImageAsync()
    {
        if (string.IsNullOrEmpty(_imageData))
        {
            return GetDefaultImage();
        }

        byte[] bytes = Convert.FromBase64String(_imageData);
        BitmapImage image = new BitmapImage();

        using (MemoryStream stream = new MemoryStream(bytes))
        {
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.StreamSource = stream;
            await stream.FlushAsync();
            image.EndInit();
        }
        image.Freeze();

        return image;
    }

    private BitmapImage GetDefaultImage()
    {
        string defaultPath = @"..\..\Images\DefaultImage.jpg";

        return new BitmapImage(new Uri(defaultPath, UriKind.Relative));
    }
}