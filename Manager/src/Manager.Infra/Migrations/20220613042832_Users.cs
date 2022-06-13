using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manager.Infra.Migrations
{
    public partial class Users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    username = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    email = table.Column<string>(type: "VARCHAR(180)", maxLength: 180, nullable: false),
                    phone = table.Column<string>(type: "VARCHAR(14)", maxLength: 14, nullable: true),
                    avatar = table.Column<string>(type: "VARCHAR(180)", maxLength: 180, nullable: true),
                    qrcode = table.Column<string>(type: "VARCHAR(180)", maxLength: 180, nullable: true),
                    ispresent = table.Column<bool>(type: "Bit", nullable: false),
                    score = table.Column<long>(type: "BIGINT", nullable: true),
                    password = table.Column<string>(type: "VARCHAR(1000)", maxLength: 1000, nullable: false),
                    linkedin = table.Column<string>(type: "VARCHAR(180)", maxLength: 180, nullable: true),
                    github = table.Column<string>(type: "VARCHAR(180)", maxLength: 180, nullable: true),
                    role = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
