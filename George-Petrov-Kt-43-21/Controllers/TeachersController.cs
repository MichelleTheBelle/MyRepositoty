using Microsoft.AspNetCore.Mvc;
using George_Petrov_Kt_43_21.Filters.TeacherFilters;
using George_Petrov_Kt_43_21.Interfaces.TeacherInterfaces;
using George_Petrov_Kt_43_21.Models;

namespace George_Petrov_Kt_43_21.Controllers
{
	[ApiController]
	[Route("controller")]
	public class TeachersController : ControllerBase
	{
		private readonly ILogger<TeachersController> _logger;
		private readonly ITeacherService _teacherService;
		
		public TeachersController(ILogger<TeachersController> logger, ITeacherService teacherService)
		{
			_logger = logger;
			_teacherService = teacherService;
		}

		[HttpPost(Name = "GetTeachers")]
		public async Task<IActionResult> GetTeachersAsync(TeacherFilter filter, CancellationToken cancellationToken = default)
		{
			var teachers = await _teacherService.GetTeachersAsync(filter, cancellationToken);

			return Ok(teachers);
		}

		[HttpPost("add")]
		public async Task<IActionResult> AddTeacherAsync(Teacher teacher, CancellationToken cancellationToken = default)
		{
			if (teacher == null)
			{
				return BadRequest("Teacher cannot be null.");
			}

			await _teacherService.AddTeacherAsync(teacher, cancellationToken);
			return Ok("Запись добавлена.");
		}

		[HttpPut("update/{id}")]
		public async Task<IActionResult> UpdateTeacherAsync(int id, Teacher teacher, CancellationToken cancellationToken = default)
		{
			if (teacher == null || teacher.TeacherId != id)
			{
				return BadRequest("Invalid teacher data.");
			}

			var updated = await _teacherService.UpdateTeacherAsync(teacher, cancellationToken);
			if (!updated)
			{
				return NotFound("Teacher not found.");
			}
			return Ok("Запись изменена.");
		}

		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteTeacherAsync(int id, CancellationToken cancellationToken = default)
		{
			var deleted = await _teacherService.DeleteTeacherAsync(id, cancellationToken);
			if (!deleted)
			{
				return NotFound("Teacher not found.");
			}
			return Ok("Запись удалена."); ;
		}
	}
}
