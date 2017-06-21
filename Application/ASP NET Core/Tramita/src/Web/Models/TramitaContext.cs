using Microsoft.Data.Entity;
using System.Collections.Generic;

namespace Tramita.Models
{
    public class TramitaContext : DbContext
    {
        #region Properties
        public DbSet<User> User { get; set; }
        public DbSet<List<User>> Users { get; set; }
        #endregion

        #region Methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
        }
        #endregion 
    }
}
