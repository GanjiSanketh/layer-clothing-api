using System.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;

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
    public async Task<ProductInformation> GetProductsById(int productId)
    {
        var productIdParam = new NpgsqlParameter("productId", productId);

        var productInformation = await _context.Products
            .FromSqlRaw("SELECT * FROM get_product_by_id(@productId)", productIdParam)
            .FirstOrDefaultAsync();

        return productInformation;
    }
    public async Task<bool> SaveProductDetails(ProductInformation productInformation)
    {
        using var connection = new NpgsqlConnection(_context.Database.GetDbConnection().ConnectionString);
        await connection.OpenAsync();

        using var command = new NpgsqlCommand("CALL merge_product(@product_id, @product_name, @amount, @discount, @category_id, @is_in_stock, @status_id, @is_saved)", connection);

        command.Parameters.AddWithValue("@product_id", productInformation.ProductId);
        command.Parameters.AddWithValue("@product_name", productInformation.ProductName);
        command.Parameters.AddWithValue("@amount", productInformation.Amount);
        command.Parameters.AddWithValue("@discount", productInformation.Discount);
        // command.Parameters.AddWithValue("@category_id", productInformation.CategoryId); // uncommented
        command.Parameters.AddWithValue("@is_in_stock", productInformation.IsInStock); // use actual value
        command.Parameters.AddWithValue("@status_id", productInformation.StatusId);    // use actual value

        var isSavedValue = new NpgsqlParameter("@is_saved", NpgsqlTypes.NpgsqlDbType.Boolean)
        {
            Direction = ParameterDirection.Output
        };
        command.Parameters.Add(isSavedValue);

        await command.ExecuteNonQueryAsync();

        return (bool)isSavedValue.Value; // properly cast the output value
    }
    public async Task<bool> DeleteProductInformations(int productId)
    {
        using var connection = new NpgsqlConnection(_context.Database.GetDbConnection().ConnectionString);
        await connection.OpenAsync();

        using var command = new NpgsqlCommand("CALL update_product_status(@p_product_id, @p_status_id)", connection);
        command.Parameters.AddWithValue("@p_product_id", productId);

        await command.ExecuteNonQueryAsync();
        return true;
    }

}
