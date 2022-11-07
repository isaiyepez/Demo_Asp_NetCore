using Demo_Asp_NetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Asp_NetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        public WarehouseController()
        {

        }

        [HttpGet("GetWarehouse")]
        public IActionResult GetWarehouse()
        {
            return Ok("Hello World!");
        }

        //Es recomendable agregar "From query" decorator por legibilidad
        [HttpGet("GetWarehouseFromQuery")]
        public IActionResult GetWarehouseFromQuery([FromQuery] int userId, [FromQuery] string userName)
        {
            return Ok($"Hello user ID {userId}, and username {userName}");
        }

        [HttpGet("GetWarehouseFromRoute/{warehouseId}/{warehouseName}")]
        public IActionResult GetWarehouseFromRoute([FromRoute] int warehouseId, [FromRoute] string warehouseName)
        {
            return Ok($"Hello user id from route {warehouseId}, wharehouse {warehouseName}");
        }

        [HttpPost("CreateWarehouse")]
        public IActionResult CreateWarehouse(Warehouse warehouse)
        {
            return Ok($"Hello user id {warehouse.Id}, and username {warehouse.Name}");
        }
    }
}
