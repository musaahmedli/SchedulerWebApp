using EntityLib;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccessLib
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DaysOfWeek>()
                .HasData(
                new DaysOfWeek { DayId = 1, Day = "Bazar ertəsi" },
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

            modelBuilder.Entity<Employee>()
                .HasIndex(m => m.Username).IsUnique();

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

            modelBuilder.Entity<MeetingDays>()
                .HasOne(m => m.Days)
                .WithMany(m => m.MeetingDays)
                .HasForeignKey(m => m.DayId);

            modelBuilder.Entity<MeetingDays>()
                .HasOne(m => m.MeetingWeek)
                .WithMany(m => m.MeetingDays)
                .HasForeignKey(m => m.MeetingWeekId);

            modelBuilder.Entity<MeetingWeek>()
                .HasQueryFilter(m => m.IsActive);

            modelBuilder.Entity<Meeting>()
                .HasQueryFilter(m => !m.IsDeleted);

            modelBuilder.Entity<Organization>()
                .HasData(
                new Organization()
                {
                    OrganizationId = 1,
                    Name = "İqtisadiyyat Nazirliyi",
                },
                new Organization()
                {
                    OrganizationId = 2,
                    Name = "Əmlak Məsələləri Dövlət Xidməti"
                },
                new Organization()
                {
                    OrganizationId=3,
                    Name= "Maliyyə Nazirliyi"
                }
                );

            modelBuilder.Entity<Department>()
                .HasData(
                    new Department()
                    {
                        DepartmentId = 1,
                        Name = "Layihələrin idarə edilməsi",
                        OrganizationId=1
                        
                    },
                    new Department()
                    {
                        DepartmentId = 2,
                        Name = "Proqram təminatının hazırlanması",
                        OrganizationId=2
                    }
                );

            modelBuilder.Entity<Sector>()
                .HasData(
                    new Sector()
                    {
                        SectorId = 1,
                        Name = "Backend",
                        DepartmentId = 2
                    },
                    new Sector()
                    {
                        SectorId = 2,
                        Name = "Frontend",
                        DepartmentId = 2
                    },
                    new Sector()
                    {
                        SectorId = 3,
                        Name = "Analiz",
                        DepartmentId = 1
                    }
                );

            modelBuilder.Entity<Position>()
                .HasData(
                    new Position()
                    {
                        PositionId = 1,
                        Name = "Direktor"
                    },
                    new Position()
                    {
                        PositionId = 2,
                        Name = "Direktor müavini"
                    },
                    new Position()
                    {
                        PositionId = 3,
                        Name = "Şöbə müdiri"
                    },
                    new Position()
                    {
                        PositionId = 4,
                        Name = "Sektor müdiri"
                    },
                    new Position()
                    {
                        PositionId = 5,
                        Name = "Aparıcı proqramçı mühəndis"
                    }
                );

            modelBuilder.Entity<Project>()
                .HasData(
                    new Project()
                    {
                        ProjectId = 1,
                        Name = "Coğrafi informasiya sistemi ilə xəritənin yaradılması",
                        Description = "Veb sayt",
                        Attendances = 252,
                        CreatedDate = DateTime.Now
                    }
                );

            modelBuilder.Entity<Employee>()
                .HasData(
                    new Employee()
                    {
                        EmployeeId=1,
                        Name="Musa",
                        Surname="Ahmadov",
                        Email="adnsu.musa@mail.ru",
                        Username="musaahmedli",
                        IsAdmin=true,
                        Password= "5af93949ba1dd001c7ae02b0c15f15ba332a56437fb58e90a2b6d2b0f59286b3",
                        PhoneNumber="+994703040404",
                        PositionId=5,
                        SectorId=1,
                    }
                );


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
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
        public DbSet<MeetingDays> MeetingDays { get; set; }
        public DbSet<MeetingWeek> MeetingWeeks { get; set; }


    }
}
