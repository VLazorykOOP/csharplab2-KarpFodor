namespace Lab2CSharp
{
    using System;

    class Program
    {
        static void Main()
        {
            bool continueRunning = true;

            while (continueRunning)
            {
                Console.WriteLine("Виберiть завдання (1-4):");
                Console.WriteLine("1. Вивести на екран номери всiх елементiв, якi не дiляться на 7.");
                Console.WriteLine("2. Знайти мiнiмум з додатних елементiв.");
                Console.WriteLine("3. З'ясувати, чи є матриця симетричною вiдносно головної дiагоналi.");
                Console.WriteLine("4. Парнi стовпцi таблицi замiнити на вектор x.");

                char choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        task1();
                        break;
                    case '2':
                        task2();
                        break;
                    case '3':
                        task3();
                        break;
                    case '4':
                        task4();
                        break;
                    default:
                        Console.WriteLine("Неправильний вибiр.");
                        break;
                }

                Console.WriteLine("Бажаєте продовжити? (Y/N)");
                char continueChoice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                continueRunning = (continueChoice == 'Y' || continueChoice == 'y');
            }

            Console.WriteLine("Натиснiть будь-яку клавiшу, щоб вийти...");
            Console.ReadKey();
        }

        static void task1()
        {
            Console.WriteLine("Task1 !");

            Console.WriteLine("Виберiть тип масиву:");
            Console.WriteLine("1. Одновимiрний");
            Console.WriteLine("2. Двовимiрний");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Task1_OneDimensional();
                    break;
                case 2:
                    Task1_TwoDimensional();
                    break;
                default:
                    Console.WriteLine("Неправильний вибiр.");
                    break;
            }
        }

        static void Task1_OneDimensional()
        {
            Console.WriteLine("Введiть розмiрнiсть масиву:");
            int size = int.Parse(Console.ReadLine());

            int[] array = new int[size];

            Console.WriteLine("Введiть елементи масиву:");
            for (int i = 0; i < size; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Елементи масиву, якi не дiляться на 7:");
            for (int i = 0; i < size; i++)
            {
                if (array[i] % 7 != 0)
                {
                    Console.WriteLine(array[i]);
                }
            }
        }

        static void Task1_TwoDimensional()
        {
            Console.WriteLine("Введiть кiлькiсть рядкiв масиву:");
            int rows = int.Parse(Console.ReadLine());

            Console.WriteLine("Введiть кiлькiсть стовпцiв масиву:");
            int cols = int.Parse(Console.ReadLine());

            int[,] array = new int[rows, cols];

            Console.WriteLine("Введiть елементи масиву:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    array[i, j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("Елементи масиву, якi не дiляться на 7:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (array[i, j] % 7 != 0)
                    {
                        Console.WriteLine(array[i, j]);
                    }
                }
            }
        }

        static void task2()
        {
            Console.WriteLine("Task2 !");
            Console.WriteLine("Введiть розмiрність масиву:");
            int size = int.Parse(Console.ReadLine());

            double[] array = new double[size];

            Console.WriteLine("Введiть елементи масиву:");
            for (int i = 0; i < size; i++)
            {
                array[i] = double.Parse(Console.ReadLine());
            }

            double minPositive = FindMinPositive(array);

            if (minPositive == double.MaxValue)
            {
                Console.WriteLine("В масивi немає додатнiх чисел.");
            }
            else
            {
                Console.WriteLine("Мiнiмум з додатних елементiв: " + minPositive);
            }
        }


        static double FindMinPositive(double[] arr)
        {
            double minPositive = double.MaxValue;
            foreach (double num in arr)
            {
                if (num > 0 && num < minPositive)
                {
                    minPositive = num;
                }
            }
            return minPositive;
        }


        static void task3()
        {

            Console.WriteLine("Task3 !");
            Console.WriteLine("Введiть розмiрнiсть матрицi (n):");
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            Console.WriteLine("Введiть елементи матрицi:");

            // Введення елементів матриці
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("matrix[{0},{1}]: ", i, j);
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }

            // Перевірка на симетрію відносно головної діагоналі
            bool symmetric = true;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++) // Перевірка елементів над головною діагоналлю
                {
                    if (matrix[i, j] != matrix[j, i])
                    {
                        symmetric = false;
                        break;
                    }
                }
                if (!symmetric)
                {
                    break;
                }
            }

            // Виведення результату
            if (symmetric)
            {
                Console.WriteLine("Матриця є симетричною вiдносно головної дiагоналі.");
            }
            else
            {
                Console.WriteLine("Матриця не є симетричною вiдносно головної дiагоналi.");
            }
        }

        static void task4()
        {
            Console.WriteLine("Task4 !");

            Console.WriteLine("Введiть кiлькiсть рядкiв матриці (n):");
            int n = int.Parse(Console.ReadLine());

            int[][] matrix = new int[n][]; // Створення східчастого масиву

            // Введення елементів матриці
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введiть кiлькiсть елементiв у {i + 1}-му рядку:");
                int m = int.Parse(Console.ReadLine());
                matrix[i] = new int[m]; // Ініціалізація вкладеного масиву в кожному рядку

                Console.WriteLine($"Введiть елементи для {i + 1}-го рядку:");
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"matrix[{i}][{j}]: ");
                    matrix[i][j] = int.Parse(Console.ReadLine());
                }
            }

            // Заміна парних стовпців на вектор x
            int[] vectorX = new int[matrix[0].Length]; 

            Console.WriteLine("Введiть елементи вектора x:");

            for (int j = 0; j < vectorX.Length; j++)
            {
                Console.Write($"x[{j}]: ");
                vectorX[j] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (j % 2 == 0) // Перевіряємо, чи є стовпець парним
                    {
                        matrix[i][j] = vectorX[j]; // Заміна елементу на вектор x
                    }
                }
            }

            Console.WriteLine("Змiнена матриця:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}
