namespace NewTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Comments", newName: "Commenttbls");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Commenttbls", newName: "Comments");
        }
    }
}
