using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using George_Petrov_Kt_43_21.Helpers;
using George_Petrov_Kt_43_21.Models;

namespace George_Petrov_Kt_43_21.Configurations
{
	public class PositionConfiguration : IEntityTypeConfiguration<Position>
	{
		private const string TableName = "cd_position";

		public void Configure(EntityTypeBuilder<Position> builder)
		{
			builder
				.HasKey(t => t.PositionId)
				.HasName($"pk_{TableName}_position_id");

			builder.Property(t => t.PositionId)
				.ValueGeneratedOnAdd();

			builder.Property(t => t.PositionId)
				.HasColumnName("position_id")
				.HasComment("Идентификатор записи должности");

			builder.Property(t => t.Name)
				.IsRequired()
				.HasColumnName("c_position_name")
				.HasColumnType(ColumnType.String).HasMaxLength(100)
				.HasComment("Название должности");
			builder.ToTable(TableName);
		}
	}
}
