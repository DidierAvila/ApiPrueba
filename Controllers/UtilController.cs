using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using ApiPrueba.Services.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace ApiPrueba.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UtilController : ControllerBase
    {
        private readonly IUtilService _UtilService;

        public UtilController(IUtilService utilService)
        {
            _UtilService = utilService;
        }

        [HttpGet()]
        [Route("ArrayAscOrder")]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult ArrayAscOrder()
        {
            int[] result = _UtilService.ArrayAscOrder();
            return Ok(result);
        }
    }
}