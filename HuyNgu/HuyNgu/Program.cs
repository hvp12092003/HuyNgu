using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            try
            {
                id = float.Parse(Console.ReadLine());
            }
            catch
            {
                ErrorEndWithTimeout("Invalid information", 26, 6, 1500);
            }

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
                    ErrorEndWithTimeout("Invalid information", 26, 6, 1500);
                }
                Console.SetCursorPosition(0, 18);
                Console.WriteLine("                                  ╔══════════════════════════════════╗");
                Console.WriteLine("                                  ║ NEW NAME:                        ║");
                Console.WriteLine("                                  ╠══════════════════════════════════╣");
                Console.WriteLine("                                  ║ NEW PRACTICESORE:                ║");
                Console.WriteLine("                                  ╠══════════════════════════════════╣");
                Console.WriteLine("                                  ║ NEW THEORETICALSCORE:            ║");
                Console.WriteLine("                                  ╚══════════════════════════════════╝");
                LinkedListNode<Student> currentNode = students.First;
                while (currentNode != null)
                {
                    if (currentNode.Value._id == id)
                    {
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
                                ErrorEndWithTimeout(" Invalid information", 26, 6, 1500);
                                EditStudent();
                            }

                            Console.SetCursorPosition(58, 23);
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
            } while (!done);
        }

        public void Processing()
        {
            bool done = false;
            float count = 1;
            do
            {
                count++;
                Console.Clear();
                Console.SetCursorPosition(0, 7);
                Console.WriteLine("                            ██████╗ ██████╗  ██████╗  ██████╗ ██████╗  █████╗ ███╗   ███╗");
                Console.WriteLine("                            ██╔══██╗██╔══██╗██╔═══██╗██╔════╝ ██╔══██╗██╔══██╗████╗ ████║");
                Console.WriteLine("                            ██████╔╝██████╔╝██║   ██║██║  ███╗██████╔╝███████║██╔████╔██║");
                Console.WriteLine("                            ██╔═══╝ ██╔══██╗██║   ██║██║   ██║██╔══██╗██╔══██║██║╚██╔╝██║");
                Console.WriteLine("                            ██║     ██║  ██║╚██████╔╝╚██████╔╝██║  ██║██║  ██║██║ ╚═╝ ██║");
                Console.WriteLine("                            ╚═╝     ╚═╝  ╚═╝ ╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝     ╚═╝");
                Console.SetCursorPosition(0, 11);
                Console.WriteLine("                    ╔══════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("                    ║                                                                                  ║");
                Console.WriteLine("                    ╚══════════════════════════════════════════════════════════════════════════════════╝");
                Console.SetCursorPosition(21, 12);
                for (int i = 0; i <= count; i++)
                {
                    Console.Write("█");
                }
                if (count >= 81) done = true;
                Thread.Sleep(50);
            } while (!done);
        }

        public void MainMenu()
        {
            // Program program = new Program();

            // Processing();

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
