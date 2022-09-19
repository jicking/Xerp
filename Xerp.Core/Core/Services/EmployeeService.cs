using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xerp.Core.DTO;
using Xerp.Core.Entities;
using Xerp.Data;

namespace Xerp.Core.Services;

public interface IEmployeeService {
	Task<List<EmployeeDto>> GetAllAsync();
	Task<EmployeeDto> AddAsync(EmployeeDto payload);

	void SeedInMemoryDb();
}

public class EmployeeService : IEmployeeService {
	private readonly XerpDbContext _db;

	public EmployeeService(XerpDbContext db) {
		_db = db;
	}

	public async Task<EmployeeDto> AddAsync(EmployeeDto payload) {
		var employee = payload.ToEntity();
		_db.Employees.Add(employee);
		await _db.SaveChangesAsync();
		return employee.ToDto();
	}

	public async Task<List<EmployeeDto>> GetAllAsync() {
		var employees = await _db.Employees.AsNoTracking().ToListAsync();
		return employees.ToDto();
	}

	public void SeedInMemoryDb() {
		_db.SeedInMemoryDb();
	}
}
