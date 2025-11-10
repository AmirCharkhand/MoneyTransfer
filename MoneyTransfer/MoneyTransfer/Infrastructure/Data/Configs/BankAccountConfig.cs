using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyTransfer.CoreBusiness.Models;

namespace MoneyTransfer.Infrastructure.Data.Configs
{
    public class BankAccountConfig : IEntityTypeConfiguration<BankAcount>
    {
        public void Configure(EntityTypeBuilder<BankAcount> builder)
        {
            builder
                .HasMany<Transaction>()
                .WithOne(Transaction => Transaction.Acount)
                .HasForeignKey(Transaction => Transaction.AccountId);

            builder
                .Property(ba => ba.Balance)
                .HasAnnotation("RangeMin", 0)
                .HasAnnotation("RangeMax", double.MaxValue);

            builder
                .HasData(
                    new BankAcount { Id = 1, Balance = 10000000 },
                    new BankAcount { Id = 2, Balance = 25000000 },
                    new BankAcount { Id = 3, Balance = 5000000 }
                );
        }
    }
}
