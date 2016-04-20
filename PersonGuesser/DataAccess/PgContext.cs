using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataAccess.Entities;

namespace DataAccess
{
    public class PgContext : DbContext
    {
        /// <summary>
        /// all colections used in db
        /// </summary>
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
    }
}
