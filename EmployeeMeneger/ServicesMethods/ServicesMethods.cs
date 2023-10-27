using EmployeeMeneger.Enums;
using EmployeeMeneger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMeneger.ServicesMethods
{
    public static class ServicesMethods
    {
        public static Employee StrListToEmployee(List<string> employees)
        {
            Employee employee = new Employee()
            {
                Id = Convert.ToInt32(employees[0]),
                Name = employees[1],
                SurName = employees[2],
                Email = employees[3],
                Login = employees[4],
                Password = employees[5],
                Status = (Enum_Status)Convert.ToInt32(employees[6]),
                Role = (Enum_Role)Convert.ToInt32(employees[7]),
                CreatedDate = (employees[8]),
                ModifyDate = (employees[9]),
                DeletedDate = (employees[10]),
            };
            return employee;
        }
    }
}
