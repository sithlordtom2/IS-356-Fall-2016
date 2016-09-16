using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IS356Main.Data.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    groupName = table.Column<string>(nullable: true),
                    logoLink = table.Column<string>(nullable: true),
                    memberFive = table.Column<string>(nullable: true),
                    memberFour = table.Column<string>(nullable: true),
                    memberOne = table.Column<string>(nullable: true),
                    memberThree = table.Column<string>(nullable: true),
                    memberTwo = table.Column<string>(nullable: true),
                    siteLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
