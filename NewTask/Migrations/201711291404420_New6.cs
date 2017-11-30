namespace NewTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Task_table", "Assign to", "dbo.User_assign_project");
            DropIndex("dbo.Task_table", new[] { "Assign to" });
            AddColumn("dbo.Task_table", "user_assign_project_UserAssignid", c => c.Int());
            CreateIndex("dbo.Task_table", "user_assign_project_UserAssignid");
            AddForeignKey("dbo.Task_table", "user_assign_project_UserAssignid", "dbo.User_assign_project", "UserAssignid");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Task_table", "user_assign_project_UserAssignid", "dbo.User_assign_project");
            DropIndex("dbo.Task_table", new[] { "user_assign_project_UserAssignid" });
            DropColumn("dbo.Task_table", "user_assign_project_UserAssignid");
            CreateIndex("dbo.Task_table", "Assign to");
            AddForeignKey("dbo.Task_table", "Assign to", "dbo.User_assign_project", "UserAssignid", cascadeDelete: false);
        }
    }
}
