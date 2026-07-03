using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Models;
using System.IO;
using System.Linq;


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
            var sorted = tasks.OrderBy(t => t.Priority).ToList();
            foreach (var task in sorted)
            {
                Console.WriteLine($"{task.Item} {task.Priority}");
            }
        }

        public void SaveToFile()
        {
            string path = "Tasks.txt";
            {
                string[] createText = tasks.Select(t => $"{t.Item},{t.Priority}").ToArray();
                File.WriteAllLines(path, createText, Encoding.UTF8);
            }
        }

        public void LoadFromFile()
        {
            string path = "Tasks.txt";
            if (File.Exists(path))
            {
                string[] readText = File.ReadAllLines(path, Encoding.UTF8);
                tasks.Clear();
                foreach (string s in readText)
                {
                    string[] part = s.Split(',');
                    string item = part[0];
                    int priority= Convert.ToInt32(part[1]);
                    TaskItem Task = new TaskItem(item, priority);
                    tasks.Add(Task);
                }
            }
        }
    }


}