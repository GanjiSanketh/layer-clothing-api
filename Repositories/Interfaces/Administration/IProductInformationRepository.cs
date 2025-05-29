public interface IProductInformationRepository
{
    Task<List<ProductInformation>> GetAllProductInformations();
    Task<List<ProductInformation>> GetActiveProductInformations();
}