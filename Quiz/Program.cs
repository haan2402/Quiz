//Projekt - Quiz, Hanna Angeria


using Quiz;
using System;

class Program
{
    //metod som startar programmet
    static void Main()
    {
        //för att svenska tecken ska visas korrekt
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        //skapar ett nytt quizgame.objekt och startar igång spelet 
        var game = new QuizMenu();
        game.Run();
    }
}