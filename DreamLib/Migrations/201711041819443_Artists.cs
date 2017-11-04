namespace DreamLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Artists : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Songs", "ArtistId", c => c.Int());
            CreateIndex("dbo.Songs", "ArtistId");
            AddForeignKey("dbo.Songs", "ArtistId", "dbo.Artists", "Id");
            DropColumn("dbo.Songs", "Artist");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Songs", "Artist", c => c.String(nullable: false));
            DropForeignKey("dbo.Songs", "ArtistId", "dbo.Artists");
            DropIndex("dbo.Songs", new[] { "ArtistId" });
            DropColumn("dbo.Songs", "ArtistId");
            DropTable("dbo.Artists");
        }
    }
}
