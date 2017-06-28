namespace KhoWebAPI2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PhieuNhaps", "NhanVienId", "dbo.NhanViens");
            DropIndex("dbo.PhieuNhaps", new[] { "NhanVienId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.PhieuNhaps", "NhanVienId");
            AddForeignKey("dbo.PhieuNhaps", "NhanVienId", "dbo.NhanViens", "Id", cascadeDelete: true);
        }
    }
}
