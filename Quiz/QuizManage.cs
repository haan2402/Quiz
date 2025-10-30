using System;
using System.Collections.Generic;


namespace Quiz
{
    //klass som ansvarar för logiken i quizet, visar frågor och svarsalternativ, tar emot svar och räknar ut totalpoäng
    internal class QuizManage
    {
        private List<Question> Questions; //lista med frågorna som läses in från json-fil
        private int Score; //håller reda på poängen

        //en kontruktor som tar emot en lista med frågorna
        public QuizManage(List<Question> questions)
        {
            Questions = questions;
            Score = 0;
        }

        //startar quizet och går igenom alla frågorna i listan
        public int Start()
        {

            Score = 0; 

            for(int i=0; i<Questions.Count; i++)
            {
                var quest = Questions[i];

                Console.Clear(); //rensar konsollen innan varje ny fråga
                //skriver ut frågan
                Console.WriteLine($"Fråga {i + 1}/{Questions.Count}");
                Console.WriteLine(quest.QuestionText);
                Console.WriteLine();

                //skriver ut de olika svarsalternativen
                for( int j = 0; j < quest.Options.Length; j++)
                    Console.WriteLine($"{j + 1}. {quest.Options[j]}");

                //hämtar in svaret som skrivits in
                int answer = GetAnswer(quest.Options.Length);

                //en kontroll om svaret är rätt eller fel, lagt på grön färg på rätt svar och röd på fel
                if( answer == quest.CorrectAnswer )
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Rätt svar!");
                    Console.ResetColor();
                    Score++;
                } else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Fel svar! Rätt svar: {quest.Options[quest.CorrectAnswer - 1]}");
                    Console.ResetColor();
                }

                Console.WriteLine("Tryck på en tangent för nästa fråga!");
                Console.ReadKey();
                Console.Clear();
            }

            // när man svarat på alla frågor så visas totalpoängen
            Console.Clear();
            Console.WriteLine("============================================================");
            Console.WriteLine($"Quizet är klart! Du fick {Score} av {Questions.Count} rätt!");
            Console.WriteLine("============================================================");

            return Score; 
        }

        //metod som läser in det användaren svarat och gör en kontroll om det är ett giltigt svar
        private int GetAnswer(int options)
        {
            int answer;
            while (true)
            {
                Console.Write($"Ditt svar: (1-{options}): ");
                string input = Console.ReadLine();

                //omvandlar text till tal och gör en kontroll att det ligger inom 1-3 som är svarsalternativen 
                if (int.TryParse(input, out answer) && answer >= 1 && answer <= options)
                    return answer;

                //skrivs ut vid ogiltigt svar
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Ogiltigt svar! Testa igen!");
                Console.ResetColor();
            }
        }
    }
}
