using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Models;
using System.IO;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using static System.Net.WebRequestMethods;


namespace TodoApp.Services
{
    internal class TaskService
    {

        public List<TaskItem> tasks;
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Todo;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public TaskService()
        {
            tasks = new List<TaskItem>();
           
        }


        public void AddTask(TaskItem task)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Tasks (Item, Priority) VALUES (@Item, @Priority)";
                db.Execute(sql, task);
            }
            tasks.Add(task);
        }

        public bool CompleteTask(String task)
        {
            int existed = 0;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Tasks WHERE Item = @task";
                existed = db.Execute(sql, new { task = task });
            }
            if (existed > 0 )
            {
                var found = tasks.Find(t => t.Item == task);
                if (found != null)
                {
                    tasks.Remove(found);
                }
                return true;   

            }
            return false;             
        }

        public void DisplayTasks()
        {
            var sorted = tasks.OrderBy(t => t.Priority).ToList();
            foreach (var task in sorted)
            {
                Console.WriteLine($"{task.Item} {task.Priority}");
            }
        }

        public void LoadFromBase()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var data = db.Query<TaskItem>("SELECT Item, Priority FROM Tasks").ToList();

                tasks.Clear();
                foreach (var item in data)
                {
                    tasks.Add(item);
                }
            }
        }


        /*
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
        */
    }



}