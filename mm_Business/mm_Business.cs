using System;
using mm_DAL;
using mm_entity;
using mm_exceptions;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Security;

namespace mm_Business
{
    public class MovieManagementBusiness
    {
        MovieManagementDAL dal = new MovieManagementDAL();
        //MovieList mlist;
        SqlConnection c1 = new SqlConnection("Data Source=SRILEKHA-R;Initial Catalog=moviems;Integrated Security=True");//used to connect to our SQL server database


        public void valid_total_list()//Display all the Movie datails in the database
        {
            dal.total_list();
        }
        public bool search_by_name()//Search with the movie name
        {
            string mname2 = search();
            try
            {
                return dal.search_name(mname2);
            }
            catch (MovieManagementException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
                return false;
            }

        }
        public bool search_by_year()//Search with Realease year of movie
        {
            int myear2 = search_year();

            try
            {
                return dal.search_year(myear2);
            }
            catch (MovieManagementException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
                return false;

            }



        }
        public bool search_by_category()//Search with Category of movie
        {
            string mcat2 = search();

            try
            {
                return dal.search_category(mcat2);
            }
            catch (MovieManagementException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
                return false;

            }



        }
        public bool search_by_language()//Search with Language of movie
        {
            string mlang2 = search();

            try
            {
                return dal.search_language(mlang2);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
                return false;
            }


        }
        public bool search_by_rating()//Search with Rating of movie
        {
            double mrate2 = search_rate();


            try
            {
                return dal.search_rating(mrate2);
            }
            catch (MovieManagementException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
                return false;
            }


        }
        public bool search_by_lead()//Search with Lead actor of movie
        {
            string mlead2 = search();

            try
            {
                return dal.search_lead(mlead2);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
                return false;
            }


        }
        public bool Admin_add(AdminDetails ls)//Add admin registration details to dtatabase
        {
            bool var;

            try
            {

                if (string.IsNullOrEmpty(ls.adminname))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new MovieManagementException("Admin name should not be EMPTY");
                }
                    
                if (ls.adminid < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new MovieManagementException("ID cannot be NEGATIVE");
                }
                    
                if (string.IsNullOrEmpty(ls.adminpswd))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new MovieManagementException("Empty Password isn't allowed");
                }

               
                var = dal.admin_det_insert(ls);


            }
            catch (MovieManagementException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                return false;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                return false;
            }
            return var;

        }

        public bool admin_validity(int aid, string apwd)//Check if valid admin
        {
            bool var;
            if (aid > 0)
            {
                try
                {
                    var = dal.admin_validity(aid, apwd);

                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                    var = false;

                }
            }
            else
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new MovieManagementException("Admin Id is INVALID!");
                }
                catch (MovieManagementException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                    var = false;

                }
            }
            return var;
        }
        public bool cust_validity(int cid, string cpwd)//Check if valid Customer
        {
            bool var;
            if (cid > 0 && cpwd != "")
            {
                try
                {
                    var = dal.cust_validity(cid, cpwd);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                    var = false;
                }
            }
            else
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new MovieManagementException("User Id is INVALID!");
                }
                catch (MovieManagementException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                    var = false;
                }
            }
            return var;
        }

        public bool user_add(UserDetails ls)//Add Customer registration to database
        {
            bool var;

            try
            {
                if (string.IsNullOrEmpty(ls.username))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new MovieManagementException("User name should not be EMPTY");
                }
                    
                if (ls.usernid < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new MovieManagementException("ID cannot be NEGATIVE");
                }
                    
                if (string.IsNullOrEmpty(ls.userpswd))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new MovieManagementException("Empty Password isn't allowed");
                }

                //if (!Regex.IsMatch(ls.userpswd, @"^(?=.?[A-Z])(?=.?[a-z])(?=.?[0-9])(?=.?[#?!@$%^&*-]).{8,}$"))
                //    throw new MovieManagementException("Password should contain one Captial letter ,one small letter,a number and a symbol");
                var = var = dal.cust_det_insert(ls);
            }
            catch (MovieManagementException e)
            {
                var = false;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();

            }
            return var;
        }
        public bool insert_movie(MovieList m)//Inser movie details to database
        {
            return dal.admin_insert(m);
        }
        public bool delete_movie()//delete movie from database

        {
            string mname = search();
            return dal.admin_delete(mname);
        }

        // MovieManagementBusiness e = new MovieManagementBusiness();

        public string search()//used for updating and inserting as exception are handled here
        {
            string value = Console.ReadLine();
            if (string.IsNullOrEmpty(value))
            {
                Console.WriteLine("Value entered is empty. Please try again");
                Console.WriteLine("Enter correct value: ");
                return search();
            }
            return value;

        }
        public double search_rate()//used for updating and inserting Movie rating as exception are handled here
        {
            try
            {
                string mi = Console.ReadLine();
                double rate;
                if (string.IsNullOrEmpty(mi))
                {
                    rate = 0;
                }
                    
                else if (!Regex.IsMatch(mi, @"^(10|\d)(\.\d{2,2})?$"))
                {
                    rate = 0;
                }
                else
                {
                    rate = Convert.ToDouble(mi);
                }
                    

                if (rate <= 0 || rate > 10)
                {
                    Console.WriteLine("Enter rating between 1 to 10");
                    return search_rate();
                }
                return rate;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                return search_rate();
            }
        }

        public int search_year()//used for updating and inserting Movie year of release as exception are handled here
        {
            try
            {
                string mi = Console.ReadLine();
                int myear;
                if (string.IsNullOrEmpty(mi))
                {
                    myear = 0;
                }
                else if(!Regex.IsMatch(mi, @"^\d+$"))
                {
                    myear = 0;
                }
                else
                {
                    myear = Convert.ToInt32(mi);
                }
                    
                if (myear > 2021 || myear <= 1950)//Year of release Should be less than 2021 and greater than 1950
                {
                    Console.WriteLine("Entered year is INVALID. Try again");
                    return search_year();
                }
                return myear;
            }

            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                return search_year();

            }
        }

        public bool update_by_year(string nm)//Update the year
        {
            dal.give_value(nm, "myear");
            Console.Write("Enter new year: ");
            int year = search_year();
            Console.WriteLine();
            return dal.update_by_year(nm, year);
        }

        public bool update_all(MovieList m)//Update all the movie details
        {
            // int year = search_year();
            return dal.admin_update(m);
        }
        public bool update_by_category(string nm)//Update the Category
        {
            dal.give_value(nm, "mcategory");
            Console.Write("Enter new category: ");
            string category = search(); 
            Console.WriteLine();

            return dal.update_by_category(nm, category);
        }

        public bool update_by_language(string nm)//Update the language
        {
            dal.give_value(nm, "mlanguage");
            Console.Write("Enter new language: ");
            string language = search();
            Console.WriteLine();

            return dal.update_by_language(nm, language);
        }
        public bool update_by_rate(string nm)//Update the rating
        {

            dal.give_value(nm, "rating");
            Console.Write("Enter new rating: ");
            double rate = search_rate();
            Console.WriteLine();
            return dal.update_by_rating(nm, rate);
        }

        public bool update_by_lead(string nm)//Update the lead actor
        {
            dal.give_value(nm, "mlead");
            Console.Write("Enter new lead actor: ");
            string lead = search();
            Console.WriteLine();
            return dal.update_by_lead(nm, lead);
        }
        public bool update_by_description(string nm)//Update the description
        {
            dal.give_value(nm, "mdescription");
            Console.Write("Enter new description: ");
            string desc = search();
            Console.WriteLine();
            if (desc.Length < 100)
            {
                Console.WriteLine("Description is too short");
                return update_by_description(nm);
            }
            return dal.update_by_description(nm, desc);


        }
        public bool update_by_duration(string nm)//Update the duration
        {
            dal.give_value(nm, "mduration");
            Console.Write("Enter new duration: ");
            string duration = search();
            Console.WriteLine();

            return dal.update_by_duration(nm, duration);
        }
        public bool update_by_budget(string nm)//Update the budget
        {

            dal.give_value(nm, "mbudget");
            Console.Write("Enter new budget: ");
            string budget = search();
            Console.WriteLine();
            return dal.update_by_duration(nm, budget);
        }
        public int aID()//validation for admin id
        {
            try
            {
                string mi = Console.ReadLine();
                Console.WriteLine();

                int Id;
                
                if (string.IsNullOrEmpty(mi))
                    Id = 0;
                else if (!Regex.IsMatch(mi, @"^\d+$"))
                {
                    Id = 0;
                }
                else
                    Id = Convert.ToInt32(mi);




                if (Id <= 0)
                    {
                        Console.Write("Enter Valid ID: ");
                        return aID();
                    }
                    else if (dal.admin_id_check(Id))
                    {
                        Console.WriteLine("ID Already exists.");
                        Console.WriteLine("Enter new id");
                        return aID();
                    }
                
                
                return Id;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                return aID();
            }
        }

        public int cID()//validation of customer id
        {
            try
            {
                string mi = Console.ReadLine();
                Console.WriteLine();

                int Id;

                if (string.IsNullOrEmpty(mi))
                    Id = 0;
                else if (!Regex.IsMatch(mi, @"^\d+$"))
                {
                    Id = 0;
                }
                else
                    Id = Convert.ToInt32(mi);




                if (Id <= 0)
                {
                    Console.Write("Enter Valid ID: ");
                    return cID();
                }
                else if (dal.cust_id_check(Id))
                {
                    Console.WriteLine("ID Already exists.");
                    Console.WriteLine("Enter new id");
                    return cID();
                }


                return Id;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                return cID();
            }
        }

        public int ID()//used for validating id while login (for both user and customer)
        {
            try
            {
                string mi = Console.ReadLine();
                Console.WriteLine();

                int Id;

                if (string.IsNullOrEmpty(mi))
                    Id = 0;
                else if (!Regex.IsMatch(mi, @"^\d+$"))
                {
                    Id = 0;
                }
                else
                    Id = Convert.ToInt32(mi);




                if (Id <= 0)
                {
                    Console.Write("Enter Valid ID: ");
                    return ID();
                }
                

                return Id;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                return cID();
            }
        }
        public bool check_name(string s1)//Check name entered is valid
        {
            if (dal.check_Name(s1))
            {
                return true;
            }
            return false;
        }
        public string searchpwd()//Check if password is valid
        {
            string value = MaskInputString();
            Console.WriteLine();
            if (string.IsNullOrEmpty(value))
            {
                Console.WriteLine("Value entered is empty. Please try again");
                Console.Write("Enter correct value: ");
                return searchpwd();
            }
            if (!Regex.IsMatch(value, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$"))
            {
                Console.WriteLine("Password should contain one Captial letter ,one small letter,a number and a symbol");
                Console.Write("Enter correct value: ");
                return searchpwd();

            }

            return value;

        }
        private static string MaskInputString()//Mask the string i.e key using this function
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
