using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserInformationMap : IEntityTypeConfiguration<UserInformation>
{
    public void Configure(EntityTypeBuilder<UserInformation> builder)
    {
        builder.HasKey(p => p.UserId); // Still required for EF Core to work

        builder.Property(p => p.UserId)
            .HasColumnName("user_id");

        builder.Property(p => p.FullName)
            .HasColumnName("full_name");

        builder.Property(p => p.MobileNumber)
            .HasColumnName("mobile_number");

        builder.Property(p => p.PasswordHash)
            .HasColumnName("password_hash");

        builder.Property(p => p.RoleId)
            .HasColumnName("role_id");

        builder.Property(p => p.CreatedDate)
            .HasColumnName("created_date");
    }
}
