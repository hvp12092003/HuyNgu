using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace HuyNgu
{
    public class Student
    {
        public float _id { get; set; }
        public string _name { get; set; }
        public float _theoreticalScore { get; set; }
        public float _practiceScore { get; set; }
        public float _mediumScore { get; set; }

        public Student(float id, string name, float theoreticalScore, float practiceScore, float mediumScore)
        {
            _id = id;
            _name = name;
            _theoreticalScore = theoreticalScore;
            _practiceScore = practiceScore;
            _mediumScore = mediumScore;
        }
    }
    public class Program
    {
        float chose;
        static LinkedList<Student> students = new LinkedList<Student>();


        public void DisplayStudents()
        {
            Console.WriteLine("Student list:");
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student._id}, Name: {student._name}, TheoreticalScore: {student._theoreticalScore},PracticeScore: {student._practiceScore}, MediumScore: {student._mediumScore}");
            }
            Console.ReadKey();
        }


        public void DeleteStudent()
        {
            Console.Write("Enter the student's ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());

            LinkedListNode<Student> currentNode = students.First;
            while (currentNode != null)
            {
                if (currentNode.Value._id == id)
                {
                    students.Remove(currentNode);
                    Console.WriteLine("Successful students have deleted.");
                    return;
                }
                else
                {
                    ErrorEndWithTimeout("Invalid information", 26, 6, 1500);
                }
                currentNode = currentNode.Next;
            }
            Console.WriteLine("Can not find students with ID imported.");
        }

        float id;
        string name;
        float practiceScore;
        float theoreticalScore;
        float mediumScore;
        public void AddStudent()
        {
            Program program = new Program();
            bool done = true;

            do
            {
                Console.Clear();
                Console.WriteLine("ID: ");
                Console.SetCursorPosition(3, 0);
                try
                {
                    id = float.Parse(Console.ReadLine());
                }
                catch
                {
                    ErrorEndWithTimeout("Invalid information", 26, 6, 1500);
                    AddStudent();
                }

                Console.WriteLine("Name: ");
                name = Console.ReadLine() ?? "";

                Console.WriteLine("PracticeScore: ");
                try
                {
                    practiceScore = float.Parse(Console.ReadLine());
                }
                catch
                {
                    ErrorEndWithTimeout("Invalid information", 26, 6, 1500);
                    AddStudent();
                }

                Console.WriteLine("TheoreticalScore: ");
                try
                {
                    theoreticalScore = float.Parse(Console.ReadLine());
                }
                catch
                {
                    ErrorEndWithTimeout("Invalid information", 26, 6, 1500);
                    AddStudent();
                }
                if (practiceScore >= 0 && theoreticalScore >= 0 && theoreticalScore <= 10 && practiceScore <= 10)
                {
                    mediumScore = GPA(practiceScore, theoreticalScore);
                    Student newStudent = new Student(id, name, theoreticalScore, practiceScore, mediumScore);
                    students.AddLast(newStudent);
                    done = false;
                }
                else
                {
                    ErrorEndWithTimeout("Invalid information", 26, 6, 1500);
                    AddStudent();
                }
            } while (done);
            program.MainMenu();
        }

        public float GPA(float practiceScore, float theoreticalScore)
        {
            return (practiceScore + theoreticalScore) / 2;
        }
        private void EditStudent()
        {
            bool done = false;
            Console.Write("Enter the student's ID to correct: ");
            int id = Convert.ToInt32(Console.ReadLine());

            LinkedListNode<Student> currentNode = students.First;
            while (currentNode != null)
            {
                if (currentNode.Value._id == id)
                {
                    do
                    {

                        Console.Write("New name: ");
                        name = Console.ReadLine() ?? "";


                        Console.Write("New practiceScore: ");
                        try
                        {
                            practiceScore = float.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            ErrorEndWithTimeout("New invalid information", 26, 6, 1500);
                            EditStudent();
                        }

                        Console.Write("New theoreticalScore: ");
                        try
                        {
                            theoreticalScore = float.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            ErrorEndWithTimeout("Invalid information", 26, 6, 1500);
                            EditStudent();
                        }

                        if (practiceScore >= 0 && theoreticalScore >= 0 && theoreticalScore <= 10 && practiceScore <= 10)
                        {
                            mediumScore = GPA(practiceScore, theoreticalScore);
                            done = true;
                        }
                        else
                        {
                            ErrorEndWithTimeout("Invalid information", 26, 6, 1500);
                        }
                    } while (!done);
                    currentNode.Value._name = name;
                    currentNode.Value._practiceScore = practiceScore;
                    currentNode.Value._theoreticalScore = theoreticalScore;
                    currentNode.Value._mediumScore = mediumScore;

                    Console.WriteLine("Successful student information has been repaired.");
                    return;
                }
                else
                {
                    ErrorEndWithTimeout("Invalid information", 26, 6, 1500);
                }
                currentNode = currentNode.Next;
            }

            Console.WriteLine("Can't find students with ID imported.");
        }

        public void Processing()
        {
            bool done = false;
            do
            {
                Console.Clear();
            } while (!done);
        }

        public void MainMenu()
        {
            Program program = new Program();
            Console.Clear();
            Console.WriteLine("1.add");
            Console.WriteLine("2.edit");
            Console.WriteLine("3.delete");
            Console.WriteLine("4.show");
            try
            {
                chose = float.Parse(Console.ReadLine());
            }
            catch
            {
                ErrorEndWithTimeout("Invalid information", 26, 6, 1500);
                MainMenu();
            }
            switch (chose)
            {
                case 1:
                    program.AddStudent();
                    break;
                case 2:
                    program.EditStudent();
                    break;
                case 3:
                    program.DeleteStudent();
                    break;
                case 4:
                    program.DisplayStudents();
                    break;
            }
        }
        public void ErrorEndWithTimeout(string message, int left, int top, int timeout)
        {
            int count = message.Count() + 5;
            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(timeout);
            Console.SetCursorPosition(left, top);
            for (int i = 0; i < count; i++)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(left, top);
        }
        public static void Main()
        {
            Program program = new Program();

            do
            {
                program.MainMenu();
            } while (true);
        }
    }
}
