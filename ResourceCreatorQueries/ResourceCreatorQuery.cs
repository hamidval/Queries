using Core;
using Dapper;
using Domain.Dtos;
using Queries.ResourceCreatorQueries.Contract;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Queries.ResourceCreatorQueries
{
    public class ResourceCreatorQuery : IResourceCreatorQuery
    {
        private readonly string ConnectionString = DbConnectionFactory.ConnectionString;
        public List<ResourceCreatorDto> GetResourceCreator(string userId)
        {
            var sql = @"SELECT * FROM dbo.ResourceCreators r WHERE r.UserId = @userId;";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var result = connection.Query<ResourceCreatorDto>(sql, new { UserId = userId }).ToList();
                return result;
            }
        }
    }
}
