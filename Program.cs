using HTTPUtils;
using System.Text.Json;
using AnsiTools;
using Colors = AnsiTools.ANSICodes.Colors;
using System.Runtime.CompilerServices;
using System.Diagnostics.CodeAnalysis;

Console.Clear();
Console.WriteLine("Starting Assignment 2");

// SETUP 
const string myPersonalID = "c40b8fc46fb28dc1a89da405e192fc8b543f709d8b19c13bd6e2ece5d777cb7b";
const string baseURL = "https://mm-203-module-2-server.onrender.com/";
const string startEndpoint = "start/";
const string taskEndpoint = "task/";

HttpUtils httpUtils = HttpUtils.instance;

//#### REGISTRATION
Response startRespons = await httpUtils.Get(baseURL + startEndpoint + myPersonalID);
Console.WriteLine($"Start:\n{Colors.Magenta}{startRespons}{ANSICodes.Reset}\n\n"); // Print the response from the server to the console
string taskID = ""; // We get the taskID from the previous response and use it to get the task (look at the console output to find the taskID)



//#### FIRST TASK 
// Gathering the task
taskID = "rEu25ZX";
Response task1Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID);
Task task1 = Functions.GetTask(task1Response);

//Solution
string romanNumeral = task1.parameters.Split(" ")[0];
int answerTaskOne = Functions.RomanToInteger(romanNumeral);

// Sending the answer to the server
Response task1AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answerTaskOne.ToString());
Functions.WriteAnswerMessage(task1AnswerResponse);



//#### SECOND TASK
// Gathering the task
taskID = "otYK2";
Response task2Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID);
Task task2 = Functions.GetTask(task2Response);

//Solution
string[] words = task2.parameters.Split(",");
string[] uniqueWords = words.Distinct().ToArray();
Array.Sort(uniqueWords);
string answerTaskTwo = string.Join(",", uniqueWords);

// Sending the answer to the server
Response task2AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answerTaskTwo);
Functions.WriteAnswerMessage(task2AnswerResponse);



//#### THIRD TASK
// Gathering the task
taskID = "psu31_4";
Response task3Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID);
Task task3 = Functions.GetTask(task3Response);

//Solution
string[] numbers = task3.parameters.Split(",");
int[] intNumbers = new int[numbers.Length];
for (int i = 0; i < numbers.Length; i++)
{
    intNumbers[i] = int.Parse(numbers[i]);
}
int answerTaskThree = intNumbers.Sum();

// Sending the answer to the server
Response task3AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answerTaskThree.ToString());
Functions.WriteAnswerMessage(task3AnswerResponse);



//#### FOURTH TASK
// Gathering the task
taskID = "kuTw53L";
Response task4Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID);
Task task4 = Functions.GetTask(task4Response);

//Solution
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

// Sending the answer to the server
Response task4AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answerTaskFour);
Functions.WriteAnswerMessage(task4AnswerResponse);

public class Task
{
    public string? title { get; set; }
    public string? description { get; set; }
    public string? taskID { get; set; }
    public string? usierID { get; set; }
    public string? parameters { get; set; }
}