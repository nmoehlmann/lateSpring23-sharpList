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
  }
}