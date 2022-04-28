using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace Zadanie1_Przedziały
{
    class Program
    {
        static void Main(string[] args)
        {       
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            StreamReader file = new StreamReader("in_maly.txt");
            List<Set> sets = new List<Set>();

            int sets_count = Convert.ToInt32(file.ReadLine());
                     
            string data = file.ReadLine();

            while(data != null)
            {
                Set set = new Set();

                string[] values = data.Split(' ');
               
                set.Beginning = Int64.Parse(values[0]);
                set.End = Int64.Parse(values[1]);
                sets.Add(set);

                data = file.ReadLine();
            }

            sets = quick_sort(sets, 0, sets_count - 1);        

            int index = 1;

            List<Set> result = new List<Set>();
            
            result.Add(new Set(sets[0].Beginning, sets[0].End));

            var EndToCompare = result[result.Count - 1].End;

            while (sets.Count != index)
            {
                var next = sets[index];

                if (EndToCompare >= next.Beginning)
                {
                    if (EndToCompare < next.End)
                    {
                        result[result.Count - 1].End = next.End;
                    }
                }
                else
                {
                    result.Add(new Set(next.Beginning, next.End));
                }
                index++;
                EndToCompare = result[result.Count - 1].End;   
            }        

            using (StreamWriter streamWriter = new StreamWriter("out.txt"))
            {
                for(int i=0;i<result.Count;i++)
                {
                    streamWriter.WriteLine($"{result[i].Beginning} {result[i].End}");
                    Console.WriteLine($"{result[i].Beginning} {result[i].End}");
                }
            }
            stopwatch.Stop();
            Console.WriteLine($"Czas wykonania programu: {stopwatch.ElapsedMilliseconds} ms");
        }
        public static List<Set> quick_sort(List<Set> sets, int left, int right)
        {
            if (right <= left) return sets;

            int i = left - 1, j = right + 1;
            long pivot = sets[(left + right) / 2].Beginning;

            while (true)
            {
                while (pivot > sets[++i].Beginning) ;
                while (pivot < sets[--j].Beginning) ;

                if (i <= j)
                {
                    (sets[i].Beginning, sets[j].Beginning) = (sets[j].Beginning, sets[i].Beginning);
                    (sets[i].End, sets[j].End) = (sets[j].End, sets[i].End);
                }
                else break;
            }

            if (j > left)
                quick_sort(sets, left, j);
            if (i < right)
                quick_sort(sets, i, right);

            return sets;
        }
    }
}
