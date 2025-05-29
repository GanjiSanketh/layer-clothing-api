public interface IProductInformationRepository
{
    Task<List<ProductInformation>> GetAllProductInformations();
    Task<List<ProductInformation>> GetActiveProductInformations();
    Task<List<ProductInformation>> GetProductsById(int productId);
    Task<bool> SaveProductDetails(ProductInformation productInformation);
    Task<bool> DeleteProductInformations(int productId);
}