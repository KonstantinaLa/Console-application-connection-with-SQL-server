using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectPartB
{
    class Course
    {
        //print all courses from the database
        public static void AllCourses(bool AllData)
        {
            //Connection String
            string connectionString = "Data Source = LAPTOP-5Q2SN5J3\\SQLEXPRESS; Initial Catalog =Private School; Integrated Security = true; ";
            string coursesQuery = "";

            if (AllData)
            {
                //prints all data of each course
                coursesQuery = "SELECT * FROM Course ";
            }
            else
            {   
                //print some data of each course
                coursesQuery = "SELECT CourseId, Title LastName FROM Course ";
            }



            using (SqlConnection connection = new SqlConnection(connectionString))      
            {
                SqlCommand command = new SqlCommand(coursesQuery, connection);          
                SqlDataReader reader = null;

                try
                {
                    connection.Open();
                    reader = command.ExecuteReader();                                   

                    while (reader.Read())
                    {
                        if (AllData)
                        {
                            //take only the date not the time
                            var startDate = string.Format("{0:d/M/yyyy}", reader[4]);  
                            var endDate = string.Format("{0:d/M/yyyy}", reader[5]);

                            //print all course Data
                            Console.WriteLine($"{reader[0],-3} {reader[1],-10} {reader[2],-10} {reader[3],-10} Start Date:{startDate} End Date:{endDate}");
                        }
                        else
                        {
                            //Print some course Data
                            Console.WriteLine($"CourseId:{reader[0],-3} Title:{reader[1],-15}");
                        }
                       
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                }
            }
        }

        //Insert course Data to the Database
        private static void insertCoursesDb(string Title, string stream, string type, DateTime start_date, DateTime end_date)
        {
            //Connection String
            string connectionString = "Data Source = LAPTOP-5Q2SN5J3\\SQLEXPRESS; Initial Catalog = Private School; Integrated Security = true; ";
            //query that it will be executed
            string coursesQuery = "INSERT INTO Course VALUES(@title, @stream, @type, @startDate,@endDate)";         

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(coursesQuery, connection))
                {

                    //add Parameters of the inserted data
                    command.Parameters.Add(new SqlParameter("@title", Title));
                    command.Parameters.Add(new SqlParameter("@stream", stream));
                    command.Parameters.Add(new SqlParameter("@type", type));
                    command.Parameters.Add(new SqlParameter("@startDate", start_date));
                    command.Parameters.Add(new SqlParameter("@endDate", end_date));

                    try
                    {

                        connection.Open();
                        command.ExecuteNonQuery();      //execute
                        Console.WriteLine("Insert successful!");    //Inform user for the successful insert
                    }
                    catch (Exception)   
                    {
                        throw;
                    }
                }
            }
        }

        //user insert the data for the course
        public static void insertCourseData()
        {
            //Ask user to insert the data
            Console.Write("Write the title of the course or press enter: "); 
            string title = Console.ReadLine().Trim();

            while (title.ToUpper().Trim() != "")
            {

                Console.Write("Give me the Stream: ");
                string stream = Console.ReadLine().Trim();

                Console.Write("Give me the type of the course: ");
                string type = Console.ReadLine().Trim();

                Console.Write("Give me the start date: ");
                DateTime start_date;
                //check if the input is valid
                while (!DateTime.TryParse(Console.ReadLine(), out start_date))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid date.Give me the start date again: ");
                    Console.ResetColor();
                }

                Console.Write("Give me the end date: ");
                DateTime end_date;
                //check if the input is valid
                while (!DateTime.TryParse(Console.ReadLine(), out end_date))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid date.Give me the start date again: ");
                    Console.ResetColor();
                }

                //call method that insert data in the database
                insertCoursesDb(title, stream, type,start_date, end_date);

                //Continue with next course input or 'finish'
                Console.Write("Write the title of the course or press enter: ");
                title = Console.ReadLine().Trim();
                Console.Clear();
            }

        }
    }
}
