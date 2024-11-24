using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using George_Petrov_Kt_43_21.Helpers;
using George_Petrov_Kt_43_21.Models;

namespace George_Petrov_Kt_43_21.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        private const string TableName = "cd_teacher";

        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder
                .HasKey(p => p.TeacherId)
                .HasName($"pk_{TableName}_teacher_id");

            builder.Property(p => p.TeacherId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.TeacherId)
                .HasColumnName("teacher_id")
                .HasComment("Идентификатор записи учителя");

			builder.Property(p => p.LastName)
				.HasColumnName("c_teacher_lastname")
				.HasColumnType(ColumnType.String).HasMaxLength(50)
				.HasComment("Фамилия преподавателя");

			builder.Property(p => p.FirstName)
				.HasColumnName("c_teacher_firstname")
				.HasColumnType(ColumnType.String).HasMaxLength(50)
				.HasComment("Имя преподавателя");

			builder.Property(p => p.Patronymic)
				.HasColumnName("c_teacher_patronymic")
				.HasColumnType(ColumnType.String).HasMaxLength(50)
				.HasComment("Отчество преподавателя");

			builder.Property(p => p.DegreeId)
				.HasColumnName("c_teacher_degree_id")
				.HasComment("Идентификатор степени");

			builder.Property(p => p.PositionId)
				.HasColumnName("c_teacher_position_id")
				.HasComment("Идентификатор должности");

			builder.Property(p => p.DepartmentId)
				.HasColumnName("c_teacher_department_id")
				.HasComment("Идентификатор кафедры");

			builder.ToTable(TableName)
				.HasOne(p => p.Degree)
				.WithMany()
				.HasForeignKey(p => p.DegreeId)
				.HasConstraintName("fk_f_degree_id")
				.OnDelete(DeleteBehavior.Cascade);

			builder.ToTable(TableName)
				.HasOne(p => p.Position)
				.WithMany()
				.HasForeignKey(p => p.PositionId)
				.HasConstraintName("fk_f_position_id")
				.OnDelete(DeleteBehavior.Cascade);

			builder.ToTable(TableName)
				.HasOne(p => p.Department)
				.WithMany()
				.HasForeignKey(p => p.DepartmentId)
				.HasConstraintName("fk_f_department_id")
				.OnDelete(DeleteBehavior.Cascade);

			builder.ToTable(TableName)
			  .HasIndex(p => p.DegreeId, $"idx_{TableName}_fk_f_degree_id");

			builder.Navigation(p => p.Degree)
				.AutoInclude();

			builder.ToTable(TableName)
			  .HasIndex(p => p.PositionId, $"idx_{TableName}_fk_f_position_id");

			builder.Navigation(p => p.Position)
				.AutoInclude();

			builder.ToTable(TableName)
			  .HasIndex(p => p.DepartmentId, $"idx_{TableName}_fk_f_department_id");

			builder.Navigation(p => p.Department)
				.AutoInclude();
		}
    }
}
