using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LojaVirtualAPI.Migrations
{
    /// <inheritdoc />
    public partial class FakeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    IconCSS = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    ImageURL = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    Qtd = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CartId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Qtd = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IconCSS", "Name" },
                values: new object[,]
                {
                    { 1, "fas fa-spa", "Beleza" },
                    { 2, "fas fa-couch", "Moveis" },
                    { 3, "fas fa-headphones", "Eletronicos" },
                    { 4, "fas fa-shoe-prints", "Calcados" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "apa@test.com", "Alysson", "123" },
                    { 2, "jan@test.com", "Janice", "123" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageURL", "Name", "Price", "Qtd" },
                values: new object[,]
                {
                    { 1, 1, "Um kit fornecido pela Natura, contendo Products para cuidados com a pele", "/img/Beleza/Beleza1.png", "Glossier - Beleza Kit", 100m, 100 },
                    { 2, 1, "Um kit fornecido pela Curology, contendo Products para cuidados com a pele", "/img/Beleza/Beleza2.png", "Curology - Kit para Pele", 50m, 45 },
                    { 3, 1, "Um kit fornecido pela Glossier, contendo Products para cuidados com a pele", "/img/Beleza/Beleza3.png", "Óleo de Coco Orgânico", 20m, 30 },
                    { 4, 1, "Um kit fornecido pela Curology, contendo Products para cuidados com a pele", "/img/Beleza/Beleza4.png", "Schwarzkopf - Kit de cuidados com a pele e cabelo", 50m, 60 },
                    { 5, 1, "Kit de cuidados com a pele, contendo Products para cuidados com a pele e cabelos", "/img/Beleza/Beleza5.png", "Kit de cuidados com a pele", 30m, 85 },
                    { 6, 3, "Air Pods - fones de ouvido sem fio intra-auriculares", "/img/Eletronicos/eletronico1.png", "Fones de ouvidos", 100m, 120 },
                    { 7, 3, "Fones de ouvido dourados na orelha - esses fones de ouvido não são sem fio", "/img/Eletronicos/eletronico2.png", "Fones de ouvido dourados", 40m, 200 },
                    { 8, 3, "Fones de ouvido pretos na orelha - esses fones de ouvido não são sem fio", "/img/Eletronicos/eletronico3.png", "Fones de ouvido pretos", 40m, 300 },
                    { 9, 3, "Câmera Digital Sennheiser - Câmera digital de alta qualidade fornecida pela Sennheiser - inclui tripé", "/img/Eletronicos/eletronico4.png", "Câmera digital Sennheiser com tripé", 600m, 20 },
                    { 10, 3, "Canon Digital Camera - Câmera digital de alta qualidade fornecida pela Canon", "/img/Eletronicos/eletronico5.png", "Câmera Digital Canon", 500m, 15 },
                    { 11, 3, "Gameboy - Fornecido por Nintendo", "/img/Eletronicos/tecnologia6.png", "Nintendo Gameboy", 100m, 60 },
                    { 12, 2, "Cadeira de escritório em couro preto muito confortável", "/img/Moveis/moveis1.png", "Cadeira de escritório de couro preto", 50m, 212 },
                    { 13, 2, "Cadeira de escritório em couro rosa muito confortável", "/img/Moveis/moveis2.png", "Cadeira de escritório de couro rosa", 50m, 112 },
                    { 14, 2, "Poltrona muito confortável", "/img/Moveis/moveis3.png", "Espreguiçadeira", 70m, 90 },
                    { 15, 2, "Poltrona prateada muito confortável", "/img/Moveis/moveis4.png", "Silver Lounge Chair", 120m, 95 },
                    { 16, 2, "Abajur de mesa de porcelana branco e azul", "/img/Moveis/moveis6.png", "Luminária de mesa de porcelana", 15m, 100 },
                    { 17, 2, "Abajur de mesa de escritório", "/img/Moveis/moveis7.png", "Office Table Lamp", 20m, 73 },
                    { 18, 4, "Tênis Puma confortáveis na maioria dos tamanhos", "/img/Calcados/calcado1.png", "Tênis Puma", 100m, 50 },
                    { 19, 4, "Tênis coloridos - disponíveis na maioria dos tamanhos", "/img/Calcados/calcado2.png", "Tênis Colodiros", 150m, 60 },
                    { 20, 4, "Tênis Nike azul - disponível na maioria dos tamanhos", "/img/Calcados/calcado3.png", "Tênis Nike Azul", 200m, 70 },
                    { 21, 4, "Treinadores Hummel coloridos - disponíveis na maioria dos tamanhos", "/img/Calcados/calcado4.png", "Tênis Hummel Coloridos", 120m, 120 },
                    { 22, 4, "Tênis Nike vermelho - disponível na maioria dos tamanhos", "/img/Calcados/calcado5.png", "Tênis Nike Vermelho", 200m, 100 },
                    { 23, 4, "Sandálias Birkenstock - disponíveis na maioria dos tamanhos", "/img/Calcados/calcado6.png", "Sandálidas Birkenstock", 50m, 150 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_CartId",
                table: "Items",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ProductId",
                table: "Items",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
