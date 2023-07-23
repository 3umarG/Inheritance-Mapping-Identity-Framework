using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using TPT.Models;

namespace TPT.Data
{
	public class ApplicationDbContext : IdentityDbContext<User>
	{
		public ApplicationDbContext()
		{

		}

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			// Inheritance Mapping : 
			builder.Entity<User>().UseTptMappingStrategy().ToTable("Users");
			builder.Entity<Student>().ToTable("Students");
			builder.Entity<Teacher>().ToTable("Teachers");
			builder.Entity<Manager>().ToTable("Managers");
			
			builder.Entity<Room>().ToTable("Rooms");
			builder.Entity<Subject>().ToTable("Subjects");
			builder.Entity<StudentWithSubject>().ToTable("StudentsWithSubjects");

			builder.Entity<IdentityRole>().ToTable("Roles");
			builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
			builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
			builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
			builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
			builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");

			builder.Entity<User>()
				.OwnsMany(
				"RefreshTokens",
				u => u.RefreshTokens,
				t =>
				{
					t.WithOwner().HasForeignKey("UserId");
					t.Property<int>("Id");
					t.HasKey("Id");
					t.ToTable("RefreshTokens");
				});

			builder.Entity<Student>()
				.HasMany(s => s.Subjects)
				.WithOne(sub => sub.Student)
				.HasForeignKey(sb => sb.StudentId);

			builder.Entity<Subject>()
				.HasMany(sub => sub.Students)
				.WithOne(s => s.Subject)
				.HasForeignKey(s => s.SubjectId);

			builder.Entity<Teacher>()
				.HasMany(t => t.Subjects)
				.WithOne(s => s.Teacher)
				.HasForeignKey(s => s.TeacherId);

			builder.Entity<Room>()
				.HasMany(r => r.Teachers)
				.WithOne(t => t.Room)
				.HasForeignKey(t => t.RoomId);

			builder.Entity<StudentWithSubject>()
				.HasKey(sb => new { sb.StudentId, sb.SubjectId });
		}

		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<Student> Students { get; set; }
		public virtual DbSet<Teacher> Teachers { get; set; }
		public virtual DbSet<Manager> Managers { get; set; }
		public virtual DbSet<StudentWithSubject> StudentsWithSubjects { get; set; }
	}
}
