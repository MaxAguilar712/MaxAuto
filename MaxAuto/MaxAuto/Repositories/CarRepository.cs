

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
    public class CarRepository : BaseRepository, ICarRepository
    {

        public CarRepository(IConfiguration configuration) : base(configuration) { }

        public List<Car> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                SELECT c.Id AS CarId, c.Price, c.Year, c.Name, c.Transmission, c.Manufacturer,
                        c.Mileage, c.ImageUrl AS CarImageUrl, c.Worth
                       
                  FROM Car c 
                       
              ORDER BY c.Id"
                    ;

                    var reader = cmd.ExecuteReader();

                    var cars = new List<Car>();
                    while (reader.Read())
                    {
                        cars.Add(new Car()
                        {
                            Id = DbUtils.GetInt(reader, "CarId"),
                            Price = DbUtils.GetInt(reader, "Price"),
                            Year = DbUtils.GetInt(reader, "Year"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Transmission = DbUtils.GetString(reader, "Transmission"),
                            Manufacturer = DbUtils.GetString(reader, "Manufacturer"),
                            Mileage = DbUtils.GetInt(reader, "Mileage"),
                            ImageUrl = DbUtils.GetString(reader, "CarImageUrl"),
                            Worth = DbUtils.GetInt(reader, "Worth"),
                            //UserProfile = new UserProfile()
                            //{
                            //    Id = DbUtils.GetInt(reader, "UserProfileId"),
                            //    Name = DbUtils.GetString(reader, "Name"),
                            //    Email = DbUtils.GetString(reader, "Email"),
                            //    DateCreated = DbUtils.GetDateTime(reader, "UserProfileDateCreated"),
                            //    ImageUrl = DbUtils.GetString(reader, "UserProfileImageUrl"),
                            //},
                        });
                    }

                    reader.Close();

                    return cars;
                }
            }
        }

        //public List<Car> GetAllWithComments()
        //{
        //    using (var conn = Connection)
        //    {
        //        conn.Open();
        //        using (var cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandText = @"
        //           SELECT p.Id AS PostId, p.Title, p.Caption, p.DateCreated AS PostDateCreated,
        //               p.ImageUrl AS PostImageUrl, p.UserProfileId AS PostUserProfileId,

        //               up.Name, up.Bio, up.Email, up.DateCreated AS UserProfileDateCreated,
        //               up.ImageUrl AS UserProfileImageUrl,

        //               c.Id AS CommentId, c.Message, c.UserProfileId AS CommentUserProfileId,

        //               u.[Name] as CommentUserProfileName
        //          FROM Post p
        //               LEFT JOIN UserProfile up ON p.UserProfileId = up.id
        //               LEFT JOIN Comment c on c.PostId = p.id
        //               Left Join UserProfile u on c.UserProfileId = u.id
        //      ORDER BY p.DateCreated";

        //            var reader = cmd.ExecuteReader();

        //            var posts = new List<Post>();
        //            while (reader.Read())
        //            {
        //                var postId = DbUtils.GetInt(reader, "PostId");

        //                var existingPost = posts.FirstOrDefault(p => p.Id == postId);
        //                if (existingPost == null)
        //                {
        //                    existingPost = new Post()
        //                    {
        //                        Id = postId,
        //                        Title = DbUtils.GetString(reader, "Title"),
        //                        Caption = DbUtils.GetString(reader, "Caption"),
        //                        DateCreated = DbUtils.GetDateTime(reader, "PostDateCreated"),
        //                        ImageUrl = DbUtils.GetString(reader, "PostImageUrl"),
        //                        UserProfileId = DbUtils.GetInt(reader, "PostUserProfileId"),
        //                        UserProfile = new UserProfile()
        //                        {
        //                            Id = DbUtils.GetInt(reader, "PostUserProfileId"),
        //                            Name = DbUtils.GetString(reader, "Name"),
        //                            Email = DbUtils.GetString(reader, "Email"),
        //                            DateCreated = DbUtils.GetDateTime(reader, "UserProfileDateCreated"),
        //                            ImageUrl = DbUtils.GetString(reader, "UserProfileImageUrl"),
        //                        },
        //                        Comments = new List<Comment>()
        //                    };

        //                    posts.Add(existingPost);
        //                }

        //                if (DbUtils.IsNotDbNull(reader, "CommentId"))
        //                {
        //                    existingPost.Comments.Add(new Comment()
        //                    {
        //                        Id = DbUtils.GetInt(reader, "CommentId"),
        //                        Message = DbUtils.GetString(reader, "Message"),
        //                        PostId = postId,
        //                        UserProfileId = DbUtils.GetInt(reader, "CommentUserProfileId"),
        //                        UserProfile = new UserProfile()
        //                        {
        //                            Id = DbUtils.GetInt(reader, "CommentUserProfileId"),
        //                            Name = DbUtils.GetString(reader, "CommentUserProfileName")
        //                        }
        //                    });
        //                }
        //            }

        //            reader.Close();

        //            return posts;
        //        }
        //    }
        //}
        public Car GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                          SELECT c.Id AS CarId, c.Price, c.Year, c.Name, c.Transmission, c.Manufacturer,
                          c.Mileage, c.ImageUrl AS CarImageUrl, c.Worth
                       
                          FROM Car c 
                          WHERE Id = @Id";



                    DbUtils.AddParameter(cmd, "@Id", id);

                    var reader = cmd.ExecuteReader();

                    Car car = null;
                    if (reader.Read())
                    {
                        car = new Car()
                        {
                            Id = DbUtils.GetInt(reader, "CarId"),
                            Price = DbUtils.GetInt(reader, "Price"),
                            Year = DbUtils.GetInt(reader, "Year"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Transmission = DbUtils.GetString(reader, "Transmission"),
                            Manufacturer = DbUtils.GetString(reader, "Manufacturer"),
                            Mileage = DbUtils.GetInt(reader, "Mileage"),
                            ImageUrl = DbUtils.GetString(reader, "CarImageUrl"),
                            Worth = DbUtils.GetInt(reader, "Worth"),
                        };
                    }

                    reader.Close();

                    return car;
                }
            }
        }
    }
}
        //public Car GetByIdWithComments(int id)
        //{
        //    using (var conn = Connection)
        //    {
        //        conn.Open();
        //        using (var cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandText = @"
        //           SELECT p.Id AS PostId, p.Title, p.Caption, p.DateCreated AS PostDateCreated,
        //               p.ImageUrl AS PostImageUrl, p.UserProfileId AS PostUserProfileId,

