using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncMail.data.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MailBox",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sender = table.Column<string>(nullable: true),
                    Recipient = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    Time = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailBox", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MailBox");
        }
    }
}
