# Quiz
Detta Quiz är skapar i C# och quizet körs i konsolen. Användaren får 10 frågor att svara på, varje fråga har 3 svarsalternativ, användaren får
ett resultat och får resultaten sparade i en topplista.

## Funktioner
 - Frågor med tre svarsalternativ.
 - Feedback direkt i konsollen, grönt är rätt svar, rött är fel svar, gult är ogiltig inmatning
 - Poängen räknas och topplistan sparas i en JSON-fil
 - Menyn och regler för quizet visas i konsolen
	

## Struktur
Quizet är byggt med följande klasser:
- **Program** - startar sjävla applikationen
- **QuizMenu** - hanterar menyn
- **QuizManage** - hanterar logiken för quizet
- **Question** - representerar en enskild fråga
- **Results** - representerar ett användar resultat
- **HighScore** - sparar och visar resultaten 

## JSON-filer
Frågor och resultat sparas i två JSON-filer:
- `questions.json` - frågorna till quizet
- `results.json` - innehåller resultaten i topplistan 

### Av:
Hanna Angeria - 2025 