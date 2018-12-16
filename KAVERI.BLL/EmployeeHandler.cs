using System;
using System.Collections.Generic;
using System.Text;
using KAVERI.DAL;
using LIS.DO;

namespace BLL
{
  public class EmployeeHandler
  {
    private EmployeeDBAccess employeeDb = (EmployeeDBAccess) null;

    public EmployeeHandler()
    {
      this.employeeDb = new EmployeeDBAccess();
    }

    public List<Employee> GetEmployeeList()
    {
      return this.employeeDb.GetEmployeeList();
    }

    public bool UpdateEmployee(Employee employee)
    {
      return this.employeeDb.UpdateEmployee(employee);
    }

    public Employee GetEmployeeDetails(int empID)
    {
      return this.employeeDb.GetEmployeeDetails(empID);
    }

    public bool DeleteEmployee(int empID)
    {
      return this.employeeDb.DeleteEmployee(empID);
    }

    public bool AddNewEmployee(Employee employee)
    {
      return this.employeeDb.AddNewEmployee(employee);
    }
  }
}
