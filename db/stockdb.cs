using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.db;

public class StockDb:DbContext
{
    public StockDb(DbContextOptions<StockDb> options): base(options){} 
    //Child receives DB details from DI.
    //Child passes them to parent
    public DbSet<Stock> Stocks { get; set; }
    //Child defines tables
    //DbContext (parent) manages them
}