using Cosmetic.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic.DataModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Cosmetic.DataModel.Entities;
    public partial class CosmeticsContext: DbContext
    {
        public CosmeticsContext():base ("name=CosConnectionString")
        {
            Database.SetInitializer<CosmeticsContext>(new CreateDatabaseIfNotExists<CosmeticsContext>());
            ((IObjectContextAdapter)this).ObjectContext.ContextOptions.LazyLoadingEnabled = true;
        }
        //====Create DBSets===============================
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ModulesOnRole> ModulesOnRoles { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Customer> Customers { get; set; }

        //===============================================
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetAssembly(typeof(CosmeticsContext)).GetTypes().Where(type => type.Namespace != null
              && type.Namespace.Equals(typeof(CosmeticsContext).Namespace))
            .Where(type => type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            
        }
    }
}
