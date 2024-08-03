using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerShop.DataAccess.Migrations
{
    public partial class BurgerApp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelivered = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Burger",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    IsVegetarian = table.Column<bool>(type: "bit", nullable: false),
                    IsVegan = table.Column<bool>(type: "bit", nullable: false),
                    HasFries = table.Column<bool>(type: "bit", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Burger", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Burger_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpensAt = table.Column<int>(type: "int", nullable: false),
                    ClosesAt = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Burger",
                columns: new[] { "Id", "HasFries", "IsVegan", "IsVegetarian", "Name", "OrderId", "Price" },
                values: new object[,]
                {
                    { 1, true, false, false, "Classic Cheeseburger", null, 8 },
                    { 2, false, true, true, "Veggie Delight", null, 9 },
                    { 3, true, false, false, "BBQ Bacon Burger", null, 10 },
                    { 4, false, false, true, "Mushroom Swiss Burger", null, 9 },
                    { 5, true, true, true, "Spicy Black Bean Burger", null, 8 },
                    { 6, false, false, false, "Double Beef Burger", null, 11 },
                    { 7, true, false, true, "Grilled Portobello Burger", null, 8 },
                    { 8, false, false, false, "Chicken Avocado Burger", null, 10 },
                    { 9, true, true, true, "Falafel Burger", null, 8 },
                    { 10, false, false, false, "Fish Fillet Burger", null, 9 }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "ClosesAt", "Name", "OpensAt", "OrderId" },
                values: new object[,]
                {
                    { 1, "22br", 1, "Ireland", 12, null },
                    { 2, "BeverlySt52", 8, "New York", 12, null },
                    { 3, "Drachevo", 6, "Skopje", 12, null }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "Address", "FullName", "IsDelivered" },
                values: new object[,]
                {
                    { 1, "123 Main St", "John Doe", false },
                    { 2, "456 Elm St", "Jane Smith", true },
                    { 3, "789 Maple Ave", "Mike Johnson", false },
                    { 4, "321 Oak St", "Emily Davis", true },
                    { 5, "654 Pine St", "Chris Brown", false },
                    { 6, "987 Cedar St", "Sarah Wilson", true },
                    { 7, "741 Birch St", "David Lee", false },
                    { 8, "852 Spruce St", "Jessica Taylor", true },
                    { 9, "963 Willow St", "Paul White", false },
                    { 10, "159 Aspen St", "Laura Green", true },
                    { 11, "357 Maple St", "Mark Harris", false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Burger_OrderId",
                table: "Burger",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_OrderId",
                table: "Locations",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Burger");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
