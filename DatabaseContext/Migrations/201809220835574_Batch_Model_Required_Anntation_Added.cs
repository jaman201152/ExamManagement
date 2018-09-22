namespace DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Batch_Model_Required_Anntation_Added : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Batches", "BatchNo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Batches", "BatchNo", c => c.String());
        }
    }
}
