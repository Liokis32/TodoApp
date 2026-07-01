using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Models
{
    internal class TaskItem
    {
        public string Item {  get; set; }   

        public TaskItem(string item) 
        { 
            this.Item = item;
        }

    }

}
