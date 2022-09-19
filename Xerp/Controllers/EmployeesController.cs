using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Xerp.Core.DTO;
using Xerp.Core.Services;

namespace Xerp.Controllers;

[Route("api/[controller]"), ApiController, Authorize]
public class EmployeesController : ControllerBase {
	private readonly ILogger<EmployeesController> _logger;
	private readonly IEmployeeService _employeeSvc;

	public EmployeesController(
		ILogger<EmployeesController> logger,
		IEmployeeService employeeSvc
		) {
		_logger = logger;
		_employeeSvc = employeeSvc;

		// seed data (remove when connects to db.)
		_employeeSvc.SeedInMemoryDb();
	}

	// GET: api/<EmployeesController>
	[HttpGet]
	public async Task<IEnumerable<EmployeeDto>> GetAsync() {
		return await _employeeSvc.GetAllAsync();
	}

	// GET api/<EmployeesController>/5
	//[HttpGet("{id}")]
	//public EmployeeDto? Get(Guid id) {
	//	return _employees.FirstOrDefault(e => e.Id == id);
	//}

	// POST: api/<EmployeesController>
	[HttpPost]
	public async Task<EmployeeDto> PostAsync(EmployeeDto payload) {
		return await _employeeSvc.AddAsync(payload);
	}

	[HttpGet("test")]
	public IEnumerable<string> Test() {
		_logger.LogTrace("test log");
		_logger.LogDebug("test log");
		_logger.LogInformation("test log");
		_logger.LogError("test log");
		_logger.LogCritical("test log");

		return new string[] { "value1", "value2" };
	}
}
