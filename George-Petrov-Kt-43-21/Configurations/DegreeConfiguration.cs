using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using George_Petrov_Kt_43_21.Helpers;
using George_Petrov_Kt_43_21.Models;

namespace George_Petrov_Kt_43_21.Configurations
{
	public class DegreeConfiguration : IEntityTypeConfiguration<Degree>
	{
		private const string TableName = "cd_degree";

		public void Configure(EntityTypeBuilder<Degree> builder)
		{
			builder
				.HasKey(t => t.DegreeId)
				.HasName($"pk_{TableName}_degree_id");

			builder.Property(t => t.DegreeId)
				.ValueGeneratedOnAdd();

			builder.Property(t => t.DegreeId)
				.HasColumnName("degree_id")
				.HasComment("Идентификатор записи степени");

			builder.Property(t => t.Name)
				.IsRequired()
				.HasColumnName("c_degree_name")
				.HasColumnType(ColumnType.String).HasMaxLength(100)
				.HasComment("Название степени");
			builder.ToTable(TableName);
		}
	}
}
