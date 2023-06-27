namespace sharpList.Services;

public class CarsService
{
  private readonly CarsRepository _repo;

  public CarsService(CarsRepository repo)
  {
    _repo = repo;
  }

  internal Car CreateCar(Car carData)
  {
    Car car = _repo.CreateCar(carData);
    return car;
  }

  internal List<Car> GetAllCars()
  {
    List<Car> cars = _repo.GetAllCars();
    return cars;
  }

  internal Car GetById(int carId)
  {
    Car car = _repo.GetById(carId);
    if (car == null) throw new Exception($"no car at Id:{carId}");
    return car;
  }

  internal string RemoveCar(int carId)
  {
    Car car = GetById(carId);
    // TODO check if you are authorized to do this

    int rows = _repo.RemoveCar(carId);
    if (rows > 1) throw new Exception("Im not sure what happened. We Spared not exspense and yet still more than 1 thing got deleted, go check the DB immediately");

    return $"She gone. She being {car.Make} & {car.Model}.";
  }

  internal Car UpdateCar(Car updateData)
  {
    Car original = GetById(updateData.Id);
    // TODO check if you are authorized to do this

    original.Make = updateData.Make != null ? updateData.Make : original.Make;
    original.Model = updateData.Model != null ? updateData.Model : original.Model;
    original.Year = updateData.Year != null ? updateData.Year : original.Year;
    original.Price = updateData.Price != null ? updateData.Price : original.Price;
    original.Color = updateData.Color != null ? updateData.Color : original.Color;
    original.Description = updateData.Description != null ? updateData.Description : original.Description;

    _repo.UpdateCar(original);
    return original;
  }
}
