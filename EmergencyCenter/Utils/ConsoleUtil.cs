namespace EmergencyCenter.Utils;

public static class ConsoleUtil
{
    public static string GetRawInput(string message)
    {
        Console.Write($"Please {message}: ");
        return Console.ReadLine() ?? "";
    }

    public static string GetValidInput(string message, Func<string, bool> validator)
    {
        var rawInput = GetRawInput(message);
        
        try
        {
            validator(rawInput);
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine($"{e.Message}");
            return GetValidInput("try again", validator);
        }

        return rawInput;
    }
    
    public static void PrintEnumOptions<T>() where T : struct, IConvertible
    {
        foreach(int i in Enum.GetValues(typeof(T))) {
            Console.Write($"{i}. ");
            Console.WriteLine($"{Enum.GetName(typeof(T), i)}");
        }
    }
}