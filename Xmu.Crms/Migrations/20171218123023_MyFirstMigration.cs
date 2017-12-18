using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Xmu.Crms.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "School",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Avatar = table.Column<string>(nullable: true),
                    Education = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    SchoolId = table.Column<int>(nullable: true),
                    Title = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInfo_School_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "School",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: false),
                    FivePointPercentage = table.Column<int>(nullable: false),
                    FourPointPercentage = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PresentationPercentage = table.Column<int>(nullable: false),
                    ReportPercentage = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    TeacherId = table.Column<int>(nullable: true),
                    ThreePointPercentage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_UserInfo_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClassTime = table.Column<string>(nullable: true),
                    CourseId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FivePointPercentage = table.Column<int>(nullable: false),
                    FourPointPercentage = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PresentationPercentage = table.Column<int>(nullable: false),
                    ReportPercentage = table.Column<int>(nullable: false),
                    Site = table.Column<string>(nullable: true),
                    ThreePointPercentage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassInfo_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Seminar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EndTime = table.Column<DateTime>(nullable: false),
                    IsFixed = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seminar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seminar_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attendence",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AttendanceSatus = table.Column<int>(nullable: false),
                    ClassInfoId = table.Column<int>(nullable: true),
                    StudentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendence_ClassInfo_ClassInfoId",
                        column: x => x.ClassInfoId,
                        principalTable: "ClassInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attendence_UserInfo_StudentId",
                        column: x => x.StudentId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseSelection",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClassInfoId = table.Column<int>(nullable: true),
                    StudentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSelection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSelection_ClassInfo_ClassInfoId",
                        column: x => x.ClassInfoId,
                        principalTable: "ClassInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseSelection_UserInfo_StudentId",
                        column: x => x.StudentId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FixGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClassInfoId = table.Column<int>(nullable: true),
                    LeaderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FixGroup_ClassInfo_ClassInfoId",
                        column: x => x.ClassInfoId,
                        principalTable: "ClassInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FixGroup_UserInfo_LeaderId",
                        column: x => x.LeaderId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClassInfoId = table.Column<int>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    SeminarId = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_ClassInfo_ClassInfoId",
                        column: x => x.ClassInfoId,
                        principalTable: "ClassInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Location_Seminar_SeminarId",
                        column: x => x.SeminarId,
                        principalTable: "Seminar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SeminarGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClassInfoId = table.Column<int>(nullable: true),
                    FinalGrade = table.Column<int>(nullable: false),
                    LeaderId = table.Column<int>(nullable: true),
                    PresentationGrade = table.Column<int>(nullable: false),
                    Report = table.Column<string>(nullable: true),
                    ReportGrade = table.Column<int>(nullable: false),
                    SeminarId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeminarGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeminarGroup_ClassInfo_ClassInfoId",
                        column: x => x.ClassInfoId,
                        principalTable: "ClassInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SeminarGroup_UserInfo_LeaderId",
                        column: x => x.LeaderId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SeminarGroup_Seminar_SeminarId",
                        column: x => x.SeminarId,
                        principalTable: "Seminar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    GroupNumberLimit = table.Column<int>(nullable: false),
                    GroupStudentLimit = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SeminarId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topic_Seminar_SeminarId",
                        column: x => x.SeminarId,
                        principalTable: "Seminar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FixGroupMember",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FixGroupId = table.Column<int>(nullable: true),
                    StudentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixGroupMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FixGroupMember_FixGroup_FixGroupId",
                        column: x => x.FixGroupId,
                        principalTable: "FixGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FixGroupMember_UserInfo_StudentId",
                        column: x => x.StudentId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SeminarGroupMember",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SeminarGroupId = table.Column<int>(nullable: true),
                    StudentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeminarGroupMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeminarGroupMember_SeminarGroup_SeminarGroupId",
                        column: x => x.SeminarGroupId,
                        principalTable: "SeminarGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SeminarGroupMember_UserInfo_StudentId",
                        column: x => x.StudentId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SeminarGroupTopic",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PresentationGrade = table.Column<int>(nullable: false),
                    SeminarGroupId = table.Column<int>(nullable: true),
                    TopicId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeminarGroupTopic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeminarGroupTopic_SeminarGroup_SeminarGroupId",
                        column: x => x.SeminarGroupId,
                        principalTable: "SeminarGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SeminarGroupTopic_Topic_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentScoreGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Grade = table.Column<int>(nullable: false),
                    SeminarGroupTopicId = table.Column<int>(nullable: true),
                    StudentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentScoreGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentScoreGroup_SeminarGroupTopic_SeminarGroupTopicId",
                        column: x => x.SeminarGroupTopicId,
                        principalTable: "SeminarGroupTopic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentScoreGroup_UserInfo_StudentId",
                        column: x => x.StudentId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendence_ClassInfoId",
                table: "Attendence",
                column: "ClassInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendence_StudentId",
                table: "Attendence",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassInfo_CourseId",
                table: "ClassInfo",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_TeacherId",
                table: "Course",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSelection_ClassInfoId",
                table: "CourseSelection",
                column: "ClassInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSelection_StudentId",
                table: "CourseSelection",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_FixGroup_ClassInfoId",
                table: "FixGroup",
                column: "ClassInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_FixGroup_LeaderId",
                table: "FixGroup",
                column: "LeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_FixGroupMember_FixGroupId",
                table: "FixGroupMember",
                column: "FixGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_FixGroupMember_StudentId",
                table: "FixGroupMember",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_ClassInfoId",
                table: "Location",
                column: "ClassInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_SeminarId",
                table: "Location",
                column: "SeminarId");

            migrationBuilder.CreateIndex(
                name: "IX_Seminar_CourseId",
                table: "Seminar",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SeminarGroup_ClassInfoId",
                table: "SeminarGroup",
                column: "ClassInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_SeminarGroup_LeaderId",
                table: "SeminarGroup",
                column: "LeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_SeminarGroup_SeminarId",
                table: "SeminarGroup",
                column: "SeminarId");

            migrationBuilder.CreateIndex(
                name: "IX_SeminarGroupMember_SeminarGroupId",
                table: "SeminarGroupMember",
                column: "SeminarGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SeminarGroupMember_StudentId",
                table: "SeminarGroupMember",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SeminarGroupTopic_SeminarGroupId",
                table: "SeminarGroupTopic",
                column: "SeminarGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SeminarGroupTopic_TopicId",
                table: "SeminarGroupTopic",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentScoreGroup_SeminarGroupTopicId",
                table: "StudentScoreGroup",
                column: "SeminarGroupTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentScoreGroup_StudentId",
                table: "StudentScoreGroup",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_SeminarId",
                table: "Topic",
                column: "SeminarId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_SchoolId",
                table: "UserInfo",
                column: "SchoolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendence");

            migrationBuilder.DropTable(
                name: "CourseSelection");

            migrationBuilder.DropTable(
                name: "FixGroupMember");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "SeminarGroupMember");

            migrationBuilder.DropTable(
                name: "StudentScoreGroup");

            migrationBuilder.DropTable(
                name: "FixGroup");

            migrationBuilder.DropTable(
                name: "SeminarGroupTopic");

            migrationBuilder.DropTable(
                name: "SeminarGroup");

            migrationBuilder.DropTable(
                name: "Topic");

            migrationBuilder.DropTable(
                name: "ClassInfo");

            migrationBuilder.DropTable(
                name: "Seminar");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "School");
        }
    }
}
