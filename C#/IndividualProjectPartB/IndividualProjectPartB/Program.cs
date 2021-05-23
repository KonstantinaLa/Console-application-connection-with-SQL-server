using System;
using System.Data.SqlClient;
using System.Text;

namespace IndividualProjectPartB
{
    class Program
    {
        //Main Menu
        private static bool Menu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n--------Choose an option:--------\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1)Add extra students"); 
            Console.WriteLine("2)Print a list of student\n"); 
            Console.WriteLine("3)Add extra courses"); 
            Console.WriteLine("4)Print a list of courses.\n");
            Console.WriteLine("5)Add extra trainers");
            Console.WriteLine("6)Print a list of trainers\n");
            Console.WriteLine("7)Add extra assignments");
            Console.WriteLine("8)Print a list of assignments \n"); 
            Console.WriteLine("9)Print all the studens per course.");
            Console.WriteLine("10)Print all the trainers per course.");
            Console.WriteLine("11)Print all the assignements per course.");
            Console.WriteLine("12)Print all the assignments per student per course."); 
            Console.WriteLine("13)Print a list of students that belong to more than one courses");
            Console.WriteLine("14) Make new matches");
            Console.WriteLine("\n15) Exit\n");
            Console.ResetColor();
           
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Clear();
                    Student.insertStudentData();
                    return true;
                case "2":
                    Console.Clear();
                    Student.AllStudents(true);
                    return true;
                case "3":
                    Console.Clear();
                    Course.insertCourseData();
                    return true;
                case "4":
                    Console.Clear();
                    Course.AllCourses(true);
                    return true;
                case "5":
                    Console.Clear();
                    Trainer.insertTrainerData();
                    return true;
                case "6":
                    Console.Clear();
                    Trainer.AllTrainers(true);
                    return true;
                case "7":
                    Console.Clear();
                    Assignment.insertAssignmentData();
                    return true;
                case "8":
                    Console.Clear();
                    Assignment.AllAssignments(true);
                    return true;
                case "9":
                    Console.Clear();
                    School.StudentsPerCourse();
                    return true;
                case "10":
                    Console.Clear();
                    School.TrainersPerCourse();
                    return true;
                case "11":
                    Console.Clear();
                    School.AssignmentsPerCourse();
                    return true;
                case "12":
                    Console.Clear();
                    School.PrintAssignmentsPerCoursePerStudent();
                    return true;
                case "13":
                    Console.Clear();
                    School.PrintStudentsWithMoreThanOneCourse();
                    return true;
                case "14":
                    Console.Clear();
                    bool showMenu = true;
                    while (showMenu)
                    {
                        showMenu = MenuMatches();
                    }
                    return true;
                case "15":
                    return false;
                default:
                    return true;

            }
        }
        //Menu for matches
        private static bool MenuMatches()
        {
            Console.Clear();
            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n--------Choose an option:--------");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1)Match course with attendees");
            Console.WriteLine("2)Match course with trainers");
            Console.WriteLine("3)Match course with assignments");
            Console.WriteLine("4)Return to first menu\n");
            Console.ResetColor();
            string input = Console.ReadLine().Trim();
            switch (input)
            {
                case "1":
                    Console.Clear();
                    School.MatchCourseAttendees();
                    return true;
                case "2":
                    Console.Clear();
                    School.MatchCourseTrainers();
                    return true;
                case "3":
                    Console.Clear();
                    School.MatchCourseAssignment();
                    return true;
                default:
                    Console.Clear();
                    return false;
            }
        }

        static void Main(string[] args)
        {

            bool showMenu = true;
            while (showMenu)
            {
                showMenu = Menu();
            }
                
        }

        
    }
}
