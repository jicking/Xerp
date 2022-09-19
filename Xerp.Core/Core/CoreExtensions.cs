using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xerp.Core.DTO;
using Xerp.Core.Entities;

namespace Xerp.Core;
public static class CoreExtensions {
	public static EmployeeDto ToDto(this Employee model) {
		if (model == null) return null;
		return model.Adapt<EmployeeDto>();
	}

	public static List<EmployeeDto> ToDto(this IList<Employee> model) {
		var result = new List<EmployeeDto>();
		foreach (var item in model)
			result.Add(item.ToDto());
		return result;
	}

	public static Employee ToEntity(this EmployeeDto dto) {
		if (dto == null) return null;
		return dto.Adapt<Employee>();
	}
}
