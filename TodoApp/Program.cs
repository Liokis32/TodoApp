using TodoApp.Services;
using TodoApp.Models;

TaskService taskService = new TaskService();
taskService.LoadFromBase();
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
            var item = Console.ReadLine().Trim();
            Console.WriteLine("Enter Priority (1-3):");
            string input = Console.ReadLine();
            int priority;
            while (!int.TryParse(input, out priority) || priority < 1 || priority > 3)
            {
                Console.WriteLine("Invalid input! Please enter a number between 1 and 3:");
                input = Console.ReadLine();
            }
            TaskItem newTask = new TaskItem(item, priority);
            taskService.AddTask(newTask);
            break;

        case "2":
            Console.WriteLine("Enter the name of the task ");
            var item2 = Console.ReadLine().Trim();
            bool success = taskService.CompleteTask(item2);
            if (success)
            {
                Console.WriteLine("Success: The task was found.");
            }
            else
            {
                Console.WriteLine("Error: Task not found.");
            }
            break;

        case "3":
            taskService.DisplayTasks();
            break;

        case "4":
            return;
    }

}
