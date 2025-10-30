using System;


namespace Quiz
{
    //klass som representerar en fråga
    internal class Question
    {
        public string QuestionText { get; set; } //quiz frågan
        public string[] Options { get; set; } //de olika svarsalternativen
        public int CorrectAnswer { get; set; } //visar det rätta svaret 

    }
}
