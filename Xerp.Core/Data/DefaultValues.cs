using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xerp.Core.Entities;

namespace Xerp.Data;
internal class DefaultValues {
	public static readonly Guid employeeId = Guid.Parse("851adb9f-2e63-4df5-b2b4-d6f4aa69904e");

	public static List<Employee> Employees {
		get {
			return new List<Employee>() {
				new Employee() {
					Id = employeeId,
					FirstName = "Jick",
					LastName = "Ing",
					MiddleName = "X",
					BirthDate = DateTime.Now
				}
			};
		}
	}
}
