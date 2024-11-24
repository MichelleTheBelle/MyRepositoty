using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using George_Petrov_Kt_43_21.Helpers;
using George_Petrov_Kt_43_21.Models;

namespace George_Petrov_Kt_43_21.Configurations
{
    public class TeachingLoadConfiguration : IEntityTypeConfiguration<TeachingLoad>
    {
        private const string TableName = "cd_load";

        public void Configure(EntityTypeBuilder<TeachingLoad> builder)
        {
            builder
                .HasKey(p => p.TeachingLoadId)
                .HasName($"pk_{TableName}_load_id");

            builder.Property(p => p.TeachingLoadId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.TeachingLoadId)
                .HasColumnName("teachingload_id")
                .HasComment("Идентификатор нагрузки преподавателя");

            builder.Property(p => p.Hours)
                .HasColumnName("c_teachingload_hours")
                .HasColumnType(ColumnType.Int)
                .HasComment("Часы");

			builder.ToTable(TableName);
		}
    }
}
