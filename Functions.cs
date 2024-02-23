using AnsiTools;
using Colors = AnsiTools.ANSICodes.Colors;
using HTTPUtils;
public class Testing
{
    public static void Test<T>(T expected, T actual, string description = "Test")
    {
        if (expected.Equals(actual))
        {
            Console.WriteLine($"{Colors.Green} --PASSED--{description}.{Colors.Yellow}Expected: {expected}, Actual: {actual}{ANSICodes.Reset}");
        }
        else
        {
            Console.WriteLine($"{Colors.Red} --FAILED-- {description}.{Colors.Yellow} Expected: {expected}, {Colors.Red}Actual: {actual}{ANSICodes.Reset}");
        }
    }
}

public class Functions
{
    HttpUtils httpUtils = HttpUtils.instance;
    public static int RomanToInteger(string input)
    {
        Dictionary<char, int> romanValues = new Dictionary<char, int>
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };
        int result = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (i + 1 < input.Length && romanValues[input[i]] < romanValues[input[i + 1]])
            {
                result -= romanValues[input[i]];
            }
            else
            {
                result += romanValues[input[i]];
            }
        }
        return result;
    }

    public static bool IsNumberPrime(int number)
    {
        if (number <= 1)
        {
            return false;
        }
        for (int i = 2; i < number; i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }
        return true;
    }

    public static void WriteAnswerMessage(Response taskAnswerResponse)
    {
        if (taskAnswerResponse.statusCode == 200)
        {
            Console.WriteLine($"Answer: {Colors.Green}{"Correct"}{ANSICodes.Reset}");
        }
        else
        {
            Console.WriteLine($"Answer: {Colors.Red}{"Incorrect"}{ANSICodes.Reset}");
        }
    }
    public static void WriteTaskMessage(Task? CurrentTask)
    {
        Console.WriteLine($"TASK: {ANSICodes.Effects.Bold}{ANSICodes.Effects.Underline}{CurrentTask?.title}{ANSICodes.Reset}\nDescription: {Colors.Cyan}{CurrentTask?.description}{ANSICodes.Reset}\nParameters: {Colors.Yellow}{CurrentTask?.parameters}{ANSICodes.Reset}");
    }
}