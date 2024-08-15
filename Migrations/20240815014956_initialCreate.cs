using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintSerApp.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrintEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false, comment: "主键")
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false, comment: "模板名称"),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true, comment: "描述说明"),
                    CreateTime = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2024, 8, 15, 9, 49, 55, 842, DateTimeKind.Local).AddTicks(2308), comment: "创建时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrintEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrintEntity_Name",
                table: "PrintEntity",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrintEntity");
        }
    }
}
