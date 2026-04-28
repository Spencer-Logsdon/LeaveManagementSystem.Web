using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<LeaveType> LeaveTypes { get; set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		// MySQL doesn't allow TEXT columns as key columns; set max lengths so EF uses VARCHAR.
		const int keyMaxLength = 191; // safe length for older MySQL/utf8mb4

		builder.Entity<IdentityUser>(b => b.Property(u => u.Id).HasMaxLength(keyMaxLength));
		builder.Entity<IdentityRole>(b => b.Property(r => r.Id).HasMaxLength(keyMaxLength));

		builder.Entity<IdentityUserLogin<string>>(b =>
		{
			b.Property(l => l.LoginProvider).HasMaxLength(keyMaxLength);
			b.Property(l => l.ProviderKey).HasMaxLength(keyMaxLength);
		});

		builder.Entity<IdentityUserToken<string>>(b =>
		{
			b.Property(t => t.LoginProvider).HasMaxLength(keyMaxLength);
			b.Property(t => t.Name).HasMaxLength(keyMaxLength);
		});

		builder.Entity<IdentityUserRole<string>>(b =>
		{
			b.Property(ur => ur.UserId).HasMaxLength(keyMaxLength);
			b.Property(ur => ur.RoleId).HasMaxLength(keyMaxLength);
		});

		builder.Entity<IdentityUserClaim<string>>(b => b.Property(c => c.Id).HasColumnType("int"));
		builder.Entity<IdentityRoleClaim<string>>(b => b.Property(c => c.Id).HasColumnType("int"));
	}
}
