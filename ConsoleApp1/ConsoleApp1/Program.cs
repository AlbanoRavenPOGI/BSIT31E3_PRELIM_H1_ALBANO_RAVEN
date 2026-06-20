using System;

namespace StudentManagementSystem
{
    class Program
    {
        // Instantiate the public manager class
        static StudentManager manager = new StudentManager();

        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\n====================================");
                Console.WriteLine("     STUDENT MANAGEMENT SYSTEM      ");
                Console.WriteLine("====================================");
                Console.WriteLine("1. Add Student Record");
                Console.WriteLine("2. View All Student Records");
                Console.WriteLine("3. View Class Summary & Analytics");
                Console.WriteLine("4. Exit");
                Console.WriteLine("====================================");
                Console.Write("Enter your choice (1-4): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddStudentRecord();
                        break;
                    case "2":
                        ViewStudentRecords();
                        break;
                    case "3":
                        ViewClassSummary();
                        break;
                    case "4":
                        Console.WriteLine("Exiting the program. Thank you!");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please select 1 to 4.");
                        break;
                }
            }
        }

        static void AddStudentRecord()
        {
            Console.WriteLine("--- ADD NEW STUDENT RECORD ---");
            string name = "";
            while (true)
            {
                Console.Write("Enter Student Name: ");
                name = Console.ReadLine().Trim();
                if (!string.IsNullOrEmpty(name)) break;
                Console.WriteLine("Name cannot be empty.");
            }

            double grade = 0;
            while (true)
            {
                Console.Write("Enter Student Grade (0 - 100): ");
                if (double.TryParse(Console.ReadLine(), out grade) && grade >= 0 && grade <= 100) break;
                Console.WriteLine("Invalid Input! Must be 0 to 100.");
            }

            // Using the public class method here
            manager.AddStudent(name, grade);
            Console.WriteLine($"\nSuccess: Record for '{name}' saved.");
        }

        static void ViewStudentRecords()
        {
            Console.WriteLine("--- ALL STUDENT RECORDS ---");
            if (manager.Students.Count == 0)
            {
                Console.WriteLine("No records found.");
                return;
            }

            Console.WriteLine("------------------------------------");
            Console.WriteLine(String.Format("{0,-5} | {1,-20} | {2,-10}", "No.", "Student Name", "Grade"));
            Console.WriteLine("------------------------------------");

            for (int i = 0; i < manager.Students.Count; i++)
            {
                Console.WriteLine(String.Format("{0,-5} | {1,-20} | {2,-10:F2}",
                    (i + 1), manager.Students[i].Name, manager.Students[i].Grade));
            }
        }

        static void ViewClassSummary()
        {
            Console.WriteLine("--- CLASS SUMMARY & ANALYTICS ---");
            if (manager.Students.Count == 0)
            {
                Console.WriteLine("No data available.");
                return;
            }

            Student top = manager.GetTopStudent();

            Console.WriteLine($"Total Students Enrolled : {manager.Students.Count}");
            Console.WriteLine($"Class Average Grade     : {manager.CalculateAverage():F2}");
            Console.WriteLine($"Highest Grade in Class  : {top.Grade:F2}");
            Console.WriteLine($"Top Performing Student  : {top.Name}");
            Console.WriteLine("------------------------------------");
        }
    }
}