//               up.Name, up.Bio, up.Email, up.DateCreated AS UserProfileDateCreated,
//               up.ImageUrl AS UserProfileImageUrl,

//               c.Id AS CommentId, c.Message, c.UserProfileId AS CommentUserProfileId,

//               u.[Name] as CommentUserProfileName
//          FROM Post p
//               LEFT JOIN UserProfile up ON p.UserProfileId = up.id
//               LEFT JOIN Comment c on c.PostId = p.id
//               Left Join UserProfile u on c.UserProfileId = u.id
//             WHERE p.Id = @Id";

//            DbUtils.AddParameter(cmd, "@Id", id);

//            var reader = cmd.ExecuteReader();

//            Car post = null;
//            if (reader.Read())
//            {

//                var postId = DbUtils.GetInt(reader, "PostId");

//                if (post == null)
//                {
//                    post = new Car()
//                    {
//                        Id = postId,
//                        Title = DbUtils.GetString(reader, "Title"),
//                        Caption = DbUtils.GetString(reader, "Caption"),
//                        DateCreated = DbUtils.GetDateTime(reader, "PostDateCreated"),
//                        ImageUrl = DbUtils.GetString(reader, "PostImageUrl"),
//                        UserProfileId = DbUtils.GetInt(reader, "PostUserProfileId"),
//                        UserProfile = new UserProfile()
//                        {
//                            Id = DbUtils.GetInt(reader, "PostUserProfileId"),
//                            Name = DbUtils.GetString(reader, "Name"),
//                            Email = DbUtils.GetString(reader, "Email"),
//                            DateCreated = DbUtils.GetDateTime(reader, "UserProfileDateCreated"),
//                            ImageUrl = DbUtils.GetString(reader, "UserProfileImageUrl"),
//                        },
//                        Comments = new List<Comment>()
//                    };

