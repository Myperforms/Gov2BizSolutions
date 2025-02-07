using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using CodeAssessment.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeAssessment.Infrastructure.Context
{
    public partial class CodeAssessmentDBContext : DbContext
    {
        public CodeAssessmentDBContext(DbContextOptions<CodeAssessmentDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<AdminUser> AdminUsers { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK__t_Employ__3214EC27D05C9772");

                entity.ToTable("t_EmployeeDetails");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");             

            });

            modelBuilder.Entity<AdminUser>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK__t_AdminD__3214EC275644050C");

                entity.ToTable("t_AdminDetails");
            });
        }
    }
}
