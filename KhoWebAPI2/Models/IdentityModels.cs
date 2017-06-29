using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace KhoWebAPI2.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<KhoWebAPI2.Models.NhanVien> NhanViens { get; set; }

        public System.Data.Entity.DbSet<KhoWebAPI2.Models.SanPham> SanPhams { get; set; }

        public System.Data.Entity.DbSet<KhoWebAPI2.Models.PhieuNhap> PhieuNhaps { get; set; }

        public System.Data.Entity.DbSet<KhoWebAPI2.Models.ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }

        public System.Data.Entity.DbSet<KhoWebAPI2.Models.PhieuXuat> PhieuXuats { get; set; }

        public System.Data.Entity.DbSet<KhoWebAPI2.Models.ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }

        public System.Data.Entity.DbSet<KhoWebAPI2.Models.GiaTien> GiaTiens { get; set; }
        public object PhieuXuatDTO { get; internal set; }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditableEntity
                    && (x.State == System.Data.Entity.EntityState.Added || x.State == System.Data.Entity.EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                IAuditableEntity entity = entry.Entity as IAuditableEntity;
                if (entity != null)
                {
                    string identityName = Thread.CurrentPrincipal.Identity.Name;
                    DateTime now = DateTime.UtcNow;

                    if (entry.State == System.Data.Entity.EntityState.Added)
                    {
                       // entity.CreatedBy = identityName;
                        entity.CreatedDate = now;
                    }
                    else
                    {
                       // base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                        base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                    }

                   // entity.UpdatedBy = identityName;
                    entity.UpdatedDate = now;
                }
            }

            return base.SaveChanges();
        }
    }
}