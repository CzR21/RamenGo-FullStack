using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RamenGo_API_Domain.Helpers;

#nullable disable

namespace RamenGo_API_Data.Migrations
{
    /// <inheritdoc />
    public partial class DBCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_broth",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    imageActive = table.Column<string>(type: "text", nullable: false),
                    imageInactive = table.Column<string>(type: "text", nullable: false),
                    tp_status = table.Column<string>(type: "varchar(255)", nullable: false),
                    dt_creation = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    dt_modification = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_broth", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_protein",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    imageActive = table.Column<string>(type: "text", nullable: false),
                    imageInactive = table.Column<string>(type: "text", nullable: false),
                    tp_status = table.Column<string>(type: "varchar(255)", nullable: false),
                    dt_creation = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    dt_modification = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_protein", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_order",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    brothId = table.Column<int>(type: "integer", nullable: false),
                    proteinId = table.Column<int>(type: "integer", nullable: false),
                    tp_status = table.Column<string>(type: "varchar(255)", nullable: false),
                    dt_creation = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    dt_modification = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_order", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_order_tb_broth_brothId",
                        column: x => x.brothId,
                        principalTable: "tb_broth",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_order_tb_protein_proteinId",
                        column: x => x.proteinId,
                        principalTable: "tb_protein",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_order_brothId",
                table: "tb_order",
                column: "brothId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_order_proteinId",
                table: "tb_order",
                column: "proteinId");

            migrationBuilder.InsertData(
                table: "tb_broth",
                columns: new[] { "name", "description", "price", "imageActive", "imageInactive", "tp_status", "dt_creation" },
                values: new object[,]
                {
                    { "Salt", "Simple like the seawater, nothing more", 10.0, "https://tech.redventures.com.br/icons/salt/active.svg", "https://tech.redventures.com.br/icons/salt/inactive.svg", "Active", DateHelper.GetDateTimeBrazil() },
                    { "Shoyu", "The good old and traditional soy sauce", 10.0, "https://tech.redventures.com.br/icons/shoyu/active.svg", "https://tech.redventures.com.br/icons/shoyu/inactive.svg", "Active", DateHelper.GetDateTimeBrazil() },
                    { "Miso", "Paste made of fermented soybeans", 12.0, "https://tech.redventures.com.br/icons/miso/active.svg", "https://tech.redventures.com.br/icons/miso/inactive.svg", "Active", DateHelper.GetDateTimeBrazil() }
                });

            migrationBuilder.InsertData(
                table: "tb_protein",
                columns: new[] { "name", "description", "price", "imageActive", "imageInactive", "tp_status", "dt_creation" },
                values: new object[,]
                {
                    { "Chasu", "A sliced flavourful pork meat with a selection of season vegetables.", 10.0, "https://tech.redventures.com.br/icons/pork/active.svg", "https://tech.redventures.com.br/icons/pork/inactive.svg", "Active", DateHelper.GetDateTimeBrazil() },
                    { "Yasai Vegetarian", "A delicious vegetarian lamen with a selection of season vegetables.", 10.0, "https://tech.redventures.com.br/icons/yasai/active.svg", "https://tech.redventures.com.br/icons/yasai/inactive.svg", "Active", DateHelper.GetDateTimeBrazil() },
                    { "Karaague", "Three units of fried chicken, moyashi, ajitama egg and other vegetables.", 12.0, "https://tech.redventures.com.br/icons/chicken/active.svg", "https://tech.redventures.com.br/icons/chicken/inactive.svg", "Active", DateHelper.GetDateTimeBrazil() }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_order");

            migrationBuilder.DropTable(
                name: "tb_broth");

            migrationBuilder.DropTable(
                name: "tb_protein");
        }
    }
}
