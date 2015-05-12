using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient; //life is a lot easier with this namespace

namespace MyFirstContactForm.Models
{
    public class ContactFormDataAccess
    {
        public static bool InsertContactForm(ContactForm contactForm)
        {
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                //this using 'block' declares a varaible for the scope of the code block
                con.Open(); //opens the connection to the database
                try
                {
                    //actually doing the sql call
                    SqlCommand command = new SqlCommand("INSERT INTO ContactForms (Name, Email, Body) Values (@name, @email, @body)", con);
                    //using parameters avoids SQL injections and is paramount in your continued employment
                    command.Parameters.Add(new SqlParameter("name", contactForm.Name));
                    command.Parameters.Add(new SqlParameter("email", contactForm.Email));
                    command.Parameters.Add(new SqlParameter("body", contactForm.Body));
                    //actually execute the statement
                    command.ExecuteNonQuery();
                    return true;
                }
                catch 
                {
                    return false;
                }

            }

        }
    }
}