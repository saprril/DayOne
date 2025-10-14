using StatePattern.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace StatePattern.Data
{
    /// <summary>
    /// Application database context that integrates Identity with domain models.
    /// </summary>
    public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>

    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // --- Domain Entities ---
        public DbSet<Document> Documents { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure relationships
            builder.Entity<Document>()
                .HasOne(d => d.Author)
                .WithMany(u => u.AuthoredDocuments)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Document>()
                .HasOne(d => d.Reviewer)
                .WithMany(u => u.ReviewedDocuments)
                .HasForeignKey(d => d.ReviewedBy)
                .OnDelete(DeleteBehavior.Cascade);

            // Optional: Configure enum conversion to string for better readability in DB
            builder.Entity<Document>()
                .Property(d => d.StateType)
                .HasConversion<string>();

            // Optional: Default Role for new users
            builder.Entity<User>()
                .Property(u => u.Role)
                .HasDefaultValue("User");
        }
    }
}
