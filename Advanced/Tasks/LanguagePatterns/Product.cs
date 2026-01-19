namespace Advanced.Tasks.LanguagePatterns;

/// <summary>
/// Задание 4.2: Класс Product с init-only свойствами.
/// </summary>
public class Product
{
    public string Name { get; init; }
    public decimal Price { get; init; }
    public int Stock { get; init; }
}