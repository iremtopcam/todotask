using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Dtos1.Interfaces;

namespace ToDoApp.Dtos1.Dtos
{
    public class NoteCreateDto : IDto
    {

        public string Defination { get; set; }
        public bool IsCompleted { get; set; }
    }
}
