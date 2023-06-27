using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sharpList.Services
{
  public class HousesService
  {
    private readonly HousesRepository _repo;

    public HousesService(HousesRepository repo)
    {
      _repo = repo;
    }

    internal List<House> GetAllHouses()
    {
      List<House> houses = _repo.GetAllHouses();
      return houses;
    }
    internal House GetHouseById(int houseId)
    {
      House house = _repo.GetHouseById(houseId);
      if (house == null) throw new Exception($"no house at id:{house}");
      return house;
    }
    internal House CreateHouse(House houseData)
    {
      House newHouse = _repo.CreateHouse(houseData);
      return newHouse;
    }
    internal string DeleteHouse(int houseId)
    {
      House house = GetHouseById(houseId);

      int rows = _repo.DeleteHouse(houseId);
      return $"House at id:{houseId} has been deleted";
    }

    internal House UpdateHouse(House updateData)
    {
      House original = GetHouseById(updateData.Id);

      original.name = updateData.name != null ? updateData.name : original.name;

      original.levels = updateData.levels != null ? updateData.levels : original.levels;

      original.bathrooms = updateData.bathrooms != null ? updateData.bathrooms : original.bathrooms;

      original.bedrooms = updateData.bedrooms != null ? updateData.bedrooms : original.bedrooms;

      original.price = updateData.price != null ? updateData.price : original.price;

      original.description = updateData.description != null ? updateData.description : original.description;

      _repo.UpdateHouse(original);
      return original;
    }
  }
}