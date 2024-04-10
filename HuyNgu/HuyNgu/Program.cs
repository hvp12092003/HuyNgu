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
            Console.Clear();
            Console.SetCursorPosition(0, 7);
            Console.WriteLine("          ███████╗████████╗██╗   ██╗██████╗ ███████╗███╗   ██╗████████╗    ██╗     ██╗███████╗████████╗");
            Console.WriteLine("          ██╔════╝╚══██╔══╝██║   ██║██╔══██╗██╔════╝████╗  ██║╚══██╔══╝    ██║     ██║██╔════╝╚══██╔══╝");
            Console.WriteLine("          ███████╗   ██║   ██║   ██║██║  ██║█████╗  ██╔██╗ ██║   ██║       ██║     ██║███████╗   ██║   ");
            Console.WriteLine("          ╚════██║   ██║   ██║   ██║██║  ██║██╔══╝  ██║╚██╗██║   ██║       ██║     ██║╚════██║   ██║   ");
            Console.WriteLine("          ███████║   ██║   ╚██████╔╝██████╔╝███████╗██║ ╚████║   ██║       ███████╗██║███████║   ██║   ");
            Console.WriteLine("          ╚══════╝   ╚═╝    ╚═════╝ ╚═════╝ ╚══════╝╚═╝  ╚═══╝   ╚═╝       ╚══════╝╚═╝╚══════╝   ╚═╝   ");

            Console.SetCursorPosition(0, 14);
            foreach (var student in students)
            {
                Console.WriteLine("  ╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine($"  ║  ID: {student._id,-5}║   Name: {student._name,-20}║   TheoreticalScore: {student._theoreticalScore,-5}║   PracticeScore: {student._practiceScore,-5}║   MediumScore: {student._mediumScore,-5}║");
                Console.WriteLine("  ╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
            }
            Console.ReadKey();
        }


        public void DeleteStudent()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 7);
            Console.WriteLine("                          ██████╗ ███████╗██╗     ███████╗██╗  ████████╗███████╗");
            Console.WriteLine("                          ██╔══██╗██╔════╝██║     ██╔════╝██║  ╚══██╔══╝██╔════╝");
            Console.WriteLine("                          ██║  ██║█████╗  ██║     █████╗  ██║     ██║   █████╗  ");
            Console.WriteLine("                          ██║  ██║██╔══╝  ██║     ██╔══╝  ██║     ██║   ██╔══╝  ");
            Console.WriteLine("                          ██████╔╝███████╗███████╗███████╗███████╗██║   ███████╗");
            Console.WriteLine("                          ╚═════╝ ╚══════╝╚══════╝╚══════╝╚══════╝╚═╝   ╚══════╝");
            Console.SetCursorPosition(0, 14);
            Console.WriteLine("                 ╔══════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("                 ║ Enter the student's ID to correct:                                   ║");
            Console.WriteLine("                 ╚══════════════════════════════════════════════════════════════════════╝");
            Console.SetCursorPosition(54, 15);
            try
            {
                id = float.Parse(Console.ReadLine());
            }
            catch
            {
                ErrorEndWithTimeout("Invalid information", 26, 17, 1500);
                return;
            }

            LinkedListNode<Student> currentNode = students.First;
            while (currentNode != null)
            {
                if (currentNode.Value._id == id)
                {
                    students.Remove(currentNode);
                    SuccessEndWithTimeout("Successful students have deleted", 28, 17, 1500);
                    return;
                }
                else
                {
                    ErrorEndWithTimeout("Student ID is not found!", 28, 17, 1500);
                }
                currentNode = currentNode.Next;
            }

        }

        float id;
        string name;
        float practiceScore;
        float theoreticalScore;
        float mediumScore;
        public void AddStudent()
        {
            bool done = true;

            do
            {
                Console.Clear();
                Console.SetCursorPosition(0, 5);
                Console.WriteLine("                █████╗ ██████╗ ██████╗     ███████╗████████╗██╗   ██╗██████╗ ███████╗███╗   ██╗████████╗");
                Console.WriteLine("               ██╔══██╗██╔══██╗██╔══██╗    ██╔════╝╚══██╔══╝██║   ██║██╔══██╗██╔════╝████╗  ██║╚══██╔══╝");
                Console.WriteLine("               ███████║██║  ██║██║  ██║    ███████╗   ██║   ██║   ██║██║  ██║█████╗  ██╔██╗ ██║   ██║  ");
                Console.WriteLine("               ██╔══██║██║  ██║██║  ██║    ╚════██║   ██║   ██║   ██║██║  ██║██╔══╝  ██║╚██╗██║   ██║   ");
                Console.WriteLine("               ██║  ██║██████╔╝██████╔╝    ███████║   ██║   ╚██████╔╝██████╔╝███████╗██║ ╚████║   ██║  ");
                Console.WriteLine("               ╚═╝  ╚═╝╚═════╝ ╚═════╝     ╚══════╝   ╚═╝    ╚═════╝ ╚═════╝ ╚══════╝╚═╝  ╚═══╝   ╚═╝   ");
                Console.SetCursorPosition(0, 14);
                Console.WriteLine("                                           ╔══════════════════════════════════╗");
                Console.WriteLine("                                           ║ ID:                              ║");
                Console.WriteLine("                                           ╠══════════════════════════════════╣");
                Console.WriteLine("                                           ║ NAME:                            ║");
                Console.WriteLine("                                           ╠══════════════════════════════════╣");
                Console.WriteLine("                                           ║ PRACTICESORE:                    ║");
                Console.WriteLine("                                           ╠══════════════════════════════════╣");
                Console.WriteLine("                                           ║ THEORETICALSCORE:                ║");
                Console.WriteLine("                                           ╚══════════════════════════════════╝");
                Console.SetCursorPosition(51, 15);
                try
                {
                    id = float.Parse(Console.ReadLine());
                }
                catch
                {
                    ErrorEndWithTimeout("Invalid information", 26, 6, 1500);
                    AddStudent();
                }

                Console.SetCursorPosition(53, 17);
                name = Console.ReadLine() ?? "";

                Console.SetCursorPosition(61, 19);
                try
                {
                    practiceScore = float.Parse(Console.ReadLine());
                }
                catch
                {
                    ErrorEndWithTimeout("Invalid information", 26, 6, 1500);
                    AddStudent();
                }

                Console.SetCursorPosition(65, 21);
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
            MainMenu();
        }

        public float GPA(float practiceScore, float theoreticalScore)
        {
            return (practiceScore + theoreticalScore) / 2;
        }
        private void EditStudent()
        {
            bool done = false;
            do
            {
                Console.Clear();
                Console.SetCursorPosition(0, 7);
                Console.WriteLine("                            ███████╗██████╗ ██╗████████╗██╗███╗   ██╗ ██████╗ ");
                Console.WriteLine("                            ██╔════╝██╔══██╗██║╚══██╔══╝██║████╗  ██║██╔════╝ ");
                Console.WriteLine("                            █████╗  ██║  ██║██║   ██║   ██║██╔██╗ ██║██║  ███╗");
                Console.WriteLine("                            ██╔══╝  ██║  ██║██║   ██║   ██║██║╚██╗██║██║   ██║");
                Console.WriteLine("                            ███████╗██████╔╝██║   ██║   ██║██║ ╚████║╚██████╔╝");
                Console.WriteLine("                            ╚══════╝╚═════╝ ╚═╝   ╚═╝   ╚═╝╚═╝  ╚═══╝ ╚═════╝ ");
                Console.SetCursorPosition(0, 14);
                Console.WriteLine("                 ╔══════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("                 ║ Enter the student's ID to correct:                                   ║");
                Console.WriteLine("                 ╚══════════════════════════════════════════════════════════════════════╝");
                Console.SetCursorPosition(54, 15);
                try
                {
                    id = float.Parse(Console.ReadLine());
                }
                catch
                {
                    ErrorEndWithTimeout("Invalid information", 26, 17, 1500);
                    return;
                }
                LinkedListNode<Student> currentNode = students.First;
                while (currentNode != null)
                {
                    if (currentNode.Value._id == id)
                    {
                        Console.SetCursorPosition(0, 18);
                        Console.WriteLine("                                  ╔══════════════════════════════════╗");
                        Console.WriteLine("                                  ║ NEW NAME:                        ║");
                        Console.WriteLine("                                  ╠══════════════════════════════════╣");
                        Console.WriteLine("                                  ║ NEW PRACTICESORE:                ║");
                        Console.WriteLine("                                  ╠══════════════════════════════════╣");
                        Console.WriteLine("                                  ║ NEW THEORETICALSCORE:            ║");
                        Console.WriteLine("                                  ╚══════════════════════════════════╝");
                        do
                        {
                            Console.SetCursorPosition(46, 19);
                            name = Console.ReadLine() ?? "";


                            Console.SetCursorPosition(54, 21);
                            try
                            {
                                practiceScore = float.Parse(Console.ReadLine());
                            }
                            catch
                            {
                                ErrorEndWithTimeout("Invalid information", 35, 25, 1500);
                                return;
                            }

                            Console.SetCursorPosition(58, 23);
                            try
                            {
                                theoreticalScore = float.Parse(Console.ReadLine());
                            }
                            catch
                            {
                                ErrorEndWithTimeout("Invalid information", 35, 25, 1500);
                                return;
                            }

                            if (practiceScore >= 0 && theoreticalScore >= 0 && theoreticalScore <= 10 && practiceScore <= 10)
                            {
                                mediumScore = GPA(practiceScore, theoreticalScore);
                                done = true;
                            }
                            else
                            {
                                ErrorEndWithTimeout("Invalid score", 35, 25, 1500);
                                return;
                            }
                        } while (!done);
                        currentNode.Value._name = name;
                        currentNode.Value._practiceScore = practiceScore;
                        currentNode.Value._theoreticalScore = theoreticalScore;
                        currentNode.Value._mediumScore = mediumScore;
                        SuccessEndWithTimeout("Successful student information has been repaired", 26, 6, 1500);
                        return;
                    }
                    currentNode = currentNode.Next;
                }
                ErrorEndWithTimeout("Can't find students with ID imported", 26, 17, 1500);
                return;
            } while (!done);
        }

        public void Processing()
        {
            bool done = false;
            float count = 1;

            count++;
            Console.Clear();
            Console.SetCursorPosition(0, 7);
            Console.WriteLine("                            ██████╗ ██████╗  ██████╗  ██████╗ ██████╗  █████╗ ███╗   ███╗");
            Console.WriteLine("                            ██╔══██╗██╔══██╗██╔═══██╗██╔════╝ ██╔══██╗██╔══██╗████╗ ████║");
            Console.WriteLine("                            ██████╔╝██████╔╝██║   ██║██║  ███╗██████╔╝███████║██╔████╔██║");
            Console.WriteLine("                            ██╔═══╝ ██╔══██╗██║   ██║██║   ██║██╔══██╗██╔══██║██║╚██╔╝██║");
            Console.WriteLine("                            ██║     ██║  ██║╚██████╔╝╚██████╔╝██║  ██║██║  ██║██║ ╚═╝ ██║");
            Console.WriteLine("                            ╚═╝     ╚═╝  ╚═╝ ╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝     ╚═╝");
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("                    ╔══════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("                    ║                                                                                  ║");
            Console.WriteLine("                    ╚══════════════════════════════════════════════════════════════════════════════════╝");
            Console.SetCursorPosition(21, 16);
            for (int i = 0; i <= 81; i++)
            {
                Console.Write("█");
                Thread.Sleep(25);
                if (i == 70) Thread.Sleep(1500);
                if (i == 40) Thread.Sleep(1500);
            }
        }

        public void MainMenu()
        {

            Console.Clear();
            Console.SetCursorPosition(0, 7);
            Console.WriteLine("               ███╗   ███╗ █████╗ ███╗   ██╗ █████╗  ██████╗ ███████╗███╗   ███╗███████╗███╗   ██╗████████╗  ");
            Console.WriteLine("               ████╗ ████║██╔══██╗████╗  ██║██╔══██╗██╔════╝ ██╔════╝████╗ ████║██╔════╝████╗  ██║╚══██╔══╝  ");
            Console.WriteLine("               ██╔████╔██║███████║██╔██╗ ██║███████║██║  ███╗█████╗  ██╔████╔██║█████╗  ██╔██╗ ██║   ██║     ");
            Console.WriteLine("               ██║╚██╔╝██║██╔══██║██║╚██╗██║██╔══██║██║   ██║██╔══╝  ██║╚██╔╝██║██╔══╝  ██║╚██╗██║   ██║     ");
            Console.WriteLine("               ██║ ╚═╝ ██║██║  ██║██║ ╚████║██║  ██║╚██████╔╝███████╗██║ ╚═╝ ██║███████╗██║ ╚████║   ██║     ");
            Console.WriteLine("               ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚═╝     ╚═╝╚══════╝╚═╝  ╚═══╝   ╚═╝     ");
            Console.SetCursorPosition(0, 14);
            Console.WriteLine("                                       ╔══════════════════════════════════╗");
            Console.WriteLine("                                       ║ 1. ADD STUDENT                   ║");
            Console.WriteLine("                                       ╠══════════════════════════════════╣");
            Console.WriteLine("                                       ║ 2. STUDENT INFORMATION EDITING   ║");
            Console.WriteLine("                                       ╠══════════════════════════════════╣");
            Console.WriteLine("                                       ║ 3. DELETE STUDENT INFORMATION    ║");
            Console.WriteLine("                                       ╠══════════════════════════════════╣");
            Console.WriteLine("                                       ║ 4. DISPLAY STUDENTS INFORMATION  ║");
            Console.WriteLine("                                       ╚══════════════════════════════════╝");
            Console.WriteLine("                                       ╔══════════════════════════════════╗");
            Console.WriteLine("                                       ║ YOU CHOOSE:                      ║");
            Console.WriteLine("                                       ╚══════════════════════════════════╝");
            Console.SetCursorPosition(52, 24);
            try
            {
                chose = float.Parse(Console.ReadLine());
            }
            catch
            {
                ErrorEndWithTimeout("Invalid information", 44, 26, 1500);
            }
            switch (chose)
            {
                case 1:
                    AddStudent();
                    break;
                case 2:
                    if (students.Count > 0) EditStudent();
                    else ErrorEndWithTimeout("No students in the list", 44, 26, 1500);
                    break;
                case 3:
                    if (students.Count > 0) DeleteStudent();
                    else ErrorEndWithTimeout("No students in the list", 44, 26, 1500);
                    break;
                case 4:
                    if (students.Count > 0) DisplayStudents();
                    else ErrorEndWithTimeout("No students in the list", 44, 26, 1500);
                    break;
                default:
                    ErrorEndWithTimeout("Invalid information", 44, 26, 1500);
                    break;
            }
        }
        public void SuccessEndWithTimeout(string message, int left, int top, int timeout)
        {
            int count = message.Count() + 5;
            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = ConsoleColor.Green;
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
            program.Processing();
            Student newStudent = new Student(1, "1", 1, 1, 1);
            students.AddLast(newStudent);
            do
            {
                program.MainMenu();
            } while (true);
        }
    }

}
