using AirlinesSystem.Interfaces;
using System;

namespace AirlinesSystem.Utilities;

public static class RandomIDGen 
{
    private static readonly string ValidChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    public static string GenerateID(int length)
    {
        Random random = new Random();
        char[] result = new char[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = ValidChars[random.Next(ValidChars.Length)];
        }

        return new string(result);
    }
}