using MessageProjectSignalR.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MessageProjectSignalR.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-COQ9ECD\\SQLEXPRESS;Database=SignarlRMessage;Integrated Security=True;TrustServerCertificate=True;");
            }
        }


        public DbSet<Message> Messages { get; set; }  // Erişim seviyesini public olarak değiştirin
    }
}
