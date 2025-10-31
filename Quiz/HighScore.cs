using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;

namespace Quiz
{
    internal class HighScore
    {
        private const string Filename = "results.json"; //lagrar resultat i denna fil

        //sparar ett nytt resultat från quizet
        public void SaveResult( string name, int score, int total)
        {
            var result = new Results
            {
                Player = name,
                Score = score,
                Total = total,
                Date = DateTime.Now
            };

            var results = LoadResult();
            results.Add(result);

            //soterar poängen, börjar med det högsta
            results = results.OrderByDescending( result =>  result.Score ).ThenBy(result => result.Date ).Take(15).ToList();

            string json = JsonSerializer.Serialize(results, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(Filename, json);

        }

        //läser in resultaten från Json-filen
        private List<Results>LoadResult()
        {
            if(!File.Exists(Filename))
                return new List<Results>();

            string json = File.ReadAllText(Filename);
            return JsonSerializer.Deserialize<List<Results>>(json) ?? new List<Results>();
        }

        //visar HighScore resultaten
        public void ShowHighScore()
        {
            //rensar konsol och skriver ut rubriken
            Console.Clear();
            Console.WriteLine("=======================================================");
            Console.WriteLine("                     HIGHSCORE ");
            Console.WriteLine("=======================================================");

            //hämtar sparade resultat från json-fil 
            var results = LoadResult();

            //om inga resultat finns visas ett meddelande
            if (results.Count == 0)
            {
                Console.WriteLine("Finns inga resultat att visa ännu!");
            } else
            {
                //denna håller koll på vilekn plats man hamnar pp i topplistan
                int ranking = 1;

                //loopar genom de 15 bästa resultaten
                foreach( var r in results.Take(15))
                {
                    string rankText;

                    //bestämmer hur resultaten skrivs ut i topplistan
                    switch (ranking)
                    {
                        case 1:
                            rankText = "1. ";
                            break;
                        case 2:
                            rankText = "2. ";
                            break;
                        case 3:
                            rankText = "3. ";
                            break;
                        default:
                            rankText = " ";
                            break;

                    }
                    //skriver ut resultatet
                    Console.WriteLine($"{rankText} {r.Player, -15} {r.Score}/{r.Total} poäng - {r.Date.ToShortDateString()}");
                    ranking++;
                }
            }

            Console.WriteLine("======================================================");
            Console.WriteLine("Tryck på en tangent för att komma tillbaka till menyn!");
            Console.ReadKey(true);
        }

    }
}
