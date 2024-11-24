using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using George_Petrov_Kt_43_21.Helpers;
using George_Petrov_Kt_43_21.Models;

namespace George_Petrov_Kt_43_21.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        private const string TableName = "cd_subject";

        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder
                .HasKey(t => t.SubjectId)
                .HasName($"pk_{TableName}_subject_id");

            builder.Property(t => t.SubjectId)
                .ValueGeneratedOnAdd();

            builder.Property(t => t.SubjectId)
                .HasColumnName("subject_id")
                .HasComment("Идентификатор записи дисциплины");

            builder.Property(t => t.Name)
                .IsRequired()
                .HasColumnName("c_subject_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Название дисциплины");

			builder.Property(p => p.TeacherId)
	            .HasColumnName("c_subject_teacher_id")
	            .HasComment("Идентификатор преподавателя");

			builder.ToTable(TableName)
                .HasOne(p => p.Teacher)
                .WithMany()
                .HasForeignKey(p => p.TeacherId)
                .HasConstraintName("fk_f_teacher_id")
                .OnDelete(DeleteBehavior.Restrict);

			builder.ToTable(TableName)
				.HasIndex(p => p.TeacherId, $"idx_{TableName}_fk_f_teacher_id");

			builder.Navigation(p => p.Teacher)
				.AutoInclude();


			builder.Property(p => p.TeachingLoadId)
				.HasColumnName("c_subject_teachingload_id")
				.HasComment("Идентификатор нагрузки");

			builder.ToTable(TableName)
				.HasOne(p => p.TeachingLoad)
				.WithOne()
				.HasForeignKey<Subject>(p => p.TeachingLoadId)
				.HasConstraintName("fk_f_teachingload_id")
				.OnDelete(DeleteBehavior.Cascade);

			builder.ToTable(TableName)
				.HasIndex(p => p.TeachingLoadId, $"idx_{TableName}_fk_f_teachingload_id");

			builder.Navigation(p => p.TeachingLoad)
				.AutoInclude();
		}
    }
}
