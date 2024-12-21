using System.Text.Json;

namespace AirlinesSystem.Interfaces;

public interface IJsonHelper
{
    Task<T> DeserializeAsync<T>(string json);
    Task<string> SerializeAsync<T>(T data);
}
