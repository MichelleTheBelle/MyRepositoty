using George_Petrov_Kt_43_21.Database;
using George_Petrov_Kt_43_21.Models;
using Microsoft.EntityFrameworkCore;
using George_Petrov_Kt_43_21.Filters.TeacherFilters;

namespace George_Petrov_Kt_43_21.Interfaces.TeacherInterfaces
{
	public interface ITeacherService
	{
		public Task<Teacher[]> GetTeachersAsync(TeacherFilter filter, CancellationToken cancellationToken);
		Task AddTeacherAsync(Teacher teacher, CancellationToken cancellationToken);
		Task<bool> UpdateTeacherAsync(Teacher teacher, CancellationToken cancellationToken);
		Task<bool> DeleteTeacherAsync(int id, CancellationToken cancellationToken);
	}

	public class TeacherService : ITeacherService
	{
		private readonly TeacherDbContext _dbContext;
		public TeacherService(TeacherDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public Task<Teacher[]> GetTeachersAsync(TeacherFilter filter, CancellationToken cancellationToken = default)
		{
			var query = _dbContext.Set<Teacher>().AsQueryable();

			if (!string.IsNullOrEmpty(filter.Name))
			{
				query = query.Where(w => w.Degree.Name == filter.Name);
			}
			if (!string.IsNullOrEmpty(filter.Position))
			{
				query = query.Where(w => w.Position.Name == filter.Position);
			}

			if (!string.IsNullOrEmpty(filter.Department))
			{
				query = query.Where(w => w.Department.Name == filter.Department);
			}

				return query.ToArrayAsync(cancellationToken);
		}
		public async Task AddTeacherAsync(Teacher teacher, CancellationToken cancellationToken = default)
		{
			await _dbContext.Set<Teacher>().AddAsync(teacher, cancellationToken);
			await _dbContext.SaveChangesAsync(cancellationToken);
		}
		public async Task<bool> UpdateTeacherAsync(Teacher teacher, CancellationToken cancellationToken = default)
		{
			var existingTeacher = await _dbContext.Set<Teacher>().FindAsync(new object[] { teacher.TeacherId }, cancellationToken);
			if (existingTeacher == null)
			{
				return false;
			}

			if (!string.IsNullOrEmpty(teacher.LastName))
			{
				existingTeacher.LastName = teacher.LastName;
			}

			if (!string.IsNullOrEmpty(teacher.FirstName))
			{
				existingTeacher.FirstName = teacher.FirstName;
			}

			if (!string.IsNullOrEmpty(teacher.Patronymic))
			{
				existingTeacher.Patronymic = teacher.Patronymic;
			}

			existingTeacher.DegreeId = teacher.DegreeId;
			existingTeacher.PositionId = teacher.PositionId;
			existingTeacher.DepartmentId = teacher.DepartmentId;

			await _dbContext.SaveChangesAsync(cancellationToken);
			return true;
		}

		public async Task<bool> DeleteTeacherAsync(int id, CancellationToken cancellationToken = default)
		{
			var teacher = await _dbContext.Set<Teacher>().FindAsync(new object[] { id }, cancellationToken);
			if (teacher == null)
			{
				return false;
			}

			_dbContext.Set<Teacher>().Remove(teacher);
			await _dbContext.SaveChangesAsync(cancellationToken);
			return true;
		}
	}
}
