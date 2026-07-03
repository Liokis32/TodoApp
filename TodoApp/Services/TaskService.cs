using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Models;


namespace TodoApp.Services
{
    internal class TaskService
    {

        public List<TaskItem> tasks;

        public TaskService()
        {
            tasks = new List<TaskItem>();
           
        }


        public void AddTask(TaskItem task)
        {
            tasks.Add(task);
        }

        public void CompleteTask(String task)
        {
            var found = tasks.Find(t => t.Item == task);
            if (found != null)
            {
                tasks.Remove(found);
            }
        }

        public void DisplayTasks()
        {
            foreach (var task in tasks)
            {
                Console.WriteLine(task.Item);
            }
        }
    }


}