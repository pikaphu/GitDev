using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebMVCTest1.Models
{
    /// <summary>
    /// Table name
    /// </summary>
    public class ContactDB
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
    }
    public class ContactDBContext : DbContext
    {
        /// <summary>
        /// Database name 
        /// </summary>
        public DbSet<ContactDB> Contacts { get; set; }
    }
}