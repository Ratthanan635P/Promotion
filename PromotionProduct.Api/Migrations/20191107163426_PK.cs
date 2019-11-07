using Microsoft.EntityFrameworkCore.Migrations;

namespace PromotionProduct.Api.Migrations
{
    public partial class PK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_Tb_UserPromotion",
                table: "Tb_UserPromotion",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tb_User",
                table: "Tb_User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tb_PromotionProduct",
                table: "Tb_PromotionProduct",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tb_UserPromotion",
                table: "Tb_UserPromotion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tb_User",
                table: "Tb_User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tb_PromotionProduct",
                table: "Tb_PromotionProduct");
        }
    }
}