//                }

//                if (DbUtils.IsNotDbNull(reader, "CommentId"))
//                {
//                    post.Comments.Add(new Comment()
//                    {
//                        Id = DbUtils.GetInt(reader, "CommentId"),
//                        Message = DbUtils.GetString(reader, "Message"),
//                        PostId = postId,
//                        UserProfileId = DbUtils.GetInt(reader, "CommentUserProfileId"),
//                        UserProfile = new UserProfile()
//                        {
//                            Id = DbUtils.GetInt(reader, "CommentUserProfileId"),
//                            Name = DbUtils.GetString(reader, "CommentUserProfileName")
//                        }
//                    });
//                }
//            }

//            reader.Close();

//            return post;
//        }
//    }
//}
//public List<Post> Search(string criterion, bool sortDescending)
//{
//    using (var conn = Connection)
//    {
//        conn.Open();
//        using (var cmd = conn.CreateCommand())
//        {
//            var sql =
//                @"SELECT p.Id AS PostId, p.Title, p.Caption, p.DateCreated AS PostDateCreated, 
//                p.ImageUrl AS PostImageUrl, p.UserProfileId,

//                up.Name, up.Bio, up.Email, up.DateCreated AS UserProfileDateCreated, 
//                up.ImageUrl AS UserProfileImageUrl
//            FROM Post p 
//                LEFT JOIN UserProfile up ON p.UserProfileId = up.id
//            WHERE p.Title LIKE @Criterion OR p.Caption LIKE @Criterion";

//            if (sortDescending)
//            {
//                sql += " ORDER BY p.DateCreated DESC";
//            }
//            else
//            {
//                sql += " ORDER BY p.DateCreated";
//            }

//            cmd.CommandText = sql;
//            DbUtils.AddParameter(cmd, "@Criterion", $"%{criterion}%");
//            var reader = cmd.ExecuteReader();

//            var posts = new List<Post>();
//            while (reader.Read())
//            {
//                posts.Add(new Post()
//                {
//                    Id = DbUtils.GetInt(reader, "PostId"),
//                    Title = DbUtils.GetString(reader, "Title"),
//                    Caption = DbUtils.GetString(reader, "Caption"),
//                    DateCreated = DbUtils.GetDateTime(reader, "PostDateCreated"),
//                    ImageUrl = DbUtils.GetString(reader, "PostImageUrl"),
//                    UserProfileId = DbUtils.GetInt(reader, "UserProfileId"),
//                    UserProfile = new UserProfile()
//                    {
//                        Id = DbUtils.GetInt(reader, "UserProfileId"),
//                        Name = DbUtils.GetString(reader, "Name"),
//                        Email = DbUtils.GetString(reader, "Email"),
//                        DateCreated = DbUtils.GetDateTime(reader, "UserProfileDateCreated"),
//                        ImageUrl = DbUtils.GetString(reader, "UserProfileImageUrl"),
//                    },
//                });
//            }

//            reader.Close();

//            return posts;
//        }
//    }
//}

//public List<Post> SearchHottest(DateTime since)
//{
//    using (var conn = Connection)
//    {
//        conn.Open();
//        using (var cmd = conn.CreateCommand())
//        {
//            cmd.CommandText = @"
//                SELECT p.Id AS PostId, p.Title, p.Caption, p.DateCreated AS PostDateCreated, 
//                p.ImageUrl AS PostImageUrl, p.UserProfileId,

//                up.Name, up.Bio, up.Email, up.DateCreated AS UserProfileDateCreated, 
//                up.ImageUrl AS UserProfileImageUrl
//            FROM Post p 
//                LEFT JOIN UserProfile up ON p.UserProfileId = up.id
//            WHERE p.DateCreated >= @Since";

//            DbUtils.AddParameter(cmd, "@Since", $"{since}");
//            var reader = cmd.ExecuteReader();

