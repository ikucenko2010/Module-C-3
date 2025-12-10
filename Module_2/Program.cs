using System;

class Program
{
    static void Main()
    {
        int[] A = new int[5];
        double[,] B = new double[3, 4];
        Random rand = new Random();

        Console.WriteLine("Введіть 5 цілих чисел для масиву A:");
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"A[{i}] = ");
            while (!int.TryParse(Console.ReadLine(), out A[i]))
            {
                Console.Write("Невірний формат. Введіть ціле число: ");
            }
        }

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                B[i, j] = Math.Round(rand.NextDouble() * 200 - 100, 2);
            }
        }

        Console.Write("\nМасив A: ");
        for (int i = 0; i < 5; i++)
        {
            Console.Write(A[i] + " ");
        }
        Console.WriteLine();

        Console.WriteLine("\nМасив B:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Console.Write($"{B[i, j],8:F2} ");
            }
            Console.WriteLine();
        }

        double min = double.MaxValue;
        double max = double.MinValue;
        double totalSum = 0;
        double totalProduct = 1;
        long sumEvenA = 0;
        double sumOddColumnsB = 0;

        foreach (int x in A)
        {
            double v = x;
            if (v < min) min = v;
            if (v > max) max = v;
            totalSum += v;
            totalProduct *= v;
            if (x % 2 == 0) sumEvenA += x;
        }

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                double v = B[i, j];
                if (v < min) min = v;
                if (v > max) max = v;
                totalSum += v;
                totalProduct *= v;
                if (j == 0 || j == 2) sumOddColumnsB += v;
            }
        }

        Console.WriteLine("\n--- Результати ---");
        Console.WriteLine($"Максимальний елемент: {max:F2}");
        Console.WriteLine($"Мінімальний елемент: {min:F2}");
        Console.WriteLine($"Загальна сума: {totalSum:F2}");
        Console.WriteLine($"Загальний добуток: {totalProduct:E3}");
        Console.WriteLine($"Сума парних елементів A: {sumEvenA}");
        Console.WriteLine($"Сума непарних стовпців B: {sumOddColumnsB:F2}");

        Console.ReadKey();
    }
}