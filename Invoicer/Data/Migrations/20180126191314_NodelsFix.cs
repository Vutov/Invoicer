using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Invoicer.Data.Migrations
{
    public partial class NodelsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentDetail_Distributors_ClientID",
                table: "PaymentDetail");

            migrationBuilder.RenameColumn(
                name: "ClientID",
                table: "PaymentDetail",
                newName: "DistributorID");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentDetail_ClientID",
                table: "PaymentDetail",
                newName: "IX_PaymentDetail_DistributorID");

            migrationBuilder.AddColumn<int>(
                name: "Language",
                table: "Name",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "InvoiceDate",
                table: "Invoices",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "InvoiceNumber",
                table: "Invoices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Distributors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Clients",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Language",
                table: "Address",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Distributors_CreatedById",
                table: "Distributors",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CreatedById",
                table: "Clients",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_AspNetUsers_CreatedById",
                table: "Clients",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Distributors_AspNetUsers_CreatedById",
                table: "Distributors",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentDetail_Distributors_DistributorID",
                table: "PaymentDetail",
                column: "DistributorID",
                principalTable: "Distributors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_AspNetUsers_CreatedById",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Distributors_AspNetUsers_CreatedById",
                table: "Distributors");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentDetail_Distributors_DistributorID",
                table: "PaymentDetail");

            migrationBuilder.DropIndex(
                name: "IX_Distributors_CreatedById",
                table: "Distributors");

            migrationBuilder.DropIndex(
                name: "IX_Clients_CreatedById",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Name");

            migrationBuilder.DropColumn(
                name: "InvoiceDate",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "InvoiceNumber",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Distributors");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "DistributorID",
                table: "PaymentDetail",
                newName: "ClientID");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentDetail_DistributorID",
                table: "PaymentDetail",
                newName: "IX_PaymentDetail_ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentDetail_Distributors_ClientID",
                table: "PaymentDetail",
                column: "ClientID",
                principalTable: "Distributors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
