using System.Text.Json;

namespace AirlinesSystem.Interfaces;

public interface IJsonHelper
{
    Task<string> SerializeAsync<T>(T obj);      // Асинхронная сериализация объекта в строку JSON
    Task<T> DeserializeAsync<T>(string json);   // Асинхронная десериализация строки JSON в объект
}
