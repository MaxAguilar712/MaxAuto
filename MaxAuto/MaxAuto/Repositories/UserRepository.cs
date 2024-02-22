
﻿using MaxAuto.Models;
using MaxAuto.Utils;


namespace MaxAuto.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration) { }

        public List<UserProfile> GetAllProfiles()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                         SELECT up.Id, up.FirstName, up.LastName, up.DisplayName, 
                               up.Email, up.CreateDateTime, up.ImageLocation, up.UserTypeId, up.UserStatusId, up.Password,
                               ut.Name AS UserTypeName, us.Name AS UserStatusName
                          FROM UserProfile up
                               LEFT JOIN UserType ut on up.UserTypeId = ut.Id
                               LEFT JOIN UserStatus us on up.UserStatusId = us.Id
                         ORDER BY up.DisplayName";

                    // DbUtils.AddParameter(cmd, "@email", email);

                    // UserProfile userProfile = null;

                    var reader = cmd.ExecuteReader();

                    var profiles = new List<UserProfile>();
                    while (reader.Read())
                    {
                        profiles.Add(new UserProfile()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            FirstName = DbUtils.GetString(reader, "FirstName"),
                            LastName = DbUtils.GetString(reader, "LastName"),
                            DisplayName = DbUtils.GetString(reader, "DisplayName"),
                            Email = DbUtils.GetString(reader, "Email"),
                            CreateDateTime = DbUtils.GetDateTime(reader, "CreateDateTime"),
                            ImageLocation = DbUtils.GetString(reader, "ImageLocation"),
                            UserTypeId = DbUtils.GetInt(reader, "UserTypeId"),
                            UserType = new UserType()
                            {
                                Id = DbUtils.GetInt(reader, "UserTypeId"),
                                Name = DbUtils.GetString(reader, "UserTypeName"),
                            },
                            UserStatusId = DbUtils.GetInt(reader, "UserStatusId"),
                            UserStatus = new UserStatus()
                            {
                                Id = DbUtils.GetInt(reader, "UserStatusId"),
                                Name = DbUtils.GetString(reader, "UserStatusName"),
                            },
                            Password = DbUtils.GetNullableString(reader, "Password")
                        });
                    }
                    reader.Close();

                    return profiles;
                }
            }
        }

        public List<UserProfile> GetByStatusId(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                         SELECT up.Id, up.FirstName, up.LastName, up.DisplayName, 
                               up.Email, up.CreateDateTime, up.ImageLocation, up.UserTypeId, up.UserStatusId, up.Password,
                               ut.Name AS UserTypeName, us.Name AS UserStatusName
                          FROM UserProfile up
                               LEFT JOIN UserType ut on up.UserTypeId = ut.Id
                               LEFT JOIN UserStatus us on up.UserStatusId = us.Id
                          WHERE up.UserStatusId = @id
                         ORDER BY up.DisplayName";

                    DbUtils.AddParameter(cmd, "@id", id);



                    var reader = cmd.ExecuteReader();

                    var profiles = new List<UserProfile>();
                    while (reader.Read())
                    {
                        profiles.Add(new UserProfile()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            FirstName = DbUtils.GetString(reader, "FirstName"),
                            LastName = DbUtils.GetString(reader, "LastName"),
                            DisplayName = DbUtils.GetString(reader, "DisplayName"),
                            Email = DbUtils.GetString(reader, "Email"),
                            CreateDateTime = DbUtils.GetDateTime(reader, "CreateDateTime"),
                            ImageLocation = DbUtils.GetString(reader, "ImageLocation"),
                            UserTypeId = DbUtils.GetInt(reader, "UserTypeId"),
                            UserType = new UserType()
                            {
                                Id = DbUtils.GetInt(reader, "UserTypeId"),
                                Name = DbUtils.GetString(reader, "UserTypeName"),
                            },
                            UserStatusId = DbUtils.GetInt(reader, "UserStatusId"),
                            UserStatus = new UserStatus()
                            {
                                Id = DbUtils.GetInt(reader, "UserStatusId"),
                                Name = DbUtils.GetString(reader, "UserStatusName"),
                            },
                            Password = DbUtils.GetNullableString(reader, "Password")
                        });
                    }
                    reader.Close();

                    return profiles;
                }
            }
        }

        public UserProfile GetByEmail(string email)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT up.Id, up.FirstName, up.LastName, up.DisplayName, 
                               up.Email, up.CreateDateTime, up.ImageLocation, up.UserTypeId, up.UserStatusId, up.Password,
                               ut.Name AS UserTypeName, us.Name AS UserStatusName
                          FROM UserProfile up
                               LEFT JOIN UserType ut on up.UserTypeId = ut.Id
                               LEFT JOIN UserStatus us on up.UserStatusId = us.Id
                         WHERE Email = @email";

                    DbUtils.AddParameter(cmd, "@email", email);

                    UserProfile userProfile = null;

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        userProfile = new UserProfile()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            FirstName = DbUtils.GetString(reader, "FirstName"),
                            LastName = DbUtils.GetString(reader, "LastName"),
                            DisplayName = DbUtils.GetString(reader, "DisplayName"),
                            Email = DbUtils.GetString(reader, "Email"),
                            CreateDateTime = DbUtils.GetDateTime(reader, "CreateDateTime"),
                            ImageLocation = DbUtils.GetString(reader, "ImageLocation"),
                            UserTypeId = DbUtils.GetInt(reader, "UserTypeId"),
                            UserType = new UserType()
                            {
                                Id = DbUtils.GetInt(reader, "UserTypeId"),
                                Name = DbUtils.GetString(reader, "UserTypeName"),
                            },
                            UserStatusId = DbUtils.GetInt(reader, "UserStatusId"),
                            UserStatus = new UserStatus()
                            {
                                Id = DbUtils.GetInt(reader, "UserStatusId"),
                                Name = DbUtils.GetString(reader, "UserStatusName"),
                            },
                            Password = DbUtils.GetNullableString(reader, "Password")
                        };
                    }
                    reader.Close();

                    return userProfile;
                }
            }
        }

        public UserProfile GetById(int Id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT up.Id, up.FirstName, up.LastName, up.DisplayName, 
                               up.Email, up.CreateDateTime, up.ImageLocation, up.UserTypeId, up.UserStatusId, up.Password,
                               ut.Name AS UserTypeName, us.Name AS UserStatusName
                          FROM UserProfile up
                               LEFT JOIN UserType ut on up.UserTypeId = ut.Id
                               LEFT JOIN UserStatus us on up.UserStatusId = us.Id
                         WHERE up.Id = @Id";

                    DbUtils.AddParameter(cmd, "@Id", Id);

                    UserProfile userProfile = null;

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        userProfile = new UserProfile()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            FirstName = DbUtils.GetString(reader, "FirstName"),
                            LastName = DbUtils.GetString(reader, "LastName"),
                            DisplayName = DbUtils.GetString(reader, "DisplayName"),
                            Email = DbUtils.GetString(reader, "Email"),
                            CreateDateTime = DbUtils.GetDateTime(reader, "CreateDateTime"),
                            ImageLocation = DbUtils.GetString(reader, "ImageLocation"),
                            UserTypeId = DbUtils.GetInt(reader, "UserTypeId"),
                            UserType = new UserType()
                            {
                                Id = DbUtils.GetInt(reader, "UserTypeId"),
                                Name = DbUtils.GetString(reader, "UserTypeName"),
                            },
                            UserStatusId = DbUtils.GetInt(reader, "UserStatusId"),
                            UserStatus = new UserStatus()
                            {
                                Id = DbUtils.GetInt(reader, "UserStatusId"),
                                Name = DbUtils.GetString(reader, "UserStatusName"),
                            },
                            Password = DbUtils.GetNullableString(reader, "Password")
                        };
                    }
                    reader.Close();

                    return userProfile;
                }
            }
        }

        public void Add(UserProfile userProfile)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO UserProfile (FirstName, LastName, DisplayName, 
                                                                    Email, CreateDateTime, ImageLocation, UserTypeId, UserStatusId, Password)
                                            OUTPUT INSERTED.ID
                                            VALUES (@FirstName, @LastName, @DisplayName, 
                                                    @Email, @CreateDateTime, @ImageLocation, @UserTypeId, @UserStatusId, @Password)";
                    DbUtils.AddParameter(cmd, "@FirstName", userProfile.FirstName);
                    DbUtils.AddParameter(cmd, "@LastName", userProfile.LastName);
                    DbUtils.AddParameter(cmd, "@DisplayName", userProfile.DisplayName);
                    DbUtils.AddParameter(cmd, "@Email", userProfile.Email);
                    DbUtils.AddParameter(cmd, "@CreateDateTime", userProfile.CreateDateTime);
                    DbUtils.AddParameter(cmd, "@ImageLocation", userProfile.ImageLocation);
                    DbUtils.AddParameter(cmd, "@UserTypeId", userProfile.UserTypeId);
                    DbUtils.AddParameter(cmd, "@UserStatusId", userProfile.UserStatusId);
                    DbUtils.AddParameter(cmd, "@Password", DbUtils.ValueOrDBNull(userProfile.Password));

                    userProfile.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void UpdateStatusId(UserProfile user)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE UserProfile
                           SET UserStatusId = @UserStatusId
                           WHERE Id = @Id";

                    DbUtils.AddParameter(cmd, "@UserStatusId", user.UserStatusId);
                    DbUtils.AddParameter(cmd, "@Id", user.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}