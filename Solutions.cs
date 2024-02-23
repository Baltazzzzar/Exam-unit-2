public class TaskSolver
{
    public static int SolveTaskOne(string parameter)
    {
        string romanNumeral = parameter.Split(" ")[0];
        int solution = Functions.RomanToInteger(romanNumeral);
        return solution;
    }
    public static string SolveTaskTwo(string parameter)
    {
        string[] words = parameter.Split(",");
        string[] uniqueWords = words.Distinct().ToArray();
        Array.Sort(uniqueWords);
        string solution = string.Join(",", uniqueWords);
        return solution;
    }
    public static int SolveTaskThree(string parameter)
    {
        string[] numbers = parameter.Split(",");
        int[] intNumbers = new int[numbers.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            intNumbers[i] = int.Parse(numbers[i]);
        }
        int solution = intNumbers.Sum();
        return solution;
    }
    public static string SolveTaskFour(string parameter)
    {
        string[] numbersArray = parameter.Split(",");
        int[] intNumbersArray = new int[numbersArray.Length];
        List<int> primeNumbers = new List<int>();
        for (int i = 0; i < numbersArray.Length; i++)
        {
            intNumbersArray[i] = int.Parse(numbersArray[i]);
        }
        Array.Sort(intNumbersArray);
        foreach (int number in intNumbersArray)
        {
            if (Functions.IsNumberPrime(number))
            {
                primeNumbers.Add(number);
            }
        }
        string solution = string.Join(",", primeNumbers);
        return solution;
    }
}