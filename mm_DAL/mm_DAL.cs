using System;
using System.Data;
using System.Data.SqlClient;
using mm_entity;
using System.Diagnostics;
using System.Configuration;
using mm_exceptions;
using System.Threading;

namespace mm_DAL
{
    public class MovieManagementDAL
    {

        //MovieList ml = new MovieList();

        SqlDataAdapter sd = new SqlDataAdapter();
        SqlConnection c1 = new SqlConnection("Data Source=SRILEKHA-R;Initial Catalog=moviems;Integrated Security=True");//This is used to connect to the database.
        public void total_list()//Display All the movie details in the database
        {
            SqlCommand pro = new SqlCommand();
            c1.Open();//Open connection to database
            pro.CommandType = CommandType.StoredProcedure;
            pro.CommandText = "total_list";//execute procedure total_list
            pro.Connection = c1;//connect the sql Commands with the database
            DataSet d7 = new DataSet();
            sd.SelectCommand = pro;
            sd.Fill(d7, "movie_list");
            c1.Close();

            dataset_print(d7);
        }
        public bool search_name(string mname2)// Search with Movie name
        {
            SqlCommand pro = new SqlCommand();
            c1.Open();
            pro.CommandType = CommandType.StoredProcedure;
            pro.CommandText = "search_name";
            pro.Parameters.AddWithValue("@name", mname2);
            pro.Connection = c1;
            int r = pro.ExecuteNonQuery();
            DataSet d1 = new DataSet();
            sd.SelectCommand = pro;
            sd.Fill(d1, "movie_list");
            c1.Close();
            int n = d1.Tables[0].Rows.Count;

            dataset_print(d1);
            c1.Close();
            if (n > 0)
            {
                return true;
            }
            return false;
        }
        public bool search_year(int myear2)//Search with Year of release
        {
            SqlCommand pro = new SqlCommand();
            c1.Open();
            pro.CommandType = CommandType.StoredProcedure;
            pro.CommandText = "search_year";
            pro.Parameters.AddWithValue("@year", myear2);
            pro.Connection = c1;
            DataSet d1 = new DataSet();
            sd.SelectCommand = pro;
            sd.Fill(d1, "movie_list");
            c1.Close();
            int n = d1.Tables[0].Rows.Count;
            dataset_print(d1);

            c1.Close();
            if (n > 0)
            {
                return true;
            }
            return false;

        }
        public bool search_category(string mcat2)//Search with Category of movie
        {
            SqlCommand pro = new SqlCommand();
            c1.Open();
            pro.CommandType = CommandType.StoredProcedure;
            pro.CommandText = "search_category";
            pro.Parameters.AddWithValue("@category", mcat2);
            pro.Connection = c1;
            DataSet d1 = new DataSet();
            sd.SelectCommand = pro;
            sd.Fill(d1, "movie_list");
            c1.Close();
            int n = d1.Tables[0].Rows.Count;

            dataset_print(d1);
            c1.Close();
            if (n > 0)
            {
                return true;
            }
            return false;
        }
        public bool search_language(string mlang2)//Search with Language of movie
        {
            SqlCommand pro = new SqlCommand();
            c1.Open();
            pro.CommandType = CommandType.StoredProcedure;
            pro.CommandText = "search_language";
            pro.Parameters.AddWithValue("@language", mlang2);
            pro.Connection = c1;
            DataSet d1 = new DataSet();
            sd.SelectCommand = pro;
            sd.Fill(d1, "movie_list");
            c1.Close();
            int n = d1.Tables[0].Rows.Count;
            dataset_print(d1);
            if (n > 0)
            {
                return true;
            }
            return false;
        }
        public bool search_rating(double mrate2)//Search with rating of movie
        {
            SqlCommand pro = new SqlCommand();
            c1.Open();
            pro.CommandType = CommandType.StoredProcedure;
            pro.CommandText = "search_rating";
            pro.Parameters.AddWithValue("@rate", mrate2);
            pro.Connection = c1;
            DataSet d6 = new DataSet();
            sd.SelectCommand = pro;
            sd.Fill(d6, "movie_list");
            c1.Close();
            int n = d6.Tables[0].Rows.Count;
            dataset_print(d6);
            if (n > 0)
            {
                return true;
            }
            return false;
        }
        public bool search_lead(string mlead2)//Search with lead actor of movie
        {
            SqlCommand pro = new SqlCommand();
            c1.Open();
            pro.CommandType = CommandType.StoredProcedure;
            pro.CommandText = "search_lead";
            pro.Parameters.AddWithValue("@lead", mlead2);
            pro.Connection = c1;
            DataSet d7 = new DataSet();
            sd.SelectCommand = pro;
            sd.Fill(d7, "movie_list");
            c1.Close();
            int n = d7.Tables[0].Rows.Count;
            dataset_print(d7);
            if (n > 0)
            {
                return true;
            }
            return false;

        }
        public bool admin_delete(string maname)//Delete a movie 
        {
            SqlCommand pro = new SqlCommand();
            c1.Open();
            pro.CommandType = CommandType.StoredProcedure;
            pro.CommandText = "admin_delete";
            pro.Parameters.AddWithValue("@name_del", maname);
            pro.Connection = c1;
            int r = pro.ExecuteNonQuery();
            c1.Close();
            if (r > 0)
            {
                return true;
            }
            return false;
        }
        public bool admin_insert(MovieList m1)//Insert Movie details into database
        {
            try
            {
                SqlCommand pro = new SqlCommand();
                c1.Open();
                pro.CommandType = CommandType.StoredProcedure;
                pro.CommandText = "admin_insert";
                pro.Parameters.AddWithValue("@name", m1.moviename);
                pro.Parameters.AddWithValue("@year", m1.movieyear);
                pro.Parameters.AddWithValue("@category", m1.moviecat);
                pro.Parameters.AddWithValue("@language", m1.movielang);
                pro.Parameters.AddWithValue("@rated", m1.movierate);
                pro.Parameters.AddWithValue("@lead", m1.movielead);
                pro.Parameters.AddWithValue("@desc", m1.moviedesc);
                pro.Parameters.AddWithValue("@dur", m1.movieduration);
                pro.Parameters.AddWithValue("@bud", m1.moviebudget);

                pro.Connection = c1;
                int r = pro.ExecuteNonQuery();

                c1.Close();
                if (r > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                return false;
            }
            finally
            {
                c1.Close();
            }
        }
        public bool admin_update(MovieList m1)//Update movie details
        {
            try
            {
                SqlCommand pro = new SqlCommand();
                c1.Open();
                pro.CommandType = CommandType.StoredProcedure;
                pro.CommandText = "admin_update";
                pro.Parameters.AddWithValue("@name", m1.moviename);
                pro.Parameters.AddWithValue("@year", m1.movieyear);
                pro.Parameters.AddWithValue("@category", m1.moviecat);
                pro.Parameters.AddWithValue("@language", m1.movielang);
                pro.Parameters.AddWithValue("@rated", m1.movierate);
                pro.Parameters.AddWithValue("@lead", m1.movielead);
                pro.Parameters.AddWithValue("@desc", m1.moviedesc);
                pro.Parameters.AddWithValue("@dur", m1.movieduration);
                pro.Parameters.AddWithValue("@bud", m1.moviebudget);

                pro.Connection = c1;
                int r = pro.ExecuteNonQuery();
                c1.Close();
                if (r > 0) return true;
                else return false;
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                return false;
            }
            finally { c1.Close(); }
        }


        public bool admin_det_insert(AdminDetails m1)//insert admin registration details
        {
            try
            {
                SqlCommand p1 = new SqlCommand();
                c1.Open();
                p1.CommandText = "select * from admin_details where admin_id=@aid";
                p1.Parameters.AddWithValue("@aid", m1.adminid);
                p1.Connection = c1;
                DataSet d = new DataSet();
                sd.SelectCommand = p1;
                sd.Fill(d, "admin_details");
                if (d.Tables[0].Rows.Count > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new MovieManagementException("Id already exists. Try again");
                }
                c1.Close();
                SqlCommand pro = new SqlCommand();
                c1.Open();
                //pro.CommandType = CommandType.StoredProcedure;
                pro.CommandText = "insert into admin_details values(@aid,@nm,@pwdd)";
                pro.Parameters.AddWithValue("@nm", m1.adminname);
                pro.Parameters.AddWithValue("@aid", m1.adminid);
                pro.Parameters.AddWithValue("@pwdd", m1.adminpswd);

                pro.Connection = c1;
                int r = pro.ExecuteNonQuery();
                c1.Close();

                if (r > 0) return true;
                return false;
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



        }

        public bool cust_det_insert(UserDetails m1)//Insert customer registration details     
        {
            try
            {
                SqlCommand p1 = new SqlCommand();
                c1.Open();
                p1.CommandText = "select * from customer_details where cust_id=@aid";
                p1.Parameters.AddWithValue("@aid", m1.usernid);
                p1.Connection = c1;
                DataSet d = new DataSet();
                sd.SelectCommand = p1;
                sd.Fill(d, "customer_details");
                if (d.Tables[0].Rows.Count > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new MovieManagementException("Id already exists. Try again");
                }
                c1.Close();
                SqlCommand pro = new SqlCommand();
                c1.Open();
                pro.CommandType = CommandType.StoredProcedure;
                pro.CommandText = "cust_det_insert";
                pro.Parameters.AddWithValue("@nm", m1.username);
                pro.Parameters.AddWithValue("@aid", m1.usernid);
                pro.Parameters.AddWithValue("@pwdd", m1.userpswd);

                pro.Connection = c1;
                int r = pro.ExecuteNonQuery();
                c1.Close();
                if (r > 0) return true;
                return false;
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
        }
        public bool admin_validity(int aid, string apwd)//Validate Admin login
        {
            SqlCommand pro = new SqlCommand();
            c1.Open();
            pro.CommandType = CommandType.StoredProcedure;
            pro.Connection = c1;

            pro.CommandText = "admin_validity";
            pro.Parameters.AddWithValue("@aid", aid);
            pro.Parameters.AddWithValue("@apwd", apwd);

            DataSet d = new DataSet();
            sd.SelectCommand = pro;
            sd.Fill(d, "admin_details");

            int t = d.Tables[0].Rows.Count;
            c1.Close();

            if (t > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Welcome " + d.Tables[0].Rows[0][1] + "!");
                Thread.Sleep(3000);
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }
            else
                return false;
        }
        public bool cust_validity(int cid, string cpwd)//Validate Customer login
        {
            SqlCommand pro = new SqlCommand();
            c1.Open();
            pro.CommandType = CommandType.StoredProcedure;
            pro.CommandText = "cust_validdity";
            pro.Parameters.AddWithValue("@aid", cid);
            pro.Parameters.AddWithValue("@apwd", cpwd);

            pro.Connection = c1;
            DataSet d = new DataSet();
            sd.SelectCommand = pro;
            sd.Fill(d, "customer_details");

            int t = d.Tables[0].Rows.Count;
            c1.Close();

            if (t > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Welcome " + d.Tables[0].Rows[0][1] + "!");
                Thread.Sleep(3000);
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }
            else
                return false;
        }



        /*
        public void update_by_name(string sname1, string sname2)
        {
            SqlCommand pro = new SqlCommand();
            c1.Open();
            pro.CommandText = "update movie_list set sname=@name1 where sname=@name2";
            pro.Parameters.AddWithValue("@name", sname1);
            pro.Parameters.AddWithValue("@name2", sname2);
            pro.Connection = c1;
            pro.ExecuteNonQuery();
            c1.Close();

        }*/


        public bool update_by_year(string name, int sy1)//Update the year
        {
            SqlCommand pro1 = new SqlCommand();
            c1.Open();

            //Console.WriteLine("New Year:");
            pro1.CommandType = CommandType.StoredProcedure;
            pro1.CommandText = "update_by_year";
            pro1.Parameters.AddWithValue("@name1", name);
            pro1.Parameters.AddWithValue("@sy1", sy1);

            pro1.Connection = c1;

            int r = pro1.ExecuteNonQuery();
            c1.Close();
            if (r > 0) return true;
            else return false;

        }
        public bool update_by_category(string cat1, string cat2)//Update the category
        {
            SqlCommand pro = new SqlCommand();
            c1.Open();
            pro.CommandType = CommandType.StoredProcedure;
            pro.CommandText = "update_by_category";
            pro.Parameters.AddWithValue("@name1", cat1);
            pro.Parameters.AddWithValue("@sy1", cat2);
            pro.Connection = c1;
            pro.ExecuteNonQuery();
            int r = pro.ExecuteNonQuery();
            c1.Close();
            if (r > 0) return true;
            else return false;


        }

        public bool update_by_language(string lan1, string lan2)//Update the language
        {
            SqlCommand pro = new SqlCommand();
            c1.Open();
            pro.CommandType = CommandType.StoredProcedure;
            pro.CommandText = "update_by_language";
            pro.Parameters.AddWithValue("@name1", lan1);
            pro.Parameters.AddWithValue("@sy1", lan2);
            pro.Connection = c1;
            pro.ExecuteNonQuery();
            int r = pro.ExecuteNonQuery();
            c1.Close();
            if (r > 0) return true;
            else return false;

        }

        public bool update_by_rating(string name, double rate1)//Update the rating
        {
            try
            {
                SqlCommand pro = new SqlCommand();
                c1.Open();
                pro.CommandType = CommandType.StoredProcedure;
                pro.CommandText = "update_by_rating";
                pro.Parameters.AddWithValue("@name1", name);
                pro.Parameters.AddWithValue("@sy1", rate1);
                pro.Connection = c1;
                pro.ExecuteNonQuery();
                int r = pro.ExecuteNonQuery();
                c1.Close();
                if (r > 0) return true;
                else return false;
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(e.Message);
                Console.ResetColor();
                return false;
            }
            finally
            {
                c1.Close();
            }
        }



        public bool update_by_lead(string lead1, string lead2)//Update the lead
        {
            SqlCommand pro = new SqlCommand();
            c1.Open();
            pro.CommandType = CommandType.StoredProcedure;
            pro.CommandText = "update_by_lead";
            pro.Parameters.AddWithValue("@name1", lead1);
            pro.Parameters.AddWithValue("@sy1", lead2);
            pro.Connection = c1;
            pro.ExecuteNonQuery();
            int r = pro.ExecuteNonQuery();
            c1.Close();
            if (r > 0) return true;
            else return false;

        }
        public bool update_by_description(string lead1, string lead2)//Update the description
        {
            SqlCommand pro = new SqlCommand();
            c1.Open();
            pro.CommandType = CommandType.StoredProcedure;
            pro.CommandText = "update_by_description";
            pro.Parameters.AddWithValue("@name1", lead1);
            pro.Parameters.AddWithValue("@sy1", lead2);
            pro.Connection = c1;
            pro.ExecuteNonQuery();
            int r = pro.ExecuteNonQuery();
            c1.Close();
            if (r > 0) return true;
            else return false;

        }
        public bool update_by_duration(string lead1, string lead2)//Update the duration
        {
            SqlCommand pro = new SqlCommand();
            c1.Open();
            pro.CommandType = CommandType.StoredProcedure;
            pro.CommandText = "update_by_duration";
            pro.Parameters.AddWithValue("@name1", lead1);
            pro.Parameters.AddWithValue("@sy1", lead2);
            pro.Connection = c1;
            pro.ExecuteNonQuery();
            int r = pro.ExecuteNonQuery();
            c1.Close();
            if (r > 0) return true;
            else return false;

        }
        public bool update_by_budget(string lead1, string lead2)//Update the budget
        {
            SqlCommand pro = new SqlCommand();
            c1.Open();
            pro.CommandType = CommandType.StoredProcedure;
            pro.CommandText = "update_by_budget";
            pro.Parameters.AddWithValue("@name1", lead1);
            pro.Parameters.AddWithValue("@sy1", lead2);
            pro.Connection = c1;
            pro.ExecuteNonQuery();
            int r = pro.ExecuteNonQuery();
            c1.Close();
            if (r > 0) return true;
            else return false;

        }
        public void give_value(string lead1, dynamic lead2)//Select Movie element(name,description etc) with respect to name
        {
            try
            {
                SqlCommand pro = new SqlCommand();
                c1.Open();
                pro.Connection = c1;
                pro.CommandText = "select " + lead2 + " from movie_list where mname = '" + lead1 + "' ";
                DataSet d = new DataSet();
                sd.SelectCommand = pro;
                sd.Fill(d, "movie_list");
                Console.WriteLine("current value:" + d.Tables[0].Rows[0][0]);
                c1.Close();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(e.Message);
                Console.ResetColor();
            }
            finally { c1.Close(); }

        }

        static void dataset_print(DataSet d7)//Used to print the dataset
        {
            int n = d7.Tables[0].Rows.Count;
            for (int i = 0; i < n; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t\t\t #" + (i + 1));
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("- - - - - - - - - - - - - - - -- - - - - - - - - - - - -");
                Console.WriteLine("\t\t\t" + (d7.Tables[0].Rows[i][0]).ToString().ToUpper());
                Console.WriteLine("Name: " + d7.Tables[0].Rows[i][0]);
                Console.WriteLine("Year: " + d7.Tables[0].Rows[i][1]);
                Console.WriteLine("Category: " + d7.Tables[0].Rows[i][2]);
                Console.WriteLine("Language: " + d7.Tables[0].Rows[i][3]);
                Console.WriteLine("Rating: " + d7.Tables[0].Rows[i][4]);
                Console.WriteLine("Lead Actor: " + d7.Tables[0].Rows[i][5]);
                Console.WriteLine("Description: " + d7.Tables[0].Rows[i][6]);
                Console.WriteLine("Duration: " + d7.Tables[0].Rows[i][7]);
                Console.WriteLine("Budget: " + d7.Tables[0].Rows[i][8]);
                Console.WriteLine("- - - - - - - - - - - - - - - -- - - - - - - - - - - - -");

            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public bool check_Name(string s1)//Check the movie name
        {
            try
            {
                SqlCommand pro = new SqlCommand();
                c1.Open();
                pro.Connection = c1;

                pro.CommandText = "select count(mname) from movie_list where mname = '" + s1 + "' ";

                DataSet d = new DataSet();
                sd.SelectCommand = pro;
                sd.Fill(d, "movie_list");

                int t = Convert.ToInt32(d.Tables[0].Rows[0][0].ToString());
                c1.Close();

                if (t > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(e.Message);
                Console.ResetColor();
                return true;
            }
            finally
            {
                c1.Close();
            }
        }


        public bool admin_id_check(int aid)//check if admin id entered while registration exists or no
        {
            SqlCommand pro = new SqlCommand();
            c1.Open();
            pro.Connection = c1;

            pro.CommandText = "select count(admin_id) from admin_details where admin_id = " + aid ;

            DataSet d = new DataSet();
            sd.SelectCommand = pro;
            sd.Fill(d, "admin_details");

            int t = Convert.ToInt32(d.Tables[0].Rows[0][0].ToString());
            c1.Close();

            if (t > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool cust_id_check(int aid)// check if customer id while registration exists or no
        {
            SqlCommand pro = new SqlCommand();
            c1.Open();
            pro.Connection = c1;

            pro.CommandText = "select count(cust_id) from customer_details where cust_id = " + aid;

            DataSet d = new DataSet();
            sd.SelectCommand = pro;
            sd.Fill(d, "customer_details");

            int t = Convert.ToInt32(d.Tables[0].Rows[0][0].ToString());
            c1.Close();

            if (t > 0)
            {
                return true;
            }
            else
                return false;
        }
    }
}
