using Microsoft.EntityFrameworkCore;
using NLayer.Core.Entities;
using NLayer.Core.Entities.Base;
using System.Reflection;

namespace NLayer.Repository.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<ProductFeature>().HasData(
                new ProductFeature() { Id = 1, Color = "Kırmızı", Height = 100, Width = 200, ProductId = 1 },
                new ProductFeature() { Id = 2, Color = "Mavi", Height = 200, Width = 300, ProductId = 2 }
                );

            base.OnModelCreating(modelBuilder);
        }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                Entry(entityReference).Property(x => x.UpdatedDate).IsModified = false;
                                entityReference.CreatedDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                Entry(entityReference).Property(x => x.CreatedDate).IsModified = false;
                                entityReference.UpdatedDate = DateTime.Now;
                                break;
                            }
                        default:
                            break;
                    }
                }
            }

            //var datas = ChangeTracker.Entries<BaseEntity>();
            //foreach (var data in datas)
            //{
            //    _ = data.State switch
            //    {
            //        EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
            //        EntityState.Modified => data.Entity.UpdatedDate = DateTime.Now,
            //        _ => DateTime.Now
            //    };
            //}
            return await base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            //var datas = ChangeTracker.Entries<BaseEntity>();
            //foreach (var data in datas)
            //{
            //    _ = data.State switch
            //    {
            //        EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
            //        EntityState.Modified => data.Entity.UpdatedDate = DateTime.Now,
            //        _ => DateTime.Now
            //    };
            //}

            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                Entry(entityReference).Property(x => x.UpdatedDate).IsModified = false;
                                entityReference.CreatedDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                Entry(entityReference).Property(x => x.CreatedDate).IsModified = false;
                                entityReference.UpdatedDate = DateTime.Now;
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}
