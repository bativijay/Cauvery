using System;
using System.Collections.Generic;
using System.Text;

namespace LIS.DO
{
  public class Employee
  {
    private int employeeID;
    private string lastName;
    private string firstName;
    private string title;
    private string address;
    private string city;
    private string region;
    private string postalCode;
    private string country;
    private string extension;

    public int EmployeeID
    {
      get
      {
        return this.employeeID;
      }
      set
      {
        this.employeeID = value;
      }
    }

    public string LastName
    {
      get
      {
        return this.lastName;
      }
      set
      {
        this.lastName = value;
      }
    }

    public string FirstName
    {
      get
      {
        return this.firstName;
      }
      set
      {
        this.firstName = value;
      }
    }

    public string Title
    {
      get
      {
        return this.title;
      }
      set
      {
        this.title = value;
      }
    }

    public string Address
    {
      get
      {
        return this.address;
      }
      set
      {
        this.address = value;
      }
    }

    public string City
    {
      get
      {
        return this.city;
      }
      set
      {
        this.city = value;
      }
    }

    public string Region
    {
      get
      {
        return this.region;
      }
      set
      {
        this.region = value;
      }
    }

    public string PostalCode
    {
      get
      {
        return this.postalCode;
      }
      set
      {
        this.postalCode = value;
      }
    }

    public string Country
    {
      get
      {
        return this.country;
      }
      set
      {
        this.country = value;
      }
    }

    public string Extension
    {
      get
      {
        return this.extension;
      }
      set
      {
        this.extension = value;
      }
    }
  }
}
