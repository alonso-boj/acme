using ACME.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ACME.Store.Infrastructure.Configurations.Mappings;

public class AddressMap : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("address");

        builder.HasKey(address => address.Id);

        builder.Property(address => address.Id)
            .HasColumnOrder(0)
            .HasColumnName("id")
            .HasColumnType("nvarchar(36)")
            .HasMaxLength(36)
            .IsRequired();

        builder.Property(address => address.Main)
            .HasColumnOrder(1)
            .HasColumnName("main")
            .HasColumnType("bit")
            .IsRequired();

        builder.Property(address => address.Street)
            .HasColumnOrder(2)
            .HasColumnName("street")
            .HasColumnType("nvarchar(128)")
            .HasMaxLength(128)
            .IsRequired();

        builder.Property(address => address.Number)
            .HasColumnOrder(3)
            .HasColumnName("number")
            .HasColumnType("int")
            .HasMaxLength(10000)
            .IsRequired();

        builder.Property(address => address.Complement)
            .HasColumnOrder(4)
            .HasColumnName("complement")
            .HasColumnType("nvarchar(128)")
            .HasMaxLength(128);

        builder.Property(address => address.Neighborhood)
            .HasColumnOrder(5)
            .HasColumnName("neighborhood")
            .HasColumnType("nvarchar(128)")
            .HasMaxLength(128)
            .IsRequired();

        builder.Property(address => address.City)
            .HasColumnOrder(6)
            .HasColumnName("city")
            .HasColumnType("nvarchar(128)")
            .HasMaxLength(128)
            .IsRequired();

        builder.Property(address => address.State)
            .HasColumnOrder(7)
            .HasColumnName("state")
            .HasColumnType("nvarchar(64)")
            .HasMaxLength(64)
            .IsRequired();

        builder.Property(address => address.ZipCode)
            .HasColumnOrder(8)
            .HasColumnName("zip-code")
            .HasColumnType("nvarchar(8)")
            .HasMaxLength(8)
            .IsRequired();

        builder.Property(address => address.CreatedAt)
            .HasColumnOrder(9)
            .HasColumnName("created-at")
            .HasColumnType("smalldatetime")
            .IsRequired();

        builder.Property(address => address.LastUpdatedAt)
            .HasColumnOrder(10)
            .HasColumnName("last-updated-at")
            .HasColumnType("smalldatetime");

        builder.Property(address => address.CustomerId)
            .HasColumnOrder(11)
            .HasColumnName("customer-id")
            .HasColumnType("nvarchar(36)")
            .HasMaxLength(36)
            .IsRequired();
    }
}
