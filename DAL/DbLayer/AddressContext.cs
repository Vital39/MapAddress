namespace DAL.DbLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AddressContext : DbContext
    {
        public AddressContext()
            : base("name=AddressContext")
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Street> Streets { get; set; }
        public virtual DbSet<Subdivision> Subdivisions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
