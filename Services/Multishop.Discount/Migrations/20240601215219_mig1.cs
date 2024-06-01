using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Multishop.Discount.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 6, 2, 0, 52, 18, 384, DateTimeKind.Local).AddTicks(4742)),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                    table.CheckConstraint("CouponExpirationDateConstraint", "ExpirationDate > GetDate()");
                    table.CheckConstraint("CouponMaxRateConstraint", "Rate <= 100");
                    table.CheckConstraint("CouponMinCodeLengthConstraint", "Len(Code) > 0");
                    table.CheckConstraint("CouponMinRateConstraint", "Rate > 0");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupons");
        }
    }
}
