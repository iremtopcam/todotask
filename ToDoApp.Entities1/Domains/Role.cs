
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Entities1.Domains
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(300)]
        public string RoleName { get; set; }

        [Required]
        [MaxLength(50)]
        public string RoleType { get; set; }
    }
}
