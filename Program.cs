using HTTPUtils;
using System.Text.Json;
using AnsiTools;
using Colors = AnsiTools.ANSICodes.Colors;
using System.Runtime.CompilerServices;
using System.Diagnostics.CodeAnalysis;

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
Task CurrentTask = JsonSerializer.Deserialize<Task>(task1Response.content);
Console.WriteLine($"TASK: {ANSICodes.Effects.Bold}{CurrentTask?.title}{ANSICodes.Reset}\n{CurrentTask?.description}\nParameters: {Colors.Yellow}{CurrentTask?.parameters}{ANSICodes.Reset}");

string romanNumeral = CurrentTask.parameters.Split(" ")[0];
Dictionary<char, int> romanValues = new Dictionary<char, int>
{
    {'I', 1},
    {'V', 5},
    {'X', 10},
    {'L', 50},
    {'C', 100},
};
int answerTaskOne = RomanToInteger(romanNumeral);

// Send the answer to the server
Response task1AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answerTaskOne.ToString());
WriteAnswerMessage(task1AnswerResponse);

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
string answerTaskTwo = string.Join(",", uniqueWords);

// Send the answer to the server
Response task2AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answerTaskTwo);
WriteAnswerMessage(task2AnswerResponse);

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
int answerTaskThree = intNumbers.Sum();

// Send the answer to the server
Response task3AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answerTaskThree.ToString());
WriteAnswerMessage(task3AnswerResponse);
//#### FOURTH TASK
// Fetch the details of the task from the server.
taskID = "kuTw53L";
Response task4Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); // Get the task from the server
Task task4 = JsonSerializer.Deserialize<Task>(task4Response.content);
Console.WriteLine($"TASK: {ANSICodes.Effects.Bold}{task4?.title}{ANSICodes.Reset}\n{task4?.description}\nParameters: {Colors.Yellow}{task4?.parameters}{ANSICodes.Reset}");


//Solution to the fourth task
string[] numbersArray = task4.parameters.Split(",");
int[] intNumbersArray = new int[numbersArray.Length];
List<int> primeNumbers = new List<int>();
for (int i = 0; i < numbersArray.Length; i++)
{
    intNumbersArray[i] = int.Parse(numbersArray[i]);
}

Array.Sort(intNumbersArray);
foreach (int number in intNumbersArray)
{
    if (IsNumberPrime(number))
    {
        primeNumbers.Add(number);
    }
}
string answerTaskFour = string.Join(",", primeNumbers);

// Send the answer to the server
Response task4AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answerTaskFour);
WriteAnswerMessage(task4AnswerResponse);

//###Functions
int RomanToInteger(string input)
{
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

void WriteAnswerMessage(Response taskAnswerResponse)
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

//###Testing
//Testing function
static void Test<T>(T expected, T actual, string description = "Test")
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