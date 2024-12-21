namespace AirlinesSystem.Utilities;

using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using AirlinesSystem.Interfaces;

public class JsonHelper : IJsonHelper
{
    public async Task<string> SerializeAsync<T>(T obj)
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

    public async Task<T> DeserializeAsync<T>(string json)
    {
        using (var memoryStream = new MemoryStream())
        {
            var writer = new StreamWriter(memoryStream);
            await writer.WriteAsync(json);
            await writer.FlushAsync();
            memoryStream.Seek(0, SeekOrigin.Begin);
            // Десериализует информацию, вызывает исключение, елси null
            var result = await JsonSerializer.DeserializeAsync<T>(memoryStream) ?? throw new InvalidOperationException("Deserialization failed, result is null.");
            return result;
        }
    }
}
