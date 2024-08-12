using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MasterDetailsCoreAPITest.Migrations
{
    /// <inheritdoc />
    public partial class ii : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TblUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TblUser",
                type: "datetime",
                nullable: true);
        }
    }
}
