using ApiPrueba.Dtos.Products;
using ApiPrueba.Services.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiPrueba.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _ProductService;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _ProductService = productService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Cajero")]
        public async Task<IActionResult> Read([FromRoute]int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Read");
            ReadProduct response = await _ProductService.Get(id, cancellationToken);
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return NotFound("Not Found Product");
            }
        }

        [HttpGet()]
        [Authorize(Roles = "Cajero")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetAll");
            ICollection<ReadProduct> response = await _ProductService.GetAll(cancellationToken);
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return NotFound("Not Found Products");
            }
        }
    }
}