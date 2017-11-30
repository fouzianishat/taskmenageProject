namespace NewTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New51 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Task_table", "Priority", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Task_table", "Priority", c => c.String());
        }
    }
}
