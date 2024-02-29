
﻿using MaxAuto.Models;
using MaxAuto.Utils;



namespace MaxAuto.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration) { }

        public List<User> GetAllProfiles()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                         SELECT u.Id, u.Name, u.Email, u.UserTypeId,
                               ut.Name AS UserTypeName, Money
                          FROM [User] u
                               LEFT JOIN UserType ut on u.UserTypeId = ut.Id
                         ORDER BY u.Name";

                    // DbUtils.AddParameter(cmd, "@email", email);

                    // User user = null;

                    var reader = cmd.ExecuteReader();

                    var profiles = new List<User>();
                    while (reader.Read())
                    {
                        profiles.Add(new User()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Email = DbUtils.GetString(reader, "Email"),
                            UserTypeId = DbUtils.GetInt(reader, "UserTypeId"),
                            UserType = new UserType()
                            {
                                Id = DbUtils.GetInt(reader, "UserTypeId"),
                                Name = DbUtils.GetString(reader, "UserTypeName"),
                            },
                            Money = DbUtils.GetInt(reader, "Money"),
                        });
                    }
                    reader.Close();

                    return profiles;
                }
            }
        }

        public List<User> GetByStatusId(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                         SELECT u.Id, u.Name, u.Email, u.UserTypeId,
                               ut.Name AS UserTypeName, Money
                          FROM [User] u
                               LEFT JOIN UserType ut on u.UserTypeId = ut.Id
                         ORDER BY u.Name";

                    DbUtils.AddParameter(cmd, "@id", id);



                    var reader = cmd.ExecuteReader();

                    var profiles = new List<User>();
                    while (reader.Read())
                    {
                        profiles.Add(new User()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Email = DbUtils.GetString(reader, "Email"),
                            UserTypeId = DbUtils.GetInt(reader, "UserTypeId"),
                            UserType = new UserType()
                            {
                                Id = DbUtils.GetInt(reader, "UserTypeId"),
                                Name = DbUtils.GetString(reader, "UserTypeName"),
                                },
                            Money = DbUtils.GetInt(reader, "Money"),
                        });
                    }
                    reader.Close();

                    return profiles;
                }
            }
        }

        public User GetByEmail(string email)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT u.Id, u.Name, u.Email, u.UserTypeId,
                               ut.Name AS UserTypeName, Money
                          FROM [User] u
                               LEFT JOIN UserType ut on u.UserTypeId = ut.Id
                         WHERE Email = @email";

                    DbUtils.AddParameter(cmd, "@email", email);

                    User user = null;

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        user = new User()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Email = DbUtils.GetString(reader, "Email"),
                            UserTypeId = DbUtils.GetInt(reader, "UserTypeId"),
                            UserType = new UserType()
                            {
                                Id = DbUtils.GetInt(reader, "UserTypeId"),
                                Name = DbUtils.GetString(reader, "UserTypeName"),
                            },
                            Money = DbUtils.GetInt(reader, "Money"),
                        };
                    }
                    reader.Close();

                    return user;
                }
            }
        }

        public User GetById(int Id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT u.Id, u.Name, u.Email, u.UserTypeId, 
                               ut.Name AS UserTypeName
                          FROM [User] u
                               LEFT JOIN UserType ut on u.UserTypeId = ut.Id
                         WHERE u.Id = @Id";

                    DbUtils.AddParameter(cmd, "@Id", Id);

                    User user = null;

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())

                        user = new User()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Email = DbUtils.GetString(reader, "Email"),
                            UserTypeId = DbUtils.GetInt(reader, "UserTypeId"),
                            UserType = new UserType()
                            {
                                Id = DbUtils.GetInt(reader, "UserTypeId"),
                                Name = DbUtils.GetString(reader, "UserTypeName"),
                            },
                            Money = DbUtils.GetInt(reader, "Money"),
                        };
                
                reader.Close();

                return user;
            }
        }
    }

        public void Add(User user)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO [User] (Name, Email, UserTypeId, Money )
                                            OUTPUT INSERTED.ID
                                            VALUES (@Name, @Email, @UserTypeId, Money )";
                    DbUtils.AddParameter(cmd, "@Name", user.Name);
                    DbUtils.AddParameter(cmd, "@Email", user.Email);
                    DbUtils.AddParameter(cmd, "@UserTypeId", user.UserTypeId);
                    DbUtils.AddParameter(cmd, "@Money", user.Money);

                    user.Id = (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}