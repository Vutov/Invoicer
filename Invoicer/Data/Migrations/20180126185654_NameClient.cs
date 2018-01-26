using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Invoicer.Data.Migrations
{
    public partial class NameClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Name_Clients_ClientID",
                table: "Name");

            migrationBuilder.DropIndex(
                name: "IX_Name_ClientID",
                table: "Name");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Clients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Clients");

            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "Name",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Name_ClientID",
                table: "Name",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Name_Clients_ClientID",
                table: "Name",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
