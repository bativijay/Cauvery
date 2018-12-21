using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using LIS.DO;
using KAVERI.DAL;
namespace KAVERI.DAL
{
  public class EmployeeDBAccess
  {
    public bool AddNewEmployee(Employee employee)
    {
      return SqlDBHelper.ExecuteNonQuery("AddNewEmployee", CommandType.StoredProcedure, new SqlParameter[9]
      {
        new SqlParameter("@LastName", (object) employee.LastName),
        new SqlParameter("@FirstName", (object) employee.FirstName),
        new SqlParameter("@Title", (object) employee.Title),
        new SqlParameter("@Address", (object) employee.Address),
        new SqlParameter("@City", (object) employee.City),
        new SqlParameter("@Region", (object) employee.Region),
        new SqlParameter("@PostalCode", (object) employee.PostalCode),
        new SqlParameter("@Country", (object) employee.Country),
        new SqlParameter("@Extension", (object) employee.Extension)
      });
    }

    public bool UpdateEmployee(Employee employee)
    {
      return SqlDBHelper.ExecuteNonQuery("UpdateEmployee", CommandType.StoredProcedure, new SqlParameter[10]
      {
        new SqlParameter("@EmployeeID", (object) employee.EmployeeID),
        new SqlParameter("@LastName", (object) employee.LastName),
        new SqlParameter("@FirstName", (object) employee.FirstName),
        new SqlParameter("@Title", (object) employee.Title),
        new SqlParameter("@Address", (object) employee.Address),
        new SqlParameter("@City", (object) employee.City),
        new SqlParameter("@Region", (object) employee.Region),
        new SqlParameter("@PostalCode", (object) employee.PostalCode),
        new SqlParameter("@Country", (object) employee.Country),
        new SqlParameter("@Extension", (object) employee.Extension)
      });
    }

    public bool DeleteEmployee(int empID)
    {
      return SqlDBHelper.ExecuteNonQuery("DeleteEmployee", CommandType.StoredProcedure, new SqlParameter[1]
      {
        new SqlParameter("@empId", (object) empID)
      });
    }

    public Employee GetEmployeeDetails(int empID)
    {
      Employee employee = (Employee) null;
      using (DataTable dataTable = SqlDBHelper.ExecuteParamerizedSelectCommand("GetEmployeeDetails", CommandType.StoredProcedure, new SqlParameter[1]
      {
        new SqlParameter("@empId", (object) empID)
      }))
      {
        if (dataTable.Rows.Count == 1)
        {
          DataRow dataRow = dataTable.Rows[0];
          employee = new Employee();
          employee.EmployeeID = Convert.ToInt32(dataRow["EmployeeID"]);
          employee.LastName = dataRow["LastName"].ToString();
          employee.FirstName = dataRow["FirstName"].ToString();
          employee.Title = dataRow["Title"].ToString();
          employee.Address = dataRow["Address"].ToString();
          employee.City = dataRow["City"].ToString();
          employee.Region = dataRow["Region"].ToString();
          employee.PostalCode = dataRow["PostalCode"].ToString();
          employee.Country = dataRow["Country"].ToString();
          employee.Extension = dataRow["Extension"].ToString();
        }
      }
      return employee;
    }

    public List<Employee> GetEmployeeList()
    {
      List<Employee> list = (List<Employee>) null;
      using (DataTable dataTable = SqlDBHelper.ExecuteSelectCommand("GetEmployeeList", CommandType.StoredProcedure))
      {
        if (dataTable.Rows.Count > 0)
        {
          list = new List<Employee>();
          foreach (DataRow dataRow in (InternalDataCollectionBase) dataTable.Rows)
            list.Add(new Employee()
            {
              EmployeeID = Convert.ToInt32(dataRow["EmployeeID"]),
              LastName = dataRow["LastName"].ToString(),
              FirstName = dataRow["FirstName"].ToString(),
              Title = dataRow["Title"].ToString(),
              Address = dataRow["Address"].ToString(),
              City = dataRow["City"].ToString(),
              Region = dataRow["Region"].ToString(),
              PostalCode = dataRow["PostalCode"].ToString(),
              Country = dataRow["Country"].ToString(),
              Extension = dataRow["Extension"].ToString()
            });
        }
      }
      return list;
    }
  }
}
