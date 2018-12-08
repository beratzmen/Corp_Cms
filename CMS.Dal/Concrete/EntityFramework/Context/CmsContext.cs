namespace CMS.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CmsContext : DbContext
    {
        public CmsContext()
            : base("name=CmsContext")
        {
        }

        public virtual DbSet<Bulletin> Bulletin { get; set; }
        public virtual DbSet<BulletinMember> BulletinMember { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<ELMAH_Error> ELMAH_Error { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<JobUser> JobUser { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Pages> Pages { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Reference> Reference { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Slider> Slider { get; set; }
        public virtual DbSet<SocialIcon> SocialIcon { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Job>()
                .HasMany(e => e.JobUser)
                .WithOptional(e => e.Job)
                .WillCascadeOnDelete();

            modelBuilder.Entity<JobUser>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.User)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);
        }
    }
}
