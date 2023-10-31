using System;
using System.Collections.Generic;

namespace Labb3_NET22.DataModels;

public class Quiz : NotifyPropertyChangedHandler
{
    private List<Question> _questions { get; set; } = new List<Question>();
    public List<Question> Questions
    {
        get { return _questions; }
        set { _questions = value; NotifyPropertyChanged(nameof(Questions)); }
    }
    private string _title;
    public string Title
    {
        get { return _title; }
        set { _title = value; NotifyPropertyChanged(nameof(Title)); }
    }

    public Quiz(string title)
    {
        Title = title;
        Questions = new List<Question>();
    }

    public Question GetRandomQuestion()
    {
        throw new NotImplementedException("A random Question needs to be returned here!");
    }

    public void AddQuestion(string statement, int correctAnswer, params string[] answers)
    {
        List<string> Answers = new List<string>();
        foreach (string answer in answers)
        {
            Answers.Add(answer);
        }
        Question question = new Question(statement, correctAnswer, Answers);
        Questions.Add(question);
    }

    public void RemoveQuestion(int index)
    {
        Questions.RemoveAt(index);
    }
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Quiz otherQuiz = (Quiz)obj;
        return Title == otherQuiz.Title;
    }

    public override int GetHashCode()
    {
        return Title.GetHashCode();
    }
}
