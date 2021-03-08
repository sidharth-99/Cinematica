using System;
using Decryption;
using mm_entity;
using mm_Business;
using System.Diagnostics;

namespace AdminConsole
{
    class Program
    {
        static MovieManagementBusiness mmb = new MovieManagementBusiness();
        static void Main(string[] args)
        {
            //Program pg = new Program();
            Console.Clear();
            string prompt = @"
                             ==================================================================================================================================================================
                                                                                                        Admin Console                                                                    
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
                int adminid;
                string adminpswd;
                string adminname;

                switch (selectedIndex)
                {
                    case 0:
                        //Register as an admin
                        Console.WriteLine("\nADMIN REGISTRATION FORM");
                        Console.WriteLine("-----------------------------------");
                        Console.Write("Enter ID: ");
                        adminid = mmb.aID();
                        Console.WriteLine();
                        Console.Write("Enter Name: ");
                        adminname = mmb.search();
                        Console.WriteLine();
                        Console.Write("Create Password: ");
                        adminpswd = mmb.searchpwd();
                        Console.WriteLine();
                        AdminDetails a = new AdminDetails(adminid, adminname, adminpswd);//Adding the details ito AdminDetails class in entity layer
                        if (mmb.Admin_add(a))//Checkin if successully added the details
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Registration Successful!!");
                            Console.ResetColor();
                        }
                        break;
                    case 1://logging in as admin
                        Console.WriteLine("\nADMIN LOGIN FORM");
                        Console.WriteLine("-----------------------------------");
                        Console.Write("Enter ID: ");
                        adminid = mmb.ID();
                        Console.WriteLine();
                        Console.Write("Enter Password: ");
                        adminpswd = mmb.searchpwd();
                        Console.WriteLine();
                        if (mmb.admin_validity(adminid, adminpswd))//Checking if valid login details
                        {
                            Console.Clear();
                            Console.WriteLine("Login Successful!!");
                            string y2;
                            do
                            {
                                Console.WriteLine("Choose from the following options: ");
                                string[] options1 = { "Manage your Movie Dataset", "Search Movie", "Display all Movies" };
                                Menu colorMenu = new Menu(prompt, options1);//Initiaializing object of menu
                                int selectedIndex1 = colorMenu.Run();//Creates a custom menu with the menu object initialized

                                switch (selectedIndex1)
                                {
                                    case 0://Manage your Movie i.e add,update,delete
                                        string y3;
                                        do
                                        {
                                            Console.Clear();
                                            string[] options2 = { "Add a Movie", "Delete a Movie", "Update details of an existing Movie" };
                                            Menu colorMenu1 = new Menu(prompt, options2);
                                            int selectedIndex2 = colorMenu1.Run();
                                            //Console.BackgroundColor = ConsoleColor.White;
                                            
                                            switch (selectedIndex2)
                                            {
                                                case 0: //Add Movie details
                                                    Console.WriteLine("--You have chosen ADD option--");
                                                    Console.WriteLine("Add Movie details");
                                                    Console.Write("Enter the Movie name: ");
                                                    string mname = mmb.search();
                                                    if (!mmb.check_name(mname))
                                                    {
                                                        Console.Write("Year of release: ");
                                                        int myear = mmb.search_year();

                                                        Console.Write("Category of the movie: ");
                                                        string mcat = mmb.search();

                                                        Console.Write("Language: ");
                                                        string mlang = mmb.search();

                                                        Console.Write("Rating of the movie: ");
                                                        double mrate = mmb.search_rate();

                                                        Console.Write("Lead actor: ");
                                                        string mlead = mmb.search(); ;

                                                        Console.Write("Description of the movie: ");
                                                        string mdesc = mmb.search();

                                                        Console.Write("Duration of the movie: ");
                                                        string duration = mmb.search();

                                                        Console.Write("Budget for the movie: ");
                                                        string mbudge = mmb.search();
                                                        MovieList ml = new MovieList(mname, myear, mcat, mlang, mrate, mlead, mdesc, duration, mbudge);
                                                        if (mmb.insert_movie(ml)) //Checking if insertion successfully
                                                        {
                                                            Console.Write("Inserted succesfully!!");
                                                        }

                                                        Console.Write("\n");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Movie ALREADY exists!!");
                                                    }
                                                    break;
                                                case 1:
                                                    //Delete Movie
                                                    Console.Clear();
                                                    Console.WriteLine("--You have chosen DELETE option--");
                                                    Console.Write("Enter name of the movie to be deleted: ");
                                                    if (mmb.delete_movie())//Checking if the movie is deleted
                                                    {
                                                        Console.WriteLine("Movie DELETED!!\n");
                                                    }
                                                    else
                                                    { 
                                                        Console.WriteLine("Movie NOT present\n"); 
                                                    }
                                                    break;

                                                case 2://Update movie details
                                                    Console.Clear();
                                                    Console.WriteLine("--You have chosen UPDATE option--");
                                                    Console.Write("Enter the name of the movie to be updated: ");
                                                    string mn = mmb.search(); //Check if the movie is ther which needs to be updated
                                                    if (mmb.check_name(mn))
                                                    {


                                                        // string att = mmb.search_by_category(mcat);
                                                        char y4;
                                                        do
                                                        {
                                                            Console.Write("Update movie based on: ");
                                                            Console.WriteLine("\n");
                                                            string[] options3 = { "Release year", "Movie category", "Language", "Rating", "Lead Actor", "Description", "Duration", "Budget", "Update All" };
                                                            Menu colorMenu2 = new Menu(prompt, options3); //Initiaializing object of menu
                                                            int selectedIndex3 = colorMenu2.Run(); //Creates a custom menu with the menu object initialized
                                                            //Console.BackgroundColor = ConsoleColor.White;

                                                            switch (selectedIndex3)
                                                            {
                                                                case 0: //Update the year

                                                                    bool val1 = mmb.update_by_year(mn);
                                                                    if (val1)
                                                                        Console.WriteLine("Successfully updated");
                                                                    else
                                                                        Console.WriteLine("NOT updated");
                                                                    break;
                                                                case 1:
                                                                    //Update the category

                                                                    bool val2 = mmb.update_by_category(mn);
                                                                    if (val2)
                                                                        Console.WriteLine("Successfully updated");
                                                                    else
                                                                        Console.WriteLine("NOT updated");
                                                                    break;
                                                                case 2:
                                                                    //Update the language
                                                                    bool val3 = mmb.update_by_language(mn);
                                                                    if (val3)
                                                                        Console.WriteLine("Successfully updated");
                                                                    else
                                                                        Console.WriteLine("NOT updated");
                                                                    break;
                                                                case 3:
                                                                    //Update the rate
                                                                    bool val4 = mmb.update_by_rate(mn);
                                                                    if (val4)
                                                                        Console.WriteLine("Successfully updated");
                                                                    else
                                                                        Console.WriteLine("NOT updated");
                                                                    break;
                                                                case 4:
                                                                    //Update the lead actor
                                                                    bool val5 = mmb.update_by_lead(mn);
                                                                    if (val5)
                                                                        Console.WriteLine("Successfully updated");
                                                                    else
                                                                        Console.WriteLine("NOT updated");
                                                                    break;
                                                                case 5:
                                                                    //Update the description
                                                                    bool val6 = mmb.update_by_description(mn);
                                                                    if (val6)
                                                                        Console.WriteLine("Successfully updated");
                                                                    else
                                                                        Console.WriteLine("NOT updated");
                                                                    break;
                                                                case 6:
                                                                    //Update the duration
                                                                    bool val7 = mmb.update_by_duration(mn);
                                                                    if (val7)
                                                                        Console.WriteLine("Successfully updated");
                                                                    else
                                                                        Console.WriteLine("NOT updated");
                                                                    break;
                                                                case 7:
                                                                    //Update the budget
                                                                    bool val8 = mmb.update_by_budget(mn);
                                                                    if (val8)
                                                                        Console.WriteLine("Successfully updated");
                                                                    else
                                                                        Console.WriteLine("NOT updated");
                                                                    break;
                                                                case 8: //Update the whole movie details
                                                                        

                                                                    Console.WriteLine("Enter the details to be updated");

                                                                    Console.Write("Year of release: ");
                                                                    int myear1 = mmb.search_year();
                                                                    Console.WriteLine();

                                                                    Console.Write("Category of the movie: ");
                                                                    string mcat1 = mmb.search();
                                                                    Console.WriteLine();

                                                                    Console.Write("Language: ");
                                                                    string mlang1 = mmb.search();
                                                                    Console.WriteLine();

                                                                    Console.Write("Rating of the movie: ");
                                                                    double mrate1 = mmb.search_rate();
                                                                    Console.WriteLine();

                                                                    Console.Write("Lead actor: ");
                                                                    string mlead1 = mmb.search();
                                                                    Console.WriteLine();

                                                                    Console.Write("Description of the movie: ");
                                                                    string mdesc1 = mmb.search();
                                                                    Console.WriteLine();

                                                                    Console.Write("Duration of the movie:  ");
                                                                    string duration1 = mmb.search();
                                                                    Console.WriteLine();

                                                                    Console.Write("Budget for the movie: ");
                                                                    string mbudge1 = mmb.search();
                                                                    Console.WriteLine();

                                                                    MovieList m2 = new MovieList(mn, myear1, mcat1, mlang1, mrate1, mlead1, mdesc1, duration1, mbudge1);
                                                                    bool val9 = mmb.update_all(m2);
                                                                    if (val9)
                                                                        Console.WriteLine("Successfully updated");
                                                                    else
                                                                        Console.WriteLine("NOT updated");
                                                                    break;
                                                            }
                                                            Console.WriteLine("Press y/Y to continue updating same movie. \tPress any other key to move out of present menu.");
                                                            y4 = Convert.ToChar(Console.ReadLine());
                                                        } while (y4 == 'y' || y4 == 'Y');
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Movie does NOT exist");
                                                    }
                                                    break;
                                            }
                                            Console.WriteLine("Press y/Y to continue editing the movie dataset. \tPress any other key to move out of present menu.");
                                            Console.WriteLine("\n");
                                            y3 = Console.ReadLine();
                                            Console.WriteLine("\n");

                                        } while (y3.Equals("y") || y3.Equals("Y"));

                                        break;

                                    case 1: //Search Movies
                                        Console.Clear();
                                        Console.Write("Search movie based on: ");
                                        Console.WriteLine("\n");
                                        string[] options11 = { "Name", "Release year", "Movie category", "Language", "Rating", "Lead Actor"};
                                        Menu mainMenu11 = new Menu(prompt, options11);//Inistaizing object of menu
                                        int selectedIndex11 = mainMenu11.Run(); //Creates a custom menu with the menu object initialized

                                        switch (selectedIndex11)
                                        {
                                            case 0: //Search with name of movie
                                                Console.Write("Movie name: ");
                                                if (!mmb.search_by_name())
                                                {
                                                    Console.WriteLine("No Data Available");
                                                }
                                                Console.WriteLine();

                                                break;
                                            case 1: //Search with Realease year of movie
                                                Console.Write("Year of release: ");

                                                if (!mmb.search_by_year())
                                                {
                                                    Console.WriteLine("No Data Available");
                                                }
                                                Console.WriteLine();
                                                break;
                                            case 2: //Search with Category of movie
                                                Console.Write("Category of the movie: ");
                                                if (!mmb.search_by_category())
                                                {
                                                    Console.WriteLine("No Data Available");

                                                }
                                                Console.WriteLine();
                                                break;
                                            case 3: //Search with language of movie
                                                Console.Write("Language: ");
                                                if (!mmb.search_by_language())
                                                {
                                                    Console.WriteLine("No Data Available");

                                                }
                                                Console.WriteLine();
                                                break;
                                            case 4: //Search with rating of movie
                                                Console.Write("Rating of the movie: ");


                                                if (!mmb.search_by_rating())
                                                {
                                                    Console.WriteLine("No Data Available");
                                                }
                                                Console.WriteLine();
                                                break;
                                            case 5: //Search with lead actor of movie
                                                Console.Write("Enter the lead actor: ");
                                                if (!mmb.search_by_lead())
                                                {
                                                    Console.WriteLine("No Data Available");
                                                }
                                                Console.WriteLine();
                                                break;
                                        }

                                        break;
                                    case 2: //Diaplay the whole movie details in the database
                                        Console.Clear();
                                        Console.WriteLine("All Movies:");
                                        Console.WriteLine();
                                        mmb.valid_total_list();
                                        break;
                                }

                                Console.WriteLine("Press y to get original menu. \tPress any other key to move out.");
                                y2 = Console.ReadLine();
                            } while (y2.Equals("y") || y2.Equals("Y"));

                        }


                        else
                        {
                            Console.WriteLine("invalid Credentials");
                        }
                        break;


                }
                Console.WriteLine("Press y to continue/login as adminstrator. \tPress any other key to exit admin page.");
                y = Console.ReadLine();
            } while (y.Equals("y") || y.Equals("Y"));

            using (var p1 = new Process()) //use this process to go back to movie management console
            {
                Console.Clear();
                p1.StartInfo.FileName = @"D:\WORK\Movie-Management-System-core\Movie-Management-System-core\moviemanagement\bin\Debug\netcoreapp3.1\moviemanagement.exe";
                p1.Start();

            }


            Console.ReadKey();

        }
        class Menu //Class needed to create the bblueprint for the game menu
        {
            private int SelectedIndex;//used as a key for switch statements
            private string[] Options;//used as the options in the menu
            private string Prompt;//This element will always be displayed in the menu before the actual menu

            public Menu(string prompt, string[] options) //parametrized constructor
            {
                Prompt = prompt;
                Options = options;
                SelectedIndex = 0;
            }
            private void DisplayOptions() //Displays all the values i.e Menu and the Prompt
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
            public int Run() //Function used to change the value of key for menu based on keyboard arrow keys
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
