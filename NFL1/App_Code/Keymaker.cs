using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Keymaker
/// Check line 36
/// Create connection to server database, insert and/or validate the user info.
/// </summary>
public class Keymaker
{
    //protected string connString = "Data Source=DESKTOP-2OVG5TT;Initial Catalog=master;Integrated Security=True;";// Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    protected string connString = "Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = master; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    protected SqlCommand cmd;
    protected SqlConnection conn;
    protected SqlDataReader rdr;
    protected string query;
    public List<string> Teams = new List<string>();
    public Keymaker()
    {
        using (conn = new SqlConnection(connString))
        {
            conn.Open();
        }

    }

    public Keymaker(Profile p)
    {


        //
        // TODO: Add constructor logic here 
        using (conn = new SqlConnection(connString))
        {
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                // Week 2 code... 
                //cmd.Parameters.Add("@UserN", SqlDbType.VarChar); // null reference exception thrown.
                //cmd.Parameters.Add("@Password", SqlDbType.VarChar);
                //cmd.Parameters.Add("@First", SqlDbType.VarChar);
                //cmd.Parameters.Add("@Last", SqlDbType.VarChar);
                //cmd.Parameters.Add("@Age", SqlDbType.Int);
                //cmd.Parameters.Add("@Email", SqlDbType.VarChar);
                //cmd.Parameters.Add("@Admin", SqlDbType.Bit);
                query = "Insert into Users(UserName, Password, FirstName, LastName, Age, Email, Administrator) Values( '"
                    + p.Position + "', '" + p.Mascot + "', '" + p.First + "', '" + p.Last + "', " + p.Age + ", " 
                    + p.Height + ", " + p.Weight + ", " + p.JNumber + ", " 
                    + Convert.ToInt16(p.InjuredReserve) + Convert.ToInt16(p.Active) + ");";

                cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }

        }
        conn.Close();

    }
    public void KeymakerProfile(string user, string pass)
    {
        query = "Select * from Users Where User = '" + user + "';";
        using (conn = new SqlConnection(connString))
        {
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                cmd = new SqlCommand(query, conn);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (rdr.Read())
                {
                    if (CheckForPassMatch(user, pass) == true)
                    {
                        string userName = rdr["UserName"].ToString();
                        string password = rdr["Password"].ToString();
                        string first = rdr["FirstName"].ToString();
                        string last = rdr["LastName"].ToString();
                        string email = rdr["Email"].ToString();
                        int age = Convert.ToInt16(rdr["Age"]);
                        bool admin = Convert.ToBoolean(rdr["Administrator"]);
                        userProfile = new Profile(userName, password, first, last, email, age, admin);
                    }
                    else
                    { rdr.Close(); }
                }

            }

        }
        conn.Close();
    }
    public void KeymakerRem(string userName)
    {
        string queryRemove = "Delete from Users Where Username = '" + userName + "';";
        //cmd.Parameters.Add("@userName", SqlDbType.VarChar);
        using (conn = new SqlConnection(connString))
        {
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                cmd = new SqlCommand(queryRemove, conn);
                cmd.ExecuteNonQuery();
            }

        }
        conn.Close();
    }
    public bool KeymakerSelect(string user)
    {

        using (conn = new SqlConnection(connString))
        {
            conn.Open();
            //userCheck.Parameters.Add("@user", SqlDbType.VarChar);
            if (conn.State == ConnectionState.Open)
            {
                cmd = new SqlCommand("Select Username from Users Where Username = '" + user + "';", conn);
                rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            else
                rdr.Close();
            return false;

        }
    }
    //public bool CheckIfEmailExists(string email)
    //{

    //    using (conn = new SqlConnection(connString))
    //    {
    //        conn.Open();
    //        //userCheck.Parameters.Add("@user", SqlDbType.VarChar);
    //        //userCheck.Parameters.Add("@email", SqlDbType.VarChar);
    //        if (conn.State == ConnectionState.Open)
    //        {
    //            cmd = new SqlCommand("Select Username, Email from Users Where Email = '" + email + "';", conn);
    //            rdr = cmd.ExecuteReader();

    //            if (rdr.HasRows)
    //            {
    //                return true;
    //            }
    //            else
    //            {
    //                return false;
    //            }


    //        }
    //        else
    //            rdr.Close();
    //        return false;

    //    }


    //}
    //public bool CheckForPassMatch(string user, string pass)
    //{

    //    using (conn = new SqlConnection(connString))
    //    {
    //        conn.Open();
    //        //passCheck.Parameters.Add("@user", SqlDbType.VarChar);
    //        //passCheck.Parameters.Add("@password", SqlDbType.VarChar);
    //        if (conn.State == ConnectionState.Open)
    //        {
    //            cmd = new SqlCommand("Select Password from Users Where Username = '" + user + "' and Password = '" + pass + "';", conn);
    //            rdr = cmd.ExecuteReader();

    //            if (rdr.HasRows)
    //                return true;
    //            else
    //                return false;


    //        }
    //        else
    //            rdr.Close();
    //        return false;
    //    }
    //}
    public List<Teams> GetAllTeams()
    {
        List<Teams> allTeams = new List<Teams>();
        query = "Select * from AFCNorth;";
        using (conn = new SqlConnection(connString))
        {
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                cmd = new SqlCommand(query, conn);
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {

                        string userName = rdr["UserName"].ToString();
                        string password = rdr["Password"].ToString();
                        string first = rdr["FirstName"].ToString();
                        string last = rdr["LastName"].ToString();                        
                        userProfile = new Profile(userName, password, first, last, email, age, admin);
                        allUsers.Add(userProfile);


                    }
                }
                else { rdr.Close(); }

            }
            if (allUsers != null)
                return allUsers;
            else
                return null;

        }
    }
}