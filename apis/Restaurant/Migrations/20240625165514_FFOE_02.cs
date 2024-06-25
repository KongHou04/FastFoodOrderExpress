using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace restaurant.Migrations
{
    /// <inheritdoc />
    public partial class FFOE_02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CouponId",
                table: "orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_orders_CouponId",
                table: "orders",
                column: "CouponId",
                unique: true,
                filter: "[CouponId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_coupons_CouponId",
                table: "orders",
                column: "CouponId",
                principalTable: "coupons",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_coupons_CouponId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_CouponId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "CouponId",
                table: "orders");
        }
    }
}
