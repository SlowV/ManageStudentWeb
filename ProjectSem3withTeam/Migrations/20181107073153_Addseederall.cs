using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSem3withTeam.Migrations
{
    public partial class Addseederall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Avatar = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mark",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubjectId = table.Column<int>(nullable: false),
                    StudentRollNumber = table.Column<string>(nullable: true),
                    SubjectMark = table.Column<int>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mark", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mark_Student_StudentRollNumber",
                        column: x => x.StudentRollNumber,
                        principalTable: "Student",
                        principalColumn: "RollNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mark_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mark_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "RollNumber", "Avatar", "CreatedAt", "Email", "FirstName", "LastName", "Phone", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { "A001", "https://scontent.fhan5-2.fna.fbcdn.net/v/t1.0-9/43728863_918300711698721_2592658880836141056_n.jpg?_nc_cat=102&_nc_ht=scontent.fhan5-2.fna&oh=afbb930ed930627f4682eeef3d58c271&oe=5C725A56", new DateTime(2018, 11, 7, 14, 31, 52, 865, DateTimeKind.Local), "quocviet.hn98@gmail.com", "Trịnh", "Việt", "0349555602", 1, new DateTime(2018, 11, 7, 14, 31, 52, 866, DateTimeKind.Local) },
                    { "A002", "https://scontent.fhan5-7.fna.fbcdn.net/v/t1.0-9/74230_571993326151147_1564071477_n.jpg?_nc_cat=100&_nc_ht=scontent.fhan5-7.fna&oh=d47a59698c8c56599511f5bfde14c90e&oe=5C88977B", new DateTime(2018, 11, 7, 14, 31, 52, 866, DateTimeKind.Local), "thanhtung.hn98@gmail.com", "Thanh", "Tùng", "0349321324", 1, new DateTime(2018, 11, 7, 14, 31, 52, 866, DateTimeKind.Local) },
                    { "A003", "https://scontent.fhan5-6.fna.fbcdn.net/v/t1.0-9/42434595_2098209036910379_4231368300749127680_n.jpg?_nc_cat=107&_nc_ht=scontent.fhan5-6.fna&oh=60a1bf8f30a256768b5fd4af128e9932&oe=5C40E10E", new DateTime(2018, 11, 7, 14, 31, 52, 866, DateTimeKind.Local), "quecong.hn98@gmail.com", "Quế", "Công", "043243255", 1, new DateTime(2018, 11, 7, 14, 31, 52, 866, DateTimeKind.Local) },
                    { "A004", "https://scontent.fhan5-1.fna.fbcdn.net/v/t1.0-9/23380126_514878092204816_4605254026945740300_n.jpg?_nc_cat=109&_nc_ht=scontent.fhan5-1.fna&oh=d20b108d93199e0adffa8f9a425d5dc7&oe=5C405AE8", new DateTime(2018, 11, 7, 14, 31, 52, 866, DateTimeKind.Local), "huongly.hn98@gmail.com", "Hương", "Ly", "0432443243", 1, new DateTime(2018, 11, 7, 14, 31, 52, 866, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 11, 7, 14, 31, 52, 863, DateTimeKind.Local), "Dễ học.", "HTML", new DateTime(2018, 11, 7, 14, 31, 52, 864, DateTimeKind.Local) },
                    { 2, new DateTime(2018, 11, 7, 14, 31, 52, 864, DateTimeKind.Local), "Khá loằng ngoằng.", "Java", new DateTime(2018, 11, 7, 14, 31, 52, 864, DateTimeKind.Local) },
                    { 3, new DateTime(2018, 11, 7, 14, 31, 52, 864, DateTimeKind.Local), "Dễ hơn java 1 chút.", "C#", new DateTime(2018, 11, 7, 14, 31, 52, 864, DateTimeKind.Local) },
                    { 4, new DateTime(2018, 11, 7, 14, 31, 52, 864, DateTimeKind.Local), "Dễ học.", "PHP", new DateTime(2018, 11, 7, 14, 31, 52, 864, DateTimeKind.Local) },
                    { 5, new DateTime(2018, 11, 7, 14, 31, 52, 864, DateTimeKind.Local), "Chưa xác định.", "ASP.NET", new DateTime(2018, 11, 7, 14, 31, 52, 864, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "Id", "Avatar", "CreatedAt", "Email", "Name", "Phone", "Status", "UpdatedAt" },
                values: new object[] { 1, "https://i.stack.imgur.com/EFHit.jpg?s=328&g=1", new DateTime(2018, 11, 7, 14, 31, 52, 865, DateTimeKind.Local), "Xuanhung2401@gmail.com", "Xuân Hùng", "012349876", 1, new DateTime(2018, 11, 7, 14, 31, 52, 865, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Mark",
                columns: new[] { "Id", "CreatedAt", "StudentRollNumber", "SubjectId", "SubjectMark", "TeacherId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 11, 7, 14, 31, 52, 866, DateTimeKind.Local), "A001", 1, 63, 1, new DateTime(2018, 11, 7, 14, 31, 52, 866, DateTimeKind.Local) },
                    { 2, new DateTime(2018, 11, 7, 14, 31, 52, 867, DateTimeKind.Local), "A002", 2, 45, 1, new DateTime(2018, 11, 7, 14, 31, 52, 867, DateTimeKind.Local) },
                    { 3, new DateTime(2018, 11, 7, 14, 31, 52, 867, DateTimeKind.Local), "A003", 3, 85, 1, new DateTime(2018, 11, 7, 14, 31, 52, 867, DateTimeKind.Local) },
                    { 4, new DateTime(2018, 11, 7, 14, 31, 52, 867, DateTimeKind.Local), "A004", 5, 95, 1, new DateTime(2018, 11, 7, 14, 31, 52, 867, DateTimeKind.Local) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mark_StudentRollNumber",
                table: "Mark",
                column: "StudentRollNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Mark_SubjectId",
                table: "Mark",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Mark_TeacherId",
                table: "Mark",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mark");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "RollNumber",
                keyValue: "A001");

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "RollNumber",
                keyValue: "A002");

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "RollNumber",
                keyValue: "A003");

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "RollNumber",
                keyValue: "A004");
        }
    }
}
