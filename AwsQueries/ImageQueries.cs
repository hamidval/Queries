using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Domain.Dtos;
using System.Data.SqlClient;

namespace Queries.ImageQueries
{
    public class ImageQueries
    {
        private readonly string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=library;Trusted_Connection=True;MultipleActiveResultSets=true";
        public ImageQueries() {
            
        }


        public S3ImageDto GetImage(int id)
        {

            var sql = @"SELECT * FROM dbo.S3Images i WHERE i.Id = @id";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var result = connection.Query<S3ImageDto>(sql, new { id = id }).ToList();
                return result.FirstOrDefault();
            }

        }
    }
}
