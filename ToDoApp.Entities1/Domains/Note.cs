using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Entities1.Domains
{
    public class Note : BaseEntity
    {
        public string Defination { get; set; }
        public bool IsCompleted { get; set; }

        //public DateTime DueDate { get; set; }




    }
}
