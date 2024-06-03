using Microsoft.EntityFrameworkCore;
using ZDZCode_Api.Src.Domain.Entities;

public class DbAdapter(DbContextOptions<DbAdapter> options) : DbContext(options)
{
    public DbSet<BillsEntity> Bills => Set<BillsEntity>();
}