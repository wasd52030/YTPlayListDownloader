using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YTPlayListDownloader.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "Video",
                newName: "comment");

            migrationBuilder.RenameColumn(
                name: "Author",
                table: "Playlists",
                newName: "Owner");

            migrationBuilder.CreateTable(
                name: "PlaylistInfo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Owner = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Position = table.Column<int>(type: "INTEGER", nullable: false),
                    VideoId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaylistInfo_Video_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Video",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "_8WlyB761g0" },
                column: "Position",
                value: 168);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "-EKxzId_Sj4" },
                column: "Position",
                value: 209);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "-kZBuzsZ7Ho" },
                column: "Position",
                value: 30);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "0_pfGRDugxg" },
                column: "Position",
                value: 169);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "0A00OqHvTOA" },
                column: "Position",
                value: 95);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "0dHbpmhy1Bk" },
                column: "Position",
                value: 19);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "0gFy1XeYKSw" },
                column: "Position",
                value: 94);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "0LwM_2h-HGc" },
                column: "Position",
                value: 166);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "0r399LOfHG8" },
                column: "Position",
                value: 116);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "1K7wktyUta0" },
                column: "Position",
                value: 56);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "2C2fAU9fn-U" },
                column: "Position",
                value: 157);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "2FgcZMqkZfc" },
                column: "Position",
                value: 175);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "2Gs9N0nlCiE" },
                column: "Position",
                value: 60);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "2RhWAYp-yvc" },
                column: "Position",
                value: 191);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "35iPH7jJLH0" },
                column: "Position",
                value: 170);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "3PXswuSz6W4" },
                column: "Position",
                value: 120);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "45jSY48vd6A" },
                column: "Position",
                value: 98);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "4bdnip1vjhc" },
                column: "Position",
                value: 111);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "4ibYwtra0eY" },
                column: "Position",
                value: 200);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "4QXCPuwBz2E" },
                column: "Position",
                value: 73);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "4tW1Mhm-ZtY" },
                column: "Position",
                value: 212);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "4ucamH-_cPw" },
                column: "Position",
                value: 158);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "4v7VQOILPfc" },
                column: "Position",
                value: 148);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "4vbIKFMn9mU" },
                column: "Position",
                value: 12);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "5AuY2Jzl284" },
                column: "Position",
                value: 27);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "5c4SG9gGNWE" },
                column: "Position",
                value: 42);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "5DeioSB7AU4" },
                column: "Position",
                value: 77);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "6gar6MONCKs" },
                column: "Position",
                value: 102);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "6mOoCFDcs3E" },
                column: "Position",
                value: 89);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "6PBmiE_k12E" },
                column: "Position",
                value: 205);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "6ZjgzePvoyg" },
                column: "Position",
                value: 145);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "7AVI8pYUSYM" },
                column: "Position",
                value: 142);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "7G0ovtPqHnI" },
                column: "Position",
                value: 129);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "7NrQei36fJk" },
                column: "Position",
                value: 78);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "87moOXPTtSk" },
                column: "Position",
                value: 146);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "8J3mAIM8N60" },
                column: "Position",
                value: 75);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "8pGRdRhjX3o" },
                column: "Position",
                value: 149);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "9eyyhtOrKPI" },
                column: "Position",
                value: 217);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "9FaDpS_IFpM" },
                column: "Position",
                value: 208);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "9lVPAWLWtWc" },
                column: "Position",
                value: 204);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "A_J3UhPK-Zo" },
                column: "Position",
                value: 52);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "a6j5lbt6OLQ" },
                column: "Position",
                value: 22);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "ADIP3Um32Gc" },
                column: "Position",
                value: 81);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "AHZJh5P15i4" },
                column: "Position",
                value: 67);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "aK81oAFippw" },
                column: "Position",
                value: 192);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "AkBKzjlCNX0" },
                column: "Position",
                value: 14);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "AY7ug521lHo" },
                column: "Position",
                value: 176);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "B2HQSekxMUc" },
                column: "Position",
                value: 159);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "B776HM2cZWM" },
                column: "Position",
                value: 213);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "bDx8-LmNSPI" },
                column: "Position",
                value: 49);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "bFUnWu6hQuU" },
                column: "Position",
                value: 178);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "bMWg0-dSP9s" },
                column: "Position",
                value: 182);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "bnCnnY2tDOo" },
                column: "Position",
                value: 185);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "BqbzJ4uXcNc" },
                column: "Position",
                value: 110);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "bzlHPlq8hIs" },
                column: "Position",
                value: 90);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "c_D37tFw7Z8" },
                column: "Position",
                value: 31);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "c9PEYJdwdwI" },
                column: "Position",
                value: 130);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "caMRArcGhmg" },
                column: "Position",
                value: 155);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "ceIwCBy9zcs" },
                column: "Position",
                value: 29);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "CHs04xmtenA" },
                column: "Position",
                value: 61);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "CJGSo0aZaak" },
                column: "Position",
                value: 181);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "CkIHA_m5d84" },
                column: "Position",
                value: 134);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "CkvWJNt77mU" },
                column: "Position",
                value: 50);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "CniSkoogfZs" },
                column: "Position",
                value: 132);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "cP6VqB4klpQ" },
                column: "Position",
                value: 83);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "CT-P8-D8CC0" },
                column: "Position",
                value: 65);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "d-K3bNOwhGo" },
                column: "Position",
                value: 45);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "D1YGeQLjdiw" },
                column: "Position",
                value: 41);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "D8hCn4no4O8" },
                column: "Position",
                value: 87);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "Di3R-7Y_RSI" },
                column: "Position",
                value: 58);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "dl7CLaZFG1c" },
                column: "Position",
                value: 80);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "DnLFVUi3oOU" },
                column: "Position",
                value: 36);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "DrG1CjMWaM8" },
                column: "Position",
                value: 165);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "dSw8CucthGc" },
                column: "Position",
                value: 113);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "duTWwnGtGBo" },
                column: "Position",
                value: 177);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "Dy3qLNZyDZA" },
                column: "Position",
                value: 5);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "EGLoIaHwKfE" },
                column: "Position",
                value: 93);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "eiN74eBG0cU" },
                column: "Position",
                value: 24);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "Ej0DA0BgbRU" },
                column: "Position",
                value: 119);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "ejhcSi4W568" },
                column: "Position",
                value: 106);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "elql9b_31IY" },
                column: "Position",
                value: 143);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "EpAnuMO_nuk" },
                column: "Position",
                value: 69);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "epGtVG2-SAo" },
                column: "Position",
                value: 162);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "EQI8oKA6X4o" },
                column: "Position",
                value: 172);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "F64yFFnZfkI" },
                column: "Position",
                value: 206);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "fCU4VJ6DseY" },
                column: "Position",
                value: 171);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "fgwBoi_6_Ys" },
                column: "Position",
                value: 107);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "FLs2faYqoNU" },
                column: "Position",
                value: 127);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "FQQ6Ef1iTP4" },
                column: "Position",
                value: 152);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "FV_-8DWuq5w" },
                column: "Position",
                value: 91);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "FWN5GCr8iqc" },
                column: "Position",
                value: 32);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "g9H9R2KYaVY" },
                column: "Position",
                value: 28);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "GB3DN7B4mx4" },
                column: "Position",
                value: 121);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "GBVotNefYME" },
                column: "Position",
                value: 210);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "ghoUnQMbuEw" },
                column: "Position",
                value: 167);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "GIlMPJNk-pU" },
                column: "Position",
                value: 44);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "gJ1Mz7kGVf0" },
                column: "Position",
                value: 74);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "gPpZJlE0Ca8" },
                column: "Position",
                value: 68);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "GrqPwrCvPHY" },
                column: "Position",
                value: 151);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "GvFT3YqmUgw" },
                column: "Position",
                value: 193);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "GVrRXhS0mLs" },
                column: "Position",
                value: 115);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "h5amxhRgsRQ" },
                column: "Position",
                value: 179);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "HaTn3oRPtzg" },
                column: "Position",
                value: 38);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "heviU6h0snM" },
                column: "Position",
                value: 163);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "hmPqnfZMbzA" },
                column: "Position",
                value: 40);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "HNC5eu16hEw" },
                column: "Position",
                value: 97);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "hyO3xBbf2mg" },
                column: "Position",
                value: 214);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "hZFBTnzKa54" },
                column: "Position",
                value: 190);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "iASoRE5k0Vw" },
                column: "Position",
                value: 7);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "ib8-PeMrMjo" },
                column: "Position",
                value: 180);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "iCp3yL-Q6nM" },
                column: "Position",
                value: 184);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "imSVDa7KCDU" },
                column: "Position",
                value: 211);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "IV6s7IKxocU" },
                column: "Position",
                value: 16);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "jH1RNk8954Q" },
                column: "Position",
                value: 70);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "Jy_78LzkGsQ" },
                column: "Position",
                value: 66);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "jZzHK4iJ1jM" },
                column: "Position",
                value: 9);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "kENX7x5-42g" },
                column: "Position",
                value: 57);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "KiJUDlwwznE" },
                column: "Position",
                value: 21);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "kIxNIs5GzGY" },
                column: "Position",
                value: 108);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "klbXQsHkHkA" },
                column: "Position",
                value: 109);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "KLr_M5CcEJ0" },
                column: "Position",
                value: 128);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "kyZz2BOy8ow" },
                column: "Position",
                value: 122);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "LEpMTU8pjIs" },
                column: "Position",
                value: 137);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "LfephiFN76E" },
                column: "Position",
                value: 219);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "LLV-OrsllQw" },
                column: "Position",
                value: 218);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "lNuXbIfwXP4" },
                column: "Position",
                value: 201);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "Lq2-HHP04jM" },
                column: "Position",
                value: 160);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "LqQ_xF1LfYg" },
                column: "Position",
                value: 154);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "lzAyrgSqeeE" },
                column: "Position",
                value: 207);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "M0n_6L9_msk" },
                column: "Position",
                value: 51);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "M2shOfNNGRk" },
                column: "Position",
                value: 43);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "m7lO_hLBgq4" },
                column: "Position",
                value: 126);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "m9v6VIj500I" },
                column: "Position",
                value: 105);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "mFn8xMRo4yg" },
                column: "Position",
                value: 118);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "MOe5AOuBWv4" },
                column: "Position",
                value: 147);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "mrqKvu-rqIc" },
                column: "Position",
                value: 215);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "MtwWoZ9vfJk" },
                column: "Position",
                value: 138);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "mumUMScImLk" },
                column: "Position",
                value: 117);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "mX8_pWK95JU" },
                column: "Position",
                value: 55);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "NCUVY9Gua9o" },
                column: "Position",
                value: 46);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "NEK43tVhWMY" },
                column: "Position",
                value: 202);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "NinvX4S9Es0" },
                column: "Position",
                value: 186);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "o3OPrWglbBg" },
                column: "Position",
                value: 18);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "olHs3ykdE1c" },
                column: "Position",
                value: 183);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "p-zv4JaEz78" },
                column: "Position",
                value: 135);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "p3BHyOhVXmE" },
                column: "Position",
                value: 62);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "pDylHkqNwFU" },
                column: "Position",
                value: 11);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "pgelkyK0XgA" },
                column: "Position",
                value: 112);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "pHdJmDFYqTU" },
                column: "Position",
                value: 131);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "pp_-Xk-RmDc" },
                column: "Position",
                value: 187);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "PQDDCgrI8No" },
                column: "Position",
                value: 173);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "PtKBTFLUPVo" },
                column: "Position",
                value: 79);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "ptZ4puTZbpQ" },
                column: "Position",
                value: 15);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "PvHo6zG46S4" },
                column: "Position",
                value: 47);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "q-y_AV2appc" },
                column: "Position",
                value: 3);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "Q0IefxI6rXM" },
                column: "Position",
                value: 59);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "q2dbhaEEpiw" },
                column: "Position",
                value: 141);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "Q76cSapPP7M" },
                column: "Position",
                value: 8);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "qh6Sy67s6zM" },
                column: "Position",
                value: 84);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "QJq6GAZYH18" },
                column: "Position",
                value: 20);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "qJSVRia9HAI" },
                column: "Position",
                value: 71);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "Qp3U_YqdWho" },
                column: "Position",
                value: 26);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "qRLPsGvya00" },
                column: "Position",
                value: 220);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "qs61KYSvGZI" },
                column: "Position",
                value: 194);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "QVVv4aICofc" },
                column: "Position",
                value: 136);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "r105CzDvoo0" },
                column: "Position",
                value: 100);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "rcVb6l4TpHw" },
                column: "Position",
                value: 99);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "rcYhYO02f98" },
                column: "Position",
                value: 39);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "rEnYSN3xa3A" },
                column: "Position",
                value: 133);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "RLpkmEKqfR4" },
                column: "Position",
                value: 216);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "RQoysVOE_qg" },
                column: "Position",
                value: 53);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "ry3Tupx4BL4" },
                column: "Position",
                value: 85);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "S4JLJVVjevI" },
                column: "Position",
                value: 54);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "S9L02o1a9h0" },
                column: "Position",
                value: 198);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "sa6eXtg6PgM" },
                column: "Position",
                value: 4);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "sF_dZQQPTRs" },
                column: "Position",
                value: 72);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "siYDPB2K0t0" },
                column: "Position",
                value: 188);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "sZR3IMkVLNk" },
                column: "Position",
                value: 125);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "t7MBzMP4OzY" },
                column: "Position",
                value: 199);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "TP1iYThHWHg" },
                column: "Position",
                value: 33);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "u-h_FzQDV-Q" },
                column: "Position",
                value: 37);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "u9ckcrP4S-c" },
                column: "Position",
                value: 197);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "UEdZyNbqYl4" },
                column: "Position",
                value: 195);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "UkDa--C624I" },
                column: "Position",
                value: 2);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "uoL_7cX0pCQ" },
                column: "Position",
                value: 161);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "UqDByhCDBMk" },
                column: "Position",
                value: 153);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "uvC1tOleSJk" },
                column: "Position",
                value: 76);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "uXcG3tXYNF8" },
                column: "Position",
                value: 124);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "V46K7apDziA" },
                column: "Position",
                value: 114);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "vHn2pglEhK8" },
                column: "Position",
                value: 101);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "vJvoZfeGN-0" },
                column: "Position",
                value: 203);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "vtJscsqrhL4" },
                column: "Position",
                value: 88);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "WRgxXRUAX-Q" },
                column: "Position",
                value: 156);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "wS8yk2dQBN4" },
                column: "Position",
                value: 35);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "WYVPWs-qANs" },
                column: "Position",
                value: 103);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "x-pCAngjeOw" },
                column: "Position",
                value: 13);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "x5xXGqTQLUE" },
                column: "Position",
                value: 92);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "X7OnmTYTzKU" },
                column: "Position",
                value: 17);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "X9D5Qu_B6oA" },
                column: "Position",
                value: 140);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "XeMVu1OYYps" },
                column: "Position",
                value: 63);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "XFqKHgd0eB0" },
                column: "Position",
                value: 48);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "XQ3SxNM8rnw" },
                column: "Position",
                value: 34);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "xQOXxmznGPg" },
                column: "Position",
                value: 82);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "XXEFaMlOIhE" },
                column: "Position",
                value: 23);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "Y16x_uNGjpo" },
                column: "Position",
                value: 123);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "Y2sPl0G1yck" },
                column: "Position",
                value: 86);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "YA1OvUaoVuc" },
                column: "Position",
                value: 96);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "ykCuoeIqbEU" },
                column: "Position",
                value: 6);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "yrW2i4magt4" },
                column: "Position",
                value: 139);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "YwfkuXAZ1Lc" },
                column: "Position",
                value: 10);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "yz_kza6idVA" },
                column: "Position",
                value: 174);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "Z2MqvQMC3hQ" },
                column: "Position",
                value: 189);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "Z8CH2UHNdHQ" },
                column: "Position",
                value: 25);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "z8NxbzqPf4M" },
                column: "Position",
                value: 144);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "zesMlkz7nvM" },
                column: "Position",
                value: 150);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "zF1tLgSSvQs" },
                column: "Position",
                value: 196);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "ZQqbhwH87OM" },
                column: "Position",
                value: 64);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "zTm666EKYRs" },
                column: "Position",
                value: 164);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "ZzZ1qmXZBuY" },
                column: "Position",
                value: 104);

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "Id",
                keyValue: "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip",
                columns: new[] { "Owner", "Title" },
                values: new object[] { "BBBGGGMMM", "Виктор собел" });

            migrationBuilder.InsertData(
                table: "Video",
                columns: new[] { "Id", "Title", "comment" },
                values: new object[] { "TIy3n2b7V9k", "[Avril Lavigne] Sk8er Boi", "" });

            migrationBuilder.InsertData(
                table: "PlaylistVideos",
                columns: new[] { "PlayListId", "VideoId", "Position" },
                values: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "TIy3n2b7V9k", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistInfo_VideoId",
                table: "PlaylistInfo",
                column: "VideoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaylistInfo");

            migrationBuilder.DeleteData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "TIy3n2b7V9k" });

            migrationBuilder.DeleteData(
                table: "Video",
                keyColumn: "Id",
                keyValue: "TIy3n2b7V9k");

            migrationBuilder.RenameColumn(
                name: "comment",
                table: "Video",
                newName: "Comment");

            migrationBuilder.RenameColumn(
                name: "Owner",
                table: "Playlists",
                newName: "Author");

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "_8WlyB761g0" },
                column: "Position",
                value: 167);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "-EKxzId_Sj4" },
                column: "Position",
                value: 208);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "-kZBuzsZ7Ho" },
                column: "Position",
                value: 29);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "0_pfGRDugxg" },
                column: "Position",
                value: 168);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "0A00OqHvTOA" },
                column: "Position",
                value: 94);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "0dHbpmhy1Bk" },
                column: "Position",
                value: 18);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "0gFy1XeYKSw" },
                column: "Position",
                value: 93);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "0LwM_2h-HGc" },
                column: "Position",
                value: 165);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "0r399LOfHG8" },
                column: "Position",
                value: 115);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "1K7wktyUta0" },
                column: "Position",
                value: 55);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "2C2fAU9fn-U" },
                column: "Position",
                value: 156);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "2FgcZMqkZfc" },
                column: "Position",
                value: 174);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "2Gs9N0nlCiE" },
                column: "Position",
                value: 59);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "2RhWAYp-yvc" },
                column: "Position",
                value: 190);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "35iPH7jJLH0" },
                column: "Position",
                value: 169);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "3PXswuSz6W4" },
                column: "Position",
                value: 119);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "45jSY48vd6A" },
                column: "Position",
                value: 97);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "4bdnip1vjhc" },
                column: "Position",
                value: 110);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "4ibYwtra0eY" },
                column: "Position",
                value: 199);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "4QXCPuwBz2E" },
                column: "Position",
                value: 72);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "4tW1Mhm-ZtY" },
                column: "Position",
                value: 211);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "4ucamH-_cPw" },
                column: "Position",
                value: 157);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "4v7VQOILPfc" },
                column: "Position",
                value: 147);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "4vbIKFMn9mU" },
                column: "Position",
                value: 11);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "5AuY2Jzl284" },
                column: "Position",
                value: 26);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "5c4SG9gGNWE" },
                column: "Position",
                value: 41);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "5DeioSB7AU4" },
                column: "Position",
                value: 76);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "6gar6MONCKs" },
                column: "Position",
                value: 101);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "6mOoCFDcs3E" },
                column: "Position",
                value: 88);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "6PBmiE_k12E" },
                column: "Position",
                value: 204);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "6ZjgzePvoyg" },
                column: "Position",
                value: 144);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "7AVI8pYUSYM" },
                column: "Position",
                value: 141);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "7G0ovtPqHnI" },
                column: "Position",
                value: 128);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "7NrQei36fJk" },
                column: "Position",
                value: 77);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "87moOXPTtSk" },
                column: "Position",
                value: 145);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "8J3mAIM8N60" },
                column: "Position",
                value: 74);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "8pGRdRhjX3o" },
                column: "Position",
                value: 148);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "9eyyhtOrKPI" },
                column: "Position",
                value: 216);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "9FaDpS_IFpM" },
                column: "Position",
                value: 207);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "9lVPAWLWtWc" },
                column: "Position",
                value: 203);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "A_J3UhPK-Zo" },
                column: "Position",
                value: 51);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "a6j5lbt6OLQ" },
                column: "Position",
                value: 21);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "ADIP3Um32Gc" },
                column: "Position",
                value: 80);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "AHZJh5P15i4" },
                column: "Position",
                value: 66);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "aK81oAFippw" },
                column: "Position",
                value: 191);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "AkBKzjlCNX0" },
                column: "Position",
                value: 13);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "AY7ug521lHo" },
                column: "Position",
                value: 175);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "B2HQSekxMUc" },
                column: "Position",
                value: 158);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "B776HM2cZWM" },
                column: "Position",
                value: 212);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "bDx8-LmNSPI" },
                column: "Position",
                value: 48);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "bFUnWu6hQuU" },
                column: "Position",
                value: 177);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "bMWg0-dSP9s" },
                column: "Position",
                value: 181);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "bnCnnY2tDOo" },
                column: "Position",
                value: 184);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "BqbzJ4uXcNc" },
                column: "Position",
                value: 109);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "bzlHPlq8hIs" },
                column: "Position",
                value: 89);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "c_D37tFw7Z8" },
                column: "Position",
                value: 30);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "c9PEYJdwdwI" },
                column: "Position",
                value: 129);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "caMRArcGhmg" },
                column: "Position",
                value: 154);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "ceIwCBy9zcs" },
                column: "Position",
                value: 28);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "CHs04xmtenA" },
                column: "Position",
                value: 60);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "CJGSo0aZaak" },
                column: "Position",
                value: 180);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "CkIHA_m5d84" },
                column: "Position",
                value: 133);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "CkvWJNt77mU" },
                column: "Position",
                value: 49);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "CniSkoogfZs" },
                column: "Position",
                value: 131);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "cP6VqB4klpQ" },
                column: "Position",
                value: 82);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "CT-P8-D8CC0" },
                column: "Position",
                value: 64);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "d-K3bNOwhGo" },
                column: "Position",
                value: 44);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "D1YGeQLjdiw" },
                column: "Position",
                value: 40);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "D8hCn4no4O8" },
                column: "Position",
                value: 86);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "Di3R-7Y_RSI" },
                column: "Position",
                value: 57);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "dl7CLaZFG1c" },
                column: "Position",
                value: 79);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "DnLFVUi3oOU" },
                column: "Position",
                value: 35);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "DrG1CjMWaM8" },
                column: "Position",
                value: 164);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "dSw8CucthGc" },
                column: "Position",
                value: 112);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "duTWwnGtGBo" },
                column: "Position",
                value: 176);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "Dy3qLNZyDZA" },
                column: "Position",
                value: 4);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "EGLoIaHwKfE" },
                column: "Position",
                value: 92);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "eiN74eBG0cU" },
                column: "Position",
                value: 23);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "Ej0DA0BgbRU" },
                column: "Position",
                value: 118);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "ejhcSi4W568" },
                column: "Position",
                value: 105);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "elql9b_31IY" },
                column: "Position",
                value: 142);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "EpAnuMO_nuk" },
                column: "Position",
                value: 68);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "epGtVG2-SAo" },
                column: "Position",
                value: 161);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "EQI8oKA6X4o" },
                column: "Position",
                value: 171);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "F64yFFnZfkI" },
                column: "Position",
                value: 205);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "fCU4VJ6DseY" },
                column: "Position",
                value: 170);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "fgwBoi_6_Ys" },
                column: "Position",
                value: 106);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "FLs2faYqoNU" },
                column: "Position",
                value: 126);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "FQQ6Ef1iTP4" },
                column: "Position",
                value: 151);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "FV_-8DWuq5w" },
                column: "Position",
                value: 90);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "FWN5GCr8iqc" },
                column: "Position",
                value: 31);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "g9H9R2KYaVY" },
                column: "Position",
                value: 27);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "GB3DN7B4mx4" },
                column: "Position",
                value: 120);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "GBVotNefYME" },
                column: "Position",
                value: 209);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "ghoUnQMbuEw" },
                column: "Position",
                value: 166);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "GIlMPJNk-pU" },
                column: "Position",
                value: 43);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "gJ1Mz7kGVf0" },
                column: "Position",
                value: 73);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "gPpZJlE0Ca8" },
                column: "Position",
                value: 67);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "GrqPwrCvPHY" },
                column: "Position",
                value: 150);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "GvFT3YqmUgw" },
                column: "Position",
                value: 192);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "GVrRXhS0mLs" },
                column: "Position",
                value: 114);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "h5amxhRgsRQ" },
                column: "Position",
                value: 178);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "HaTn3oRPtzg" },
                column: "Position",
                value: 37);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "heviU6h0snM" },
                column: "Position",
                value: 162);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "hmPqnfZMbzA" },
                column: "Position",
                value: 39);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "HNC5eu16hEw" },
                column: "Position",
                value: 96);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "hyO3xBbf2mg" },
                column: "Position",
                value: 213);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "hZFBTnzKa54" },
                column: "Position",
                value: 189);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "iASoRE5k0Vw" },
                column: "Position",
                value: 6);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "ib8-PeMrMjo" },
                column: "Position",
                value: 179);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "iCp3yL-Q6nM" },
                column: "Position",
                value: 183);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "imSVDa7KCDU" },
                column: "Position",
                value: 210);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "IV6s7IKxocU" },
                column: "Position",
                value: 15);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "jH1RNk8954Q" },
                column: "Position",
                value: 69);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "Jy_78LzkGsQ" },
                column: "Position",
                value: 65);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "jZzHK4iJ1jM" },
                column: "Position",
                value: 8);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "kENX7x5-42g" },
                column: "Position",
                value: 56);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "KiJUDlwwznE" },
                column: "Position",
                value: 20);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "kIxNIs5GzGY" },
                column: "Position",
                value: 107);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "klbXQsHkHkA" },
                column: "Position",
                value: 108);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "KLr_M5CcEJ0" },
                column: "Position",
                value: 127);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "kyZz2BOy8ow" },
                column: "Position",
                value: 121);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "LEpMTU8pjIs" },
                column: "Position",
                value: 136);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "LfephiFN76E" },
                column: "Position",
                value: 218);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "LLV-OrsllQw" },
                column: "Position",
                value: 217);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "lNuXbIfwXP4" },
                column: "Position",
                value: 200);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "Lq2-HHP04jM" },
                column: "Position",
                value: 159);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "LqQ_xF1LfYg" },
                column: "Position",
                value: 153);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "lzAyrgSqeeE" },
                column: "Position",
                value: 206);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "M0n_6L9_msk" },
                column: "Position",
                value: 50);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "M2shOfNNGRk" },
                column: "Position",
                value: 42);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "m7lO_hLBgq4" },
                column: "Position",
                value: 125);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "m9v6VIj500I" },
                column: "Position",
                value: 104);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "mFn8xMRo4yg" },
                column: "Position",
                value: 117);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "MOe5AOuBWv4" },
                column: "Position",
                value: 146);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "mrqKvu-rqIc" },
                column: "Position",
                value: 214);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "MtwWoZ9vfJk" },
                column: "Position",
                value: 137);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "mumUMScImLk" },
                column: "Position",
                value: 116);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "mX8_pWK95JU" },
                column: "Position",
                value: 54);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "NCUVY9Gua9o" },
                column: "Position",
                value: 45);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "NEK43tVhWMY" },
                column: "Position",
                value: 201);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "NinvX4S9Es0" },
                column: "Position",
                value: 185);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "o3OPrWglbBg" },
                column: "Position",
                value: 17);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "olHs3ykdE1c" },
                column: "Position",
                value: 182);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "p-zv4JaEz78" },
                column: "Position",
                value: 134);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "p3BHyOhVXmE" },
                column: "Position",
                value: 61);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "pDylHkqNwFU" },
                column: "Position",
                value: 10);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "pgelkyK0XgA" },
                column: "Position",
                value: 111);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "pHdJmDFYqTU" },
                column: "Position",
                value: 130);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "pp_-Xk-RmDc" },
                column: "Position",
                value: 186);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "PQDDCgrI8No" },
                column: "Position",
                value: 172);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "PtKBTFLUPVo" },
                column: "Position",
                value: 78);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "ptZ4puTZbpQ" },
                column: "Position",
                value: 14);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "PvHo6zG46S4" },
                column: "Position",
                value: 46);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "q-y_AV2appc" },
                column: "Position",
                value: 2);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "Q0IefxI6rXM" },
                column: "Position",
                value: 58);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "q2dbhaEEpiw" },
                column: "Position",
                value: 140);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "Q76cSapPP7M" },
                column: "Position",
                value: 7);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "qh6Sy67s6zM" },
                column: "Position",
                value: 83);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "QJq6GAZYH18" },
                column: "Position",
                value: 19);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "qJSVRia9HAI" },
                column: "Position",
                value: 70);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "Qp3U_YqdWho" },
                column: "Position",
                value: 25);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "qRLPsGvya00" },
                column: "Position",
                value: 219);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "qs61KYSvGZI" },
                column: "Position",
                value: 193);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "QVVv4aICofc" },
                column: "Position",
                value: 135);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "r105CzDvoo0" },
                column: "Position",
                value: 99);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "rcVb6l4TpHw" },
                column: "Position",
                value: 98);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "rcYhYO02f98" },
                column: "Position",
                value: 38);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "rEnYSN3xa3A" },
                column: "Position",
                value: 132);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "RLpkmEKqfR4" },
                column: "Position",
                value: 215);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "RQoysVOE_qg" },
                column: "Position",
                value: 52);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "ry3Tupx4BL4" },
                column: "Position",
                value: 84);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "S4JLJVVjevI" },
                column: "Position",
                value: 53);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "S9L02o1a9h0" },
                column: "Position",
                value: 197);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "sa6eXtg6PgM" },
                column: "Position",
                value: 3);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "sF_dZQQPTRs" },
                column: "Position",
                value: 71);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "siYDPB2K0t0" },
                column: "Position",
                value: 187);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "sZR3IMkVLNk" },
                column: "Position",
                value: 124);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "t7MBzMP4OzY" },
                column: "Position",
                value: 198);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "TP1iYThHWHg" },
                column: "Position",
                value: 32);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "u-h_FzQDV-Q" },
                column: "Position",
                value: 36);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "u9ckcrP4S-c" },
                column: "Position",
                value: 196);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "UEdZyNbqYl4" },
                column: "Position",
                value: 194);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "UkDa--C624I" },
                column: "Position",
                value: 1);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "uoL_7cX0pCQ" },
                column: "Position",
                value: 160);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "UqDByhCDBMk" },
                column: "Position",
                value: 152);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "uvC1tOleSJk" },
                column: "Position",
                value: 75);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "uXcG3tXYNF8" },
                column: "Position",
                value: 123);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "V46K7apDziA" },
                column: "Position",
                value: 113);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "vHn2pglEhK8" },
                column: "Position",
                value: 100);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "vJvoZfeGN-0" },
                column: "Position",
                value: 202);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "vtJscsqrhL4" },
                column: "Position",
                value: 87);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "WRgxXRUAX-Q" },
                column: "Position",
                value: 155);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "wS8yk2dQBN4" },
                column: "Position",
                value: 34);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "WYVPWs-qANs" },
                column: "Position",
                value: 102);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "x-pCAngjeOw" },
                column: "Position",
                value: 12);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "x5xXGqTQLUE" },
                column: "Position",
                value: 91);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "X7OnmTYTzKU" },
                column: "Position",
                value: 16);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "X9D5Qu_B6oA" },
                column: "Position",
                value: 139);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "XeMVu1OYYps" },
                column: "Position",
                value: 62);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "XFqKHgd0eB0" },
                column: "Position",
                value: 47);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "XQ3SxNM8rnw" },
                column: "Position",
                value: 33);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "xQOXxmznGPg" },
                column: "Position",
                value: 81);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "XXEFaMlOIhE" },
                column: "Position",
                value: 22);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "Y16x_uNGjpo" },
                column: "Position",
                value: 122);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "Y2sPl0G1yck" },
                column: "Position",
                value: 85);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "YA1OvUaoVuc" },
                column: "Position",
                value: 95);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "ykCuoeIqbEU" },
                column: "Position",
                value: 5);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "yrW2i4magt4" },
                column: "Position",
                value: 138);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "YwfkuXAZ1Lc" },
                column: "Position",
                value: 9);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "yz_kza6idVA" },
                column: "Position",
                value: 173);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "Z2MqvQMC3hQ" },
                column: "Position",
                value: 188);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "Z8CH2UHNdHQ" },
                column: "Position",
                value: 24);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "z8NxbzqPf4M" },
                column: "Position",
                value: 143);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "zesMlkz7nvM" },
                column: "Position",
                value: 149);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "zF1tLgSSvQs" },
                column: "Position",
                value: 195);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "ZQqbhwH87OM" },
                column: "Position",
                value: 63);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "zTm666EKYRs" },
                column: "Position",
                value: 163);

            migrationBuilder.UpdateData(
                table: "PlaylistVideos",
                keyColumns: new[] { "PlayListId", "VideoId" },
                keyValues: new object[] { "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip", "ZzZ1qmXZBuY" },
                column: "Position",
                value: 103);

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "Id",
                keyValue: "PLdx_s59BrvfXJXyoU5BHpUkZGmZL0g3Ip",
                columns: new[] { "Author", "Title" },
                values: new object[] { "Виктор собел", "BBBGGGMMM" });
        }
    }
}
