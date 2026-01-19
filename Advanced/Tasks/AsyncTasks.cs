namespace Advanced.Tasks;

using System.Threading;

public class AsyncTasks
{
    /// <summary>
    /// Задание 2.1: Напишите асинхронный метод, который имитирует загрузку данных.
    /// Используйте Task.Delay для имитации задержки.
    /// </summary>
    public async Task<string> LoadDataAsync()
    {
        await Task.Delay(1000);

        return "Load data async...";
    }

    /// <summary>
    /// Задание 2.2: Напишите асинхронный метод, который загружает данные с тайм-аутом.
    /// Если операция превышает timeout, бросает TimeoutException.
    /// </summary>
    public async Task<string> LoadDataWithTimeoutAsync(TimeSpan timeout)
    {
        using var cts = new CancellationTokenSource(timeout);

        try
        {
            return await LoadDataWithCancellationAsync(cts.Token);
        }
        catch (OperationCanceledException) when (cts.Token.IsCancellationRequested)
        {
            throw new TimeoutException("Operation timeout");
        }
    }

    /// <summary>
    /// Задание 2.3: Напишите метод, который выполняет несколько асинхронных операций параллельно
    /// и возвращает результат, когда все завершатся.
    /// </summary>
    public async Task<string[]> ExecuteParallelAsync(IEnumerable<Task<string>> tasks)
    {
        var taskList = tasks.ToList();

        if (taskList.Count == 0)
        {
            return Array.Empty<string>();
        }

        await Task.WhenAll(taskList);

        return taskList.Select(t => t.Result).ToArray();
    }

    /// <summary>
    /// Задание 2.4: Напишите метод, который поддерживает отмену операции через CancellationToken.
    /// </summary>
    public async Task<string> LoadDataWithCancellationAsync(CancellationToken cancellationToken)
    {
        await Task.Delay(1000, cancellationToken);

        cancellationToken.ThrowIfCancellationRequested();

        return "Data loaded...";
    }

    /// <summary>
    /// Задание 2.5: Напишите метод, который использует ConfigureAwait(false) для избежания deadlock.
    /// </summary>
    public async Task<string> LoadDataConfigureAwaitAsync()
    {
        await Task.Delay(1000).ConfigureAwait(false);

        return "Data loaded...";
    }
}