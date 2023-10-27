using EmployeeMeneger.Enums;
using EmployeeMeneger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMeneger.Models
{
    public class Employee : IEmployee
    {
        public int? Id { get ; set ; }

        public string Name { get; set ; }
        public string SurName { get; set ; }
        public string Email { get; set ; }
        public string Login { get; set ; }
        public string Password { get; set ; }
        public Enum_Status Status { get; set ; }
        public Enum_Role Role { get; set ; }

        public string? CreatedDate { get; set; }
        public string? ModifyDate { get ; set ; }
        public string? DeletedDate { get ; set ; }


        public override string ToString()
        {
            return $"{Id} {Name} {SurName} {Email} {Login} {Password} {Status} {Role}";
        }
    }
}
