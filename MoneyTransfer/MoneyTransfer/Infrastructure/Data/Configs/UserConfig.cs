using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyTransfer.Application.Services;
using MoneyTransfer.CoreBusiness.Models;

namespace MoneyTransfer.Infrastructure.Data.Configs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(u => u.Accounts)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);

            builder
                .HasIndex(u => u.Email)
                .IsUnique();

            builder
                .Property(u => u.FirstName)
                .IsRequired();

            builder
                .Property(u => u.LastName)
                .IsRequired();

            builder
                .Property(u => u.Email)
                .IsRequired();

            builder
                .Property(u => u.PasswordHash)
                .IsRequired();

            builder
                .Property(u => u.PasswordSalt)
                .IsRequired();

            SeedData(builder);
        }

        private void SeedData(EntityTypeBuilder<User> builder)
        {
            var hashService = new HashService();
            hashService.CreateHashWithSalt("Password123!", out byte[] passwordHash, out byte[] passwordSalt);
            builder.HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Rayan",
                    LastName = "Reynolds",
                    Email = "user1@email.com",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    PhoneNumber = "123-456-7890"
                },
                new User
                {
                    Id = 2,
                    FirstName = "Emma",
                    LastName = "Stone",
                    Email = "user2@email.com",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    PhoneNumber = "234-567-8901"
                },
                new User
                {
                    Id = 3,
                    FirstName = "Chris",
                    LastName = "Evans",
                    Email = "user3@email.com",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                });

        }
    }
}
