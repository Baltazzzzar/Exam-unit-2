using HTTPUtils;
using System.Text.Json;
using AnsiTools;
using Colors = AnsiTools.ANSICodes.Colors;

Console.Clear();
Console.WriteLine("Starting Assignment 2");

// SETUP 
const string myPersonalID = "c40b8fc46fb28dc1a89da405e192fc8b543f709d8b19c13bd6e2ece5d777cb7b"; // GET YOUR PERSONAL ID FROM THE ASSIGNMENT PAGE https://mm-203-module-2-server.onrender.com/
const string baseURL = "https://mm-203-module-2-server.onrender.com/";
const string startEndpoint = "start/"; // baseURl + startEndpoint + myPersonalID
const string taskEndpoint = "task/";   // baseURl + taskEndpoint + myPersonalID + "/" + taskID

// Creating a variable for the HttpUtils so that we dont have to type HttpUtils.instance every time we want to use it
HttpUtils httpUtils = HttpUtils.instance;

//#### REGISTRATION
// We start by registering and getting the first task
Response startRespons = await httpUtils.Get(baseURL + startEndpoint + myPersonalID);
Console.WriteLine($"Start:\n{Colors.Magenta}{startRespons}{ANSICodes.Reset}\n\n"); // Print the response from the server to the console
string taskID = "rEu25ZX"; // We get the taskID from the previous response and use it to get the task (look at the console output to find the taskID)

//#### FIRST TASK 
// Fetch the details of the task from the server.
Response task1Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); // Get the task from the server
Task task1 = JsonSerializer.Deserialize<Task>(task1Response.content);
Console.WriteLine($"TASK: {ANSICodes.Effects.Bold}{task1?.title}{ANSICodes.Reset}\n{task1?.description}\nParameters: {Colors.Yellow}{task1?.parameters}{ANSICodes.Reset}");

//Solution to the first task
string romanNumeral = task1.parameters.Split(" ")[0];
int RomanToInteger(string input)
{
    int result = 0;
    for (int i = 0; i < input.Length; i++)
    {
        if (input.Length - i >= 2)
        {
            if (input[i] == 'X' && input[i + 1] == 'C')
            {
                result += 90;
                i++;
            }
            else if (input[i] == 'X' && input[i + 1] == 'L')
            {
                result += 40;
                i++;
            }
            else if (input[i] == 'I' && input[i + 1] == 'V')
            {
                result += 4;
                i++;
            }
            else if (input[i] == 'I' && input[i + 1] == 'X')
            {
                result += 9;
                i++;
            }
            else if (input[i] == 'C')
            {
                result += 100;
            }
            else if (input[i] == 'L')
            {
                result += 50;
            }
            else if (input[i] == 'X')
            {
                result += 10;
            }
            else if (input[i] == 'V')
            {
                result += 5;
            }
            else if (input[i] == 'I')
            {
                result += 1;
            }
        }
        else
        {
            if (input[i] == 'C')
            {
                result += 100;
            }
            else if (input[i] == 'L')
            {
                result += 50;
            }
            else if (input[i] == 'X')
            {
                result += 10;
            }
            else if (input[i] == 'V')
            {
                result += 5;
            }
            else if (input[i] == 'I')
            {
                result += 1;
            }
        }
    }
    return result;
}

int answer = RomanToInteger(romanNumeral);

// Send the answer to the server
Response task1AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answer.ToString());
Console.WriteLine($"Answer: {Colors.Green}{task1AnswerResponse}{ANSICodes.Reset}");


//#### SECOND TASK 
// Fetch the details of the task from the server.
taskID = "otYK2";
Response task2Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); // Get the task from the server
Task task2 = JsonSerializer.Deserialize<Task>(task2Response.content);
Console.WriteLine($"TASK: {ANSICodes.Effects.Bold}{task2?.title}{ANSICodes.Reset}\n{task2?.description}\nParameters: {Colors.Yellow}{task2?.parameters}{ANSICodes.Reset}");


//Solution to the second task
string[] words = task2.parameters.Split(",");
string[] uniqueWords = words.Distinct().ToArray();
Array.Sort(uniqueWords);
string answer2 = string.Join(",", uniqueWords);

// Send the answer to the server
Response task2AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answer2);
Console.WriteLine($"Answer: {Colors.Green}{task2AnswerResponse}{ANSICodes.Reset}");

//#### THIRD TASK 
// Fetch the details of the task from the server.
taskID = "psu31_4";
Response task3Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); // Get the task from the server
Task task3 = JsonSerializer.Deserialize<Task>(task3Response.content);
Console.WriteLine($"TASK: {ANSICodes.Effects.Bold}{task3?.title}{ANSICodes.Reset}\n{task3?.description}\nParameters: {Colors.Yellow}{task3?.parameters}{ANSICodes.Reset}");

//Solution to the third task
string[] numbers = task3.parameters.Split(",");
int[] intNumbers = new int[numbers.Length];
for (int i = 0; i < numbers.Length; i++)
{
    intNumbers[i] = int.Parse(numbers[i]);
}
int answer3 = intNumbers.Sum();

// Send the answer to the server
Response task3AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answer3.ToString());
Console.WriteLine($"Answer: {Colors.Green}{task3AnswerResponse}{ANSICodes.Reset}");

//#### FOURTH TASK
// Fetch the details of the task from the server.
taskID = "kuTw53L";
Response task4Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); // Get the task from the server
Task task4 = JsonSerializer.Deserialize<Task>(task4Response.content);
Console.WriteLine($"TASK: {ANSICodes.Effects.Bold}{task4?.title}{ANSICodes.Reset}\n{task4?.description}\nParameters: {Colors.Yellow}{task4?.parameters}{ANSICodes.Reset}");


//Solution to the fourth task
string[] numbersPrime = task4.parameters.Split(",");
int[] intNumbersPrime = new int[numbersPrime.Length];
for (int i = 0; i < numbersPrime.Length; i++)
{
    intNumbersPrime[i] = int.Parse(numbersPrime[i]);
}
bool IsNumberPrime(int number)
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




//###Testing
//Testing function
static void Test<T>(T expected, T actual, string description = "Test")
{
    if (expected.Equals(actual))
    {
        Console.WriteLine($"{description} ++PASSED++. Expected: {expected}, Actual: {actual}");
    }
    else
    {
        Console.WriteLine($"{description} --FAILED--. Expected: {expected}, Actual: {actual}");
    }
}
//Testing the tasks
Test(RomanToInteger("IV"), 4, " IV ");
Test(RomanToInteger("XLIX"), 49, "XLIX");
Test(RomanToInteger("XCIX"), 99, "XCIX");
Test(IsNumberPrime(2), true, "2 is prime");
Test(IsNumberPrime(4), false, "4 is not prime");
Test(IsNumberPrime(5), true, "5 is prime");
Test(IsNumberPrime(7), true, "7 is prime");
Test(IsNumberPrime(9), false, "9 is not prime");
Test(IsNumberPrime(11), true, "11 is prime");




class Task
{
    public string? title { get; set; }
    public string? description { get; set; }
    public string? taskID { get; set; }
    public string? usierID { get; set; }
    public string? parameters { get; set; }
}