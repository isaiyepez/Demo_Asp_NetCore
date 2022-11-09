using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services.Contracts;
using Services.Services;

namespace Demo_Asp_NetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;

        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        //Usualmente se inyecta la dependencia por medio del constructor, pero
        //si solo vamos a usar un servicio en muy pocos métodos, conviene más invocar el 
        //service dentro del método en particular que lo necesita, en lugar de inyectarlo
        //en el constructor del controller
        [HttpGet("GetWarehousesFromService")]
        public IActionResult GetWarehousesFromService([FromServices] IWarehouseService _warehouseService2)
        {
            return Ok(_warehouseService2.GetWarehouses());
        }

        [HttpGet("GetWarehouses")]
        public IActionResult GetWarehouses()
        {
            return Ok(_warehouseService.GetWarehouses());
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
