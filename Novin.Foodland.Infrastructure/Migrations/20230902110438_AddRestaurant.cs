﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Novin.Foodland.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRestaurant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerUsername = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    ApprovedUsername = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ApprovedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurants_ApplicationUsers_ApprovedUsername",
                        column: x => x.ApprovedUsername,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Username");
                    table.ForeignKey(
                        name: "FK_Restaurants_ApplicationUsers_OwnerUsername",
                        column: x => x.OwnerUsername,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_ApprovedUsername",
                table: "Restaurants",
                column: "ApprovedUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_OwnerUsername",
                table: "Restaurants",
                column: "OwnerUsername");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
