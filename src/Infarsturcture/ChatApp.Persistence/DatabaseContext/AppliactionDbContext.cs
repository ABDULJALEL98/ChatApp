using ChatApp.Domain.Common;
using ChatApp.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Persistence.DatabaseContext;

 public class AppliactionDbContext :IdentityDbContext<AppUser>
{
    public AppliactionDbContext(DbContextOptions<AppliactionDbContext>  options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppliactionDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.State == EntityState.Modified)
                entry.Entity.ModifiedDate = DateTime.UtcNow;
        }
        return base.SaveChangesAsync(cancellationToken);
    }
    public DbSet <ChatApp.Domain.Entities.Message> Messages { get; set; }
    public DbSet<ChatApp.Domain.Entities.Photo> Photos { get; set; }

}
