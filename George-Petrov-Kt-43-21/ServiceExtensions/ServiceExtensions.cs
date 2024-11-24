using George_Petrov_Kt_43_21.Interfaces.DepartmentInterfaces;
using George_Petrov_Kt_43_21.Interfaces.SubjectInterfaces;
using George_Petrov_Kt_43_21.Interfaces.TeacherInterfaces;

namespace George_Petrov_Kt_43_21.ServiceExtensions
{
	public static class ServiceExtensions
	{
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddScoped<ITeacherService, TeacherService>();
			services.AddScoped<IDepartmentService, DepartmentService>();
			services.AddScoped<ISubjectService, SubjectService>();
			return services;
		}
	}
}
