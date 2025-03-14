using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kredibu_server.Migrations
{
    /// <inheritdoc />
    public partial class NewRatings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    score = table.Column<int>(type: "integer", nullable: false),
                    owner_id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.id);
                    table.ForeignKey(
                        name: "FK_Rating_businessUsers_BusinessUserId",
                        column: x => x.BusinessUserId,
                        principalTable: "businessUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rating_BusinessUserId",
                table: "Rating",
                column: "BusinessUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rating");
        }
    }
}
