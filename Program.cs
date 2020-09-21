using System;
using System.Collections.Generic;
using System.IO;

namespace lotto2
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 feladat

            List<int> lottoSzamok52het = new List<int>();
            for (int i = 0; i < 5; i++)
            {
               Console.Write("Add meg az {0} hét lotto számait: ", i+1);
               lottoSzamok52het.Add(int.Parse(Console.ReadLine()));
            }

            // 2 feladat
            Console.WriteLine("");
            lottoSzamok52het.Sort();
            foreach (var item in lottoSzamok52het)
            {
                Console.Write(item + " ");
            }
            // 3. feladat

            Console.WriteLine("");
            Console.Write("Adj meg egy egész számot 1-51 között: ");
            int szam1_51kozott = int.Parse(Console.ReadLine());

            // 4 feladat

            int[,] beOlvasottLottoSzamok = new int[52, 5];
            StreamReader sr = new StreamReader("lottosz.dat");
            for (int i = 0; !sr.EndOfStream; i++)
            {
                string[] temp = sr.ReadLine().Split(" ");

                for (int j = 0; j < 5; j++)
                {
                    beOlvasottLottoSzamok[i, j] = int.Parse(temp[j]);
                }
            }

            sr.Close();

            Console.WriteLine("");
            for (int j = 0; j < 5; j++)
            {
                Console.Write(beOlvasottLottoSzamok[szam1_51kozott-1, j] + " ");
            }

            // 5. feladat

            int[] megszamolas = new int[91];

            for (int i = 0; i!=beOlvasottLottoSzamok.GetLength(0); i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    megszamolas[beOlvasottLottoSzamok[i, j]]++;
                }
            }

            Console.WriteLine("");
            HashSet<int> nemHuztakKi = new HashSet<int>();
            for (int i = 1; i < megszamolas.Length; i++)
            {
                if (megszamolas[i] == 0)
                {
                    Console.WriteLine("Van olyan szám amit egyszer sem huztak ki: " + i);
                    nemHuztakKi.Add(i);
                }
            }

            // 6. feladat

            int paratlan = 0;

            for (int i = 0; i != beOlvasottLottoSzamok.GetLength(0); i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (beOlvasottLottoSzamok[i, j] % 2 != 0)
                    {
                        paratlan++;
                    }
                  
                }
            }

            Console.WriteLine("Ennyiszer volt páratlan szám kihúzva: " + paratlan);

            // 7. feladat

            for (int i = 0; i < 5; i++)
            {
                beOlvasottLottoSzamok[51, i] = lottoSzamok52het[i];
            }

            StreamWriter sw = new StreamWriter("lotto52.ki");

            for (int i = 0; i < 52; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                   sw.Write(beOlvasottLottoSzamok[i,j] + " ");
                }
                sw.WriteLine();
            }

            sw.Flush();
            sw.Close();

            // 8. feladat
            
              for (int j = 0; j < 5; j++)
                {
                    megszamolas[beOlvasottLottoSzamok[51, j]]++;
                }
            


            int ujSorTemp = 0;
            for (int i = 1; i < megszamolas.Length ; i++)
            {
                Console.Write(megszamolas[i] + "   ");
                ujSorTemp++;
                if (ujSorTemp==15)
                {
                    Console.WriteLine("");
                    ujSorTemp = 0;
                }
            }

            // 9. feladat.

            HashSet<int> prim = new HashSet<int>();
            for (int i = 2; i < 90; i++)
            {
            bool ezprim = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        ezprim = false;
                    }
                }

                if(ezprim==true)
                {
                    prim.Add(i);
                }
            }

            nemHuztakKi.IntersectWith(prim);
            foreach (int item in nemHuztakKi)
            {
                Console.WriteLine("Ezeket a prímeket nem huztak ki: " + item);
            }
           
        }
    }
}
