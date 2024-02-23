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
Task task1 = JsonSerializer.Deserialize<Task>(task1Response.content);
Functions.WriteTaskMessage(task1);

string romanNumeral = task1.parameters.Split(" ")[0];
Dictionary<char, int> romanValues = new Dictionary<char, int>
{
    {'I', 1},
    {'V', 5},
    {'X', 10},
    {'L', 50},
    {'C', 100},
};
int answerTaskOne = Functions.RomanToInteger(romanNumeral);

// Send the answer to the server
Response task1AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answerTaskOne.ToString());
Functions.WriteAnswerMessage(task1AnswerResponse);

//#### SECOND TASK 
// Fetch the details of the task from the server.
taskID = "otYK2";
Response task2Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); // Get the task from the server
Task task2 = JsonSerializer.Deserialize<Task>(task2Response.content);
Functions.WriteTaskMessage(task2);


//Solution to the second task
string[] words = task2.parameters.Split(",");
string[] uniqueWords = words.Distinct().ToArray();
Array.Sort(uniqueWords);
string answerTaskTwo = string.Join(",", uniqueWords);

// Send the answer to the server
Response task2AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answerTaskTwo);
Functions.WriteAnswerMessage(task2AnswerResponse);

//#### THIRD TASK 
// Fetch the details of the task from the server.
taskID = "psu31_4";
Response task3Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); // Get the task from the server
Task task3 = JsonSerializer.Deserialize<Task>(task3Response.content);
Functions.WriteTaskMessage(task3);

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
Functions.WriteAnswerMessage(task3AnswerResponse);

//#### FOURTH TASK
// Fetch the details of the task from the server.
taskID = "kuTw53L";
Response task4Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); // Get the task from the server
Task task4 = JsonSerializer.Deserialize<Task>(task4Response.content);
Functions.WriteTaskMessage(task4);


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
    if (Functions.IsNumberPrime(number))
    {
        primeNumbers.Add(number);
    }
}
string answerTaskFour = string.Join(",", primeNumbers);

// Send the answer to the server
Response task4AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answerTaskFour);
Functions.WriteAnswerMessage(task4AnswerResponse);



//###Testing
Console.WriteLine($"{Colors.Magenta}Testing the functions{ANSICodes.Reset}");
Testing.Test(Functions.RomanToInteger("IV"), 4, " IV ");
Testing.Test(Functions.RomanToInteger("XLIX"), 49, "XLIX");
Testing.Test(Functions.RomanToInteger("XCIX"), 99, "XCIX");
Testing.Test(Functions.IsNumberPrime(2), true, "2 is prime");
Testing.Test(Functions.IsNumberPrime(4), false, "4 is not prime");
Testing.Test(Functions.IsNumberPrime(5), true, "5 is prime");
Testing.Test(Functions.IsNumberPrime(7), true, "7 is prime");
Testing.Test(Functions.IsNumberPrime(9), false, "9 is not prime");
Testing.Test(Functions.IsNumberPrime(11), true, "11 is prime");


public class Task
{
    public string? title { get; set; }
    public string? description { get; set; }
    public string? taskID { get; set; }
    public string? usierID { get; set; }
    public string? parameters { get; set; }
}