using Logicea.Cards.DataAccess.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Card>().HasData(
            new Card
            {
                Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa1"),                
                Name = "Task1",
                Description = "Task1 Description",
                Color = "#E6F0FA",
                Status = CardStatus.ToDo,
                CreatedBy = "user1@logicea.com",
                CreatedDate = new DateTime(2025, 6, 15, 12, 0, 0),
                UpdatedBy = "user1@logicea.com",
                UpdatedDate = new DateTime(2025, 6, 15, 12, 0, 0)
            },
            new Card
            {
                Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa2"),                
                Name = "Task2",
                Description = "Task2 Description",
                Color = "#E0FFE0",
                Status = CardStatus.InProgress,
                CreatedBy = "user1@logicea.com",
                CreatedDate = new DateTime(2025, 6, 16, 12, 0, 0),
                UpdatedBy = "user1@logicea.com",
                UpdatedDate = new DateTime(2025, 6, 16, 12, 0, 0)
            },
            new Card
            {
                Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa3"),
                Name = "Task3",
                Description = "Task3 Description",
                Color = "#F5F5FF",
                Status = CardStatus.Done,
                CreatedBy = "user1@logicea.com",
                CreatedDate = new DateTime(2025, 6, 17, 12, 0, 0),
                UpdatedBy = "user1@logicea.com",
                UpdatedDate = new DateTime(2025, 6, 17, 12, 0, 0)
            },
            new Card
            {
                Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa4"),
                Name = "Task4",
                Description = "Task4 Description",
                Color = "#FFEAEA",
                Status = CardStatus.ToDo,
                CreatedBy = "user2@logicea.com",
                CreatedDate = new DateTime(2025, 6, 18, 12, 0, 0),
                UpdatedBy = "user2@logicea.com",
                UpdatedDate = new DateTime(2025, 6, 18, 12, 0, 0)
            },
            new Card
            {
                Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa5"),
                Name = "Task5",
                Description = "Task5 Description",
                Color = "#FFF0E0",
                Status = CardStatus.InProgress,
                CreatedBy = "user2@logicea.com",
                CreatedDate = new DateTime(2025, 6, 19, 12, 0, 0),
                UpdatedBy = "user2@logicea.com",
                UpdatedDate = new DateTime(2025, 6, 19, 12, 0, 0)
            },
            new Card
            {
                Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa6"),
                Name = "Task6",
                Description = "Task6 Description",
                Color = "#F9E4B7",
                Status = CardStatus.Done,
                CreatedBy = "user2@logicea.com",
                CreatedDate = new DateTime(2025, 6, 20, 12, 0, 0),
                UpdatedBy = "user2@logicea.com",
                UpdatedDate = new DateTime(2025, 6, 20, 12, 0, 0)
            }
        );
    }

    public DbSet<Card> Cards { get; set; }    
}