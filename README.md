# 🎮 Quiz Game (C# Console App)

A fun and interactive **Quiz Game** built with **C#**, running right in your console!  
The questions are loaded dynamically from **CSV files** that were created using **web scraping via API**, making every category full of real, interesting questions 🤓  

---

## 🚀 Features

- 🧩 **Multiple Categories** — Choose from different question topics.  
- 🎯 **Custom Question Count** — Decide how many questions you want to be asked.  
- 🧠 **Randomized Questions** — No two games are ever the same!  
- 👤 **Player Tracking** — Each player's name, score, and accuracy are saved.  
- 🏆 **Leaderboard** — See how you rank compared to other players at the end.  

---

## 🗂️ Project Structure
QuizGame/
├── Data/
│ ├── general_questions.csv
│ ├── science_questions.csv
│ └── ...
├── ProgramQuizGame.cs
├── Settings.cs
└── README.md


## 🕹️ How to Run

### Option 1: Using Visual Studio
1. Clone the repository:
   ```bash
   git clone https://github.com/<BahaaElsheikh>/<QuizGame>.git

### Option 2: Using Command Line 
cd QuizGame
dotnet run --project QuizGame.csproj



📦 Data Source

All question data was generated automatically via API-based web scraping, then stored in CSV files for offline use.

   
🧑‍💻 Author

Bahaa Elshikh
💬 Feel free to fork this project, try it out, and submit your own question categories!
