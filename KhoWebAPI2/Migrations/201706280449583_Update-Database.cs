namespace KhoWebAPI2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ChiTietPhieuXuats", "PhieuXuat_Id", "dbo.PhieuXuats");
            DropIndex("dbo.ChiTietPhieuXuats", new[] { "PhieuXuat_Id" });
            RenameColumn(table: "dbo.ChiTietPhieuXuats", name: "PhieuXuat_Id", newName: "PhieuXuatId");
            AlterColumn("dbo.ChiTietPhieuXuats", "PhieuXuatId", c => c.Int(nullable: false));
            CreateIndex("dbo.ChiTietPhieuXuats", "PhieuXuatId");
            AddForeignKey("dbo.ChiTietPhieuXuats", "PhieuXuatId", "dbo.PhieuXuats", "Id", cascadeDelete: true);
            DropColumn("dbo.ChiTietPhieuXuats", "PhieuNhapId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ChiTietPhieuXuats", "PhieuNhapId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ChiTietPhieuXuats", "PhieuXuatId", "dbo.PhieuXuats");
            DropIndex("dbo.ChiTietPhieuXuats", new[] { "PhieuXuatId" });
            AlterColumn("dbo.ChiTietPhieuXuats", "PhieuXuatId", c => c.Int());
            RenameColumn(table: "dbo.ChiTietPhieuXuats", name: "PhieuXuatId", newName: "PhieuXuat_Id");
            CreateIndex("dbo.ChiTietPhieuXuats", "PhieuXuat_Id");
            AddForeignKey("dbo.ChiTietPhieuXuats", "PhieuXuat_Id", "dbo.PhieuXuats", "Id");
        }
    }
}
