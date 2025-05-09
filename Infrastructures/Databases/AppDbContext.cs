using Infrastructures.DataModels.Academics;
using Infrastructures.DataModels.Communications;
using Infrastructures.DataModels.Leaves;
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
                Password = PasswordHelper.HashPassword("Superadmin@123"),
                Role = SystemUserRole.SuperAdmin.ToString()
            }
        );

        modelBuilder.Entity<EmployeeLeaveInfo>().HasData(
            new EmployeeLeaveInfo
            {
                Id = Guid.NewGuid().ToString(),
                LeaveName = "Annual Leave",
                LeaveType = (int)EmployeeLeaveType.Annual,
                Description = "Paid vacation leave for rest or travel",
                TypicalDays = "10–20 days"
            },
            new EmployeeLeaveInfo
            {
                Id = Guid.NewGuid().ToString(),
                LeaveName = "Sick Leave",
                LeaveType = (int)EmployeeLeaveType.Sick,
                Description = "For personal illness or medical reasons",
                TypicalDays = "5–15 days"
            },
            new EmployeeLeaveInfo
            {
                Id = Guid.NewGuid().ToString(),
                LeaveName = "Casual Leave",
                LeaveType = (int)EmployeeLeaveType.Casual,
                Description = "Short-term urgent needs (e.g., family matters, errands)",
                TypicalDays = "3–7 days"
            },
            new EmployeeLeaveInfo
            {
                Id = Guid.NewGuid().ToString(),
                LeaveName = "Maternity Leave",
                LeaveType = (int)EmployeeLeaveType.Maternity,
                Description = "For childbirth and recovery (only for female employees)",
                TypicalDays = "60–90 days"
            },
            new EmployeeLeaveInfo
            {
                Id = Guid.NewGuid().ToString(),
                LeaveName = "Paternity Leave",
                LeaveType = (int)EmployeeLeaveType.Paternity,
                Description = "For male employees after child birth",
                TypicalDays = "5–15 days"
            },
            new EmployeeLeaveInfo
            {
                Id = Guid.NewGuid().ToString(),
                LeaveName = "Unpaid Leave",
                LeaveType = (int)EmployeeLeaveType.Unpaid,
                Description = "When all other paid leave is exhausted",
                TypicalDays = "Unlimited (as approved)"
            },
            new EmployeeLeaveInfo
            {
                Id = Guid.NewGuid().ToString(),
                LeaveName = "Compensatory Leave",
                LeaveType = (int)EmployeeLeaveType.Compensatory,
                Description = "In lieu of working extra hours/weekends",
                TypicalDays = "Depends on overtime"
            },
            new EmployeeLeaveInfo
            {
                Id = Guid.NewGuid().ToString(),
                LeaveName = "Bereavement Leave",
                LeaveType = (int)EmployeeLeaveType.Bereavement,
                Description = "For death of immediate family",
                TypicalDays = "3–7 days"
            },
            new EmployeeLeaveInfo
            {
                Id = Guid.NewGuid().ToString(),
                LeaveName = "Marriage Leave",
                LeaveType = (int)EmployeeLeaveType.Marriage,
                Description = "For employee's own wedding",
                TypicalDays = "3–5 days"
            },
            new EmployeeLeaveInfo
            {
                Id = Guid.NewGuid().ToString(),
                LeaveName = "Study Leave",
                LeaveType = (int)EmployeeLeaveType.Study,
                Description = "For exam/study purposes",
                TypicalDays = "Varies (optional)"
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
    public virtual DbSet<CourseOffering> CourseOfferings { get; set; }

    #endregion

    #region Communications

    public virtual DbSet<ChatParticipant> ChatParticipants { get; set; }
    public virtual DbSet<ChatRoom> ChatRooms { get; set; }
    public virtual DbSet<Notification> Notifications { get; set; }

    #endregion

    #region Leaves
    public virtual DbSet<EmployeeLeaveInfo> EmployeeLeaveInfos { get; set; }
    #endregion

    #region Many To Many

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