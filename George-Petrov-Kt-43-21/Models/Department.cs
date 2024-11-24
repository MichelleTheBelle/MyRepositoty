using System.Text.Json.Serialization;

namespace George_Petrov_Kt_43_21.Models
{
	public class Department
	{
		public int DepartmentId { get; set; }
		public string? Name { get; set; }
		public int? HeadId { get; set; }
		[JsonIgnore]
		public Teacher? Head { get; set; }
		[JsonIgnore]
		public ICollection<Teacher>? Teachers { get; set; }
	}
}