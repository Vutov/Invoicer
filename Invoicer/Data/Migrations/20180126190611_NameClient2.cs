using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Invoicer.Data.Migrations
{
    public partial class NameClient2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Clients_ClientID",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_ResponsiblePerson_Clients_ClientID",
                table: "ResponsiblePerson");

            migrationBuilder.DropIndex(
                name: "IX_ResponsiblePerson_ClientID",
                table: "ResponsiblePerson");

            migrationBuilder.DropIndex(
                name: "IX_Address_ClientID",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "ResponsiblePerson");

            migrationBuilder.DropColumn(
                name: "EnterManualy",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Address");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResponsiblePerson",
                table: "Clients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ResponsiblePerson",
                table: "Clients");

            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "ResponsiblePerson",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EnterManualy",
                table: "Clients",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "Address",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResponsiblePerson_ClientID",
                table: "ResponsiblePerson",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Address_ClientID",
                table: "Address",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Clients_ClientID",
                table: "Address",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResponsiblePerson_Clients_ClientID",
                table: "ResponsiblePerson",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
