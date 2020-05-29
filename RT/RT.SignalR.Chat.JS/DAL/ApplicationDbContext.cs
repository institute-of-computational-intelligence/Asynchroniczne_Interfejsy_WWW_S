using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RT.SignalR.Chat.JS.BLL;

namespace RT.SignalR.Chat.JS.DAL
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        private readonly DatabaseOptions _dbOptions;
        public DbSet<ChatGroup> ChatGroups { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, DatabaseOptions dbOptions)
            : base(options)
        {
            _dbOptions = dbOptions;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_dbOptions.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ChatGroupToUsers>()
                .HasKey(t => new { t.ChatGroupId, t.UserId });
            builder.Entity<ChatGroupToUsers>()
                .HasOne(bc => bc.ChatGroup)
                .WithMany(b => b.ChatGroupToUsers)
                .HasForeignKey(bc => bc.ChatGroupId);
            builder.Entity<ChatGroupToUsers>()
                .HasOne(bc => bc.User)
                .WithMany(c => c.ChatGroupToUsers)
                .HasForeignKey(bc => bc.UserId);
        }
    }
}
