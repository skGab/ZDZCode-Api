using Microsoft.EntityFrameworkCore;
using ZDZCode_Api.Entities;

class BillsDb : DbContext
{
    public BillsDb(DbContextOptions<BillsDb> options)
        : base(options) { }

    public DbSet<BillsEntity> Bills => Set<BillsEntity>();
}