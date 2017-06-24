namespace KhoWebAPI2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiTietPhieuNhaps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SanPhamId = c.Int(nullable: false),
                        PhieuNhapId = c.Int(nullable: false),
                        giaTien = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PhieuNhaps", t => t.PhieuNhapId, cascadeDelete: true)
                .ForeignKey("dbo.SanPhams", t => t.SanPhamId, cascadeDelete: true)
                .Index(t => t.SanPhamId)
                .Index(t => t.PhieuNhapId);
            
            CreateTable(
                "dbo.PhieuNhaps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ngayNhap = c.DateTime(nullable: false),
                        tongTien = c.Int(nullable: false),
                        NhanVienId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NhanViens", t => t.NhanVienId, cascadeDelete: true)
                .Index(t => t.NhanVienId);
            
            CreateTable(
                "dbo.NhanViens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        hoNhanVien = c.String(nullable: false),
                        tenNhanVien = c.String(nullable: false),
                        ngayThamGia = c.DateTime(nullable: false),
                        diaChi = c.String(),
                        soDienThoai = c.String(),
                        email = c.String(),
                        Capbac = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SanPhams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        tenSanPham = c.String(),
                        giaSanPham = c.Int(nullable: false),
                        soLuongSanPham = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ChiTietPhieuXuats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SanPhamId = c.Int(nullable: false),
                        PhieuNhapId = c.Int(nullable: false),
                        giaTien = c.Int(nullable: false),
                        PhieuXuat_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PhieuXuats", t => t.PhieuXuat_Id)
                .ForeignKey("dbo.SanPhams", t => t.SanPhamId, cascadeDelete: true)
                .Index(t => t.SanPhamId)
                .Index(t => t.PhieuXuat_Id);
            
            CreateTable(
                "dbo.PhieuXuats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ngayNhap = c.DateTime(nullable: false),
                        tongTien = c.Int(nullable: false),
                        NhanVienId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NhanViens", t => t.NhanVienId, cascadeDelete: true)
                .Index(t => t.NhanVienId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ChiTietPhieuXuats", "SanPhamId", "dbo.SanPhams");
            DropForeignKey("dbo.ChiTietPhieuXuats", "PhieuXuat_Id", "dbo.PhieuXuats");
            DropForeignKey("dbo.PhieuXuats", "NhanVienId", "dbo.NhanViens");
            DropForeignKey("dbo.ChiTietPhieuNhaps", "SanPhamId", "dbo.SanPhams");
            DropForeignKey("dbo.ChiTietPhieuNhaps", "PhieuNhapId", "dbo.PhieuNhaps");
            DropForeignKey("dbo.PhieuNhaps", "NhanVienId", "dbo.NhanViens");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PhieuXuats", new[] { "NhanVienId" });
            DropIndex("dbo.ChiTietPhieuXuats", new[] { "PhieuXuat_Id" });
            DropIndex("dbo.ChiTietPhieuXuats", new[] { "SanPhamId" });
            DropIndex("dbo.PhieuNhaps", new[] { "NhanVienId" });
            DropIndex("dbo.ChiTietPhieuNhaps", new[] { "PhieuNhapId" });
            DropIndex("dbo.ChiTietPhieuNhaps", new[] { "SanPhamId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PhieuXuats");
            DropTable("dbo.ChiTietPhieuXuats");
            DropTable("dbo.SanPhams");
            DropTable("dbo.NhanViens");
            DropTable("dbo.PhieuNhaps");
            DropTable("dbo.ChiTietPhieuNhaps");
        }
    }
}
