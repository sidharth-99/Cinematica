
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
                Menu mainMenu = new Menu(prompt, options);
                int selectedIndex = mainMenu.Run();

                switch (selectedIndex)
                {
                    case 0:
                        Console.WriteLine("\nREGISTRATION FORM");
                        Console.WriteLine("-----------------------------------");
                        Console.Write("Enter ID: ");
                        int usernid = mmb.ID();
                        Console.WriteLine();
                        Console.Write("Enter Name: ");
                        string username = mmb.search();
                        Console.WriteLine();
                        Console.Write("Create Password: ");
                        string userpswd = mmb.searchpwd();
                        Console.WriteLine();
                        UserDetails d = new UserDetails(usernid, username, userpswd);
                        if (mmb.user_add(d))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Registration Successful!!");
                            Console.ResetColor();
                        }
                        break;
                    case 1:
                        Console.WriteLine("\nLog In");
                        Console.WriteLine("-----------------------------------");
                        Console.Write("Enter ID: ");
                        int usern_id = mmb.ID();
                        Console.WriteLine();
                        Console.Write("Enter Password: ");
                        string user_pswd = mmb.searchpwd();
                        Console.WriteLine();

                        Console.WriteLine("\n");
                        if (mmb.cust_validity(usern_id, user_pswd))
                        {
                            Console.Clear();
                            Console.WriteLine("Login Successful!!");
                            string y2;
                            do
                            {
                                Console.Clear();
                                string[] options1 = { "Search movie", "Display all Movies" };
                                Menu colorMenu = new Menu(prompt, options1);
                                int selectedIndex1 = colorMenu.Run();

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
                                            case 0:
                                                Console.Write("Movie name: ");
                                                if (!mmb.search_by_name())
                                                {
                                                    Console.WriteLine("no data");
                                                }
                                                Console.WriteLine();
                                                break;
                                            case 1:
                                                Console.Write("Year of release: ");

                                                if (!mmb.search_by_year())
                                                {
                                                    Console.WriteLine("no data");
                                                }
                                                Console.WriteLine();
                                                break;
                                            case 2:
                                                Console.Write("Category of the movie: ");
                                                if (!mmb.search_by_category())
                                                {
                                                    Console.WriteLine("no data");

                                                }
                                                Console.WriteLine();
                                                break;
                                            case 3:
                                                Console.Write("Language: ");
                                                if (!mmb.search_by_language())
                                                {
                                                    Console.WriteLine("no data");

                                                }
                                                Console.WriteLine();
                                                break;
                                            case 4:
                                                Console.Write("Rating of the movie: ");


                                                if (!mmb.search_by_rating())
                                                {
                                                    Console.WriteLine("no data");
                                                }
                                                Console.WriteLine();
                                                break;
                                            case 5:
                                                Console.Write("Lead actor: ");
                                                if (!mmb.search_by_lead())
                                                {
                                                    Console.WriteLine("no data");
                                                }
                                                Console.WriteLine();
                                                break;
                                        }

                                        break;

                                    case 1:
                                        Console.Clear();
                                        Console.WriteLine("Movies List:");
                                        mmb.valid_total_list();
                                        break;
                                }
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Press y to Continue searching or press n to move back");
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
                Console.WriteLine("Press n to go back to service page. Press y to login");
                Console.WriteLine("\n");
                y = Console.ReadLine();
                Console.WriteLine("\n");
                Console.Clear();
            } while (y.Equals('y') || y.Equals("y"));


            using (var p1 = new Process())
            {
                Console.Clear();
                p1.StartInfo.FileName = @"D:\Movie-Management-System-core\Movie-Management-System-core\moviemanagement\bin\Debug\netcoreapp3.1\moviemanagement.exe";
                p1.Start();

            }
           
        }
        class Menu
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

    }
}