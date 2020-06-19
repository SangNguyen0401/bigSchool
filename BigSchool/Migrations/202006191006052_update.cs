namespace BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attendances", "AttendeeId", "dbo.AspNetUsers");
            DropIndex("dbo.Attendances", new[] { "AttendeeId" });
            RenameColumn(table: "dbo.Attendances", name: "AttendeeId", newName: "Attendee_Id");
            DropPrimaryKey("dbo.Attendances");
            AddColumn("dbo.Attendances", "FollowerId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Attendances", "FolloweeId", c => c.String());
            AlterColumn("dbo.Attendances", "Attendee_Id", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Attendances", new[] { "CourseId", "FollowerId" });
            CreateIndex("dbo.Attendances", "Attendee_Id");
            AddForeignKey("dbo.Attendances", "Attendee_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "Attendee_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Attendances", new[] { "Attendee_Id" });
            DropPrimaryKey("dbo.Attendances");
            AlterColumn("dbo.Attendances", "Attendee_Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Attendances", "FolloweeId");
            DropColumn("dbo.Attendances", "FollowerId");
            AddPrimaryKey("dbo.Attendances", new[] { "CourseId", "AttendeeId" });
            RenameColumn(table: "dbo.Attendances", name: "Attendee_Id", newName: "AttendeeId");
            CreateIndex("dbo.Attendances", "AttendeeId");
            AddForeignKey("dbo.Attendances", "AttendeeId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
