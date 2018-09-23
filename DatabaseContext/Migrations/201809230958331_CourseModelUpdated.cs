namespace DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseModelUpdated : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Courses", "OrganizationId");
            AddForeignKey("dbo.Courses", "OrganizationId", "dbo.Organizations", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "OrganizationId", "dbo.Organizations");
            DropIndex("dbo.Courses", new[] { "OrganizationId" });
        }
    }
}
