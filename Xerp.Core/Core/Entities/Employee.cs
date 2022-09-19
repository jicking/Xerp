namespace Xerp.Core.Entities;

public class Employee : BaseEntity {
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string MiddleName { get; set; }
	public DateTime BirthDate { get; set; }
}
