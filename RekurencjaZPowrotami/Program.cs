using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RekurencjaZPowrotami
{
    class Program
    {
        static int N;

        static void WypiszPlansze(int[,] plansza)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(plansza[i, j] + " ");
                }
                Console.Write("\n");
            }
        }
        static bool CzyUmiescicHetmana(int[,] plansza, int wiersz, int kolumna)
        {
            int i, j;
            for (i = 0; i < kolumna; i++)
            {
                if (plansza[wiersz, i] == 1) return false;
            }
            for (i = wiersz, j = kolumna; i >= 0 && j >= 0; i--, j--)
            {
                if (plansza[i, j] == 1) return false;
            }
            for (i = wiersz, j = kolumna; j >= 0 && i < N; i++, j--)
            {
                if (plansza[i, j] == 1) return false;
            }
            return true;
        }
        static bool SprawdzPlansze(int[,] plansza, int kolumna)
        {
            if (kolumna >= N) return true;
            for (int i = 0; i < N; i++)
            {
                if (CzyUmiescicHetmana(plansza, i, kolumna))
                {
                    plansza[i, kolumna] = 1;
                    if (SprawdzPlansze(plansza, kolumna + 1)) return true;
                    // Rekurencja z powrotami.  
                    plansza[i, kolumna] = 0;
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            //1. Zacznij w kolumnie najbardziej na lewo
            //2. Jeżeli wszystkie hetmany są ustawione zwróć true
            //3. Sprawdź wszystkie wiersze w bieżącej kolumnie. Wykonaj następujące czynności dla każdego wypróbowanego rzędu


            Console.WriteLine("Podaj ilość hetmanów: ");
            N = int.Parse(Console.ReadLine());
            
            int[,] plansza = new int[N, N];

            
            if (!SprawdzPlansze(plansza, 0))
            {
                Console.WriteLine("Nie znaleziono rozwiązania.");
            }
            WypiszPlansze(plansza);

            Console.ReadLine();
        }

    }

    //class Program
    //{
    //    static int N;

    //    static bool CzyDozwolone(bool[,] plansza, int x, int y)
    //    {
    //        for (int i = 0; i <= x; i++)
    //        {
    //            if (plansza[i, y] || (i <= y && plansza[x - i, y - i]) || (y + i < N && plansza[x - i, y + i]))
    //            {
    //                return false;
    //            }
    //        }
    //        return true;
    //    }

    //    static bool ZnajdzRozwiazanie(bool[,] plansza, int x)
    //    {
    //        for (int i = 0; i < N; i++)
    //        {
    //            if (CzyDozwolone(plansza, x, i))
    //            {
    //                plansza[x, i] = true;
    //                if (x == N - 1 || ZnajdzRozwiazanie(plansza, x + 1))
    //                {
    //                    return true;
    //                }
    //                plansza[x, i] = false;
    //            }
    //        }
    //        return false;
    //    }

    //    static void Main(string[] args)
    //    {
    //        System.Console.Write("Podaj ilość hetmanów: ");
    //        N = int.Parse(System.Console.ReadLine());

    //        bool[,] plansza = new bool[N, N];

    //        if (ZnajdzRozwiazanie(plansza, 0))
    //        {
    //            for (int i = 0; i < N; i++)
    //            {
    //                for (int j = 0; j < N; j++)
    //                {
    //                    Console.Write(plansza[i, j] ? "|1" : "| ");
    //                }
    //                Console.WriteLine("|");
    //            }
    //        }
    //        else
    //        {
    //            Console.WriteLine("Nie znaleziono rozwiązania dla n = " + N + ".");
    //        }

    //        Console.ReadKey(true);
    //    }
    //}
}
