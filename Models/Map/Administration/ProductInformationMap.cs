using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProductInformationMap : IEntityTypeConfiguration<ProductInformation>
{
    public void Configure(EntityTypeBuilder<ProductInformation> builder)
    {
        builder.HasKey(p => p.ProductId); // Still required for EF Core to work

        builder.Property(p => p.ProductId)
            .HasColumnName("product_id");

        builder.Property(p => p.ProductName)
            .HasColumnName("product_name");

        builder.Property(p => p.Amount)
            .HasColumnName("amount");

        builder.Property(p => p.Discount)
            .HasColumnName("discount");

        builder.Property(p => p.IsInStock)
            .HasColumnName("is_in_stock");

        builder.Property(p => p.StatusId)
            .HasColumnName("status_id");
    }
}
