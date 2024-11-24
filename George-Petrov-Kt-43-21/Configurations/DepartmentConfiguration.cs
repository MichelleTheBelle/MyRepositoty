using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using George_Petrov_Kt_43_21.Helpers;
using George_Petrov_Kt_43_21.Models;
using System.Reflection.Emit;

namespace George_Petrov_Kt_43_21.Configurations
{
	public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
	{
		private const string TableName = "cd_department";

		public void Configure(EntityTypeBuilder<Department> builder)
		{
			builder
				.HasKey(t => t.DepartmentId)
				.HasName($"pk_{TableName}_department_id");

			builder.Property(t => t.DepartmentId)
				.ValueGeneratedOnAdd();

			builder.Property(t => t.DepartmentId)
				.HasColumnName("department_id")
				.HasComment("Идентификатор записи кафедры");

			builder.Property(t => t.Name)
				.IsRequired()
				.HasColumnName("c_department_name")
				.HasColumnType(ColumnType.String).HasMaxLength(100)
				.HasComment("Название кафедры");
			builder.ToTable(TableName);

			builder.Property(p => p.HeadId)
				.HasColumnName("c_department_head_id")
				.HasComment("Идентификатор заведущего");

			builder.ToTable(TableName)
				.HasOne(p => p.Head)
				.WithMany()
				.HasForeignKey(p => p.HeadId)
				.HasConstraintName("fk_f_head_id")
				.OnDelete(DeleteBehavior.Restrict);

			builder.ToTable(TableName)
				.HasMany(d => d.Teachers)
				.WithOne(t => t.Department)
				.HasForeignKey(t => t.DepartmentId);

			builder.ToTable(TableName)
				.HasIndex(p => p.HeadId, $"idx_{TableName}_fk_f_head_id");
		}
	}
}

