using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstContactForm.Models
{
    /// <summary>
    /// this class is a representation of the data table in our database
    /// </summary>
    public class ContactForm
    {
        public int ContactFormId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateCreated { get; set; }
        public string Body { get; set; }

        public ContactForm() { }
        public ContactForm(int contactFormId, string name, string email, string body, DateTime dateCreated)
        {
            this.ContactFormId = contactFormId;
            this.Name = name;
            this.Email = email;
            this.Body = body;
            this.DateCreated = DateCreated;
        }
     }
}