using BrasilGeo.Domain.Entities;
using BrasilGeo.Domain.Entities.IBGE;
using Microsoft.EntityFrameworkCore;

namespace BrasilGeo.Infra.Context
{
    public class BrazilGeoContext : DbContext
    {
        public BrazilGeoContext(DbContextOptions<BrazilGeoContext> options)
            :base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<LocationIBGE> LocationIBGEs { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);
        }
    }
}
