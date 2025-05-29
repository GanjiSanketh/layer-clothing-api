using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ProductInformationRepository : IProductInformationRepository
{
    private readonly AppDbContext _context;

    public ProductInformationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProductInformation>> GetAllProductInformations()
    {
        List<ProductInformation> productInformation = await _context.Products.FromSqlRaw("SELECT * FROM get_all_products()").ToListAsync();
        return productInformation;
    }
    public async Task<List<ProductInformation>> GetActiveProductInformations()
    {
        List<ProductInformation> productInformation = await _context.Products.FromSqlRaw("SELECT * FROM get_active_products()").ToListAsync();
        return productInformation;
    }
}
