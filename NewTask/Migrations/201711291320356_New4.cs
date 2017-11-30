namespace NewTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User_assign_project",
                c => new
                    {
                        UserAssignid = c.Int(nullable: false, identity: true),
                        User_id = c.Int(nullable: false),
                        Pro_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserAssignid)
                .ForeignKey("dbo.Projects", t => t.Pro_id, cascadeDelete: false )
                .ForeignKey("dbo.Users", t => t.User_id, cascadeDelete: false)
                .Index(t => t.User_id)
                .Index(t => t.Pro_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User_assign_project", "User_id", "dbo.Users");
            DropForeignKey("dbo.User_assign_project", "Pro_id", "dbo.Projects");
            DropIndex("dbo.User_assign_project", new[] { "Pro_id" });
            DropIndex("dbo.User_assign_project", new[] { "User_id" });
            DropTable("dbo.User_assign_project");
        }
    }
}
