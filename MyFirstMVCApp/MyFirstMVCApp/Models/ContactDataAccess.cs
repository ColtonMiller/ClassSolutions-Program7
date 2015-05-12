using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;

namespace MyFirstMVCApp.Models
{
    public class ContactDataAccess
    {

        public static bool InsertContact(string name, string email, string title, string phone)
        {
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
            {
                con.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand(
                    "INSERT INTO Contacts VALUES(@name, @email, @title, @phone)", con))
                    {
                        command.Parameters.Add(new SqlParameter("name", name));
                        command.Parameters.Add(new SqlParameter("email", email));
                        command.Parameters.Add(new SqlParameter("message", title));
                        command.Parameters.Add(new SqlParameter("phone", phone));
                        command.ExecuteNonQuery();
                    }
                    return true;
                }
                catch
                {
                    // failed..
                    return false;
                }
            }
        }

        public static bool DeleteContact(int id)
        {
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
            {
                con.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand(
                    "DELETE from contacts where contactId = @id", con))
                    {
                        command.Parameters.Add(new SqlParameter("id", id));
                        command.ExecuteNonQuery();
                    }
                    return true;
                }
                catch
                {
                    // failed..
                    return false;
                }
            }
        }

    }
}