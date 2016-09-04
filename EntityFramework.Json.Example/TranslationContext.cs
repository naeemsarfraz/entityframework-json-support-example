using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EntityFramework.Json.Example
{
    public class TranslationContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();

            modelBuilder.Entity<Translation>().ToTable("Translation");
            modelBuilder.Entity<Translation>().HasKey(k => k.ID);
            modelBuilder.Entity<Translation>().Property(p => p.Text);
            modelBuilder.Entity<Translation>().Property(p => p.APIResult).HasMaxLength(100);
        }
    }
}
