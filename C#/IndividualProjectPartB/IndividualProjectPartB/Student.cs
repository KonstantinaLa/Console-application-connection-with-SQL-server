using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;

namespace IndividualProjectPartB
{
    class Student
    {
        //print all students from the database
        public static void AllStudents(bool allData)
        {
            //Connection String
            string connectionString = "Data Source = LAPTOP-5Q2SN5J3\\SQLEXPRESS; Initial Catalog =Private School; Integrated Security = true; ";
            string studentsQuery = "";
            if (allData)
            {
                //prints all data of each student
                studentsQuery = "SELECT * FROM Student ";
            }
            else
            {
                //print some data of each student
                studentsQuery = "SELECT StudentID , FirstName, LastName FROM Student";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(studentsQuery, connection);
                SqlDataReader reader = null;

                try
                {
                    connection.Open();
                    reader = command.ExecuteReader();  //Execute

                    while (reader.Read())
                    {
                        if (allData)
                        {
                            //take only the date not the time
                            var dateOfBirth = string.Format("{0:d/M/yyyy}", reader[3]);
                            //call encoding gor euro symbol
                            Console.OutputEncoding = Encoding.UTF8;

                            //print all student Data
                            Console.WriteLine($"{reader[0],3}) {reader[1],-15} {reader[2],-15} {dateOfBirth,-10} {reader[4],-4}€");
                        }
                        else
                        {
                            //Print some student Data
                            Console.WriteLine($"StudentId:{reader[0],-3} Name: {reader[1],-15} {reader[2],-15}");
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

        //Insert student Data to the Database
        private static void insertStudentDb(string FirstName, string LastName, DateTime dateOfBirth, decimal TuitionFees)
        {
            //Connection String
            string connectionString = "Data Source = LAPTOP-5Q2SN5J3\\SQLEXPRESS; Initial Catalog = Private School; Integrated Security = true; ";
            //query that it will be executed
            string studentsQuery = "INSERT INTO Student VALUES(@FirstName, @LastName, @DateOfBirth, @TuitionFees)";
           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(studentsQuery, connection))
                {
                    //add Parameters of the inserted data
                    command.Parameters.Add(new SqlParameter("@FirstName", FirstName));
                    command.Parameters.Add(new SqlParameter("@LastName", LastName));
                    command.Parameters.Add(new SqlParameter("@DateOfBirth", dateOfBirth));
                    command.Parameters.Add(new SqlParameter("@TuitionFees", TuitionFees));

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

        //user insert the data for the student
        public static void insertStudentData()
        {
            //Ask user to insert the data
            Console.Write("Write the fullname of the student or press ENTER: ");
            string fullName = Console.ReadLine();

            while (fullName.ToUpper().Trim() != "")
            {
                //get student info
                string[] fullnameArray = fullName.Trim().Split(' ');
                string firstName = fullnameArray[0];
                string lastName = fullnameArray[1];

                Console.Write("Give me the date of birth: ");
                DateTime dateOfBirth;
                //check if the input is valid
                while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid date.Give me the date of birth");
                    Console.ResetColor();
                }

                Console.Write("Give me the tuition Fees: ");
                decimal tuitionFees = 0;
                bool notNumber = true;

                //check if tuition fees are valid input
                while (notNumber)
                {
                    try
                    {
                        tuitionFees = decimal.Parse(Console.ReadLine().Trim());
                        notNumber = false;
                    }
                    catch (Exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Invalid input.Give me the tuition Fees: ");
                        Console.ResetColor();
                    }
                }
                //call method that insert data in the database
                insertStudentDb(firstName, lastName, dateOfBirth, tuitionFees);

                //Continue with next Student input or 'finish'
                Console.Write("Write the fullname of the student or press ENTER: ");
                fullName = Console.ReadLine();

                Console.Clear();
            }
            
        }

    }
}

