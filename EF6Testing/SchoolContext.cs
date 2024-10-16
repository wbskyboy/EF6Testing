using EF6Testing;
using SQLite.CodeFirst;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;

namespace EF6Testing
{
	[DbConfigurationType(typeof(SQLiteConfiguration))]
	public class SchoolContext : DbContext
    {
		public SchoolContext() :
			base(new SQLiteConnection()
			{
				ConnectionString = new SQLiteConnectionStringBuilder() { DataSource = "D:\\Databases\\SQLiteWithEF.db", ForeignKeys = true }.ConnectionString
			}, true)
		{
		}
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //初始化Sqlite
			var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<SchoolContext>(modelBuilder);

			//SqliteCreateDatabaseIfNotExists
			//SqliteDropCreateDatabaseAlways
			//SqliteDropCreateDatabaseWhenModelChanges
			Database.SetInitializer(sqliteConnectionInitializer);

			//Adds configurations for Student from separate class
			modelBuilder.Configurations.Add(new StudentConfigurations());

			modelBuilder.Entity<Teacher>()
				.ToTable("TeacherInfo");

			modelBuilder.Entity<Teacher>()
				.MapToStoredProcedures();

			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Student> Students { get; set; }
		public DbSet<Grade> Grades { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<StudentAddress> StudentAddresses { get; set; }

		public DbSet<EmployeeMaster> EmployeeMasters { get; set; }
	}
}