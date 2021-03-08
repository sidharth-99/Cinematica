
using System;
using mm_entity;
using mm_Business;
using System.Diagnostics;

namespace CustomerConsole
{
    class Program
    {

        static MovieManagementBusiness mmb = new MovieManagementBusiness();
        static void Main(string[] args)
        {
            Console.Clear();
            string prompt = @"
                              ==================================================================================================================================================================
                                                                                                    Customer Console                                                                    
                              ==================================================================================================================================================================
            
            (Use the arrow keys to cycle through options and press enter to select an option.)

            ";
            string y;
            do
            {
                Console.WriteLine("Create an account or log into Cinematica");
                Console.WriteLine();
                Console.WriteLine("Enter to: ");
                Console.WriteLine();
                string[] options = { "Register", "Login" };
                Menu mainMenu = new Menu(prompt, options);//Initiaializing object of menu
                int selectedIndex = mainMenu.Run();//Creates a custom menu with the menu object initialized

                switch (selectedIndex)
                {
                    case 0:
                        Console.WriteLine("\nREGISTRATION FORM");
                        Console.WriteLine("-----------------------------------");
                        Console.Write("Enter ID: ");
                        int usernid = mmb.cID();
                        Console.WriteLine();
                        Console.Write("Enter Name: ");
                        string username = mmb.search();
                        Console.WriteLine();
                        Console.Write("Create Password: ");
                        string userpswd = mmb.searchpwd();
                        Console.WriteLine();
                        UserDetails d = new UserDetails(usernid, username, userpswd);////Adding the details ito USerDetails class in entity layer
                        if (mmb.user_add(d))//Checkin if successully added the details
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Registration Successful!!");
                            Console.ResetColor();
                        }
                        break;
                    case 1://logging in as Customer
                        Console.WriteLine("\nLog In");
                        Console.WriteLine("-----------------------------------");
                        Console.Write("Enter ID: ");
                        int usern_id = mmb.ID();
                        Console.WriteLine();
                        Console.Write("Enter Password: ");
                        string user_pswd = mmb.searchpwd();
                        Console.WriteLine();

                        Console.WriteLine("\n");
                        if (mmb.cust_validity(usern_id, user_pswd))//Checking if valid login details
                        {
                            Console.Clear();
                            Console.WriteLine("Login Successful!!");
                            string y2;
                            do
                            {
                                Console.Clear();
                                string[] options1 = { "Search movie", "Display all Movies" };
                                Menu colorMenu = new Menu(prompt, options1);//Inistaizing object of menu
                                int selectedIndex1 = colorMenu.Run();//Creates a custom menu with the menu object initialized

                                switch (selectedIndex1)
                                {
                                    case 0:
                                        Console.Write("Search movie based on: ");
                                        Console.WriteLine("\n");
                                        string[] options11 = { "Name", "Release year", "Movie category", "Language", "Rating", "Lead Actor" };
                                        Menu mainMenu11 = new Menu(prompt, options11);
                                        int selectedIndex11 = mainMenu11.Run();

                                        switch (selectedIndex11)
                                        {
                                            case 0: //Search with name of movie
                                                Console.Write("Movie name: ");
                                                if (!mmb.search_by_name())
                                                {
                                                    Console.WriteLine("No Data Available.");
                                                }
                                                Console.WriteLine();
                                                break;
                                            case 1://Search with release year of movie
                                                Console.Write("Year of release: ");

                                                if (!mmb.search_by_year())
                                                {
                                                    Console.WriteLine("No Data Available.");
                                                }
                                                Console.WriteLine();
                                                break;
                                            case 2://Search with category of movie
                                                Console.Write("Category of the movie: ");
                                                if (!mmb.search_by_category())
                                                {
                                                    Console.WriteLine("No Data Available.");

                                                }
                                                Console.WriteLine();
                                                break;
                                            case 3://Search with language of movie
                                                Console.Write("Language: ");
                                                if (!mmb.search_by_language())
                                                {
                                                    Console.WriteLine("No Data Available.");

                                                }
                                                Console.WriteLine();
                                                break;
                                            case 4://Search with rating of movie
                                                Console.Write("Rating of the movie: ");


                                                if (!mmb.search_by_rating())
                                                {
                                                    Console.WriteLine("No Data Available.");
                                                }
                                                Console.WriteLine();
                                                break;
                                            case 5://Search with Lead actor of movie
                                                Console.Write("Lead actor: ");
                                                if (!mmb.search_by_lead())
                                                {
                                                    Console.WriteLine("No Data Available");
                                                }
                                                Console.WriteLine();
                                                break;
                                        }

                                        break;

                                    case 1://Diaplay the whole movie details in the database
                                        Console.Clear();
                                        Console.WriteLine("Movies List:");
                                        mmb.valid_total_list();
                                        break;
                                }
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Press y/Y to Continue searching \tPress any other key to move back to previous menu");
                                Console.WriteLine("\n");
                                y2 = Console.ReadLine();
                                Console.WriteLine("\n");
                            } while (y2.Equals('y') || y2.Equals("y"));
                        }
                        else
                        {
                            Console.WriteLine("Invalid Credentials");
                        }

                        break;
                }
                Console.WriteLine("Press y/Y to continue/login as Customer. \tPress any other key to exit Customer page");
                Console.WriteLine("\n");
                y = Console.ReadLine();
                Console.WriteLine("\n");
                Console.Clear();
            } while (y.Equals('y') || y.Equals("y"));


            using (var p1 = new Process())//use this process to go back to movie management console
            {
                Console.Clear();
                p1.StartInfo.FileName = @"D:\WORK\Movie-Management-System-core\Movie-Management-System-core\moviemanagement\bin\Debug\netcoreapp3.1\moviemanagement.exe";
                p1.Start();

            }
           
        }
        class Menu//Class needed to create the bblueprint for the game menu
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
                    // Update SelectedIndex based on arrow keys
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

    }
}
