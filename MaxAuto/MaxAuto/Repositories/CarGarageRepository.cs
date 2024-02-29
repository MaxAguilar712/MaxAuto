using MaxAuto.Repositories;
using MaxAuto.Models;
using MaxAuto.Utils;

namespace MaxAuto.Repositories
{

    public class CarGarageRepository : BaseRepository, ICarGarageRepository
    {
        public CarGarageRepository(IConfiguration configuration) : base(configuration) { }



        public List<CarGarage> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM CarGarage";
                    ;

                    var reader = cmd.ExecuteReader();

                    var garagecar = new List<CarGarage>();
                    while (reader.Read())
                    {
                        garagecar.Add(new CarGarage()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Price = DbUtils.GetInt(reader, "Price"),
                            Year = DbUtils.GetInt(reader, "Year"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Transmission = DbUtils.GetString(reader, "Transmission"),
                            Manufacturer = DbUtils.GetString(reader, "Manufacturer"),
                            Mileage = DbUtils.GetInt(reader, "Mileage"),
                            ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                            Worth = DbUtils.GetInt(reader, "Worth"),
                            UserId = DbUtils.GetInt(reader, "UserId"),

                        });
                    }

                    reader.Close();

                    return garagecar;
                }
            }
        }















        public List<CarGarage> GetByUserId(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM CarGarage";
                    var reader = cmd.ExecuteReader();

                    //cargarages is the car in the garage, CarGarage is the Garage itself
                    var garagecar = new List<CarGarage>();
                    while (reader.Read())
                    {
                        garagecar.Add(new CarGarage()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Price = DbUtils.GetInt(reader, "Price"),
                            Year = DbUtils.GetInt(reader, "Year"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Transmission = DbUtils.GetString(reader, "Transmission"),
                            Manufacturer = DbUtils.GetString(reader, "Manufacturer"),
                            Mileage = DbUtils.GetInt(reader, "Mileage"),
                            ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                            Worth = DbUtils.GetInt(reader, "Worth"),
                            UserId = DbUtils.GetInt(reader, "UserId"),
                        });
                    }
                    reader.Close();
                    return garagecar;
                }
            }
        }

        public void Add(CarGarage cargarage)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO CarGarage (
                            c.Id AS CarId, c.Price, c.Year, c.Name, c.Transmission, c.Manufacturer,c.Mileage, c.ImageUrl AS CarImageUrl, c.Worth, UserId
                        OUTPUT INSERTED.ID
                        VALUES (
                            @CarId, @Price, @Year, @Name, @Transmission, @Manufacturer, @Mileage, @CarImageUrl, @Worth, @UserId)";
                    cmd.Parameters.AddWithValue("@CarId", cargarage.Id);
                    cmd.Parameters.AddWithValue("@Price", cargarage.Id);
                    cmd.Parameters.AddWithValue("@Year", cargarage.Year);
                    cmd.Parameters.AddWithValue("@Name", cargarage.Name);
                    cmd.Parameters.AddWithValue("@Transmission", cargarage.Transmission);
                    cmd.Parameters.AddWithValue("@Manufacturer", cargarage.Manufacturer);
                    cmd.Parameters.AddWithValue("@Mileage", cargarage.Mileage);
                    cmd.Parameters.AddWithValue("@CarImageUrl", cargarage.ImageUrl);
                    cmd.Parameters.AddWithValue("@Worth", cargarage.Worth);
                    cmd.Parameters.AddWithValue("@UserId", cargarage.UserId);

                    cargarage.Id = (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}