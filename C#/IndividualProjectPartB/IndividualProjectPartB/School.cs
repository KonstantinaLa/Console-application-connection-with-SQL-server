using System;
using System.Data.SqlClient;
using System.Data;

namespace IndividualProjectPartB
{
    class School
    {
        //print the attendees of the input course
        public static void PrintAttendees(string input)
        {
			Console.Clear();
            //Connection String
            
			string connectionString = "Data Source = LAPTOP-5Q2SN5J3\\SQLEXPRESS; Initial Catalog = Private School; Integrated Security = true; ";

            SqlConnection connection = null;
            SqlDataReader reader = null;
			try
			{
				connection= new SqlConnection(connectionString);
				connection.Open();

				SqlCommand cmd = new SqlCommand("Attendees", connection);

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@course", input));

				reader = cmd.ExecuteReader();
                Console.WriteLine("---------- Attendees----------");
				while (reader.Read())
				{
                    Console.WriteLine($"{reader[0],-15} {reader[1],-15}");
				}
			}
			finally
			{
				if (connection != null)
				{
					connection.Close();
				}
				if (reader != null)
				{
					reader.Close();
				}
			}
		}
		//print the trainers of the input course
		public static void PrintTrainersPerCourse(string input)
		{
			Console.Clear();
			//Connection String
			string connectionString = "Data Source = LAPTOP-5Q2SN5J3\\SQLEXPRESS; Initial Catalog = Private School; Integrated Security = true; ";

			SqlConnection connection = null;
			SqlDataReader reader = null;
			try
			{
				connection = new SqlConnection(connectionString);
				connection.Open();

				SqlCommand cmd = new SqlCommand("TrainersPerCourse", connection);

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@course", input));

				reader = cmd.ExecuteReader();

                Console.WriteLine("----------Trainers----------");
				while (reader.Read())
				{
					Console.WriteLine($"{reader[0],-15} {reader[1],-15}");
				}
			}
			finally
			{
				if (connection != null)
				{
					connection.Close();
				}
				if (reader != null)
				{
					reader.Close();
				}
			}
		}
		//print the assignment of the input course
		public static void PrintAssignmentsPerCourse(string input)
        {
			Console.Clear();
            //Connection String
            string connectionString = "Data Source = LAPTOP-5Q2SN5J3\\SQLEXPRESS; Initial Catalog = Private School; Integrated Security = true; ";

            SqlConnection connection = null;
            SqlDataReader reader = null;
			try
			{
				connection= new SqlConnection(connectionString);
				connection.Open();

				SqlCommand cmd = new SqlCommand("AssignmentPerCourse", connection);

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add(new SqlParameter("@course", input));

				reader = cmd.ExecuteReader();

                Console.WriteLine("----------Assignments----------");
				while (reader.Read())
				{
                    Console.WriteLine(reader[0]);
				}
			}
			finally
			{
				if (connection != null)
				{
					connection.Close();
				}
				if (reader != null)
				{
					reader.Close();
				}
			}
		}
		//print a list of students with the assignments and courses
		public static void PrintAssignmentsPerCoursePerStudent()
		{
			//Connection String
			string connectionString = "Data Source = LAPTOP-5Q2SN5J3\\SQLEXPRESS; Initial Catalog = Private School; Integrated Security = true;";
			string query = "SELECT DISTINCT Student.FirstName ,Student.LastName , Course.Title,  Assignment.Title FROM StudentCourse , AssignmentCourse , Assignment , Student, Course WHERE StudentCourse.CourseId = AssignmentCourse.CourseId AND AssignmentCourse.AssignmentId = Assignment.AssignmentId AND Student.StudentID = StudentCourse.StudentId AND Course.CourseId = StudentCourse.CourseId";


			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(query, connection);
				SqlDataReader reader = null;

				try
				{
					connection.Open();
					reader = command.ExecuteReader();

					while (reader.Read())
					{
						Console.WriteLine($"{reader[0],-15} {reader[1],-15} \tCourse:{reader[2],-10} \tAssignment:{reader[3]}");
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

		//print students that are in more than one course
		public static void PrintStudentsWithMoreThanOneCourse()
		{
			//Connection String
			string connectionString = "Data Source = LAPTOP-5Q2SN5J3\\SQLEXPRESS; Initial Catalog = Private School; Integrated Security = true;";
			string query = "SELECT Student.StudentId , Student.FirstName , Student.LastName FROM Student WHERE EXISTS (SELECT StudentID FROM StudentCourse WHERE StudentCourse.StudentId = Student.StudentID GROUP BY StudentId HAVING COUNT(StudentCourse.StudentId)>=2)";  

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(query, connection);
				SqlDataReader reader = null;

				try
				{
					connection.Open();
					reader = command.ExecuteReader();
					
					while (reader.Read())
					{
                        
						Console.WriteLine($"{reader[1],-15} {reader[2],-15}");
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

		//menu that the user can choose witch course attendees want to see
		public static void StudentsPerCourse()
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("----------All Courses----------");
			Course.AllCourses(false);
			Console.ResetColor();
			Console.WriteLine("\n\nWrite the course title to see the attendees or press ENTER");
			string input = Console.ReadLine().Trim();

			while (input.ToUpper() != "")
			{
				PrintAttendees(input);
				Console.WriteLine("\n\n");
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("----------All Courses----------");
				Course.AllCourses(false);
				Console.ResetColor();
				Console.WriteLine("\n\nWrite the next course title to see the attendees or press ENTER");
				input = Console.ReadLine().Trim();
				Console.Clear();
			}
		}

		//menu that user can choose witch course trainers want to see
		public static void TrainersPerCourse()
		{

			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("----------All Courses----------");
			Course.AllCourses(false);
			Console.ResetColor();
			Console.WriteLine("\n\nWrite the course title to see the trainers or press ENTER");
			string input = Console.ReadLine().Trim();

			while (input.ToUpper() != "")
			{
				PrintTrainersPerCourse(input);
				Console.WriteLine("\n\n");

				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("----------All Courses----------");
				Course.AllCourses(false);
				Console.ResetColor();
				Console.WriteLine("\n\nWrite the next course title to see the trainers or press ENTER");
				input = Console.ReadLine().Trim();
				Console.Clear();
			}

		}

		//menu that user can choose witch course assignments want to see
		public static void AssignmentsPerCourse()
        {
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("----------All Courses----------");
			Course.AllCourses(false);
			Console.ResetColor();
			Console.WriteLine("\n\nWrite the course title to see the Assignments or press ENTER");
			string input = Console.ReadLine().Trim();

			while (input.ToUpper() != "FINISH")
			{
				PrintAssignmentsPerCourse(input);
				Console.WriteLine("\n\n");
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("----------All Courses----------");
				Course.AllCourses(false);
				Console.ResetColor();
				Console.WriteLine("\n\nWrite the next course title to see the assignments or press ENTER");
				input = Console.ReadLine().Trim();
				Console.Clear();
			}

		}

		//connect with database and insert the new match user have made
		public static void MatchCourseStudentDb( int studentId,int courseId )
        {
			//Connection String
            string connectionString = "Data Source = LAPTOP-5Q2SN5J3\\SQLEXPRESS; Initial Catalog = Private School; Integrated Security = true; ";
            string query = "INSERT INTO StudentCourse VALUES(@StudentId, @CourseId)";
           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
					command.Parameters.Add(new SqlParameter("@StudentId", studentId));
					command.Parameters.Add(new SqlParameter("@CourseId", courseId));
                    
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        Console.WriteLine("Insert successful!");
                    }
					catch (Exception)
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("The match already exists");
						Console.ResetColor();
					}
				}
            }

        }

		//user make the match course-student 
		public static void MatchCourseAttendees()
        {
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("----------All Students---------");
			Student.AllStudents(false);
            Console.WriteLine("\n\n----------All Courses---------");
			Course.AllCourses(false);
			Console.ResetColor();

            Console.WriteLine("\n\n Write the courseId of the course you want to make the match or press ENTER");
			string courseId = Console.ReadLine().Trim();

            while (courseId.ToUpper() !="")
            {
				int cId;
				while (!int.TryParse(courseId, out cId))
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Invalid input. Give me a valid courseId");
					Console.ResetColor();
				}

				Console.WriteLine("Give me the studentId");
				string input = Console.ReadLine().Trim();
                while (input !="")
                {
					int studentId;
					while (!int.TryParse(input, out studentId))
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Invalid input. Give me a valid studentId");
						Console.ResetColor();
					}
					MatchCourseStudentDb(studentId, cId);
					Console.WriteLine("Give me the next studentId ");
					input = Console.ReadLine().Trim();

				}

				Console.WriteLine("\n\n Write the courseId of the next course you want to make the match or press ENTER");
				courseId = Console.ReadLine().Trim();
                Console.Clear();
			}

        }

