using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание7
{
    class Program
    {
        public static int Imput()//Ввод целых чисел
        {
            bool rightValue;
            int value;

            do
            {
                string userImput = Console.ReadLine();
                rightValue = int.TryParse(userImput, out value);
                if (!rightValue) Console.Write(@"Ожидалось целое число. Повторите ввод - ");
            }
            while (!rightValue);

            return value;
        } 

        public static string[] Sort(string[] str)//Сортировка пузырьком
        {
            string k;

            for (int i = 0; i < str.Length - 1; i++)
                for (int j = 0; j < str.Length - i - 1; j++)
                    if (String.Compare(str[j], str[j + 1]) > 0)
                    {
                        k = str[j + 1];
                        str[j + 1] = str[j];
                        str[j] = k;
                    }

            return str;
        }

        public static string[] Rec(string[] elemS, string[] newElemS)//Получение сочетаний из N по 2
        {
            int k = 0;
            string[] last = new string[elemS.Length * newElemS.Length]; 

            for (int i = 0; i < elemS.Length; i++)
            {
                for (int j = 0; j < newElemS.Length; j++)//Сочетания до текущего символад
                    if (!(newElemS[j].Contains(elemS[i])))
                    {
                        last[k] = elemS[i] + " " + newElemS[j];
                        k++;
                    }
            }

            Array.Resize(ref last, k);

            return last;
        }

        static void Main(string[] args)
        {
            Console.Write(@"Введите кол-во эл-ов, из которых будут составляться сочетания: ");
            int N = Imput();
            Console.Write(@"Введите кол-во эл-ов, по сколько будут составляться сочетания: ");
            int K = Imput();
            if (K <= N)
            {
                string[] elemS = new string[N];

                for (int i = 0; i < N; i++)
                {
                    Console.Write(@"Введите " + (i + 1) + " эл-т: ");
                    elemS[i] = Console.ReadLine();
                }
                 
                elemS = Sort(elemS);//Сортировка эл-ов

                for (int i = 0; i < elemS.Length; i++)
                    Console.WriteLine(elemS[i]);
                Console.WriteLine();

                string[] newElemS = elemS;

                for (int i = 2; i <= K; i++)//Создание сочетаний
                    newElemS = Rec(elemS, newElemS);


                for (int i = 0; i < newElemS.Length; i++)//Вывод рез-ов
                    Console.WriteLine(newElemS[i]);
                Console.WriteLine();
            }
            else
                Console.WriteLine("Таких сочетаний не существует");

            Console.ReadLine();
        }
    }
}
