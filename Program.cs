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
        static string st = "";
        static int Time, Level, diem, dem =0;
        static bool kt = true, kt1;
        const int Length_Game = 150;
        const int TimeEasy = 25;
        const int TimeMedium = 22;
        const int TimeHard = 18;

        static void KhoiTao()
        {
            Console.WriteLine("Chon muc do (De, Trung Binh, Kho)");
            string st = Console.ReadLine();
            st = st.ToUpper();
            Level = (st == "DE") ? 10 : (st == "TRUNG BINH") ? 9 : 8;
            Time = (st == "DE") ? TimeEasy : (st == "TRUNG BINH") ? TimeMedium : TimeHard;
            Console.Clear();
            for (int i = 0; i <= 29; i++)
                for (int j = 0; j < 150; j++)
                    Array[i, j] = " ";
        }
        static void TaoThanhDung()
        {
            Console.SetCursorPosition(1, 30);
            for (int i = 1; i <= Length_Game; i++)
                Console.Write('_');
            Console.SetCursorPosition(1, 20);
            for (int i = 1; i <= Length_Game; i++)
                Console.Write('_');
            Console.SetCursorPosition(0, 0);
            for (int i = 1; i <= Length_Game; i++)
                Console.Write('*');
        }
        static void RoiChu()
        {
            Random rd = new Random();

            Thread t = new Thread(() =>
            {
                do
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    st = keyInfo.Key.ToString();
                    st = st.ToLower();
                    //st = Console.ReadLine();
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
            Thread t3 = new Thread(() =>
            {
                do
                {
                    if (kt == true)
                    {
                        string TextRd = Convert.ToString((char)rd.Next(97, 122));
                        int NumRd = rd.Next(0, Length_Game - 1);
                        if (Array[0, NumRd] == " ") Array[0, NumRd] = TextRd;
                        kt = false;
                    }
                } while (true);
            });
            t3.Start();
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
            Console.SetCursorPosition(155, 2);
            Console.Write("Diem: {0}", diem);
            Thread.Sleep(Time);
        }
        static void Push()
        {
            Random rd = new Random();
            kt1 = true;
            for (int i = 29; i >= 0; i--)
            {
                for (int j = 0; j <= 149; j++)
                {

                    if (Array[i, j] == st)
                    {
                        Array[i, j] = " ";
                        if (i >= 20) diem++;
                        if (i < 20) diem--;
                        if (dem % Level != 0) kt = true;
                    } 
                    else if (Array[i, j] != " " && i < 29)
                    {
                        Array[i + 1, j] = Array[i, j];
                        Array[i, j] = " ";
                        if (kt1 == true) dem = dem + 1;
                        kt1 = false;
                        if (dem % Level == 0) { kt = true; if (dem == 20 * Level && Level > 2) Level--; dem++;}
                    }
                    else if (i == 29 && Array[i,j] != " ") { Array[i, j] = " ";  diem--; }
                }
                Write();
            }
        }
        static void Main(string[] args)
        {
            KhoiTao();
            TaoThanhDung();
            RoiChu();
        }
    }
}
