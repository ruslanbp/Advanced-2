namespace Advanced.Tasks.LanguagePatterns;

/// <summary>
/// Создавайте классы и рекорды в отдельном файле в папке LanguagePatterns
/// </summary>
public class LanguagePatternsTasks
{
    /// <summary>
    /// Задание 4.1: Создайте record Person с свойствами Name и Age.
    /// </summary>
    /// <summary>
    /// Задание 4.2: Создайте класс Product с init-only свойствами.
    /// </summary>
    /// <summary>
    /// Задание 4.3: Используйте pattern matching для определения типа объекта.
    /// </summary>
    public string GetObjectType(object obj)
    {
        return obj switch
        {
            null => "Null",
            string => "String",
            int => "Integer",
            bool => "Boolean",
            double => "Double",
            float => "Float",
            _ => "Unknown"
        };
    }

    /// <summary>
    /// Задание 4.4: Используйте switch expression для вычисления стоимости доставки.
    /// </summary>
    public decimal CalculateShippingCost(string shippingType, decimal weight)
    {
        return shippingType?.ToLowerInvariant() switch
        {
            "standard" => 10m,
            "express" => 20.0m + weight * 0.5m,
            _ => 0.0m
        };
    }

    /// <summary>
    /// Задание 4.5: Создайте record и напишите код (в отдельном классе DemonstrateDeconstruction) использования деконструкции.
    /// </summary>
    /// <summary>
    /// Задание 4.6: Используйте property patterns класса Product для проверки условий.
    /// </summary>
    public string GetProductStatus(Product product)
    {
        return product switch
        {
            null => "Недопустимый товар",
            { Price: > 1000 } => "Дорогой товар",
            { Stock: 0 } => "Нет в наличии",
            { Price: <= 0 } => "Некорректная цена",
            _ => "В наличии"
        };
    }
}