//            var posts = new List<Post>();
//            while (reader.Read())
//            {
//                posts.Add(new Post()
//                {
//                    Id = DbUtils.GetInt(reader, "PostId"),
//                    Title = DbUtils.GetString(reader, "Title"),
//                    Caption = DbUtils.GetString(reader, "Caption"),
//                    DateCreated = DbUtils.GetDateTime(reader, "PostDateCreated"),
//                    ImageUrl = DbUtils.GetString(reader, "PostImageUrl"),
//                    UserProfileId = DbUtils.GetInt(reader, "UserProfileId"),
//                    UserProfile = new UserProfile()
//                    {
//                        Id = DbUtils.GetInt(reader, "UserProfileId"),
//                        Name = DbUtils.GetString(reader, "Name"),
//                        Email = DbUtils.GetString(reader, "Email"),
//                        DateCreated = DbUtils.GetDateTime(reader, "UserProfileDateCreated"),
//                        ImageUrl = DbUtils.GetString(reader, "UserProfileImageUrl"),
//                    },
//                });
//            }

//            reader.Close();

//            return posts;
//        }
//    }
//}


// IMPLEMENT THIS  IMPLEMENT THIS  IMPLEMENT THIS  IMPLEMENT THIS  IMPLEMENT THIS  IMPLEMENT THIS  IMPLEMENT THIS  IMPLEMENT THIS  IMPLEMENT THIS 
//        public void Add(Post post)
//        {
//            using (var conn = Connection)
//            {
//                conn.Open();
//                using (var cmd = conn.CreateCommand())
//                {
//                    cmd.CommandText = @"
//                        INSERT INTO Post (Title, Caption, DateCreated, ImageUrl, UserProfileId)
//                        OUTPUT INSERTED.ID
//                        VALUES (@Title, @Caption, @DateCreated, @ImageUrl, @UserProfileId)";

//                    DbUtils.AddParameter(cmd, "@Title", post.Title);
//                    DbUtils.AddParameter(cmd, "@Caption", post.Caption);
//                    DbUtils.AddParameter(cmd, "@DateCreated", post.DateCreated);
//                    DbUtils.AddParameter(cmd, "@ImageUrl", post.ImageUrl);
//                    DbUtils.AddParameter(cmd, "@UserProfileId", post.UserProfileId);

//                    post.Id = (int)cmd.ExecuteScalar();
//                }
//            }
//        }

// IMPLEMENT THIS  IMPLEMENT THIS  IMPLEMENT THIS  IMPLEMENT THIS  IMPLEMENT THIS  IMPLEMENT THIS  IMPLEMENT THIS  IMPLEMENT THIS  IMPLEMENT THIS 

//        public void Update(Post post)
//        {
//            using (var conn = Connection)
//            {
//                conn.Open();
//                using (var cmd = conn.CreateCommand())
//                {
//                    cmd.CommandText = @"
//                        UPDATE Post
//                           SET Title = @Title,
//                               Caption = @Caption,
//                               DateCreated = @DateCreated,
//                               ImageUrl = @ImageUrl,
//                               UserProfileId = @UserProfileId
//                         WHERE Id = @Id";

//                    DbUtils.AddParameter(cmd, "@Title", post.Title);
//                    DbUtils.AddParameter(cmd, "@Caption", post.Caption);
//                    DbUtils.AddParameter(cmd, "@DateCreated", post.DateCreated);
//                    DbUtils.AddParameter(cmd, "@ImageUrl", post.ImageUrl);
//                    DbUtils.AddParameter(cmd, "@UserProfileId", post.UserProfileId);
//                    DbUtils.AddParameter(cmd, "@Id", post.Id);

//                    cmd.ExecuteNonQuery();
//                }
//            }
//        }

// IMPLEMENT THIS  IMPLEMENT THIS  IMPLEMENT THIS  IMPLEMENT THIS  IMPLEMENT THIS  IMPLEMENT THIS  IMPLEMENT THIS  IMPLEMENT THIS  IMPLEMENT THIS 

//        public void Delete(int id)
//        {
//            using (var conn = Connection)
//            {
//                conn.Open();
//                using (var cmd = conn.CreateCommand())
//                {
//                    cmd.CommandText = "DELETE FROM Post WHERE Id = @Id";
//                    DbUtils.AddParameter(cmd, "@id", id);
//                    cmd.ExecuteNonQuery();
//                }
//            }
//        }
//    }
//}