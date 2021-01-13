using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    class Program
    {
        //public delegate bool Check(int n);
        //public delegate void Print(string s);
        //public delegate void Print1(int s);
        //public delegate void Print2(bool s);
        //public delegate void Print<T>(T item);
        //public delegate int Calculate(int n1, int n2);
        //public delegate int Calculate1(string n1, string n2);
        //public delegate int Calculate<T1,T2>(T1 n1, T2 n2);
        //public delegate string Calculate1<T1,T2>(T1 n1, T2 n2);
        //public delegate bool Calculate2<T1,T2>(T1 n1, T2 n2);
        //public delegate TResult Calculate<in T1,in T2,out TResult>(T1 n1, T2 n2);
        static void Main(string[] args)
        {
            #region Delegate
            //int[] arr = { 1, 2, 3, 4, 5 };
            //Console.WriteLine(SumOdd(arr));
            //Console.WriteLine(SumEven(arr));
            //Console.WriteLine(SumElder(arr));
            //Console.WriteLine(Sum(arr,IsOdd));
            //Console.WriteLine(Sum(arr,IsEven));
            //Console.WriteLine(Sum(arr, n=>n>3));
            #region Anonimouse function,lambda expression
            //Print print = new Print(GetString);
            //Print print = GetString;
            //print += GetStrLength;
            //print += delegate (string s)
            //  {
            //      Console.WriteLine($"String last index: {s[s.Length-1]}");
            //  };
            //print += s => Console.WriteLine($"String[0]: {s[0]}");
            //print -= GetStrLength;

            //print -= s => Console.WriteLine($"String[0]: {s[0]}");

            //print("Mehemmedeli");
            //print.Invoke("Mehemmedeli");

            //Calculate calculate = (n1, n2) => n1 * n2;
            #endregion

            #region Generic type delegate
            //Print<string> printStr = GetString;
            //Print<int> printInt = n => Console.WriteLine(n);
            //Calculate<int, int, double> calculate = (n1, n2) => n1 / n2;
            //Console.WriteLine(calculate(9,5));
            #endregion

            #region Action,Func,Predecate
            //Action<string> action = GetString;
            //action("Kenan");

            //Action<string, int> action1 = (s, n) => Console.WriteLine($"{s+n}");
            //action1("Kenan", 99);

            //Func<string> func = () => "Hello World";
            //Console.WriteLine(func());

            //Func<int,int,double> func1= (n1, n2) => (double)n1 / (double)n2;
            //Console.WriteLine(func1(9,5));

            //Predicate<int> predicate = delegate (int n)
            //  {
            //      return n > 10;
            //  };

            //List<int> list = new List<int>();
            //list.Add(1);
            //list.Add(10);
            //list.Add(100);
            //list.Add(100);
            //Console.WriteLine(list.Find(n => n % 10==0));
            //Console.WriteLine(CustomFind(n => n == 1000, list));
            #endregion
            #endregion

            #region Events
            Student s1 = new Student("Mehemmedeli", 95);
            Student s2 = new Student("Tural", 65);

            s1.Notify += score =>
            {
                if (score >= 65)
                {
                    Console.WriteLine("Tebrikler");
                    return;
                }
                Console.WriteLine("Teessufler");
            };

            s2.Notify += score =>
            {
                if (score >= 65)
                {
                    Console.WriteLine("Tebrikler,senden bir denedi.Diplomunu qizildan edeceyik");
                    return;
                }
                Console.WriteLine("Biz sene layiq deyildik");
            };

            s1.SendMessage();
            s2.SendMessage();
            #endregion
        }

        #region Delegate

        static int CustomFind(Predicate<int> func,List<int> list)
        {
            foreach (int item in list)
            {
                if (func(item)) return item;
            }
            return 0;
        }
        static void GetString(string s)
        {
            Console.WriteLine($"String: {s}");
        }

        static void GetStrLength(string s)
        {
            Console.WriteLine($"String length: {s.Length.ToString()}");
        }

        static int Sum(int[] arr, Predicate<int> func)
        {
            int result = 0;
            foreach (int item in arr)
            {
                if (func(item))
                    result += item;
            }
            return result;
        }

        static bool IsOdd(int n)
        {
            return n % 2 != 0;
        }

        static bool IsEven(int n)
        {
            return n % 2 == 0;
        }

        static bool IsElder(int n)
        {
            return n > 3;
        }
        #endregion
    }

    #region Events
    class Student
    {
        public string Name { get; set; }
        private readonly int _score;
        public event Action<int> Notify;
        public Student(string name,int score)
        {
            Name = name;
            _score = score;
        }

        public void SendMessage()
        {
            Notify(_score);
            //if (_score >= 65)
            //{
            //    Console.WriteLine("Tebrikler");
            //    return;
            //}
            //Console.WriteLine("Teessuf, keche bilmediniz");
        }
    }
    #endregion
}
