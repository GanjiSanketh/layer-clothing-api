using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LayerApi.Contrllers.Administration.ProductInformationController
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductInformationController : ControllerBase
    {
        private readonly IProductInformationRepository _productInformationRepository;

        public ProductInformationController(IProductInformationRepository productInformationRepository)
        {
            _productInformationRepository = productInformationRepository;
        }

        //[Authorize]
        [HttpGet("GetAllProductInformations")]
        public async Task<List<ProductInformation>> GetAllProductInformations()
        {
            List<ProductInformation> productInformation = await _productInformationRepository.GetAllProductInformations();
            return productInformation;
        }
        //[Authorize]
        [HttpGet]
        [Route("GetActiveProductInformations")]
        public async Task<List<ProductInformation>> GetActiveProductInformations()
        {
            List<ProductInformation> productInformation = await _productInformationRepository.GetActiveProductInformations();
            return productInformation;
        }
        //[Authorize]
        [HttpGet]
        [Route("GetProductsById")]
        public async Task<List<ProductInformation>> GetProductsById(int productId)
        {
            List<ProductInformation> productInformation = await _productInformationRepository.GetProductsById(productId);
            return productInformation;
        }
        //[Authorize]
        [HttpPost]
        [Route("SaveProductDetails")]
        public async Task<bool> SaveProductDetails([FromBody] ProductInformation productInformation)
        {
            bool isSaved = await _productInformationRepository.SaveProductDetails(productInformation);
            return isSaved;
        }
        //[Authorize]
        [HttpGet]
        [Route("DeleteProductInformations")]
        public async Task<bool> DeleteProductInformations(int productId)
        {
            bool isUpdated = await _productInformationRepository.DeleteProductInformations(productId);
            return isUpdated;
        }
    }
}
