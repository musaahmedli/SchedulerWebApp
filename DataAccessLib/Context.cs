using EntityLib;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccessLib
{
    public class Context :DbContext
    {
        public Context(DbContextOptions<Context> options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DaysOfWeek>()
                .HasData(
                new DaysOfWeek { DayId =1 ,Day = "Bazar ertəsi" },
                new DaysOfWeek { DayId = 2, Day = "Çərşənbə axşamı" },
                new DaysOfWeek { DayId = 3, Day = "Çərşənbə" },
                new DaysOfWeek { DayId = 4, Day = "Cümə axşamı" },
                new DaysOfWeek { DayId = 5, Day = "Cümə" },
                new DaysOfWeek { DayId = 6, Day = "Şənbə" },
                new DaysOfWeek { DayId = 7, Day = "Bazar" }
                );

            modelBuilder.Entity<Organization>()
                .HasQueryFilter(m => !m.IsDeleted);

            modelBuilder.Entity<Department>()
                .HasQueryFilter(m => !m.IsDeleted);

            modelBuilder.Entity<Sector>()
                .HasQueryFilter(m => !m.IsDeleted);

            modelBuilder.Entity<Position>()
                .HasQueryFilter(m => !m.IsDeleted);

            modelBuilder.Entity<Employee>()
                .HasQueryFilter(m => !m.IsDeleted);

            modelBuilder.Entity<Project>()
                .HasQueryFilter(m => !m.IsDeleted);

            modelBuilder.Entity<EmployeeMeeting>()
                .HasOne(m => m.Employee)
                .WithMany(m => m.EmployeeMeetings)
                .HasForeignKey(m => m.EmployeeId);

            modelBuilder.Entity<EmployeeMeeting>()
                .HasOne(m => m.Meeting)
                .WithMany(m => m.EmployeeMeetings)
                .HasForeignKey(m => m.MeetingId);
        }
        

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<EmployeeMeeting> EmployeeMeetings { get; set; }
        public DbSet<DaysOfWeek> DaysOfWeeks { get; set; }


    }
}
