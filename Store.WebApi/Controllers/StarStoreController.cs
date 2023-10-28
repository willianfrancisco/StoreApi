using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.DTOs;
using Store.Application.Interfaces;

namespace Store.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class StarStoreController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IPurchaseService _purchaseService;

        public StarStoreController(IProductService productService, IPurchaseService purchaseService)
        {
            _productService = productService;
            _purchaseService = purchaseService;
        }

        [HttpPost("product")]
        public async Task<IActionResult> AddProductToCar([FromBody] ProductDTO productDTO)
        {
            var result = await _productService.AddProductToCart(productDTO);
            return result ?
                    new ObjectResult(productDTO){StatusCode = StatusCodes.Status201Created} 
                    : BadRequest();
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _productService.GetAllProducts());
        }

        [HttpPost("buy")]
        public async Task<IActionResult> Buy([FromBody] PurchaseDTO purchaseDTO)
        {
            var result = await _purchaseService.Buy(purchaseDTO);
            return result ?
                    new ObjectResult(purchaseDTO){StatusCode = StatusCodes.Status201Created} 
                    : BadRequest();
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetHistory()
        {
            return Ok(await _purchaseService.GetAllPurchases());
        }

        [HttpGet("{clientId}/history")]
        public async Task<IActionResult> GetHistoryByClientId([FromRoute]string clientId)
        {
            return Ok(await _purchaseService.GetPurchasesByClientId(clientId));
        }
    }
}