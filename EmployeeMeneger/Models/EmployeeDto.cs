using EmployeeMeneger.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMeneger.Models
{
    public class EmployeeDto
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        
        public Enum_Role Role { get; set; }
    }
}
