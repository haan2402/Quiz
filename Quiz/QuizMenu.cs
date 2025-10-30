using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace Quiz
{
    //klass som hanterar menyn och styr quiz
    internal class QuizMenu
    {
        //objekt för highscore funktioner 
        private HighScore highScore = new HighScore();

        //loop för quizet
        public void Run()
        {
            bool running = true; //en variabel som kontrollerar om menyn ska visas

            //en loop som körs till användaren väljer att trycka på avsluta
            while (running)
            {
                Console.Clear();
                Console.WriteLine("=======================================================");
                Console.WriteLine("                       QUIZ ");
                Console.WriteLine("=======================================================");
                Console.WriteLine("      Testa dina kunskaper i vårt quiz. Lycka till!");
                Console.WriteLine("=======================================================");
                Console.WriteLine("     1. Starta Quiz");
                Console.WriteLine("     2. Visa regler för Quiz");
                Console.WriteLine("     3. Visa HighScore");
                Console.WriteLine("     4. Avsluta Quiz");
                Console.WriteLine("=======================================================");

                //tar emot vad man klicka in för menyval
                string choice = Console.ReadLine();

                //hanterar valet i menyn
                switch (choice)
                {
                    case "1":
                        QuizStart(); //startar quiz
                        break;
                    case "2":
                        ViewRules(); // visar reglerna
                        break;
                    case "3":
                        highScore.ShowHighScore(); // visar topplistan
                        break;
                    case "4":
                        running = false; //avslutar programmet
                        Console.WriteLine("Avslutar quiz..");
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val!"); //hanterar ogiltigt val
                        Console.ReadKey();
                        break;
                }
            }
        }

        //metoden som startar quizet och läser in frågorna från json filen, samt sparar resultat
         private void QuizStart()
        {
            Console.Clear();
            Console.Write("Skriv in ditt namn: ");
            string playerName = Console.ReadLine(); 

            try
            {
                //läser in json-fil, tolkar json-text och gör om den till en lista med frågor, UT8 för svenska tecken
                string json = File.ReadAllText("questions.json", System.Text.Encoding.UTF8);
                var questions = JsonSerializer.Deserialize<List<Question>>(json);

                //kontroll att listan innehåller frågor
                if (questions == null || questions.Count == 0)
                {
                    Console.WriteLine("Frågorna kunde inte läsas in....");
                    return;
                }

                //skapar ett nytt QuizManage objekt och startar sedan quizet
                var quiz = new QuizManage(questions);
                int score = quiz.Start();

                //sparar resultatet
                highScore.SaveResult(playerName, score, questions.Count);

            }
            //fångar upp om något gick fel
            catch (Exception ex)
            {
                Console.WriteLine("Något gick fel vid inläsning av frågor: " + ex.Message);
            }
            Console.WriteLine("Tryck på en tangent för att avsluta quizet..");
            Console.ReadKey(true);
        }

        //metod för att visa reglerna för quizet
        static void ViewRules()
        {
            Console.Clear();
            Console.WriteLine("==================================================================================================================");
            Console.WriteLine("     QUIZ-REGLER ");
            Console.WriteLine("==================================================================================================================");
            Console.WriteLine("     1. Du kommer att få svara på 10 frågor med tre svarsalternativ.");
            Console.WriteLine("     2. Du kan endast välja mellan 1 och 3 på svarsalternativen.");
            Console.WriteLine("     3. En spelare åt gången.");
            Console.WriteLine("     4. Endast de femton bästa resultaten visas i topplistan.");
            Console.WriteLine("==================================================================================================================");
            Console.WriteLine();
            Console.WriteLine("Tryck på en tangent för att komma tillbaka till menyn!");
            Console.ReadKey(true);
        }
    }
}

