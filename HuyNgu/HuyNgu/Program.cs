using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HuyNgu
{
    public class Student
    {
        public float _id { get; set; }
        public string _name { get; set; }
        public float _theoreticalScore { get; set; }
        public float _practiceScore { get; set; }
        public float _mediumScore { get; set; }

    }
    public class Program
    {
        float chose;
        List<Student> studentList = new List<Student>();


        public void ShowStudentList(List<Student> studentList)
        {
            Console.Clear();
            for (int i = 0; i < studentList.Count; i++)
            {
                Console.WriteLine("================= ");
                Console.Write("ID: " + studentList[i]._id + " ");
                Console.Write("Name: " + studentList[i]._name + " ");
                Console.Write("practiceScore: " + studentList[i]._practiceScore + " ");
                Console.Write("theoreticalScore: " + studentList[i]._theoreticalScore + " ");
                Console.WriteLine("GPA: " + studentList[i]._mediumScore + " ");
            }
            Console.ReadKey();
        }

        public void FindStudent(List<Student> studentList)
        {
            Console.Clear();
            Console.Write("ID student wants to delete: ");
            float id = float.Parse(Console.ReadLine());

            studentList.Find(x => x._id == id);
        }

        public void DeleteStudent(List<Student> studentList)
        {
            Console.Clear();
        }

        public void AddStudent(List<Student> studentList)
        {
            Student newStudent = new Student();
            Program program = new Program();
            bool done = true;
            string id;
            string name;
            string practiceScore;
            string theoreticalScore;

            do
            {
                Console.Clear();
                Console.WriteLine("ID: ");
                Console.SetCursorPosition(3, 0);
                id = Console.ReadLine() ?? "";
                try
                {
                    newStudent._id = float.Parse(id);
                }
                catch
                {
                    ErrorEndWithTimeout("Invalid information", 26, 6, 1500);
                    AddStudent(studentList);
                }

                Console.WriteLine("Name: ");
                newStudent._name = Console.ReadLine() ?? "";

                Console.WriteLine("practiceScore: ");
                practiceScore = Console.ReadLine() ?? "";
                try
                {
                    newStudent._practiceScore = float.Parse(practiceScore);
                }
                catch
                {
                    ErrorEndWithTimeout("Invalid information", 26, 6, 1500);
                    AddStudent(studentList);
                }

                Console.WriteLine("theoreticalScore: ");
                theoreticalScore = Console.ReadLine() ?? "";
                try
                {
                    newStudent._theoreticalScore = float.Parse(theoreticalScore);
                }
                catch
                {
                    ErrorEndWithTimeout("Invalid information", 26, 6, 1500);
                    AddStudent(studentList);
                }

                if (newStudent._practiceScore >= 0 && newStudent._theoreticalScore >= 0 && newStudent._theoreticalScore <= 10 && newStudent._practiceScore <= 10)
                {
                    newStudent._mediumScore = GPA(newStudent._practiceScore, newStudent._theoreticalScore);
                    studentList.Add(newStudent);
                    done = false;
                }
                else
                {
                    ErrorEndWithTimeout("Invalid information", 26, 6, 1500);
                    AddStudent(studentList);
                }
            } while (done);

            program.MainMenu();
        }

        public float GPA(float practiceScore, float theoreticalScore)
        {
            return (practiceScore + theoreticalScore) / 2;
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
                    program.AddStudent(studentList);
                    break;
                case 2:
                    program.EditStudent(studentList);
                    break;
                case 3:
                    program.DeleteStudent(studentList);
                    break;
                case 4:
                    program.ShowStudentList(studentList);
                    break;
            }
        }

        private void EditStudent(List<Student> studentList)
        {
            Console.WriteLine("EditStudent");
            Console.ReadKey();
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

            program.MainMenu();

            Console.ReadLine();

        }
    }
}
