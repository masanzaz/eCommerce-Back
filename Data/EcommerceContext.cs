using System;
using System.Linq;
using System.Security.Principal;
using eCommerce.Core;
using eCommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpOverrides;
using System.Threading.Tasks;

namespace eCommerce.Data
{
    public class EcommerceContext : IdentityDbContext<Users>
    {
        private readonly IIdentity _identity;
        private readonly HttpContext _httpContext;

        public EcommerceContext(DbContextOptions<EcommerceContext> opt) : base(opt)
        {
        
        }
        protected override void OnModelCreating(ModelBuilder builder)  
        {  
            base.OnModelCreating(builder);  

            builder.Entity<IdentityRole>(entity => { entity.ToTable(name: "roles"); });
            builder.Entity<Users>(entity => { entity.ToTable(name: "users"); });
            builder.Entity<IdentityUserRole<string>>(entity => { entity.ToTable("user_roles"); });
            builder.Entity<IdentityUserClaim<string>>(entity => { entity.ToTable("user_claims"); });
            builder.Entity<IdentityUserLogin<string>>(entity => { entity.ToTable("user_logins"); });
            builder.Entity<IdentityUserToken<string>>(entity => { entity.ToTable("user_tokens"); });
            builder.Entity<IdentityRoleClaim<string>>(entity => { entity.ToTable("role_claims"); });


        }  

        public DbSet<Products> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrdersDetails> OrdersDetails { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            CheckForAuditables();
            return await base.SaveChangesAsync();
        }

        public void CheckForAuditables()
        {
            var a = ChangeTracker.Entries();
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditable
                            && (x.State == EntityState.Added
                            || x.State == EntityState.Modified
                            || x.State == EntityState.Deleted));

            DateTime now = DateTime.Now;
            string identityName = _identity?.Name ?? "Servicio Local";
            var iP = Convert.ToString(_httpContext?.Connection.RemoteIpAddress);


            foreach (var entry in modifiedEntries)
            {   
                IAuditable entity = (IAuditable)entry.Entity;               
                if (entity != null)
                {
                    switch (entry.State)
                    {
                        case (EntityState.Added):
                            entity.CreatedBy = identityName;
                            entity.CreatedDate = now;
                            entity.CreatedIp = iP;
                            entity.Active = true;
                            break;

                        case (EntityState.Modified):
                            entity.ModifiedDate = now;
                            entity.ModifiedBy = identityName;
                            entity.ModifiedBy = iP;
                            break;

                        case (EntityState.Deleted):
                            entity.ModifiedDate = now;
                            entity.ModifiedBy = identityName;
                            entity.ModifiedBy = iP;
                            entity.Active = false;
                            entry.State = EntityState.Modified;
                            break;
                    }
                }
            }
        }
    }

}