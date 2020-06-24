namespace BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixerror : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attendances", "AttendeeId", "dbo.AspNetUsers");
            DropIndex("dbo.Attendances", new[] { "AttendeeId" });
            DropPrimaryKey("dbo.Attendances");
            AddColumn("dbo.Attendances", "FollowerId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Attendances", "FolloweeId", c => c.String());
            AlterColumn("dbo.Attendances", "AttendeeId", c => c.String(maxLength: 128));
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Courses", "Place", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 255));
            AddPrimaryKey("dbo.Attendances", new[] { "CourseId", "FollowerId" });
            CreateIndex("dbo.Attendances", "AttendeeId");
            AddForeignKey("dbo.Attendances", "AttendeeId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "AttendeeId", "dbo.AspNetUsers");
            DropIndex("dbo.Attendances", new[] { "AttendeeId" });
            DropPrimaryKey("dbo.Attendances");
            AlterColumn("dbo.Categories", "Name", c => c.String(maxLength: 255));
            AlterColumn("dbo.Courses", "Place", c => c.String(maxLength: 255));
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String(maxLength: 255));
            AlterColumn("dbo.Attendances", "AttendeeId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Attendances", "FolloweeId");
            DropColumn("dbo.Attendances", "FollowerId");
            AddPrimaryKey("dbo.Attendances", new[] { "CourseId", "AttendeeId" });
            CreateIndex("dbo.Attendances", "AttendeeId");
            AddForeignKey("dbo.Attendances", "AttendeeId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
