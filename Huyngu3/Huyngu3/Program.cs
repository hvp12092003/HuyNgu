using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Huyngu3
{
    class Program
    {
        static int TimUSCLN(int a, int b)//<= ham de quy
        {
            if (b == 0)
                return a;
            return TimUSCLN(b, a % b);
        }

        static int BoiSoChungNhoNhat(int a, int b)
        {
            int uscln = TimUSCLN(a, b);
            return (a * b) / uscln;
        }

        public int NhapSoNguyenDuong(string message)
        {
            int num;
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out num) && num > 0)
                    return num;

                Console.Clear(); // Xóa màn hình để nhập lại từ đầu
                ErrorEndWithTimeout("Số không hợp lệ. Vui lòng nhập lại.", 5, 5, 1500);
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
            Console.SetCursorPosition(0, 0);
        }

        public void Menu()
        {
            do
            {
                int so1, so2;
                Console.Clear();
                Console.SetCursorPosition(0, 0);

                while (true)
                {
                    // Nhập số nguyên dương thứ nhất
                    so1 = NhapSoNguyenDuong("Nhập số nguyên dương thứ nhất: ");
                    if (so1 > 0)
                        break; // Nếu nhập đúng, thoát vòng lặp

                    Console.Clear(); // Xóa màn hình để nhập lại từ đầu
                }

                while (true)
                {
                    // Nhập số nguyên dương thứ hai
                    so2 = NhapSoNguyenDuong("Nhập số nguyên dương thứ hai: ");
                    if (so2 > 0)
                        break; // Nếu nhập đúng, thoát vòng lặp

                    Console.Clear(); // Xóa màn hình để nhập lại từ đầu
                }

                // Tìm USCLN của hai số
                int uscln = TimUSCLN(so1, so2);
                Console.WriteLine($"USCLN của {so1} và {so2} là: {uscln}");

                // Tính bội số chung nhỏ nhất của hai số
                int boiSoChung = BoiSoChungNhoNhat(so1, so2);
                Console.WriteLine($"Bội số chung nhỏ nhất của {so1} và {so2} là: {boiSoChung}");
                Console.ReadKey();
                return;

            } while (true);
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            do
            {
                program.Menu();
            } while (true);
        }
    }
}
