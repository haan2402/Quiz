using System;


namespace Quiz
{
    //klass som representerar resultaten i highscore
    internal class Results
    {
        public string Player {  get; set; } //användarens namn
        public int Score { get; set; } //poängen
        public int Total { get; set; } // totala antalet frågor i quizet
        public DateTime Date { get; set; }  //när man gjort quizet

    }
}
