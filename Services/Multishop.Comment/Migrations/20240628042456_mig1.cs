using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Multishop.Comment.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("228654f1-5d7a-4ebd-aa80-c63ff8ec7e07")),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Review = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Rating = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)0),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 6, 28, 7, 24, 56, 46, DateTimeKind.Local).AddTicks(9009)),
                    ProductId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.CheckConstraint("CommentEmailMinLengthConstraint", "Len(Email) >= 5");
                    table.CheckConstraint("CommentNameSurnameMinLengthConstraint", "Len(NameSurname) >= 5");
                    table.CheckConstraint("CommentRatingMaxConstraint", "Rating <= 5");
                    table.CheckConstraint("CommentRatingMinConstraint", "Rating >= 0");
                    table.CheckConstraint("CommentReviewMinLengthConstraint", "Len(Review) >= 10");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");
        }
    }
}
