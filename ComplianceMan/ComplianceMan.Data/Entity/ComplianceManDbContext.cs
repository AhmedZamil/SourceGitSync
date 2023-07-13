
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace ComplianceMan.Data.Entity
{
    public class ComplianceManDbContext : DbContext
    {
        public ComplianceManDbContext(DbContextOptions<ComplianceManDbContext> options):base(options)
        {
            
        }

        public DbSet<UserDTO> Users { get; set; }
        public DbSet<TeamDTO> Teams { get; set; }
        public DbSet<PolicyDTO> Policies { get; set; }
        public DbSet<RoleDTO> Roles { get; set; }
        public DbSet<RolePermissionDTO> RolePermission { get; set; }
        public DbSet<UserPolicyDTO> UserPolicies { get; set; }
        public DbSet<FileDTO> Files { get; set; }

        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Department> Departments => Set<Department>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

                string connectionString = configuration.GetConnectionString("Default");

                optionsBuilder.UseSqlServer(connectionString);
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserDTO>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<RolePermissionDTO>()
    .HasKey(rp => rp.RolePermissionId);

            modelBuilder.Entity<RolePermissionDTO>()
                .HasOne(rp => rp.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(rp => rp.RoleId);

            //modelBuilder.Entity<UserDTO>()
            //    .HasOne(u => u.Role)
            //    .WithMany(r => r.Users)
            //    .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<UserPolicyDTO>()
                .HasKey(up => up.UserPolicyId);

            modelBuilder.Entity<UserPolicyDTO>()
                .HasOne(up => up.User)
                .WithMany(u => u.UserPolicies)
                .HasForeignKey(up => up.UserId);

            modelBuilder.Entity<UserPolicyDTO>()
                .HasOne(up => up.Policy)
                .WithMany(p => p.UserPolicies)
                .HasForeignKey(up => up.PolicyId);

            modelBuilder.Entity<TeamDTO>()
                .HasMany(t => t.Users)
                .WithMany(u => u.Teams)
                .UsingEntity<Dictionary<string, object>>(
                    "UserTeam",
                    jt => jt.HasOne<UserDTO>().WithMany().HasForeignKey("UserId"),
                    jt => jt.HasOne<TeamDTO>().WithMany().HasForeignKey("TeamId"),
                    jt =>
                    {
                        jt.Property<int>("Id");
                        jt.HasKey("Id");
                        jt.ToTable("UserTeam");
                    });

            modelBuilder.Entity<PolicyDTO>()
                .HasMany(p => p.Teams)
                .WithMany(t => t.Policies)
                .UsingEntity<Dictionary<string, object>>(
                    "PolicyTeam",
                    jt => jt.HasOne<TeamDTO>().WithMany().HasForeignKey("TeamId"),
                    jt => jt.HasOne<PolicyDTO>().WithMany().HasForeignKey("PolicyId"),
                    jt =>
                    {
                        jt.Property<int>("Id");
                        jt.HasKey("Id");
                        jt.ToTable("PolicyTeam");
                    });

            modelBuilder.Entity<PolicyDTO>()
                .HasMany(p => p.Files)
                .WithOne(f => f.Policy)
                .HasForeignKey(f => f.PolicyId);

            // Standard data seeding

            modelBuilder.Entity<RoleDTO>().HasData(
                new RoleDTO { RoleId = 1, RoleName = "Admin" },
                new RoleDTO { RoleId = 2, RoleName = "User" }
            );

            modelBuilder.Entity<RolePermissionDTO>().HasData(
                new RolePermissionDTO { RolePermissionId = 1, RoleId = 1, Permission = "EditUsers" },
                new RolePermissionDTO { RolePermissionId = 2, RoleId = 1, Permission = "DeleteUsers" },
                new RolePermissionDTO { RolePermissionId = 3, RoleId = 2, Permission = "ViewUsers" }
            // Add more role permissions as needed
            );

            modelBuilder.Entity<TeamDTO>().HasData(
                new TeamDTO { TeamId = 1, TeamName = "Team 1" },
                new TeamDTO { TeamId = 2, TeamName = "Team 2" }
            );

            modelBuilder.Entity<UserDTO>().HasData(
                new UserDTO { UserId = 1, UserName = "User 1", UserCode = "U001", RoleId = 1 },
                new UserDTO { UserId = 2, UserName = "User 2", UserCode = "U002", RoleId = 2 }
            );

            modelBuilder.Entity<PolicyDTO>().HasData(
                new PolicyDTO { PolicyId = 1,Description="Policy Basic Description", PolicyName = "Policy 1" },
                new PolicyDTO { PolicyId = 2, Description = "Policy Basic Description", PolicyName = "Policy 2" }
            );

            modelBuilder.Entity<UserPolicyDTO>().HasData(
                new UserPolicyDTO { UserPolicyId = 1, UserId = 1, PolicyId = 1, AcceptanceDate = DateTime.Now },
                new UserPolicyDTO { UserPolicyId = 2, UserId = 2, PolicyId = 2, AcceptanceDate = DateTime.Now }
            );

            modelBuilder.Entity<FileDTO>().HasData(
                new FileDTO { FileId = 1, FileName = "File 1.docx", FileData = GetFileData("File1.docx"), PolicyId = 1 },
                new FileDTO { FileId = 2, FileName = "File 2.docx", FileData = GetFileData("File2.docx"), PolicyId = 2 }
            );

            modelBuilder.Entity<Department>().HasData(
                            new Department { Id = 1, Name = "Development" },
                            new Department { Id = 2, Name = "Dev Ops" },
                            new Department { Id = 3, Name = "Q&A" },
                            new Department { Id = 4, Name = "Human Resources" },
                            new Department { Id = 5, Name = "Marketing" });

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, FirstName = "Ahmed", LastName = "Zamil", DepartmentId = 2 },
                new Employee { Id = 2, FirstName = "Marielina", LastName = "Fardous", DepartmentId = 5, IsDeveloper = true },
                new Employee { Id = 3, FirstName = "Rihan", LastName = "Munabih", DepartmentId = 5, IsDeveloper = true },
                new Employee { Id = 4, FirstName = "Sara", LastName = "Ahmed", DepartmentId = 1 },
                new Employee { Id = 5, FirstName = "Rain", LastName = "Samara", DepartmentId = 4 },
                new Employee { Id = 6, FirstName = "Moni", LastName = "Xaman", DepartmentId = 3, IsDeveloper = true },
                new Employee { Id = 7, FirstName = "Sophie", LastName = "Lee", DepartmentId = 5 },
                new Employee { Id = 8, FirstName = "Julien", LastName = "Ahmed", DepartmentId = 2 },
                new Employee { Id = 9, FirstName = "Yoni", LastName = "Ashrov", DepartmentId = 4 },
                new Employee { Id = 10, FirstName = "Scott", LastName = "Barron", DepartmentId = 1, IsDeveloper = true });
        }

        private byte[] GetFileData(string fileName)
        {
            // Provide a hard-coded byte array with the content "Hello world"
            string content = "Hello Compliance Man compliance file";
            byte[] fileData = Encoding.UTF8.GetBytes(content);
            return fileData;
        }

    }
}
