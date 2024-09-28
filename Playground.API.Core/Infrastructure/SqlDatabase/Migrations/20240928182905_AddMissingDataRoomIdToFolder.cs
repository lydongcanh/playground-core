using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Playground.API.Core.Infrastructure.SqlDatabase.Migrations
{
    /// <inheritdoc />
    public partial class AddMissingDataRoomIdToFolder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folders_DataRooms_DataRoomId",
                table: "Folders");

            migrationBuilder.AlterColumn<Guid>(
                name: "DataRoomId",
                table: "Folders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_DataRooms_DataRoomId",
                table: "Folders",
                column: "DataRoomId",
                principalTable: "DataRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folders_DataRooms_DataRoomId",
                table: "Folders");

            migrationBuilder.AlterColumn<Guid>(
                name: "DataRoomId",
                table: "Folders",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_DataRooms_DataRoomId",
                table: "Folders",
                column: "DataRoomId",
                principalTable: "DataRooms",
                principalColumn: "Id");
        }
    }
}
