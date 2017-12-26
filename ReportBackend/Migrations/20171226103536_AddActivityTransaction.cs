using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ReportBackend.Migrations
{
    public partial class AddActivityTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Resource",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "User");

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    ActivityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActivityTypeCode = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTimeOffset>(nullable: false),
                    DepartmentCode = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.ActivityId);
                });

            migrationBuilder.CreateTable(
                name: "ActivityType",
                columns: table => new
                {
                    ActivityTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityType", x => x.ActivityTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectMember",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    ProjectPositionCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectMember", x => new { x.ProjectId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ProjectMember_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId");
                    table.ForeignKey(
                        name: "FK_ProjectMember_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "ProjectPosition",
                columns: table => new
                {
                    ProjectPositionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPosition", x => x.ProjectPositionId);
                });

            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    ResourceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.ResourceId);
                });

            migrationBuilder.CreateTable(
                name: "TransactionType",
                columns: table => new
                {
                    TransactionTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionType", x => x.TransactionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Treasury",
                columns: table => new
                {
                    TreasuryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountBalance = table.Column<decimal>(nullable: false),
                    AccountName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treasury", x => x.TreasuryId);
                });

            migrationBuilder.CreateTable(
                name: "AcitivityAttendance",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    ActivityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcitivityAttendance", x => new { x.UserId, x.ActivityId });
                    table.ForeignKey(
                        name: "FK_AcitivityAttendance_Activity_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "ActivityId");
                    table.ForeignKey(
                        name: "FK_AcitivityAttendance_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "UserResource",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    ResourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserResource", x => new { x.UserId, x.ResourceId });
                    table.ForeignKey(
                        name: "FK_UserResource_Resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resource",
                        principalColumn: "ResourceId");
                    table.ForeignKey(
                        name: "FK_UserResource_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<decimal>(nullable: false),
                    DepartmentCode = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    TransactionDate = table.Column<DateTimeOffset>(nullable: true),
                    TransactionTypeCode = table.Column<string>(nullable: true),
                    TreasuryId = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transaction_Treasury_TreasuryId",
                        column: x => x.TreasuryId,
                        principalTable: "Treasury",
                        principalColumn: "TreasuryId");
                    table.ForeignKey(
                        name: "FK_Transaction_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcitivityAttendance_ActivityId",
                table: "AcitivityAttendance",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMember_UserId",
                table: "ProjectMember",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_TreasuryId",
                table: "Transaction",
                column: "TreasuryId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_UserId",
                table: "Transaction",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserResource_ResourceId",
                table: "UserResource",
                column: "ResourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcitivityAttendance");

            migrationBuilder.DropTable(
                name: "ActivityType");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "ProjectMember");

            migrationBuilder.DropTable(
                name: "ProjectPosition");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "TransactionType");

            migrationBuilder.DropTable(
                name: "UserResource");

            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "Treasury");

            migrationBuilder.DropTable(
                name: "Resource");

            migrationBuilder.AddColumn<string>(
                name: "Resource",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "User",
                nullable: true);
        }
    }
}
