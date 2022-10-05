using Core;
using Dapper;
using Domain.Dtos;
using Queries.ResourceFilesQueries.Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Queries.ResourceFilesQueries
{
    public class ResourceFilesQuery : IResourceFilesQuery
    {
        private readonly string ConnectionString = DbConnectionFactory.ConnectionString;
        public List<ResourceFileDto> GetResourceFiles(int resourceId)
        {
            var sql = @"SELECT * FROM dbo.ResourceFiles rf  WHERE rf.ResourceId  = @resourceId";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var result = connection.Query<ResourceFileDto>(sql, new { ResourceId = resourceId }).ToList();
                return result;
            }
        }
    }
}
