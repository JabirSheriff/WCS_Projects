using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClinicAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Specialities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<float>(type: "real", nullable: false),
                    Phone = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorNumber);
                    table.ForeignKey(
                        name: "FK_Doctor_User",
                        column: x => x.Email,
                        principalTable: "Users",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<float>(type: "real", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Phone = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_User",
                        column: x => x.Email,
                        principalTable: "Users",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DoctorSpecialities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SpecilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSpecialities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorSpeciality_Doctor",
                        column: x => x.DoctorNumber,
                        principalTable: "Doctors",
                        principalColumn: "DoctorNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DoctorSpeciality_Specality",
                        column: x => x.SpecilityId,
                        principalTable: "Specialities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DoctorNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentNumber);
                    table.ForeignKey(
                        name: "FK_Appointment_Doctor",
                        column: x => x.DoctorNumber,
                        principalTable: "Doctors",
                        principalColumn: "DoctorNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_Patient",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Specialities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cardiologist" },
                    { 2, "Dermatologist" },
                    { 3, "Endocrinologist" },
                    { 4, "Gastroenterologist" },
                    { 5, "Hematologist" },
                    { 6, "Neurologist" },
                    { 7, "Oncologist" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorNumber",
                table: "Appointments",
                column: "DoctorNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Email",
                table: "Doctors",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSpecialities_DoctorNumber",
                table: "DoctorSpecialities",
                column: "DoctorNumber");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSpecialities_SpecilityId",
                table: "DoctorSpecialities",
                column: "SpecilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Email",
                table: "Patients",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "DoctorSpecialities");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Specialities");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
