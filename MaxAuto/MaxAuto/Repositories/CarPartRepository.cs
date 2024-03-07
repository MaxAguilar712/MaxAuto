using MaxAuto.Models;
using MaxAuto.Utils;

namespace MaxAuto.Repositories
{
    public class CarPartRepository : BaseRepository, ICarPartRepository
    {

        public CarPartRepository(IConfiguration configuration) : base(configuration) { }

        public List<CarPart> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                SELECT cp.Id, cp.GarageCarPartId, cp.GarageCarId
                       
                  FROM CarPart cp 
                       
              ORDER BY cp.Id"
                    ;

                    var reader = cmd.ExecuteReader();

                    var carparts = new List<CarPart>();
                    while (reader.Read())
                    {
                        carparts.Add(new CarPart()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            GarageCarPartId = DbUtils.GetInt(reader, "GarageCarPartId"),
                            GarageCarId = DbUtils.GetInt(reader, "GarageCarId"),
                        });
                    }

                    reader.Close();

                    return carparts;
                }
            }
        }



        public List<Part> GetParts()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                SELECT cp.Id, cp.GarageCarPartId, cp.GarageCarId, p.name, p.Category, p.Price
                       
                  FROM CarPart cp 
                    JOIN Part p
                    ON cp.GarageCarPartId = p.Id
                       
              ORDER BY cp.Id"
                    ;

                    var reader = cmd.ExecuteReader();

                    var parts = new List<Part>();
                    while (reader.Read())
                    {
                        parts.Add(new Part()
                        {
                            Id = DbUtils.GetInt(reader, "GarageCarPartId"),
                            Name = DbUtils.GetString(reader, "name"),
                            Category = DbUtils.GetString(reader, "Category"),
                            Price = DbUtils.GetInt(reader, "Price"),
                            CarId = DbUtils.GetInt(reader, "GarageCarId"),

                        });
                    }

                    reader.Close();

                    return parts;
                }
            }
        }



        public CarPart GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                          SELECT cp.Id, cp.GarageCarPartId, cp.GarageCarId
                       
                          FROM CarPart cp 
                          WHERE Id = @Id";



                    DbUtils.AddParameter(cmd, "@Id", id);

                    var reader = cmd.ExecuteReader();

                    CarPart carpart = null;
                    if (reader.Read())
                    {
                        carpart = new CarPart()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            GarageCarPartId = DbUtils.GetInt(reader, "GarageCarPartId"),
                            GarageCarId = DbUtils.GetInt(reader, "GarageCarId"),
                        };
                    }

                    reader.Close();

                    return carpart;
                }
            }
        }

        public void Add(CarPart carpart)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO CarPart (
                           GarageCarPartId, GarageCarId)
                        OUTPUT INSERTED.ID
                        VALUES (
                             @GarageCarPartId, @GarageCarId)";
                    ;
                    cmd.Parameters.AddWithValue("@GarageCarPartId", carpart.GarageCarPartId);
                    cmd.Parameters.AddWithValue("@GarageCarId", carpart.GarageCarId);


                    carpart.Id = (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}

