
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MaxAuto.Models;
using MaxAuto.Utils;
using MaxAuto.Repositories;
using Microsoft.Extensions.Hosting;

namespace MaxAuto.Repositories
{
    public class PartRepository : BaseRepository, IPartRepository
    {

        public PartRepository(IConfiguration configuration) : base(configuration) { }

        public List<Part> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                SELECT p.Id AS PartId, p.Name, p.Category, p.Price
                       
                  FROM Part p  
                       
              ORDER BY p.Id"
                    ;

                    var reader = cmd.ExecuteReader();

                    var parts = new List<Part>();
                    while (reader.Read())
                    {
                        parts.Add(new Part()
                        {
                            Id = DbUtils.GetInt(reader, "PartId"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Category = DbUtils.GetString(reader, "Category"),
                            Price = DbUtils.GetInt(reader, "Price"),

                        });
                    }

                    reader.Close();

                    return parts;
                }
            }
        }


        public Part GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                          SELECT p.Id AS PartId, p.Name, p.Category, p.Price
                       
                          FROM Part p
                          WHERE Id = @Id";



                    DbUtils.AddParameter(cmd, "@Id", id);

                    var reader = cmd.ExecuteReader();

                    Part part = null;
                    if (reader.Read())
                    {
                        part = new Part()
                        {
                            Id = DbUtils.GetInt(reader, "PartId"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Category = DbUtils.GetString(reader, "Category"),
                            Price = DbUtils.GetInt(reader, "Price"),
                        };
                    }

                    reader.Close();

                    return part;
                }
            }
        }
    }
}