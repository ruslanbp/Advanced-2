namespace Advanced.Tasks;

public class PerformanceTasks
{
    /// <summary>
    /// Задание 3.1: Напишите метод, который реверсирует массив using Span.
    /// </summary>
    public void ReverseArray<T>(T[] array)
    {
        array.AsSpan().Reverse();
    }

    /// <summary>
    /// Задание 3.2: Напишите метод, который суммирует элементы массива using Span.
    /// </summary>
    public int SumArray(Span<int> span)
    {
        int sum = 0;
        
        foreach (int item in span)
        {
            sum += item;
        }

        return sum;
    }

    /// <summary>
    /// Задание 3.3: Напишите метод, который демонстрирует boxing/unboxing.
    /// </summary>
    public object BoxValue(int value)
    {
        return value;
    }

    public int UnboxValue(object value)
    {
        return (int)value;
    }
}