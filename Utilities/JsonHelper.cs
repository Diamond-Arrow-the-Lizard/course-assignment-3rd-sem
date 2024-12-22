namespace AirlinesSystem.Utilities;

using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using AirlinesSystem.Interfaces;
using System;

public class JsonHelper : IJsonHelper
{
    // Метод для асинхронной сериализации
    public async Task<string> SerializeAsync<T>(T obj)
    {
        try
        {
            using (var memoryStream = new MemoryStream())
            {
                await JsonSerializer.SerializeAsync(memoryStream, obj);
                memoryStream.Seek(0, SeekOrigin.Begin);
                using (var reader = new StreamReader(memoryStream))
                {
                    return await reader.ReadToEndAsync();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Serialization error: {ex.Message}");
            throw; // Повторно выбрасываем исключение для дальнейшей обработки
        }
    }

    // Метод для асинхронной десериализации
    public async Task<T> DeserializeAsync<T>(string json)
    {
        if (string.IsNullOrEmpty(json))
        {
            throw new InvalidOperationException("JSON string is null or empty.");
        }

        try
        {
            // Используем асинхронный вызов, например, через память
            using (var memoryStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json)))
            {
                var result = await JsonSerializer.DeserializeAsync<T>(memoryStream);

                // Если результат равен null, выбрасываем исключение
                if (result == null)
                {
                    throw new InvalidOperationException("Deserialization failed, result is null.");
                }

                return result;
            }
        }
        catch (JsonException ex)
        {
            // Обработка ошибок десериализации
            Console.WriteLine($"Deserialization error: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            // Обработка других исключений
            Console.WriteLine($"Unexpected error during deserialization: {ex.Message}");
            throw;
        }
    }

}
