using Microsoft.EntityFrameworkCore;
using System;

namespace Epsid19.ORM
{
    public class Contexte : DbContext
    {
        public DbSet<Personnes> Personnes { get; set; }
        public DbSet<Injections> Injections { get; set; }
        public DbSet<InjectionsPersonnes> InjectionsPersonnes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=vaccins.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InjectionsPersonnes>().HasKey(ip => new { ip.InjectionsId, ip.PersonnesId });
        }
    }
}
