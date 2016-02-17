namespace mv.DataModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<BlackList> BlackList { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Complaints> Complaints { get; set; }
        public virtual DbSet<Conversations> Conversations { get; set; }
        public virtual DbSet<Likes> Likes { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<Pictures> Pictures { get; set; }
        public virtual DbSet<Points> Points { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<Rates> Rates { get; set; }
        public virtual DbSet<RateUserRelations> RateUserRelations { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<UserRelationShips> UserRelationShips { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlackList>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Comments>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<Complaints>()
                .HasMany(e => e.BlackList)
                .WithRequired(e => e.Complaints)
                .HasForeignKey(e => e.ComplaintID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Conversations>()
                .HasMany(e => e.Messages)
                .WithRequired(e => e.Conversations)
                .HasForeignKey(e => e.ConversationID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Messages>()
                .Property(e => e.Message)
                .IsUnicode(false);

            modelBuilder.Entity<Pictures>()
                .Property(e => e.PictureLoc)
                .IsUnicode(false);

            modelBuilder.Entity<Pictures>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Points>()
                .Property(e => e.UserType)
                .IsUnicode(false);

            modelBuilder.Entity<Posts>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Posts>()
                .Property(e => e.Context)
                .IsUnicode(false);

            modelBuilder.Entity<Posts>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.Posts)
                .HasForeignKey(e => e.PostID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Posts>()
                .HasMany(e => e.Likes)
                .WithRequired(e => e.Posts)
                .HasForeignKey(e => e.PostID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Posts>()
                .HasMany(e => e.Pictures)
                .WithRequired(e => e.Posts)
                .HasForeignKey(e => e.PostID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rates>()
                .Property(e => e.PictureLoc)
                .IsUnicode(false);

            modelBuilder.Entity<Rates>()
                .HasMany(e => e.RateUserRelations)
                .WithRequired(e => e.Rates)
                .HasForeignKey(e => e.RateID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.PictureLoc)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Complaints)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.ComplainerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Conversations)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserID1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Conversations1)
                .WithRequired(e => e.Users1)
                .HasForeignKey(e => e.UserID2)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Messages)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.SendingID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Points)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Posts)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Rates)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.RateUserRelations)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.RateUserRelations1)
                .WithRequired(e => e.Users1)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.UserRelationShips)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserID1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.UserRelationShips1)
                .WithRequired(e => e.Users1)
                .HasForeignKey(e => e.UserID2)
                .WillCascadeOnDelete(false);
        }
    }
}
