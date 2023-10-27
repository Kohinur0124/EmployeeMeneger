using EmployeeMeneger.Enums;
using EmployeeMeneger.Models;
using EmployeeMeneger.ServicesMethods;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMeneger.Data
{
    public static class DataServices
    {
        public static string ConnectString = "Server=.;Database=EmployeeData;Trusted_Connection=True;";

        public static bool InsertIntoEmployee(EmployeeDto employee)
        {
            using (SqlConnection connect = new SqlConnection(ConnectString))
            {
                connect.Open();

                string query = $"insert into Employee (Name,Surname,Email,Login,Password,Role)" +
                                    $"VALUES" +
                                    $"(\'{employee.Name}\',\'{employee.SurName}\',\'{employee.Email}\',\'{employee.Login}\',\'{employee.Password}\',{(int)employee.Role});";



                SqlCommand cmd = new SqlCommand(query, connect);
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }


        public static bool UpdateEmployee(int Id, EmployeeDto employee)
        {
            using (SqlConnection connect = new SqlConnection(ConnectString))
            {
                connect.Open();

                string query = $"UPDATE Employee " +
                                    $"SET Name = \'{employee.Name}\'," +
                                    $"Surname = \'{employee.SurName}\' ," +
                                    $"Email = \'{employee.Email}\'," +
                                    $"Login  = \'{employee.Login}\', " +
                                    $"Password = \'{employee.Password}\'," +
                                    $"Role = {(int)employee.Role} ," +
                                    $"Status = {(int)Enum_Status.Updated} , " +
                                    $"ModifyDate = GetDate() " +
                                    $"WHERE id = {Id} ;";


                SqlCommand cmd = new SqlCommand(query, connect);
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }

        }

        public static bool DeletedEmployee(int Id)
        {
            using (SqlConnection connect = new SqlConnection(ConnectString))
            {
                connect.Open();

                string query = $"UPDATE Employee " +
                                    $"Status = {Enum_Status.Deleted} , " +
                                    $"DeletedDate = GetDate()" +
                                    $"WHERE id = {Id} ;";


                SqlCommand cmd = new SqlCommand(query, connect);
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }

        }

        public static bool DeepDeleteEmployee(int Id)
        {
            using (SqlConnection connect = new SqlConnection(ConnectString))
            {
                connect.Open();

                string query = $"DELETE FROM Employee WHERE id = {Id}";


                SqlCommand cmd = new SqlCommand(query, connect);
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }

        }

        public static List<Employee> GetAllEmployee()
        {
            using (SqlConnection connect = new SqlConnection(ConnectString))
            {
                connect.Open();

                string query = $"SELECT * FROM Employee;";

                var employees = new List<Employee>();

                SqlCommand cmd = new SqlCommand(query, connect);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    int count = reader.FieldCount;

                    //int i = 0;
                    while (reader.Read())
                    {
                        var lst = new List<string>();
                        for (int j = 0; j < count; j++)
                        {
                            lst.Add(reader[j].ToString());
                        }
                        employees.Add(ServicesMethods.ServicesMethods.StrListToEmployee(lst));
                        Console.WriteLine();
                    }
                    return employees;
                }

            }



        }

        public static Employee GetAllByIdEmployee(int Id)
        {
            using (SqlConnection connect = new SqlConnection(ConnectString))
            {
                connect.Open();

                string query = $"SELECT * FROM Employee WHERE id = {Id};";

                var emp = new Employee();
                SqlCommand cmd = new SqlCommand(query, connect);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    int count = reader.FieldCount;

                    //int i = 0;
                    while (reader.Read())
                    {
                        var lst = new List<string>();
                        for (int j = 0; j < count; j++)
                        {
                            lst.Add(reader[j].ToString());
                        }
                        emp = (ServicesMethods.ServicesMethods.StrListToEmployee(lst));

                    }
                    return emp;

                }

            }





        }
    }
}
