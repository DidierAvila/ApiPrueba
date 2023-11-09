using System.Net.Mime;
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

        [HttpPost()]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Cajero")]
        public async Task<IActionResult> Create([FromBody] CreateProduct createRequest, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Create");
            ReadProduct result = await _ProductService.Create(createRequest, cancellationToken);
            return Ok("Created Product");
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

        [HttpPut("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Cajero")]
        public async Task<IActionResult> Update([FromRoute]int id, [FromBody] UpdateProduct updateRequest, CancellationToken cancellationToken)
        {
            ReadProduct response = await _ProductService.Get(id, cancellationToken);
            if (response == null)
            {
                return NotFound("Not found product");
            }
            else
            {
                if (updateRequest.Id != id)
                {
                    return BadRequest("Product Id and id doesn't match");
                }

                response = await _ProductService.Update(updateRequest, cancellationToken);
                return Ok("Product updated.");
            }
        }
    }
}