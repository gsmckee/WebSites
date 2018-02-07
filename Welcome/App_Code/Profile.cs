using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Profile
/// </summary>
public class Profile
{
    public string User, Password, First, Last, Email;
    public int Age;
    public bool Admin;
    public Profile(string user, string password, string first, string last, string email, int age, bool admin)
    {
        //
        // TODO: Add constructor logic here
        Password = password;
        First = first;
        Last = last;
        Email = email;
        Age = age;
        Admin = admin;
        //
    }
}