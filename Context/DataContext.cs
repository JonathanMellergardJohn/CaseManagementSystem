using CaseManagementSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CaseManagementSystem.Context
{
    public class DataContext : DbContext
    {
        private readonly string _connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\46727\Desktop\ec-utbildning\datalagring\CaseManagementSystem\Context\Case_db.mdf;Integrated Security=True;Connect Timeout=30";
        
        // Uncertain about these constructors
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        // Connecting to Db
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connString);
            }
        }
        // Sets
        public DbSet<CaseEntity> Case { get; set; }
        public DbSet<StaffEntity> Staff { get; set; }
        public DbSet<AreaEntity> Area { get; set; }
        public DbSet<StatusEntity> Status { get; set; }
        // 'OnModelCreating' makes explicit the FK relationships. If it is not
        // set, EF Core will set this by its default settings, and the way the
        // entity classes are set up, it SHOULD not be needed. Here I elect to 
        // type this out explicitly in any case for clarity!
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaseEntity>()
                .HasOne(c => c.Agent)
                .WithMany()
                .HasForeignKey(c => c.AgentId)
                // this chained method prevents the removal of Staff if there is no reference
                // to a staff memnber in the CaseEntity! Staff should basically be able to exist
                // independently of the Case entity. The same is done for all the other FK in 
                // this block!
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CaseEntity>()
                .HasOne(c => c.Principal)
                .WithMany()
                .HasForeignKey(c => c.PrincipalId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CaseEntity>()
                .HasOne(c => c.Area)
                .WithMany()
                .HasForeignKey(c => c.AreaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CaseEntity>()
                .HasOne(c => c.Status)
                .WithMany()
                .HasForeignKey(c => c.StatusId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
