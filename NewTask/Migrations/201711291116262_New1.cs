namespace NewTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        User_id = c.Int(nullable: false, identity: true),
                        User_name = c.String(nullable: false),
                        User_Email = c.String(),
                        Default_Password = c.String(nullable: false),
                        User_status = c.String(),
                        Designation = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.User_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
