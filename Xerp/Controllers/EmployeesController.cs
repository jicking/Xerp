using Microsoft.AspNetCore.Mvc;
using Xerp.Core.DTO;

namespace Xerp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase {
	private readonly ILogger<EmployeesController> _logger;
	private readonly List<EmployeeDto> _employees;

	public EmployeesController(ILogger<EmployeesController> logger) {
		_logger = logger;

		// seed data
		_employees = new List<EmployeeDto>()
		{
			new EmployeeDto()
			{
				Id = new Guid(),
				FirstName = "",
				LastName = "",
				MiddleName = "",
				BirthDate = DateTime.Now.AddYears(-18)
			}
		};
	}

	// GET: api/<EmployeesController>
	[HttpGet]
	public IEnumerable<EmployeeDto> Get() {
		return _employees;
	}

	// GET api/<EmployeesController>/5
	[HttpGet("{id}")]
	public EmployeeDto? Get(Guid id) {
		return _employees.FirstOrDefault(e => e.Id == id);
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
