namespace NewTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New112 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Roles", "Role_name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Roles", "Role_name", c => c.Int(nullable: false));
        }
    }
}
