using Data.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class TransactionContext : Microsoft.EntityFrameworkCore.DbContext
    {

        public TransactionContext()  {
           
        }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Login> Login { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Directory.GetCurrentDirectory();
            string target = path + @"\Data\Transactions.db;";
            optionsBuilder.UseSqlite(@"DataSource="+ target);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Transaction>(transaction =>
            {
                transaction.ToTable("Transaction");
                transaction.HasKey(pk => pk.Address);
                transaction.Property(p => p.Address).IsRequired().HasColumnType("char").HasMaxLength(255);
                transaction.Property(p => p.Qty).IsRequired().HasColumnType("integer").HasPrecision(50, 18);
                transaction.HasIndex(p => p.HashId).IsUnique(false);
                transaction.Property(p => p.HashId).IsRequired(false).HasColumnType("char").HasMaxLength(255);
            });
            modelBuilder.Entity<Settings>(settings =>
            {
                settings.ToTable("Settings");
                settings.HasKey(pk => pk.Address);
                settings.Property(p => p.Address).IsRequired().HasColumnType("char").HasMaxLength(255);
                settings.Property(p => p.PrivateKey).IsRequired().HasColumnType("char").HasMaxLength(255);
                settings.Property(p => p.Contract).IsRequired().HasColumnType("char").HasMaxLength(255);
                settings.Property(p => p.ChainId).IsRequired().HasColumnType("int").HasMaxLength(255);
                settings.Property(p => p.ConnectionString).IsRequired().HasColumnType("char").HasMaxLength(255);
            });
            modelBuilder.Entity<Login>(settings =>
            {
                settings.ToTable("Login");
                settings.HasKey(pk => pk.User);
                settings.Property(p => p.User).IsRequired().HasColumnType("char").HasMaxLength(255);
                settings.Property(p => p.Password).IsRequired().HasColumnType("char").HasMaxLength(255);
                settings.Property(p => p.MachineId).IsRequired().HasColumnType("char").HasMaxLength(255);
                settings.Property(p => p.MachineId).IsRequired().HasColumnType("char").HasMaxLength(255);
                settings.Property(p => p.License).IsRequired().HasColumnType("char").HasMaxLength(255);
                settings.Property(p => p.ValidTo).IsRequired().HasColumnType("datetime").HasMaxLength(255);
            });
            
        }
    }
}
