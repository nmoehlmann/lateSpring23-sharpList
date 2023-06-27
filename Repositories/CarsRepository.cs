namespace sharpList.Repositories;

public class CarsRepository
{
  private readonly IDbConnection _db;

  public CarsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Car CreateCar(Car carData)
  {
    string sql = @"
    INSERT INTO cars
    (make, model, year, price, color, description)
    VALUES
    (@make, @model, @year, @price, @color, @description);
    SELECT * FROM cars WHERE id = LAST_INSERT_ID();
    ";
    Car car = _db.Query<Car>(sql, carData).FirstOrDefault();
    return car;
  }

  internal List<Car> GetAllCars()
  {
    string sql = "SELECT * FROM cars ORDER BY createdAt DESC;";
    List<Car> cars = _db.Query<Car>(sql).ToList();
    return cars;
  }

  internal Car GetById(int carId)
  {
    // string sql = $"SELECT * FROM cars WHERE id = {carId};"; STRING interpolation make SQL injection attacks extremely easy.
    string sql = "SELECT * FROM cars WHERE id = @carId;";
    Car car = _db.Query<Car>(sql, new { carId }).FirstOrDefault();
    return car;
  }

  internal int RemoveCar(int carId)
  {
    string sql = "DELETE FROM cars WHERE id = @carId LIMIT 1;";
    int rows = _db.Execute(sql, new { carId });
    return rows;
  }

  internal void UpdateCar(Car updateData)
  {
    string sql = @"
    UPDATE cars SET
    make = @make,
    model = @model,
    year = @year,
    price = @price,
    color = @color,
    description = @description
    WHERE id = @id;";
    _db.Execute(sql, updateData);
  }
}
