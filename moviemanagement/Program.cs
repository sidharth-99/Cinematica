using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using System.Security;

namespace moviemanagement
{

    class Program
    {
        SqlConnection c1 = new SqlConnection("Data Source=SRILEKHA-R;Initial Catalog=moviems;Integrated Security=True");


        static void Main(string[] args)
        {
            Game mygame = new Game();
            mygame.Start();//The UI is presented as a Game menu using the game class
        }


    }

    public class Menu//Class needed to create the bblueprint for the game menu
    {
        private int SelectedIndex;//used as a key for switch statements
        private string[] Options;//used as the options in the menu
        private string Prompt;//This element will always be displayed in the menu before the actual menu
        public Menu(string prompt, string[] options)//parametrized constructor
        {
            Prompt = prompt;
            Options = options;
            SelectedIndex = 0;
        }
        private void DisplayOptions()//Displays all the values i.e Menu and the Prompt
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
        public int Run()//Function used to change the value of key for menu based on keyboard arrow keys
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

    public class Game//Class to initialize the functionalies of class Menu
    {
        public void Start()
        {
            Console.Title = "CINEMATICA";//Changinging the title of the console app
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
            Menu mainMenu = new Menu(prompt, options);//Passing the value of prompt and option through menu object
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0://To continue as an Admin
                    bool refval = keyValidation();//used to chek if the user is an authorized admin

                    if (refval)
                    {
                        Console.WriteLine("Going to Admin Console...");
                        Thread.Sleep(1000);
                        using (var p1 = new Process())
                        {
                            p1.StartInfo.FileName = @"D:\WORK\Movie-Management-System-core\Movie-Management-System-core\AdminConsole\AdminConsole\bin\Debug\netcoreapp3.1\AdminConsole.exe";
                            p1.Start();//executing file p1

                            Console.Clear();
                        }
                    }
                    else
                    {
                        Console.WriteLine("You are not allowed to open Admin Page");
                    }
                    break;
                case 1://To continue as customer
                    Console.WriteLine("Going to Customer Console...");
                    Thread.Sleep(1000);
                    using (var p1 = new Process())
                    {

                        p1.StartInfo.FileName = @"D:\WORK\Movie-Management-System-core\Movie-Management-System-core\CustomerConsole\CustomerConsole\bin\Debug\netcoreapp3.1\CustomerConsole.exe";
                        p1.Start();//executing file p1

                        Console.Clear();
                    }
                    break;

                case 2://Display about page
                    DisplayAboutInfo();//Displays about the information of the peoject collaborators
                    break;
                case 3://TO exit the project
                    ExitGame();//Exit the game
                    break;
            }
        }
        private void ExitGame()//Function to exit the game
        {
            Console.WriteLine("Press Escape key to exit...");
            Console.ReadKey(true);
            Environment.Exit(0);
        }
        private void DisplayAboutInfo()//Funtion to displays about the information of the peoject collaborators
        {

            Console.Clear();
            Console.WriteLine(@"

               @@/  @@(   ,@@  *@@                                        
             %   @@@.  @ @  .@@@   @                                      
             @@@@@@@&@@@ @@@&@@@@@@@                                      
              &&  @,  @@@@@  ,@  &@                                
                    @@@@@@@@#                   
            .,&@@@@@@@@@@@@@@@@@@@    .@@@@@                                                   This project is an Movie Management System (MMS). This is a console-based application.
            /@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                                                   The system stores all the information relating to Movies like the Movie Title, Movie Description,
            /@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                                                   Movie Rating, Language of the Movie, Movie category, Release year, Duration of the Movie, 
             %@@@@@@@@@@@@@@@@@@@      @@@@@                                                   Budget of the movie and the Lead Actor in the movie.
                      @@@@ 
                    @@@@@@@@/                   
                    @@ @@ @@                    
                   @@  @@  @@                   
                  @@(  @@   @@       
                                                                     ");
            Console.WriteLine("\n");
            Console.WriteLine("                                                                                                                                             Created by: ");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("                                                                                                                                             Srilekha");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                                                                                                                                             Nithish");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                                                                                                                                             Shubham");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("                                                                                                                                             Surya");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("                                                                                                                                             Nikhil");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                                                                                                                                             Wayne");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                                                                                                                                             Sidharth");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press Escape key to return to menu.");
            Console.ReadKey(true);
            RunMainMenu();
        }

        public bool keyValidation()//Funtion used to check if the user is an authorized admin (needed to register as admin)
        {
            bool ref1 = false;
            int i = 3;
            string key = "DarkHorse";
            while (i != 0)
            {
                Console.Write("Enter secret key: ");
                string enkey = MaskInputString();
                Console.WriteLine();

                if (key.Equals(enkey))
                {
                    ref1 = true;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You only have " + (i - 1) + " chance(s) more.");
                    Console.ResetColor();
                    i--;
                }
            }
            return ref1;

        }

        private static string MaskInputString()//Function to secure string for admin authorization (needed to register as admin)
        {
            SecureString pass = new SecureString();
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
                if (!char.IsControl(keyInfo.KeyChar))
                {
                    pass.AppendChar(keyInfo.KeyChar);
                    Console.Write("*");
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    pass.RemoveAt(pass.Length - 1);
                    Console.Write("\b \b");

                }
            } while (keyInfo.Key != ConsoleKey.Enter);
            string ps = new System.Net.NetworkCredential(string.Empty, pass).Password;
            return ps;
        }
    }
}
