using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
namespace moviemanagement
{

    class Program
    {
        SqlConnection c1 = new SqlConnection("Data Source=DESKTOP-TB0Q4FJ;Initial Catalog=moviems;Integrated Security=True");


        static void Main(string[] args)
        {
            Game mygame = new Game();
            mygame.Start();
        }


    }

    public class Menu
    {
        private int SelectedIndex;
        private string[] Options;
        private string Prompt;

        public Menu(string prompt, string[] options)
        {
            Prompt = prompt;
            Options = options;
            SelectedIndex = 0;
        }
        private void DisplayOptions()
        {
            Console.WriteLine(Prompt);
            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                string prefix;
                if (i == SelectedIndex)
                {
                    prefix = ">>";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine($"{prefix}  [ {currentOption} ]");
            }
            Console.ResetColor();
        }
        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DisplayOptions();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;
                // Update SelectedIndex based on arrow keys
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if (SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);
            return SelectedIndex;
        }
    }

    public class Game
    {
        public void Start()
        {
            Console.Title = "CINEMATICA";
            RunMainMenu();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey(true);
        }

        private void RunMainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;  
            string prompt = @"

                                                                                                                           ,----,                                      
                                                                  ,--.                      __                         ,/   .`|                                      
                                      ,----..      ,---,        ,--.'|     ,---,.         ,'  , `.    ,---,            ,`   .'  :    ,---,   ,----..      ,---,        
                                     /   /   \  ,`--.' |    ,--,:  : |   ,'  .' |      ,-+-,.' _ |   '  .' \         ;    ;     / ,`--.' |  /   /   \    '  .' \       
                                    |   :     : |   :  : ,`--.'`|  ' : ,---.'   |   ,-+-. ;   , ||  /  ;    '.     .'_,/    ,'  |   :  : |   :     :  /  ;    '.     
                                    .   |  ;. / :   |  ' |   :  :  | | |   |   .'  ,--.'|'   |  ;| :  :       \    |    :     |   :   |  ' .   |  ;. / :  :       \    
                                    .   ; /--`  |   :  | :   |   \ | : :   :  |-, |   |  ,', |  ': :  |   /\   \   ;    |.';  ;   |   :  | .   ; /--`  :  |   /\   \   
                                    ;   | ;     '   '  ; |   : '  '; | :   |  ;/| |   | /  | |  || |  :  ' ;.   :  `----'  |  |   '   '  ; ;   | ;     |  :  ' ;.   :  
                                    |   : |     |   |  | '   ' ;.    ; |   :   .' '   | :  | :  |, |  |  ;/  \   \     '   :  ;   |   |  | |   : |     |  |  ;/  \   \ 
                                    .   | '_  '   :  ; |   | | \   | |   |  |-, ;   . |  ; |--'  '  :  | \  \ ,'     |   |  '   '   :  ; .   | '_  '  :  | \  \ ,' 
                                    '   ; : .'| |   |  ' '   : |  ; .' '   :  ;/| |   : |  | ,     |  |  '  '--'       '   :  |   |   |  ' '   ; : .'| |  |  '  '--'   
                                    '   | '/  : '   :  | |   | '`--'   |   |    \ |   : '  |/      |  :  :             ;   |.'    '   :  | '   | '/  : |  :  :         
                                    |   :    /  ;   |.'  '   : |       |   :   .' ;   | |`-'       |  | ,'             '---'      ;   |.'  |   :    /  |  | ,'         
                                     \   \ .'   '---'    ;   |.'       |   | ,'   |   ;/           `--''                          '---'     \   \ .'   `--''           
                                      `---`              '---'         `----'     '---'                                                      `---`                     
                                                                                                                                   

  Welcome to Cinematica. What would you like to do?

  (Use the arrow keys to cycle through options and press enter to select an option.)
";
            Console.ResetColor();
            Console.WriteLine("\n");
            string[] options = { "Sign in as Admin", "Sign in as Customer", "About", "Exit" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("Going to Admin Console...");
                    Thread.Sleep(1000);
                    using (var p1 = new Process())
                    {
                        p1.StartInfo.FileName = @"D:\Movie-Management-System-core\Movie-Management-System-core\AdminConsole\AdminConsole\bin\Debug\netcoreapp3.1\AdminConsole.exe";
                        p1.Start();

                        Console.Clear();
                    }
                    break;
                case 1:
                    Console.WriteLine("Going to Customer Console...");
                    Thread.Sleep(1000);
                    using (var p1 = new Process())
                    {

                        p1.StartInfo.FileName = @"D:\Movie-Management-System-core\Movie-Management-System-core\CustomerConsole\CustomerConsole\bin\Debug\netcoreapp3.1\CustomerConsole.exe";
                        p1.Start();

                        Console.Clear();
                    }
                    break;

                case 2:
                    DisplayAboutInfo();
                    break;
                case 3:
                    ExitGame();
                    break;
            }
        }
        private void ExitGame()
        {
            Console.WriteLine("Press Escape key to exit...");
            Console.ReadKey(true);
            Environment.Exit(0);
        }
        private void DisplayAboutInfo()
        {

            Console.Clear();
            Console.WriteLine(@"
                                                                    This project is an online Movie Management System (MMS). This is a console-based application. 
                                                                    The system stores all the information relating to Movies like the Movie Title, Movie Description,
                                                                    Movie Rating, Language of the Movie, Movie category, Release year, 
                                                                    Duration of the Movie, Budget of the movie and the Lead Actor in the movie. ");
            Console.WriteLine("\n");
            Console.WriteLine("                                                                                                            Created by: ");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("                                                                                                             Srilekha");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                                                                                                             Nithish");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                                                                                                             Shubham");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("                                                                                                             Surya");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("                                                                                                             Nikhil");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                                                                                                             Wayne");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                                                                                                             Sidharth");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press Escape key to return to menu.");
            Console.ReadKey(true);
            RunMainMenu();
        }
    }
}