using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using Newtonsoft.Json;

namespace sem2lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Task1");
            Task1();
            Console.WriteLine(" ");

            Console.WriteLine("Task 2");
            Task2();
            Console.WriteLine(" ");

            Console.WriteLine("Task 3");
            Task3();
        }
    static int Task1()
        {
            List<int> elements = new List<int>();
            try
            {
                string path = "C:/lab1/lab1.txt";
                FileStream fs = new FileStream(path, FileMode.Open);
                StreamReader file = new StreamReader(fs);
              //  int line_count = 0;
                while(file.Peek() != -1)
                {
                    string line = file.ReadLine();
                   // Console.WriteLine($"{line.Length}");
                    elements.Add(line.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return 0;
            }

            foreach ( int element in elements)
            {
                Console.WriteLine(element);
            }
               return 1;
        }
        static void Task2()
        {

            Dictionary<int, string> dict = new Dictionary<int, string>
            {
                [2] = "hello",
                [3] = "hello1",
                [5] = "hello2",
            };

          int max_key = dict.Keys.Max();
          int min_key = dict.Keys.Min();
          string min_key_data = dict[max_key];
          string max_key_data = dict[min_key];
          dict.Remove(max_key);
          dict.Remove(min_key);
          dict.Add(max_key, min_key_data);
          dict.Add(min_key, max_key_data);

          string json = JsonConvert.SerializeObject(dict);

            try
            {
                string path = "lab1.json";
                File.WriteAllText(path, json);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            foreach (var element in dict)
            {
                Console.WriteLine(element.Value);
            }

        }
        static void Task3()
        {
            Console.WriteLine("Array");
            int size = 10;
           int[] array = new int[size];
            Random rand = new Random();
            for(int i=0; i< size; i++)
            {
                array[i] = rand.Next(-10, 100);
                Console.Write($"{array[i]}  ");
            }
            Console.WriteLine("");

          var ls = from p in array where p>0 && p>10 && p<100 orderby p select p;
            //array = ls.OrderBy(x=>x).ToArray();
            Console.WriteLine("Result");
            foreach ( var element in ls)
            {
                Console.Write($"{element}  ");
            }
        }
    }
}
