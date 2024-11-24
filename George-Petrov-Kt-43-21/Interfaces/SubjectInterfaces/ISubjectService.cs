using Microsoft.EntityFrameworkCore;
using George_Petrov_Kt_43_21.Database;
using George_Petrov_Kt_43_21.Filters.SubjectFilters;
using George_Petrov_Kt_43_21.Models;

namespace George_Petrov_Kt_43_21.Interfaces.SubjectInterfaces
{
	public interface ISubjectService
	{
		public Task<Subject[]> GetSubjectsAsync(SubjectFilter filter, CancellationToken cancellationToken);
		Task AddSubjectAsync(Subject subject, CancellationToken cancellationToken);
		Task<bool> UpdateSubjectAsync(Subject subject, CancellationToken cancellationToken);
		Task<bool> DeleteSubjectAsync(int id, CancellationToken cancellationToken);
	}

	public class SubjectService : ISubjectService
	{
		private readonly TeacherDbContext _dbContext;
		public SubjectService(TeacherDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public Task<Subject[]> GetSubjectsAsync(SubjectFilter filter, CancellationToken cancellationToken = default)
		{
			var query = _dbContext.Set<Subject>().AsQueryable();

			if (filter.TeacherId.HasValue)
			{
				query = query.Where(s => s.TeacherId == filter.TeacherId.Value);
			}

			if (filter.MinHours.HasValue)
			{
				query = query.Where(s => s.TeachingLoad.Hours >= filter.MinHours.Value);
			}

			if (filter.MaxHours.HasValue)
			{
				query = query.Where(s => s.TeachingLoad.Hours <= filter.MaxHours.Value);
			}

			return query.ToArrayAsync(cancellationToken);
		}

		public async Task AddSubjectAsync(Subject subject, CancellationToken cancellationToken = default)
		{
			await _dbContext.Set<Subject>().AddAsync(subject, cancellationToken);
			await _dbContext.SaveChangesAsync(cancellationToken);
		}
		public async Task<bool> UpdateSubjectAsync(Subject subject, CancellationToken cancellationToken = default)
		{
			var existingSubject = await _dbContext.Set<Subject>().FindAsync(new object[] { subject.SubjectId }, cancellationToken);
			if (existingSubject == null)
			{
				return false;
			}

			existingSubject.Name = subject.Name;
			existingSubject.TeacherId = subject.TeacherId;
			existingSubject.TeachingLoadId = subject.TeachingLoadId;

			await _dbContext.SaveChangesAsync(cancellationToken);
			return true;
		}

		public async Task<bool> DeleteSubjectAsync(int id, CancellationToken cancellationToken = default)
		{
			var subject = await _dbContext.Set<Subject>().FindAsync(new object[] { id }, cancellationToken);
			if (subject == null)
			{
				return false;
			}

			_dbContext.Set<Subject>().Remove(subject);
			await _dbContext.SaveChangesAsync(cancellationToken);
			return true;
		}
	}
}

