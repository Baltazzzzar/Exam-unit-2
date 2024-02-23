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
int answerTaskOne = TaskSolver.SolveTaskOne(task1.parameters);

// Sending the answer to the server
Response task1AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answerTaskOne.ToString());
Functions.WriteAnswerMessage(task1AnswerResponse);



//#### SECOND TASK
// Gathering the task
taskID = "otYK2";
Response task2Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID);
Task task2 = Functions.GetTask(task2Response);

//Solution
string answerTaskTwo = TaskSolver.SolveTaskTwo(task2.parameters);

// Sending the answer to the server
Response task2AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answerTaskTwo);
Functions.WriteAnswerMessage(task2AnswerResponse);



//#### THIRD TASK
// Gathering the task
taskID = "psu31_4";
Response task3Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID);
Task task3 = Functions.GetTask(task3Response);

//Solution
int answerTaskThree = TaskSolver.SolveTaskThree(task3.parameters);

// Sending the answer to the server
Response task3AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answerTaskThree.ToString());
Functions.WriteAnswerMessage(task3AnswerResponse);



//#### FOURTH TASK
// Gathering the task
taskID = "kuTw53L";
Response task4Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID);
Task task4 = Functions.GetTask(task4Response);

//Solution
string answerTaskFour = TaskSolver.SolveTaskFour(task4.parameters);

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