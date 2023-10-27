using EmployeeMeneger.Data;
using EmployeeMeneger.Enums;
using EmployeeMeneger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMeneger.Services
{
    public class EmployeeServices
    {
        public static void EmployeeCreated()
        {
            var emp =new EmployeeDto()
            {
                Name = "Sevinch",
                SurName = "Xayriddinova",
                Email = "S@gmail.com",
                Login = "Nur_0124",
                Password = "Password",
                Role = Enum_Role.Other,
            };
            if (DataServices.InsertIntoEmployee(emp))
            {
                Console.WriteLine("Created");
            }
            else
            {
                Console.WriteLine("Error");
            }

        }

        public static void EmployeeUpdated() 
        {
            var emp = new EmployeeDto()
            {
                Name = "Sevinch",
                SurName = "Xayriddinova",
                Email = "Sevinch@gmail.com",
                Login = "Nur_0124",
                Password = "Password",
                Role = Enum_Role.Other,
            };
            int id = 1;
            if (DataServices.UpdateEmployee(id, emp))
            {

                Console.WriteLine("Updated");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        public static void EmployeeDeleted() 
        {
            var Id = 1;
            var lst = DataServices.GetAllEmployee();
            var emp = lst.FirstOrDefault(x => x.Id == Id);
            if (emp !=null)
            {
                if(emp.Status != Enum_Status.Deleted)
                {
                    Console.WriteLine("Avval uchirilgan");
                }
                else
                {
                    DataServices.DeletedEmployee(Id);
                    Console.WriteLine("Employee o`chirildi");
                }
            }
            else
            {
                Console.WriteLine("Bunday element mavjud emas");
            }
                
        }
        
        public static void EmployeeDeepDeleted() 
        {
            var Id = 1;
            if(DataServices.DeepDeleteEmployee(Id))
            {
                Console.WriteLine("Deleted");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
        
        public static List<Employee> GetAll() 
        {
            var lst = DataServices.GetAllEmployee();

            return lst.Where(x=>x.Status != Enum_Status.Deleted).ToList();
        }
        
        public static Employee GetAllById() 
        {
            int Id = 2;
            var emp = DataServices.GetAllByIdEmployee(Id);

            if (emp.Status != Enum_Status.Deleted)
            {
                return emp;
            }
            else
            {
                return new Employee();
            }
            
        }




    }
}
