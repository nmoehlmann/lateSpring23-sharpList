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

    [HttpGet]
    public ActionResult<List<House>> GetAllHouses()
    {
      try
      {
        List<House> houses = _housesService.GetAllHouses();
        return Ok(houses);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{houseId}")]
    public ActionResult<House> GetHouseById(int houseId)
    {
      try
      {
        House house = _housesService.GetHouseById(houseId);
        return Ok(house);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
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
    [HttpDelete("{houseId}")]
    public ActionResult<House> DeleteHouse(int houseId)
    {
      try
      {
        string message = _housesService.DeleteHouse(houseId);
        return Ok(message);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{houseId}")]

    public ActionResult<House> UpdateHouse(int houseId, [FromBody] House updateData)
    {
      try
      {
        updateData.Id = houseId;
        House house = _housesService.UpdateHouse(updateData);
        return Ok(house);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }

}