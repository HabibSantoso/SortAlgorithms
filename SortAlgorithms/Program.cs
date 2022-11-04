using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms
{
    class Program
    {
        private int[] arr = new int[20];
        private int cmp_count = 0;
        private int mov_count = 0;

        private int n;

        void input()
        {
            while (true)
            {
                Console.Write("Enter the number of element in the array : ");
                string s = Console.ReadLine();
                n = Int32.Parse(s);
                if (n <= 20)
                {
                    Console.WriteLine("");
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Masukan elemen array");
                    Console.WriteLine("----------------------------");

                    for (int i = 0; i < n; i++)
                    {
                        Console.Write("<" + (i + 1) + "> ");
                        string s1 = Console.ReadLine();
                        arr[i] = Int32.Parse(s1);
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("\nArray can have maximum 20 elements \n");
                }
            }
        }


        static void Main(string[] args)
        {
        }
    }
}
