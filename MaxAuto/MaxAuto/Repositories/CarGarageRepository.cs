using MaxAuto.Repositories;
using MaxAuto.Models;
using MaxAuto.Utils;
using Microsoft.Data.SqlClient;
using System.Reflection.PortableExecutable;

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
                            NickName = DbUtils.GetString(reader, "NickName"),

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
                            NickName = DbUtils.GetString(reader, "NickName"),
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
                           Price, Year, Name, Transmission, Manufacturer, Mileage, ImageUrl, Worth, UserId, NickName)
                        OUTPUT INSERTED.ID
                        VALUES (
                             @Price, @Year, @Name, @Transmission, @Manufacturer, @Mileage, @ImageUrl, @Worth, @UserId, @NickName)";
;
                    cmd.Parameters.AddWithValue("@Price", cargarage.Price);
                    cmd.Parameters.AddWithValue("@Year", cargarage.Year);
                    cmd.Parameters.AddWithValue("@Name", cargarage.Name);
                    cmd.Parameters.AddWithValue("@Transmission", cargarage.Transmission);
                    cmd.Parameters.AddWithValue("@Manufacturer", cargarage.Manufacturer);
                    cmd.Parameters.AddWithValue("@Mileage", cargarage.Mileage);
                    cmd.Parameters.AddWithValue("@ImageUrl", cargarage.ImageUrl);
                    cmd.Parameters.AddWithValue("@Worth", cargarage.Worth);
                    cmd.Parameters.AddWithValue("@UserId", cargarage.UserId);
                    cmd.Parameters.AddWithValue("@NickName", cargarage.NickName);

                    cargarage.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM CarGarage WHERE Id = @Id";
                    DbUtils.AddParameter(cmd, "@Id", id);
                    cmd.ExecuteNonQuery();
                } 
            }
        }
    }
}