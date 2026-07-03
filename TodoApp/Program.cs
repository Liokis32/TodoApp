using TodoApp.Services;
using TodoApp.Models;

TaskService taskService = new TaskService();

while (true)
{
    Console.WriteLine("1. New Task");
    Console.WriteLine("2. Complete Task");
    Console.WriteLine("3. Display Tasks");
    Console.WriteLine("4. Exit");


    var number = Console.ReadLine();

    switch (number)
    {
        case "1":
            Console.WriteLine("Enter Item ");
            var item = Console.ReadLine();
            TaskItem newTask = new TaskItem(item);
            taskService.AddTask(newTask);
            break;

        case "2":
            Console.WriteLine("Enter the name of the task ");
            var item2 = Console.ReadLine();
            taskService.CompleteTask(item2);
            break;

        case "3":
            taskService.DisplayTasks();
            break;

        case "4":
            return;
    }

}
