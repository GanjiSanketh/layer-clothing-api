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

        [HttpGet("GetAllProductInformations")]
        //[Authorize]
        public async Task<List<ProductInformation>> GetAllProductInformations()
        {
            List<ProductInformation> productInformation = await _productInformationRepository.GetAllProductInformations();
            return productInformation;
        }
        [HttpGet("GetActiveProductInformations")]
        //[Authorize]
        public async Task<List<ProductInformation>> GetActiveProductInformations()
        {
            List<ProductInformation> productInformation = await _productInformationRepository.GetActiveProductInformations();
            return productInformation;
        }
    }
}
