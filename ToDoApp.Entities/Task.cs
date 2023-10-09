using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Entities
{
    public class Task : BaseEntity
    {
        public string Defination { get; set; }
        public bool IsCompleted { get; set; }

        public DateTime DueDate { get; set; }
    }
}
