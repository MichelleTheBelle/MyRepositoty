using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace George_Petrov_Kt_43_21.Migrations
{
    /// <inheritdoc />
    public partial class Migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_degree",
                columns: table => new
                {
                    degree_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи степени")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_degree_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Название степени")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_degree_degree_id", x => x.degree_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_load",
                columns: table => new
                {
                    teachingload_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор нагрузки преподавателя")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_teachingload_hours = table.Column<int>(type: "int", nullable: false, comment: "Часы")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_load_load_id", x => x.teachingload_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_position",
                columns: table => new
                {
                    position_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи должности")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_position_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Название должности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_position_position_id", x => x.position_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_department",
                columns: table => new
                {
                    department_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи кафедры")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_department_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Название кафедры"),
                    c_department_head_id = table.Column<int>(type: "int", nullable: true, comment: "Идентификатор заведущего")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_department_department_id", x => x.department_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_teacher",
                columns: table => new
                {
                    teacher_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи учителя")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_teacher_lastname = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "Фамилия преподавателя"),
                    c_teacher_firstname = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "Имя преподавателя"),
                    c_teacher_patronymic = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "Отчество преподавателя"),
                    c_teacher_degree_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор степени"),
                    c_teacher_position_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор должности"),
                    c_teacher_department_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор кафедры")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_teacher_teacher_id", x => x.teacher_id);
                    table.ForeignKey(
                        name: "fk_f_degree_id",
                        column: x => x.c_teacher_degree_id,
                        principalTable: "cd_degree",
                        principalColumn: "degree_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_department_id",
                        column: x => x.c_teacher_department_id,
                        principalTable: "cd_department",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_position_id",
                        column: x => x.c_teacher_position_id,
                        principalTable: "cd_position",
                        principalColumn: "position_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_subject",
                columns: table => new
                {
                    subject_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи дисциплины")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_subject_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Название дисциплины"),
                    c_subject_teacher_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор преподавателя"),
                    c_subject_teachingload_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор нагрузки")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_subject_subject_id", x => x.subject_id);
                    table.ForeignKey(
                        name: "fk_f_teacher_id",
                        column: x => x.c_subject_teacher_id,
                        principalTable: "cd_teacher",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_f_teachingload_id",
                        column: x => x.c_subject_teachingload_id,
                        principalTable: "cd_load",
                        principalColumn: "teachingload_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_cd_department_fk_f_head_id",
                table: "cd_department",
                column: "c_department_head_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_subject_c_subject_teachingload_id",
                table: "cd_subject",
                column: "c_subject_teachingload_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_cd_subject_fk_f_teacher_id",
                table: "cd_subject",
                column: "c_subject_teacher_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_subject_fk_f_teachingload_id",
                table: "cd_subject",
                column: "c_subject_teachingload_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_teacher_fk_f_degree_id",
                table: "cd_teacher",
                column: "c_teacher_degree_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_teacher_fk_f_department_id",
                table: "cd_teacher",
                column: "c_teacher_department_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_teacher_fk_f_position_id",
                table: "cd_teacher",
                column: "c_teacher_position_id");

            migrationBuilder.AddForeignKey(
                name: "fk_f_head_id",
                table: "cd_department",
                column: "c_department_head_id",
                principalTable: "cd_teacher",
                principalColumn: "teacher_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_f_head_id",
                table: "cd_department");

            migrationBuilder.DropTable(
                name: "cd_subject");

            migrationBuilder.DropTable(
                name: "cd_load");

            migrationBuilder.DropTable(
                name: "cd_teacher");

            migrationBuilder.DropTable(
                name: "cd_degree");

            migrationBuilder.DropTable(
                name: "cd_department");

            migrationBuilder.DropTable(
                name: "cd_position");
        }
    }
}
