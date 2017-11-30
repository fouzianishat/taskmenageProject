namespace NewTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New111 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Roles", "Role_id", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Roles", new[] { "Role_id" });
        }
    }
}
