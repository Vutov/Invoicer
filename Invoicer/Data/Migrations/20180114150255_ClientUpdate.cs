using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Invoicer.Data.Migrations
{
    public partial class ClientUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Invoices_InvoiceID",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_InvoiceID",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "InvoiceID",
                table: "Address");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceID",
                table: "Address",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_InvoiceID",
                table: "Address",
                column: "InvoiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Invoices_InvoiceID",
                table: "Address",
                column: "InvoiceID",
                principalTable: "Invoices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
