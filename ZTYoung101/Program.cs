using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTYoung101
{
    class Program
    {
        static void Main(string[] args)
        {
            char array = 'n';
            Random r = new Random();
            while (array == 'n')
            {
                int i = r.Next(10);

                Console.WriteLine("Загаданное число N >= 0 & N <= 10");
                Console.WriteLine("Введите число");

                int x = Convert.ToInt32(Console.ReadLine());
                if (i == x)
                    Console.WriteLine("Вы угадали");
                else
                    Console.WriteLine("Не угадали");

                Console.WriteLine("Еще хотите попробовайт? (n - да, m - неть)");
                array = Convert.ToChar(Console.ReadLine());
            }

        }
    }
}
