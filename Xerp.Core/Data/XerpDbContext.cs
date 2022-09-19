using Microsoft.EntityFrameworkCore;

namespace Xerp.Data;

public class XerpDbContext : DbContext {
	public XerpDbContext(DbContextOptions<XerpDbContext> options)
		: base(options) {
	}

	public DbSet<Core.Entities.Employee> Employees { get; set; }

	// enable commented lines when targeting non inmemory db.
	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		//modelBuilder.Entity<Employee>().HasData(DefaultValues.Employees);
		//modelBuilder.Entity<Employee>().HasQueryFilter(c => !c.IsDeleted);
	}

	public override int SaveChanges() {
		//SetMetaFields();
		return base.SaveChanges();
	}

	public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) {
		//SetMetaFields();
		return base.SaveChangesAsync(cancellationToken);
	}

	//private void SetMetaFields() {
	//	foreach (var entry in ChangeTracker.Entries<BaseEntity>()) {
	//		switch (entry.State) {
	//			case EntityState.Added:
	//				entry.Entity.CreatedOn = DateTimeOffset.Now;
	//				break;

	//			case EntityState.Modified:
	//				entry.Entity.LastUpdatedOn = DateTimeOffset.Now;
	//				break;
	//		}
	//	}
	//}

	public void SeedInMemoryDb() {
		if (Employees.Any())
			return;

		this.Employees.AddRange(DefaultValues.Employees);

		this.SaveChanges();
	}
}
