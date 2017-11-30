namespace NewTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Role_id = c.Int(nullable: false, identity: true),
                        Role_name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Role_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Roles");
        }
    }
}
