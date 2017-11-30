namespace NewTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Task_table", "Select project", "dbo.Projects");
            DropForeignKey("dbo.Task_table", "user_assign_project_UserAssignid", "dbo.User_assign_project");
            DropIndex("dbo.Task_table", new[] { "Select project" });
            DropIndex("dbo.Task_table", new[] { "user_assign_project_UserAssignid" });
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Comment_id = c.Int(nullable: false, identity: true),
                        Pro_id = c.Int(nullable: false),
                        Task_id = c.Int(nullable: false),
                        comment = c.String(nullable: false),
                        User_Id = c.Int(nullable: false),
                        Creation_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Comment_id)
                .ForeignKey("dbo.Projects", t => t.Pro_id, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: false)
                .Index(t => t.Pro_id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Tasktbls",
                c => new
                    {
                        Task_id = c.Int(nullable: false, identity: true),
                        Task_description = c.String(),
                        Pro_id = c.Int(nullable: false),
                        UserAssignid = c.Int(nullable: false),
                        Due_date = c.String(),
                        Priority = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Task_id)
                .ForeignKey("dbo.Projects", t => t.Pro_id, cascadeDelete: false)
                .ForeignKey("dbo.User_assign_project", t => t.UserAssignid, cascadeDelete: false)
                .Index(t => t.Pro_id)
                .Index(t => t.UserAssignid);
            
            DropTable("dbo.Task_table");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Task_table",
                c => new
                    {
                        Task_id = c.Int(nullable: false, identity: true),
                        Selectproject = c.Int(name: "Select project", nullable: false),
                        Assignto = c.Int(name: "Assign to", nullable: false),
                        Task_Description = c.String(),
                        Duedate = c.DateTime(name: "Due date", nullable: false),
                        Priority = c.Int(nullable: false),
                        user_assign_project_UserAssignid = c.Int(),
                    })
                .PrimaryKey(t => t.Task_id);
            
            DropForeignKey("dbo.Tasktbls", "UserAssignid", "dbo.User_assign_project");
            DropForeignKey("dbo.Tasktbls", "Pro_id", "dbo.Projects");
            DropForeignKey("dbo.Comments", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Comments", "Pro_id", "dbo.Projects");
            DropIndex("dbo.Tasktbls", new[] { "UserAssignid" });
            DropIndex("dbo.Tasktbls", new[] { "Pro_id" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "Pro_id" });
            DropTable("dbo.Tasktbls");
            DropTable("dbo.Comments");
            CreateIndex("dbo.Task_table", "user_assign_project_UserAssignid");
            CreateIndex("dbo.Task_table", "Select project");
            AddForeignKey("dbo.Task_table", "user_assign_project_UserAssignid", "dbo.User_assign_project", "UserAssignid");
            AddForeignKey("dbo.Task_table", "Select project", "dbo.Projects", "Pro_id", cascadeDelete: true);
        }
    }
}
