using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace sharpList.Controllers
{
  [ApiController]
  [Route("api/houses")]
  public class HousesController : ControllerBase
  {
    private readonly HousesService _housesService;

    public HousesController(HousesService housesService)
    {
      _housesService = housesService;
    }

    [HttpPost]
    public ActionResult<House> CreateHouse([FromBody] House houseData)
    {
      try
      {
        House newHouse = _housesService.CreateHouse(houseData);
        return Ok(newHouse);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}