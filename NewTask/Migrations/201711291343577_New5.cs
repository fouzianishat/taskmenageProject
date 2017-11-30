namespace NewTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New5 : DbMigration
    {
        public override void Up()
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
                        Priority = c.String(),
                    })
                .PrimaryKey(t => t.Task_id)
                .ForeignKey("dbo.Projects", t => t.Selectproject, cascadeDelete: false)
                .ForeignKey("dbo.User_assign_project", t => t.Assignto, cascadeDelete: false)
                .Index(t => t.Selectproject)
                .Index(t => t.Assignto);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Task_table", "Assign to", "dbo.User_assign_project");
            DropForeignKey("dbo.Task_table", "Select project", "dbo.Projects");
            DropIndex("dbo.Task_table", new[] { "Assign to" });
            DropIndex("dbo.Task_table", new[] { "Select project" });
            DropTable("dbo.Task_table");
        }
    }
}
