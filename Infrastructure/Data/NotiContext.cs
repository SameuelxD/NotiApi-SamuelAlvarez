using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;
    public class NotiContext : DbContext { 
        public NotiContext (DbContextOptions options) : base(options){ }
        //public DbSet<:entity> :entities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
    
