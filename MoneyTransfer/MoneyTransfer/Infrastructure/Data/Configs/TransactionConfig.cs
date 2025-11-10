using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyTransfer.CoreBusiness.Models;

namespace MoneyTransfer.Infrastructure.Data.Configs
{
    public class TransactionConfig : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder
                .Property(t => t.Number)
                .IsRequired();

            builder
                .Property(t => t.Amount)
                .IsRequired()
                .HasAnnotation("RangeMin", 0)
                .HasAnnotation("RangeMax", double.MaxValue);

            builder
                .Property(t => t.TransactionTime)
                .IsRequired();

            builder
                .Property(t => t.Type)
                .IsRequired();

            builder
                .Property(t => t.BalanceBefore)
                .IsRequired()
                .HasAnnotation("RangeMin", 0)
                .HasAnnotation("RangeMax", double.MaxValue);

            builder
                .Property(t => t.BalanceAfter)
                .IsRequired()
                .HasAnnotation("RangeMin", 0)
                .HasAnnotation("RangeMax", double.MaxValue);
        }
    }
}