		//connect with database and insert the new match trainer-course user have made
		public static void MatchCourseTrainerDb(int trainerId, int courseId)
		{
			//Connection String
			string connectionString = "Data Source = LAPTOP-5Q2SN5J3\\SQLEXPRESS; Initial Catalog = Private School; Integrated Security = true; ";
			string query = "INSERT INTO TrainerCourse VALUES(@TrainerId, @CourseId)";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.Add(new SqlParameter("@TrainerId", trainerId));
					command.Parameters.Add(new SqlParameter("@CourseId", courseId));

					try
					{
						connection.Open();
						command.ExecuteNonQuery();
						Console.WriteLine("Insert successful!");
					}
					catch (Exception)
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("The match already exists");
						Console.ResetColor();
					}
				}
			}

		}

		//user make the match Course Trainer 
		public static void MatchCourseTrainers()
        {
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("\n\n----------All Trainers---------");
			Trainer.AllTrainers(false);
			Console.WriteLine("----------All Courses---------");
			Course.AllCourses(false);
			Console.ResetColor();
            
            Console.WriteLine("\n\n Write the courseId of the course you want to make the matches or press ENTER");
			string courseId = Console.ReadLine().Trim();

            while (courseId.ToUpper() !="")
            {
				int cId;
				while (!int.TryParse(courseId, out cId))
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Invalid input. Give me a valid courseId");
					Console.ResetColor();
				}

				Console.WriteLine("Give me the TrainerId ");
				string input = Console.ReadLine().Trim();

                while (input!="")
                {
					int trainerId;
					while (!int.TryParse(input, out trainerId))
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Invalid input. Give me a valid trainerId");
						Console.ResetColor();
					}
					MatchCourseTrainerDb(trainerId, cId);
					Console.WriteLine("Give me the next TrainerId or press ENTER");
					input = Console.ReadLine().Trim();
				}
				
				Console.WriteLine("\n\n Write the courseId of the next course you want to make the match or press ENTER");
				courseId = Console.ReadLine().Trim();
			}
			Console.Clear();
		}

		//connect with DATABASE and insert the new match Assignment-course user have made
		public static void MatchCourseAssignmentDb(int assignmentId, int courseId)
		{
			//Connection String
			string connectionString = "Data Source = LAPTOP-5Q2SN5J3\\SQLEXPRESS; Initial Catalog = Private School; Integrated Security = true; ";
			string query = "INSERT INTO AssignmentCourse VALUES(@AssignmentId, @CourseId)";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.Add(new SqlParameter("@AssignmentId", assignmentId));
					command.Parameters.Add(new SqlParameter("@CourseId", courseId));

					try
					{
						connection.Open();
						command.ExecuteNonQuery();
						Console.WriteLine("Insert successful!");
					}
                    catch (Exception)
                    {
						Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The match already exists");
                        Console.ResetColor();
                    }

                }
			}

		}

		//user make the match Course Assignment 
		public static void MatchCourseAssignment()
		{

			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("\n\n----------All Assignments---------");
			Assignment.AllAssignments(false);
			Console.WriteLine("----------All Courses---------");
			Course.AllCourses(false);
			Console.ResetColor();

			Console.WriteLine("\n\n Write the courseId of the course you want to make the match or press ENTER to go back");
			string courseId = Console.ReadLine().Trim();

			while (courseId.ToUpper() != "")
			{
				int cId;
				while (!int.TryParse(courseId, out cId))
                {
					Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Give me a valid courseId");
                    Console.ResetColor();
                }

				Console.WriteLine("Give me the assignmentId");
				string input = Console.ReadLine().Trim();

				
				while (input != "")
                {
					int assignmentId;
					while (!int.TryParse(input, out assignmentId))
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Invalid input. Give me a valid assignmentId");
						Console.ResetColor();
					}
					MatchCourseAssignmentDb(assignmentId, cId);
					Console.WriteLine("Give me the next assignmentId or press ENTER");
					input = Console.ReadLine().Trim();
				}

				Console.WriteLine("\n\n Write the courseId of the course you want to make the match or press ENTER to go back");
				courseId = Console.ReadLine().Trim();
				
			}
			Console.Clear();
		}


	}
}
