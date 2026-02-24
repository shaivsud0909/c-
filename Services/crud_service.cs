using api.Models;
using api.db;
using Microsoft.EntityFrameworkCore;

namespace api.Services;

public class crudService
{
    private readonly StockDb _context; //fixed _context give access to dataset tables,connection,

    public crudService(StockDb context)  // runs whenever over object is created 
    {
        _context = context;
    }
    public async Task<Stock> CreateAsync(Stock stock)
    {
        _context.Stocks.Add(stock);        
        await _context.SaveChangesAsync(); 

        return stock;
    }
    public async Task<List<Stock>> GetAllAsync()
    {
    return await _context.Stocks.ToListAsync();
    }
}



