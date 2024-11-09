using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingMicroservice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Shipper",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Shipper",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Shipper",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Shipper",
                newName: "id");

            migrationBuilder.CreateTable(
                name: "Shipping_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_Id = table.Column<int>(type: "int", nullable: false),
                    Shipper_Id = table.Column<int>(type: "int", nullable: false),
                    Shipping_Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tracking_Number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipping_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shipping_Details_Shipper_Shipper_Id",
                        column: x => x.Shipper_Id,
                        principalTable: "Shipper",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shipping_Details_Shipper_Id",
                table: "Shipping_Details",
                column: "Shipper_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shipping_Details");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "Shipper",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Shipper",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Shipper",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Shipper",
                newName: "Id");
        }
    }
}
