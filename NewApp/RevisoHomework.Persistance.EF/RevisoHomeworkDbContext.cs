using RevisoHomework.Domain.Model;
using System.Data.Common;
using System.Data.Entity;

namespace RevisoHomework.Persistance.EF
{
    public class RevisoHomeworkDbContext : DbContext
    {
        #region RevisoHomework
        public DbSet<ProjectTimesheetModel> ProjectTimesheets { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<ProjectModel> Projects { get; set; }
        #endregion 

        public RevisoHomeworkDbContext()
        {    
        } 
        public RevisoHomeworkDbContext(DbConnection connection) 
            : base(connection,false)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<RevisoHomeworkDbContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(RevisoHomeworkDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
