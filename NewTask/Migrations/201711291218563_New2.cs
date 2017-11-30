namespace NewTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Pro_id = c.Int(nullable: false, identity: true),
                        Project_Name = c.String(nullable: false),
                        Description = c.String(nullable: false, maxLength: 150),
                        Code = c.String(),
                        Start_date = c.DateTime(nullable: false),
                        End_date = c.DateTime(nullable: false),
                        Duration = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        FileName = c.String(),
                    })
                .PrimaryKey(t => t.Pro_id);
            
            CreateTable(
                "dbo.User_assigned_project",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pro_id_Pro_id = c.Int(nullable:false),
                        User_Id_User_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.Pro_id_Pro_id)
                .ForeignKey("dbo.Users", t => t.User_Id_User_id)
                .Index(t => t.Pro_id_Pro_id)
                .Index(t => t.User_Id_User_id);
            
            AlterColumn("dbo.Users", "User_status", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User_assigned_project", "User_Id_User_id", "dbo.Users");
            DropForeignKey("dbo.User_assigned_project", "Pro_id_Pro_id", "dbo.Projects");
            DropIndex("dbo.User_assigned_project", new[] { "User_Id_User_id" });
            DropIndex("dbo.User_assigned_project", new[] { "Pro_id_Pro_id" });
            AlterColumn("dbo.Users", "User_status", c => c.String());
            DropTable("dbo.User_assigned_project");
            DropTable("dbo.Projects");
        }
    }
}
