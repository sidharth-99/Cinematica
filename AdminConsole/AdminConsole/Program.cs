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
                Menu mainMenu = new Menu(prompt, options);
                int selectedIndex = mainMenu.Run();
                int adminid;
                string adminpswd;
                string adminname;

                switch (selectedIndex)
                {
                    case 0:
                        //ALMOST WORKING
                        Console.WriteLine("\nADMIN REGISTRATION FORM");
                        Console.WriteLine("-----------------------------------");
                        Console.Write("Enter ID: ");
                        adminid = mmb.ID();
                        Console.WriteLine();
                        Console.Write("Enter Name: ");
                        adminname = mmb.search();
                        Console.WriteLine();
                        Console.Write("Create Password: ");
                        adminpswd = mmb.searchpwd();
                        Console.WriteLine();
                        AdminDetails a = new AdminDetails(adminid, adminname, adminpswd);
                        if (mmb.Admin_add(a))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Registration Successful!!");
                            Console.ResetColor();
                        }
                        break;
                    case 1:
                        Console.WriteLine("\nADMIN LOGIN FORM");
                        Console.WriteLine("-----------------------------------");
                        Console.Write("Enter ID: ");
                        adminid = mmb.ID();
                        Console.WriteLine();
                        Console.Write("Enter Password: ");
                        adminpswd = mmb.searchpwd();
                        Console.WriteLine();
                        if (mmb.admin_validity(adminid, adminpswd))
                        {
                            Console.Clear();
                            Console.WriteLine("Login Successful!!");
                            string y2;
                            do
                            {
                                Console.WriteLine("Choose from the following options: ");
                                string[] options1 = { "Manage your Movie Dataset", "Search Movie", "Display all Movies" };
                                Menu colorMenu = new Menu(prompt, options1);
                                int selectedIndex1 = colorMenu.Run();

                                switch (selectedIndex1)
                                {
                                    case 0:
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
                                                case 0:
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
                                                        if (mmb.insert_movie(ml))
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
                                                    //working fully
                                                    Console.Clear();
                                                    Console.WriteLine("--You have chosen DELETE option--");
                                                    Console.Write("Enter name of the movie to be deleted: ");
                                                    if (mmb.delete_movie())
                                                    {
                                                        Console.WriteLine("Movie DELETED!!\n");
                                                    }
                                                    else
                                                    { 
                                                        Console.WriteLine("Movie NOT present\n"); 
                                                    }
                                                    break;

                                                case 2:
                                                    Console.Clear();
                                                    Console.WriteLine("--You have chosen UPDATE option--");
                                                    Console.Write("Enter the name of the movie to be updated: ");
                                                    string mn = mmb.search();
                                                    if (mmb.check_name(mn))
                                                    {


                                                        // string att = mmb.search_by_category(mcat);
                                                        char y4;
                                                        do
                                                        {
                                                            Console.Write("Update movie based on: ");
                                                            Console.WriteLine("\n");
                                                            string[] options3 = { "Release year", "Movie category", "Language", "Rating", "Lead Actor", "Description", "Duration", "Budget", "Update All" };
                                                            Menu colorMenu2 = new Menu(prompt, options3);
                                                            int selectedIndex3 = colorMenu2.Run();
                                                            //Console.BackgroundColor = ConsoleColor.White;

                                                            switch (selectedIndex3)
                                                            {
                                                                case 0:

                                                                    bool val1 = mmb.update_by_year(mn);
                                                                    if (val1)
                                                                        Console.WriteLine("Successfully updated");
                                                                    else
                                                                        Console.WriteLine("NOT updated");
                                                                    break;
                                                                case 1:


                                                                    bool val2 = mmb.update_by_category(mn);
                                                                    if (val2)
                                                                        Console.WriteLine("Successfully updated");
                                                                    else
                                                                        Console.WriteLine("NOT updated");
                                                                    break;
                                                                case 2:
                                                                    bool val3 = mmb.update_by_language(mn);
                                                                    if (val3)
                                                                        Console.WriteLine("Successfully updated");
                                                                    else
                                                                        Console.WriteLine("NOT updated");
                                                                    break;
                                                                case 3:
                                                                    bool val4 = mmb.update_by_rate(mn);
                                                                    if (val4)
                                                                        Console.WriteLine("Successfully updated");
                                                                    else
                                                                        Console.WriteLine("NOT updated");
                                                                    break;
                                                                case 4:

                                                                    bool val5 = mmb.update_by_lead(mn);
                                                                    if (val5)
                                                                        Console.WriteLine("Successfully updated");
                                                                    else
                                                                        Console.WriteLine("NOT updated");
                                                                    break;
                                                                case 5:
                                                                    bool val6 = mmb.update_by_description(mn);
                                                                    if (val6)
                                                                        Console.WriteLine("Successfully updated");
                                                                    else
                                                                        Console.WriteLine("NOT updated");
                                                                    break;
                                                                case 6:
                                                                    bool val7 = mmb.update_by_duration(mn);
                                                                    if (val7)
                                                                        Console.WriteLine("Successfully updated");
                                                                    else
                                                                        Console.WriteLine("NOT updated");
                                                                    break;
                                                                case 7:
                                                                    bool val8 = mmb.update_by_budget(mn);
                                                                    if (val8)
                                                                        Console.WriteLine("Successfully updated");
                                                                    else
                                                                        Console.WriteLine("NOT updated");
                                                                    break;
                                                                case 8:
                                                                    //Console.WriteLine("Search for the movie name to be update");
                                                                    //string mnupd = Console.ReadLine();
                                                                    //mmb.search_by_name(mnupd);

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
                                                            Console.WriteLine("Press y to continue modifying same movie");
                                                            y4 = Convert.ToChar(Console.ReadLine());
                                                        } while (y4 == 'y' || y4 == 'Y');
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Movie does NOT exist");
                                                    }
                                                    break;
                                            }
                                            Console.WriteLine("Press y to continue editing dataset or press n to revert back to original menu.");
                                            Console.WriteLine("\n");
                                            y3 = Console.ReadLine();
                                            Console.WriteLine("\n");

                                        } while (y3.Equals("y") || y3.Equals("Y"));

                                        break;

                                    case 1:
                                        Console.Clear();
                                        Console.Write("Search movie based on: ");
                                        Console.WriteLine("\n");
                                        string[] options11 = { "Name", "Release year", "Movie category", "Language", "Rating", "Lead Actor"};
                                        Menu mainMenu11 = new Menu(prompt, options11);
                                        int selectedIndex11 = mainMenu11.Run();
                                        
                                        switch (selectedIndex11)
                                        {
                                            case 0:
                                                Console.Write("Movie name: ");
                                                if (!mmb.search_by_name())
                                                {
                                                    Console.WriteLine("No Data Available");
                                                }
                                                Console.WriteLine();

                                                break;
                                            case 1:
                                                Console.Write("Year of release: ");

                                                if (!mmb.search_by_year())
                                                {
                                                    Console.WriteLine("No Data Available");
                                                }
                                                Console.WriteLine();
                                                break;
                                            case 2:
                                                Console.Write("Category of the movie: ");
                                                if (!mmb.search_by_category())
                                                {
                                                    Console.WriteLine("No Data Available");

                                                }
                                                Console.WriteLine();
                                                break;
                                            case 3:
                                                Console.Write("Language: ");
                                                if (!mmb.search_by_language())
                                                {
                                                    Console.WriteLine("No Data Available");

                                                }
                                                Console.WriteLine();
                                                break;
                                            case 4:
                                                Console.Write("Rating of the movie: ");


                                                if (!mmb.search_by_rating())
                                                {
                                                    Console.WriteLine("No Data Available");
                                                }
                                                Console.WriteLine();
                                                break;
                                            case 5:
                                                Console.Write("Enter the lead actor: ");
                                                if (!mmb.search_by_lead())
                                                {
                                                    Console.WriteLine("No Data Available");
                                                }
                                                Console.WriteLine();
                                                break;
                                        }

                                        break;
                                    case 2://WORKING FULLY
                                        Console.Clear();
                                        Console.WriteLine("All Movies:");
                                        Console.WriteLine();
                                        mmb.valid_total_list();
                                        break;
                                }

                                Console.WriteLine("Press y to continue. Press n to move out.");
                                y2 = Console.ReadLine();
                            } while (y2.Equals("y") || y2.Equals("Y"));

                        }


                        else
                        {
                            Console.WriteLine("invalid Credentials");
                        }
                        break;


                }
                Console.WriteLine("Press y to continue/login. Press n to exit.");
                y = Console.ReadLine();
            } while (y.Equals("y") || y.Equals("Y"));

            using (var p1 = new Process())
            {
                Console.Clear();
                p1.StartInfo.FileName = @"D:\Movie-Management-System-core\Movie-Management-System-core\moviemanagement\bin\Debug\netcoreapp3.1\moviemanagement.exe";
                p1.Start();

            }


            Console.ReadKey();

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