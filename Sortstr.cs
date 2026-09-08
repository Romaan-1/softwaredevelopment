using System;
using System.Collections.Generic;

// Interface for sorting strategy
public interface ISortStrategy
{
    void Sort(List<int> list);
}

// Bubblesort class
public class BubbleSort : ISortStrategy
{
    public void Sort(List<int> list)
    {
        Console.WriteLine("[Алгоритм]: Виконується сортування бульбашкою...");
        int n = list.Count;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (list[j] > list[j + 1])
                {
                    int temp = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = temp;
                }
            }
        }
    }
}

// quicksort class
public class QuickSort : ISortStrategy
{
    public void Sort(List<int> list)
    {
        Console.WriteLine("[Алгоритм]: Виконується швидке сортування...");
        list.Sort();
    }
}

// Sorter class
public class Sorter
{
    private ISortStrategy _strategy;

    public void SetStrategy(ISortStrategy strategy)
    {
        _strategy = strategy;
        Console.WriteLine("[Система]: Стратегію успішно встановлено.");
    }

    public void Sort(List<int> list)
    {
        if (_strategy == null)
        {
            Console.WriteLine("[Помилка]: Алгоритм сортування не обрано!");
            return;
        }
        _strategy.Sort(list);
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var originalList = new List<int> { 3, 1, 2, 9, 5, 4 };
        Console.WriteLine("Початковий масив: " + string.Join(", ", originalList) + "\n");
        var sorter = new Sorter();
        var listForBubble = new List<int>(originalList);
        sorter.SetStrategy(new BubbleSort());
        sorter.Sort(listForBubble);
        Console.WriteLine("Результат: " + string.Join(", ", listForBubble) + "\n");
        var listForQuick = new List<int>(originalList);
        sorter.SetStrategy(new QuickSort());
        sorter.Sort(listForQuick);
        Console.WriteLine("Результат: " + string.Join(", ", listForQuick) + "\n");
        Console.WriteLine("Натисніть Enter для завершення...");
        Console.ReadLine();
    }
}