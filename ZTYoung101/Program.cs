using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTYoung101
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
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
            {
            */


            string[] rows = File.ReadAllLines("spells.2da");
            char[] splitter = new char[] { ' ' };


            for (int i = 3; i < rows.Length - 1; i++) 
            {
                string[] cols = rows[i].Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                if (cols.Length > 13 && cols[13] != "****")
                {
                    Console.WriteLine($"{cols[1]} {cols[9]}");
                }
            }

            var header = rows.Take(3); 
            string file = "Acid.2da"; 
            if (File.Exists(file)) 
                File.Delete(file); 
            File.AppendAllLines(file, header);

            var headerCols = header.Last().Split(splitter, StringSplitOptions.RemoveEmptyEntries).ToList();
            int immunityTypeIndex = headerCols.IndexOf("ImmunityType") + 1;
            for (int i = 3; i < rows.Length; i++)
            {
                string[] cols = rows[i].Split(splitter, StringSplitOptions.RemoveEmptyEntries); 
                if (cols.Length > immunityTypeIndex && cols[immunityTypeIndex] == "Acid") 
                    File.AppendAllText(file, rows[i] + "\n"); 
            }

            CreateFileFilterByColumn(rows, 10, "Bard.2da");
            CreateFileFilterByColumn(rows, 11, "Cleric.2da");
            CreateFileFilterByColumn(rows, 12, "Druid.2da");
            CreateFileFilterByColumn(rows, 13, "Paladin.2da");
            CreateFileFilterByColumn(rows, 14, "Ranger.2da");
            CreateFileFilterByColumn(rows, 15, "Wiz_Sorc.2da");

        }

        static void CreateFileFilterByColumn(string[] rowsFile, int indexClass, string fileName)
        {
            List<string> newFileData = new List<string>();
            var header = rowsFile.Take(3);
            newFileData.AddRange(header); 
            char[] splitter = new char[] { ' ' };
            for (int i = 3; i < rowsFile.Length; i++)
            {
                var cols = rowsFile[i].Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                if (cols.Length > indexClass && cols[indexClass] != "****")
                    newFileData.Add(rowsFile[i]); 
            }

            File.WriteAllLines(fileName, newFileData);
        }
    }
}

