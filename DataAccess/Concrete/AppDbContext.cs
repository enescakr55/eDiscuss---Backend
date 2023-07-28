
using Entities;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Concrete
{
  public class AppDbContext:DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      //base.OnConfiguring(optionsBuilder);
      if (!optionsBuilder.IsConfigured)
      {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DbString");
        optionsBuilder.UseSqlServer(connectionString);
            
      }
      
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<UserCode>().Navigation(e => e.User).AutoInclude();
      modelBuilder.Entity<SavedCode>().Navigation(e=>e.UserCode).AutoInclude();

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<UserSubject> UserSubjects { get; set; }
    public DbSet<Discuss> Discusses { get; set; }
    public DbSet<Reply> Replies { get; set; }
    public DbSet<PasswordResetCode> PasswordResetCodes { get; set; }
    public DbSet<Conversation> Conversations { get; set; }
    public DbSet<ConversationUser> ConversationUsers { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<FollowedDiscussion> FollowedDiscussions { get; set; }
    public DbSet<OnlineUser> OnlineUsers { get; set; }
    public DbSet<UserCode> UserCodes { get; set; }
    public DbSet<SavedCode> SavedCodes { get; set; }


  }
}
