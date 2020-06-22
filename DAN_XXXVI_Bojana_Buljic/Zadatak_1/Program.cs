using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zadatak_1
{
    class Program
    {
        static int[,] matrix;
        static List<int> list = new List<int>(10000);
        //object to lock for Creating and filling matrix
        static readonly object locker = new object();
        //object to lock for writing/reading file
        static readonly object fileLocker = new object();
        //file path
        static string file = @"../../File.txt";
        static int[] oddNumbers;

        /// <summary>
        /// Method for creating 100x100 matrix
        /// </summary>
        /// <returns></returns>
        static void CreateMatrix()
        {
            lock (locker)
            {
                matrix = new int[100, 100];

                while (list.Count < 10000)
                {
                    Monitor.Wait(locker);
                }

                for (int i = 0; i < 100; i++)
                {
                    for (int j = 0; j < 100; j++)
                    {

                        matrix[i, j] = list[j + i * 100];

                    }
                }

            }

        }

        /// <summary>
        /// Method is Generating random numbers and adding it into list
        /// </summary>
        static void GenerateNumbers()
        {
            int number;
            Random rnd = new Random();
            lock (locker)
            {
                for (int i = 0; i < 10000; i++)
                {
                    number = rnd.Next(10, 100);
                    list.Add(number);
                }
                Monitor.Pulse(locker);
            }

        }

        static void Main(string[] args)
        {
        }
    }
}
