using Infrastructures.DataModels.Academics;
using Infrastructures.DataModels.Communications;
using Infrastructures.DataModels.ManyToMany;
using Infrastructures.DataModels.Persons;
using Infrastructures.DataModels.SystemUsers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Shares.Enums;
using Shares.Helpers;

namespace Infrastructures.Databases;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<SystemUser>().HasData(
            new SystemUser
            {
                Name = "Super Admin",
                Email = "superadmin@studify.com",
                Password = PasswordHelper.HashPassword("superadmin"),
                Role = SystemUserRole.SUPERADMIN.ToString()
            }
        );
    }


    #region System Users

    public virtual DbSet<SystemUser> SystemUsers { get; set; }

    #endregion

    #region Persons

    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<Faculty> Faculties { get; set; }
    public virtual DbSet<Guardian> Guardians { get; set; }

    #endregion

    #region Academics

    public virtual DbSet<AcademicTerm> AcademicTerms { get; set; }
    public virtual DbSet<Attendance> Attendances { get; set; }
    public virtual DbSet<Course> Courses { get; set; }
    public virtual DbSet<ClassSchedule> ClassSchedules { get; set; }
    public virtual DbSet<Department> Departments { get; set; }
    public virtual DbSet<Enrollment> Enrollments { get; set; }
    public virtual DbSet<GradeReport> GradeReports { get; set; }
    public virtual DbSet<Prerequisite> Prerequisites { get; set; }
    public virtual DbSet<Subject> Subjects { get; set; }

    #endregion

    #region Communications

    public virtual DbSet<ChatMessage> ChatMessages { get; set; }
    public virtual DbSet<ChatParticipant> ChatParticipants { get; set; }
    public virtual DbSet<ChatRoom> ChatRooms { get; set; }
    public virtual DbSet<Notification> Notifications { get; set; }

    #endregion

    #region Many To Many

    public virtual DbSet<CourseFaculty> CourseFaculties { get; set; }
    public virtual DbSet<CoursePrerequisite> CoursePrerequisites { get; set; }

    #endregion
}

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5432;Database=studify;Username=admin;Password=rootroot;Pooling=true;Trust Server Certificate=true;");

        return new AppDbContext(optionsBuilder.Options);
    }
}