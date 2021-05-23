using System;
using System.Data.SqlClient;
using System.Text;

namespace IndividualProjectPartB
{
    class Trainer
    {
        //print all trainers from the database
        public static void AllTrainers(bool AllData)
        {
            //Connection String
            string connectionString = "Data Source = LAPTOP-5Q2SN5J3\\SQLEXPRESS; Initial Catalog = Private School; Integrated Security = true; ";
            string trainerQuery = "";
            if (AllData)
            {
                //prints all data of each course
                trainerQuery = "SELECT * FROM Trainer ";
            }
            else
            {
                //print some data of each course
                trainerQuery = "SELECT TrainerId,FirstName, LastName FROM Trainer";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(trainerQuery, connection);
                SqlDataReader reader = null;

                try
                {
                    connection.Open();
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (AllData)
                        {

                            //print all trainer Data
                            Console.WriteLine($"{reader[0],-3} {reader[1],-15} {reader[2],-15} {reader[3],-15}");
                        }
                        else
                        {
                            //Print some trainer Data
                            Console.WriteLine($"TrainerId:{reader[0],-3} Full Name: {reader[1],-15} {reader[2],-15}");
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

        //Insert trainer Data to the Database
        private static void insertTrainerDb(string FirstName, string LastName, string Subject)
        {
            //Connection String
            string connectionString = "Data Source = LAPTOP-5Q2SN5J3\\SQLEXPRESS; Initial Catalog = Private School; Integrated Security = true; ";
            //query that it will be executed
            string trainerQuery = "INSERT INTO Trainer VALUES(@FirstName, @LastName, @Subject)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(trainerQuery, connection))
                {
                    //add Parameters of the inserted data
                    command.Parameters.Add(new SqlParameter("@FirstName", FirstName));
                    command.Parameters.Add(new SqlParameter("@LastName", LastName));
                    command.Parameters.Add(new SqlParameter("@Subject", Subject));
                   

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();                       //execute
                        Console.WriteLine("Insert successful!");        //Inform user for the successful insert
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        //user insert the data for the trainer
        public static void insertTrainerData()
        {
            //Ask user to insert the data
            Console.Write("Write the fullname of the Trainer or press ENTER: ");
            string fullName = Console.ReadLine().Trim();

            while (fullName.ToUpper().Trim() != "")
            {
                //get trainer info
                string[] fullnameArray = fullName.Trim().Split(' ');
                string firstName = fullnameArray[0];
                string lastName = fullnameArray[1];


                Console.Write("Give me the Subject of the trainer: ");
                string subject = Console.ReadLine().Trim();

                //call method that insert data in the database
                insertTrainerDb(firstName, lastName,subject);

                //Continue with next Student input or 'finish'
                Console.Write("Write the fullname of the trainer or press ENTER: ");
                fullName = Console.ReadLine().Trim();

                Console.Clear();
            }

        }


    }
}
