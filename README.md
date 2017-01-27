# taskTracker
How to use the TaskTracker API:

##GET:

Get Requests return a list of tasks.
Use this format: /task?taskType=0

You may input any INT value in as the taskType value as in the example above.
0 returns a list of toDo tasks.  
1 returns In Progress tasks.
2 returns Completed tasks.

Any other INT returns a list of all tasks.

Sample Request URL (you will need a different localhost):  
http://localhost:49763/task?taskType=2

##POST: 

Post requests store a new task in the database. Use /task together with the new task in JSON form when making post requests.
Post JSON must include the following: Name (String), and completionCode (INT). You may also include a Description (String).

Completion codes: 0 = To do, 1 = In Progress , 2 = Complete (this will set the new Task's CompletedOn date to the current date)

Sample Request URL (you will need a different localhost):  
http://localhost:49763/task  

Sample JSON:
{
	"Name": "Added New Task",
	"Description": "Added New Description",
	"completionCode": 1
}

##PUT:  

Put requests will find the desired task by TaskID and overwrite the task's properties. 
Use /task together with the new task in JSON form when making put requests.  
Put JSON must include the following: TaskID (INT), Name (String), and completionCode (INT). You may also include a Description (String).

Completion codes: 0 = To do, 1 = In Progress , 2 = Complete (this will set the new Task's CompletedOn date to the current date)

Sample Request (You will use a different localhost value):  
http://localhost:49763/task  

Sample JSON:
{
	"TaskID": 3,
	"Name": "Edited Task Name",
	"Description": "Edited Task Description",
	"completionCode": 2
}

