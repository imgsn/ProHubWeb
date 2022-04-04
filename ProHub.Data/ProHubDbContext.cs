using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProHub.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ProHub.Data.Base;

namespace ProHub.Data
{
    public class ProHubDbContext : IdentityDbContext<Account, AccountRole, string,
        AccountUserClaim, AccountUserRole, AccountUserLogin, AccountRoleClaim, AccountUserToken>
    {
        public ProHubDbContext(DbContextOptions<ProHubDbContext> options)
            : base(options) { }

        public DbSet<Establishment> Establishments { get; set; }
        public DbSet<LookupItem> LookupItems { get; set; }
        public DbSet<LookupGroup> LookupGroups { get; set; }
        public DbSet<DocumentHub> DocumentHubs { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<LocationHub> LocationHubs { get; set; }
        public DbSet<MessageHub> MessageHubs { get; set; }
        public DbSet<ProductHub> ProductHubs { get; set; }
        public DbSet<TransactionHub> TransactionHubs { get; set; }







        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseLazyLoadingProxies();
        protected override void OnModelCreating(ModelBuilder builder)
        {


            base.OnModelCreating(builder);
            builder.Entity<Account>(b =>
            {
                // Each User can have many UserClaims
                b.HasMany(e => e.Claims)
                    .WithOne(e => e.User)
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                // Each User can have many UserLogins
                b.HasMany(e => e.Logins)
                    .WithOne(e => e.User)
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                // Each User can have many UserTokens
                b.HasMany(e => e.Tokens)
                    .WithOne(e => e.User)
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            builder.Entity<AccountRole>(b =>
            {
                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.UserRole)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                // Each Role can have many associated RoleClaims
                b.HasMany(e => e.RoleClaims)
                    .WithOne(e => e.Role)
                    .HasForeignKey(rc => rc.RoleId)
                    .IsRequired();
            });
            builder.Entity<Account>(b => b.ToTable("Account"));
            builder.Entity<AccountUserClaim>(b => b.ToTable("AccountUserClaim"));
            builder.Entity<AccountUserLogin>(b => b.ToTable("AccountUserLogin"));
            builder.Entity<AccountUserToken>(b => b.ToTable("AccountUserToken"));
            builder.Entity<AccountRole>(b => b.ToTable("AccountRole"));
            builder.Entity<AccountRoleClaim>(b => b.ToTable("AccountRoleClaim"));
            builder.Entity<AccountUserRole>(b => b.ToTable("AccountUserRole"));
        }

        public override int SaveChanges()
        {
            Audit();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            Audit();
            return await base.SaveChangesAsync();
        }

        private void Audit()
        {
            var entries = ChangeTracker.Entries()
                .Where(x => x.Entity is IHasAudit &&
                            (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        ((IHasAudit)entry.Entity).InsertDate = DateTime.Now;
                        // ((IHasAudite)entry.Entity).InsertUserId = Http.User.Identity
                        ;
                        break;
                    case EntityState.Modified:
                        ((IHasAudit)entry.Entity).UpdatedDate = DateTime.Now;
                        break;
                }
            }
        }

    }
}
