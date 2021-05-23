using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectPartB
{
    class Assignment
    {
        //print all Assignments from the database
        public static void AllAssignments(bool AllData)
        {
            //Connection String
            string connectionString = "Data Source = LAPTOP-5Q2SN5J3\\SQLEXPRESS; Initial Catalog = Private School; Integrated Security = true; ";
            string assignmentsQuery = "";
            
            if (AllData)
            {
                //print all data of each assignment
                assignmentsQuery = "SELECT * FROM Assignment ";
            }
            else
            {
                //print some data of each assignment
                assignmentsQuery = "SELECT AssignmentId, Title FROM Assignment";
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(assignmentsQuery, connection);
                SqlDataReader reader = null;

                try
                {
                    connection.Open();
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (AllData)
                        {
                            
                            //print all Assignment Data
                            Console.WriteLine($"{reader[0],-3} {reader[1],-18} {reader[2],-15} SubmitionDate: {reader[3],-23} Oral Mark: {reader[4],-4} Total Mark: {reader[5],-4}");
                        }
                        else
                        {
                            //Print some assignment Data
                            Console.WriteLine($"AssignmentId: {reader[0],-3} Title:{reader[1],-15}");
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

        //Insert assignment Data to the Database
        private static void insertAssignmentsDb(string Title, string description,  DateTime sub_date , float oralMark , float totalMark)
        {
            //Connection String
            string connectionString = "Data Source = LAPTOP-5Q2SN5J3\\SQLEXPRESS; Initial Catalog = Private School; Integrated Security = true; ";
            //query that it will be execute
            string assignmentQuery = "INSERT INTO Assignment VALUES(@title, @description, @sub_date, @oralMark,@totalMark)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(assignmentQuery, connection))
                {
                    //add Parameters of the inserted data
                    command.Parameters.Add(new SqlParameter("@title", Title));
                    command.Parameters.Add(new SqlParameter("@description", description));
                    command.Parameters.Add(new SqlParameter("@sub_date", sub_date));
                    command.Parameters.Add(new SqlParameter("@oralMark", oralMark));
                    command.Parameters.Add(new SqlParameter("@totalMark", totalMark));

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();                   //execute
                        Console.WriteLine("Insert successful!");    //Inform user for the successful insert
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        //user insert the data for the assignment
        public static void insertAssignmentData()
        {
            //Ask user to insert the data
            Console.Write("Write the title of the Assignment or press ENTER: ");
            string title = Console.ReadLine().Trim();

            while (title.ToUpper().Trim() != "")
            {

                Console.Write("Give me the Description ");
                string description = Console.ReadLine().Trim();

                Console.Write("Give me the sub date: ");
                DateTime sub_Date;
                //check if the input is valid
                while (!DateTime.TryParse(Console.ReadLine(), out sub_Date))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid date.Give me the sub date again: ");
                    Console.ResetColor();
                }

                Console.Write("Give me the oral mark of the course: ");
                float oralMark;
                //check if the input is valid
                while (!float.TryParse(Console.ReadLine().Trim(), out oralMark))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Give me a number");
                    Console.ResetColor();
                }   

                Console.Write("Give me the total mark of the course: ");
                float totalMark;
                //check if the input is valid
                while (!float.TryParse(Console.ReadLine().Trim(), out totalMark))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Give me a number");
                    Console.ResetColor();
                }

                //call method that insert data in the database
                insertAssignmentsDb(title, description, sub_Date, oralMark, totalMark);

                //Continue with next assignment input or 'finish'
                Console.Write("Write the title of the next Assignment or press ENTER: ");
                title = Console.ReadLine().Trim();

                Console.Clear();
            }

        }

    }
}
