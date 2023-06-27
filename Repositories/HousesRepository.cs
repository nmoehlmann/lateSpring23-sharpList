using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sharpList.Repositories
{
  public class HousesRepository
  {
    private readonly IDbConnection _db;

    public HousesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<House> GetAllHouses()
    {
      string sql = "SELECT * FROM houses ORDER BY createdAt DESC;";
      List<House> houses = _db.Query<House>(sql).ToList();
      return houses;
    }
    internal House GetHouseById(int houseId)
    {
      string sql = "SELECT * FROM houses WHERE id = @houseId;";
      House house = _db.Query<House>(sql, new { houseId }).FirstOrDefault();
      return house;
    }
    internal House CreateHouse(House houseData)
    {
      string sql = @"
        INSERT INTO houses
        (name, levels, bathrooms, bedrooms, price, description)
        VALUES
        (@name, @levels, @bathrooms, @bedrooms, @price, @description);
        SELECT * FROM houses WHERE id = LAST_INSERT_ID();
        ";
      House newHouse = _db.Query<House>(sql, houseData).FirstOrDefault();
      return newHouse;
    }

    internal int DeleteHouse(int houseId)
    {
      string sql = "DELETE FROM houses WHERE id = @houseId LIMIT 1;";
      int rows = _db.Execute(sql, new { houseId });
      return rows;
    }

    internal void UpdateHouse(House updateData)
    {
      string sql = @"
      UPDATE houses SET
      name = @name,
      levels = @levels,
      bathrooms = @bathrooms,
      bedrooms = @bedrooms,
      price = @price,
      description = @description
      WHERE id = @id;";
      _db.Execute(sql, updateData);
    }
  }
}