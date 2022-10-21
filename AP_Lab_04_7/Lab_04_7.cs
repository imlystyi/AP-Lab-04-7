// Lab_04_7.cs
// Якубовський Владислав
// Лабораторна робота № 4.7 
// Обчислення суми ряду Тейлора за допомогою ітераційних циклів та рекурентних співвідношень.
// Варіант 24
using System;

namespace AP_Lab_04_7
{
    internal class Lab_04_7
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Default;

            int n;

            double xInital, xFinal, dx, eps, a, R, sum;

            string[] varArray;

            Console.Write("Введіть змінні \"x початкове\", \"x кінцеве\", \"dx\" та \"eps\" по черзі через крапку з комою: ");

            varArray = Console.ReadLine().Split(';');

            xInital = Double.Parse(varArray[0].Replace('.', ','));
            xFinal = Double.Parse(varArray[1].Replace('.', ','));
            dx = Double.Parse(varArray[2].Replace('.', ','));
            eps = Double.Parse(varArray[3].Replace('.', ','));

            while (!(xInital > -1) || !(xFinal <= 1) || xInital > xFinal)
            {
                Console.Write("Помилка! \"x початкове\" повинно бути більшим за -1, а \"x кінцеве\" - меншим або дорівнювати 1.\n" +
                    "Введіть нові значення дли цих змінних по черзі через крапку з комою: ");

                varArray = Console.ReadLine().Split(';');

                xInital = Double.Parse(varArray[0].Replace('.', ',')); 
                xFinal = Double.Parse(varArray[1].Replace('.', ','));
            }            

            // Виведення "шапки таблиці"
            Console.WriteLine("+---------------+-----------------------+---------------+---------------+\n" +
                "|\tx\t|\tln(x + 1)\t|\tsum\t|\tn\t|\n" +
                "+---------------+-----------------------+---------------+---------------+");

            // Розрахунок значень та виведення основної частини таблиці
            for (double x = xInital; x <= xFinal; x += dx)
            {
                n = 1;

                a = x;
                sum = a;

                do
                {
                    R = -(x * n / (n + 1));
                    a *= R;
                    sum += a;

                    n++;
                } 
                while (Math.Abs(a) >= eps);

                Console.WriteLine($"|\t{x:0.####}\t|\t{Math.Log(x + 1):0.0000}\t\t|\t{sum:0.0000}\t|\t{n}\t|\n" +
                    $"+---------------+-----------------------+---------------+---------------+");
            }

            Console.ReadLine();
        }
    }
}