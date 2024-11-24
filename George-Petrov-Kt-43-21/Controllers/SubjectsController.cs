using Microsoft.AspNetCore.Mvc;
using George_Petrov_Kt_43_21.Filters.SubjectFilters;
using George_Petrov_Kt_43_21.Interfaces.SubjectInterfaces;
using George_Petrov_Kt_43_21.Models;

namespace George_Petrov_Kt_43_21.Controllers
{
	[ApiController]
	[Route("controller3")]
	public class SubjectsController : ControllerBase
	{
		private readonly ILogger<SubjectsController> _logger;
		private readonly ISubjectService _subjectService;

		public SubjectsController(ILogger<SubjectsController> logger, ISubjectService subjectService)
		{
			_logger = logger;
			_subjectService = subjectService;
		}

		[HttpPost(Name = "GetSubjects")]
		public async Task<IActionResult> GetSubjectsAsync(SubjectFilter filter, CancellationToken cancellationToken = default)
		{
			var teachers = await _subjectService.GetSubjectsAsync(filter, cancellationToken);

			return Ok(teachers);
		}

		[HttpPost("add")]
		public async Task<IActionResult> AddSubjectAsync(Subject subject, CancellationToken cancellationToken = default)
		{
			if (subject == null)
			{
				return BadRequest("Subject cannot be null.");
			}

			await _subjectService.AddSubjectAsync(subject, cancellationToken);
			return Ok("Запись добавлена.");
		}

		[HttpPut("update/{id}")]
		public async Task<IActionResult> UpdateSubjectAsync(int id, Subject subject, CancellationToken cancellationToken = default)
		{
			if (subject == null || subject.SubjectId != id)
			{
				return BadRequest("Invalid subject data.");
			}

			var updated = await _subjectService.UpdateSubjectAsync(subject, cancellationToken);
			if (!updated)
			{
				return NotFound("Subject not found.");
			}
			return NoContent();
		}

		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> DeleteSubjectAsync(int id, CancellationToken cancellationToken = default)
		{
			var deleted = await _subjectService.DeleteSubjectAsync(id, cancellationToken);
			if (!deleted)
			{
				return NotFound("Subject not found.");
			}
			return Ok("Запись удалена."); ;
		}
	}
}
