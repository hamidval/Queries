using Domain.Enums;
using Dapper;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Domain.Dtos;
using Queries.ImageQueries.Contracts;
using Core;

namespace Queries.ImageQueries
{
    public class ImageQuery : IImageQuery
    {
        private readonly string ConnectionString = DbConnectionFactory.ConnectionString;

        public List<S3ImageDto> GetImage(int id)
        {
            var sql = @"SELECT * FROM dbo.S3Images i WHERE i.Id = @id";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var result = connection.Query<S3ImageDto>(sql, new { Id = id }).ToList();
                return result;
            }
        }

        public List<S3ImageDto> GetImageByUserId(string userId)
        {
            var sql = @"SELECT * FROM dbo.S3Images i WHERE i.UserId = @userId";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var result = connection.Query<S3ImageDto>(sql, new { UserId = userId }).ToList();
                return result;
            }
        }
    }
}
