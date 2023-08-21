using ACME.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ACME.Store.Infrastructure.Configurations.Mappings;

public class CustomerMap : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("customer");

        builder.HasKey(customer => customer.Id);

        builder.Property(customer => customer.Id)
            .HasColumnOrder(0)
            .HasColumnName("id")
            .HasColumnType("nvarchar(36)")
            .HasMaxLength(36)
            .IsRequired();

        builder.Property(customer => customer.Name)
            .HasColumnOrder(1)
            .HasColumnName("name")
            .HasColumnType("nvarchar(128)")
            .HasMaxLength(128)
            .IsRequired();

        builder.Property(customer => customer.Phone)
            .HasColumnOrder(2)
            .HasColumnName("phone")
            .HasColumnType("nvarchar(11)")
            .HasMaxLength(11)
            .IsRequired();

        builder.Property(customer => customer.Mail)
            .HasColumnOrder(3)
            .HasColumnName("mail")
            .HasColumnType("nvarchar(128)")
            .HasMaxLength(128)
            .IsRequired();

        builder.Property(address => address.CreatedAt)
            .HasColumnOrder(4)
            .HasColumnName("created-at")
            .HasColumnType("smalldatetime")
            .IsRequired();

        builder.Property(address => address.LastUpdatedAt)
            .HasColumnOrder(5)
            .HasColumnName("last-updated-at")
            .HasColumnType("smalldatetime");
    }
}
