using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace touch
{
    class Program
    {
        static string[,] Array = new string[30, 150];
        static string Level, st = "";
        static int Time;
        const int Length_Game = 150;
        const int TimeEasy = 300;
        const int TimeMedium = 150;
        const int TimeHard = 70;

        static void KhoiTao()
        {
            Console.WriteLine("Chon muc do (De, Trung Binh, Kho)");
            string st = Console.ReadLine();
            st = st.ToUpper();
            Level = (st == "DE") ? "easy" : (st == "TRUNG BINH") ? "medium" : "hard";
            Time = (st == "DE") ? TimeEasy : (st == "TRUNG BINH") ? TimeMedium : TimeHard;
            Console.Clear();
            for (int i = 0; i < 29; i++)
                for (int j = 0; j < 150; j++)
                    Array[i, j] = " ";
        }
        static void TaoThanhDung()
        {
            Console.SetCursorPosition(1, 30);
            for (int i = 1; i <= Length_Game; i++)
                Console.Write('_');
        }
        static void RoiChu()
        {
            Random rd = new Random();
 
            Thread t = new Thread(() =>
            {
                do
                {
                    st = Console.ReadLine();
                } while (true);
            });
            t.Start();

            Thread t2 = new Thread(() =>
            {

                do
                {
                    Push();
                } while (true);
            });
            t2.Start();      
        }
        static void Write()
        {
            Console.Clear();
            for (int i = 1; i <= 29; i++)
            {
                for (int j = 0; j < 150; j++)
                    Console.Write(Array[i, j]);
                Console.WriteLine();
            }
            TaoThanhDung();
            Thread.Sleep(Time);
        }
        static void Push()
        {
            Random rd = new Random();
            int n = 0, NumRd;
            do
            {
                int dem = 0;
                n++;
                if (n == 5) { dem = rd.Next(0, 2); n = 0; }
                if (dem > 0)
                {
                    NumRd = rd.Next(0, 149);
                    string TextRd = Convert.ToString((char)rd.Next(97, 122));
                    Array[0, NumRd] = TextRd;
                }
                for (int k = 29; k >= 0; k++)
                {
                    for (int j = 0; j <= 149; j++)
                    {
                        if (Array[k, j] == st) Array[k, j] = " ";
                        else if (Array[k, j] != " " && k < 29)
                        {
                            Array[k + 1, j] = Array[k, j];
                            Array[k, j] = " ";
                        }
                        else if (k == 29) Array[k, j] = " ";
                    }
                    Write();
                }
            } while (true);
        }
        static void Main(string[] args)
        {
            KhoiTao();
            TaoThanhDung();
            RoiChu();
        }
    }
}
