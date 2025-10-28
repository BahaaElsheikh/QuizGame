using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IO;
namespace QuizGame
{
    internal class ProgramQuizGame
    {
        static class Settings {
            static public int Number { get; set; }
            static public string Category { get; set; }

            //Settings(int number, string category) { 

            //    Number = number;
            //    Category = category;
            //}

        };

        class Player {
            public string? Name { get; set; }

            public int TotalQ { get; set; }
            public int SolvedQ { get; set; }

            public void Display()
            {
                printC($"{Name,5}  {SolvedQ}/{TotalQ} -------> {((float)SolvedQ/ (float)TotalQ)*100}%","g");
            }

        };

        static int ValidInt(string msg = "Enter a Number")
        {
            int value;
            while (true)
            {
                printC(msg,"c");
                if (int.TryParse(Console.ReadLine(), out value)) break;
                printC("Invalid input Try Again !!\n","r");

            }

            return value;

        }

       static int total = 50;
       static int count = Settings.Number;
       static string[,] AllQs = new string[total, 6];
       static string[,] RandomQs = new string[count,6];
       static int[] RandomList = new int[Settings.Number];

        static bool Contains(int[] array, int val) {
            for (int i = 0; i <array.Length; i++)
            {
                if (array[i] == val) return true;
            }
            return false;

        }
        static void RandomValues()
        {
            
            printC($"Generating {count} random numbers...\n", "m");
            

            for (int k = 0; k < count; k++)
                RandomList[k] = -1;



            Random rand = new Random();

            int i=0; 
           while (i < count) 
            {
                int x = rand.Next(1, total);
                if ( !Contains(RandomList , x ))
                {
                    RandomList[i] = x;
                        i++;
                }
            }
        }


      
       
        static void printA<T>(T[] array) {

            printC("Random unique numbers: " + string.Join(", ", array), "y");
        }
        static void print2D<T>(T[,] array) {

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i,j]} \t");
                }
                Console.WriteLine();
            }
        }




        static void ApplySettings()
        {
            
          int n =   ValidInt("Enter The Number of Questions");
          Settings.Number = n;

         printC("""
              Which Category Would You Like The Questions About ??

              1=> General
              2=> Geography
              3=> History
              4=> Science
              5=> Sports 

              """, "b"); 
          int c = ValidInt("Enter  Category Number  ");
            string f;
            switch (c) {
                case 1:
                    f = "general_questions";
                        break;
                case 2:
                    f = "geography_questions";
                        break;
                case 3:
                    f = "history_questions";
                        break;
                case 4:
                    f = "science_questions";
                        break;
                case 5:
                    f = "sports_questions";
                        break;
                default:
                    f = "general_questions";
                    break;
            }

            Settings.Category = f;
            printC($"Settings saved!  Number of Questions {Settings.Number}, Category :{Settings.Category}\n", "m");

        }

        static void LoadQuestions()
        {
            //string filePath = $"C:\\Users\\LENOVO\\source\\repos\\test1\\QuizGame\\Data\\{Settings.Category}.csv";
            // string filePath = $"QuizGame\\{Settings.Category}.csv";
            //string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", $"{Settings.Category}.csv");

            string[] lines = File.ReadAllLines(filePath);
            
            for (int i = 0; i < total; i++)
            {
                string[]  vals = lines[i].Split(',');

               
                for (int j = 0; j < 6; j++)
                {
                    AllQs[i, j] = vals[j];
                }
            }
        }

        static void MakeRandomQs()
        {
            RandomValues();
            LoadQuestions();
            for (int i = 0; i < count; i++)
            { 
                for (int j = 0; j < 6; j++)
                {
                    RandomQs[i,j] = AllQs[RandomList[i],j];
                }
            }
        }
        
        static Player SignPlayer()
        {
            Player p = new Player();
            printC("Enter Player Name", "c");
            p.Name = Console.ReadLine()?? "Player(1)"; 
            return p;
        }


        static void AskQs(Player p)
        {
            MakeRandomQs();
            for(int i = 0; i < count;i++)
            {
                printC($"Q{i+1}: {RandomQs[i,0]}\n","y");

                for (int j = 1; j < 5; j++) // a =97 , b =98 ,c=99 , d=100 
                {
                    printC($"{(char)(96 + j)}:{RandomQs[i,j]} \t \n","b");

                }
                    p.TotalQ++;  /////////// 

                printC("\nChoose The Correct Answer  ", "c");
                string? c = Console.ReadLine().ToLower();
                string A;
                switch (c)
                {
                    case "a":
                        A = RandomQs[i, 1];
                        break;
                    case "b":
                        A = RandomQs[i, 2];
                        break;
                    case "c":
                        A = RandomQs[i, 3];
                        break;
                    case "d":
                        A = RandomQs[i, 4];
                        break;
                    default:
                        A = "p";
                        break;
                }

                
                if (A== RandomQs[i, 5])
                {
                    printC("Correct Answer ^+^ ","g");
                    p.SolvedQ++; /////////////////
                }
                else
                {
                    printC($"Wrong Answer -_- , The Correct Answer is =>  {RandomQs[i, 5]} ","r");
                    
                }

                    printC("\n----\t----\t----\t----\t----\t----\t----\t----\t----\t---\n","w");
            }

        }




        static void SaveData(Player p)
        {
            string filePath = $"C:\\Users\\LENOVO\\source\\repos\\test1\\QuizGame\\PlayersData.csv";
            
            
                string line = $"{p.Name},{p.SolvedQ},{p.TotalQ} ,{((float)p.SolvedQ / (float)p.TotalQ) * 100}%\n ";

                File.AppendAllText(filePath, line);

            printC("Data saved successfully to CSV!","grey");
            

                
        
        }

      
      static void DisplayData()
        {
            string filePath = @"C:\Users\LENOVO\source\repos\test1\QuizGame\PlayersData.csv";

            string[] lines = File.ReadAllLines(filePath);

            Console.WriteLine("\n ===== Player Statistics =====\n");

          
            Console.WriteLine($"{"Player Name",-15} {"Solved",-10} {"Total",-10} {"Percentage",-10}");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            for (int i = 1; i < lines.Length; i++) 
            {
                string[] data = lines[i].Split(',');
                if (data.Length >= 4)
                {
                    printC($"{data[0],-15} {data[1],-10} {data[2],-10} {data[3],-10}","gray");
                }
            }

            printC("\n=================================\n");
        }

        static void printC(string msg="", string color="w")
        {
            switch (color.ToLower())
            {
                case "red":
                case "r":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                case "green":
                case "g":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case "yellow":
                case "y":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

                case "blue":
                case "b":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;

                case "cyan":
                case "c":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;

                case "magenta":
                case "m":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;

                case "white":
                case "w":
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                case "gray":
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;

                default:
                    Console.ResetColor();
                    break;
            }

            Console.WriteLine(msg);
            Console.ResetColor(); 
        }

        static void Main()
        {
            ApplySettings();

            //RandomValues();
            //LoadQuestions();
            //MakeRandomQs();
            //printA(RandomList);
            //print2D(RandomQs);
            //print2D(AllQs);
            Player p = SignPlayer();
            AskQs(p);
            p.Display();
            SaveData(p);
            DisplayData();
            //Console.WriteLine("\n✅ Program finished successfully!");
        }
    }

}