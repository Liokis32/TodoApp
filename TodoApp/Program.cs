using TodoApp.Services;
using TodoApp.Models;

TaskService taskService = new TaskService();
taskService.LoadFromFile();
while (true)
{
    Console.WriteLine("1. New Task");
    Console.WriteLine("2. Complete Task");
    Console.WriteLine("3. Display Tasks");
    Console.WriteLine("4. Save and Exit");


    var number = Console.ReadLine();

    switch (number)
    {
        case "1":
            Console.WriteLine("Enter Item ");
            var item = Console.ReadLine();
            Console.WriteLine("Enter Priority ");
            int priority = Convert.ToInt32(Console.ReadLine());
            TaskItem newTask = new TaskItem(item, priority);
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
            taskService.SaveToFile();
            return;
    }

}
