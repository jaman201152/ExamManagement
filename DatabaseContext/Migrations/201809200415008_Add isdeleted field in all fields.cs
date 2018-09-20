namespace DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addisdeletedfieldinallfields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Exams", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Organizations", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Participants", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Trainers", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trainers", "IsDeleted");
            DropColumn("dbo.Participants", "IsDeleted");
            DropColumn("dbo.Organizations", "IsDeleted");
            DropColumn("dbo.Exams", "IsDeleted");
            DropColumn("dbo.Courses", "IsDeleted");
        }
    }
}
