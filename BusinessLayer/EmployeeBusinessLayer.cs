using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace BusinessLayer
{
    public class EmployeeBusinessLayer
    {
        public IEnumerable<BllEmployee> Employees
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
                List<BllEmployee> employees = new List<BllEmployee>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BllEmployee employee = new BllEmployee();
                        employee.EmpId = Convert.ToInt32(dr["EmpId"]);
                        employee.Name = dr["Name"].ToString();
                        employee.Designation = dr["Designation"].ToString();
                        employee.DepartmentId = Convert.ToInt32(dr["DepartmentId"]);
                        employee.Description = dr["Description"].ToString();
                        employees.Add(employee);
                    }
                    return employees;
                }
            }
        }

        public void CreateEmployee(BllEmployee bllEmployee)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                SqlCommand Command = new SqlCommand("spAddEmployee", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                SqlParameter ParamName = new SqlParameter();
                ParamName.ParameterName = "@Name";
                ParamName.Value = bllEmployee.Name;
                Command.Parameters.Add(ParamName);

                SqlParameter ParamDesignation = new SqlParameter();
                ParamDesignation.ParameterName = "@Designation";
                ParamDesignation.Value = bllEmployee.Designation;
                Command.Parameters.Add(ParamDesignation);

                SqlParameter ParamDepartmentId = new SqlParameter();
                ParamDepartmentId.ParameterName = "@DepartmentId";
                ParamDepartmentId.Value = Convert.ToString(bllEmployee.DepartmentId);
                Command.Parameters.Add(ParamDepartmentId);

                Connection.Open();
                Command.ExecuteNonQuery();
            }
        }

        public void UpdateEmployee(BllEmployee bllEmployee)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spUpdateEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter paramEmpId = new SqlParameter();
                paramEmpId.ParameterName = "@EmpId";
                paramEmpId.Value = bllEmployee.EmpId;
                command.Parameters.Add(paramEmpId);

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = bllEmployee.Name;
                command.Parameters.Add(paramName);

                SqlParameter ParamDesignation = new SqlParameter();
                ParamDesignation.ParameterName = "@Designation";
                ParamDesignation.Value = bllEmployee.Designation;
                command.Parameters.Add(ParamDesignation);

                SqlParameter ParamDepartmentId = new SqlParameter();
                ParamDepartmentId.ParameterName = "@DepartmentId";
                ParamDepartmentId.Value = Convert.ToString(bllEmployee.DepartmentId);
                command.Parameters.Add(ParamDepartmentId);

                connection.Open();
                command.ExecuteNonQuery();

            }
        }

        public void DeleteEmployee(int EmpId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SQLCONNECTIONSTRING"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spDeleteEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter paramEmpId = new SqlParameter();
                paramEmpId.ParameterName = "@EmpId";
                paramEmpId.Value = EmpId;
                command.Parameters.Add(paramEmpId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
