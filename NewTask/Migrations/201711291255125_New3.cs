namespace NewTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.User_assigned_project", "Pro_id_Pro_id", "dbo.Projects");
            DropForeignKey("dbo.User_assigned_project", "User_Id_User_id", "dbo.Users");
            DropIndex("dbo.User_assigned_project", new[] { "Pro_id_Pro_id" });
            DropIndex("dbo.User_assigned_project", new[] { "User_Id_User_id" });
            DropTable("dbo.User_assigned_project");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.User_assigned_project",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pro_id_Pro_id = c.Int(),
                        User_Id_User_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.User_assigned_project", "User_Id_User_id");
            CreateIndex("dbo.User_assigned_project", "Pro_id_Pro_id");
            AddForeignKey("dbo.User_assigned_project", "User_Id_User_id", "dbo.Users", "User_id");
            AddForeignKey("dbo.User_assigned_project", "Pro_id_Pro_id", "dbo.Projects", "Pro_id");
        }
    }
}
