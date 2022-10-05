using Domain.Enums;
using Dapper;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using Domain.Dtos;
using Queries.ResourceDetailsQueries.Contracts;
using Core;

namespace Queries.ResourceDetailsQuery
{
    public class ResourceDetailsQuery : IResourceDetailsQuery
    {
        private readonly string ConnectionString = DbConnectionFactory.ConnectionString;


        public List<ResourceDto> GetResources(Level level, Subject subject)
        {

            var sql = @"SELECT * FROM dbo.Resources r WHERE r.Level = @level and r.subject = @subject and r.ResourceStatus != 1";

            if (level == Level.None && subject == Subject.None)
            {
                sql = @"SELECT * FROM dbo.Resources r WHERE r.ResourceStatus != 1";
            }
            else if (level == Level.None)
            {
                sql = @"SELECT * FROM dbo.Resources r WHERE r.subject = @subject and r.ResourceStatus != 1";
            }
            else if (subject == Subject.None)
            {
                sql = @"SELECT * FROM dbo.Resources r WHERE r.Level = @level and r.ResourceStatus != 1";
            }

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var result = connection.Query<ResourceDto>(sql, new { level = level, subject = subject }).ToList();
                return result;
            }

        }

        public List<ResourceDto> GetResources(int id)
        {
            var sql = @"SELECT * FROM dbo.Resources r WHERE r.Id = @id;";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var result = connection.Query<ResourceDto>(sql, new { id = id }).ToList();
                return result;
            }
        }


        public List<ResourceFileDto> GetResourceFiles(int id) {

            var sql = @"SELECT * FROM dbo.ResourceFiles rf WHERE rf.Id = @id;";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var result = connection.Query<ResourceFileDto>(sql, new { id = id }).ToList();
                return result;
            }
        }

        public List<ResourceFileDto> GetResourceFilesByResource(int id)
        {

            var sql = @"SELECT * FROM dbo.ResourceFiles rf WHERE rf.ResourceId = @id;";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var result = connection.Query<ResourceFileDto>(sql, new { id = id }).ToList();
                return result;
            }
        }
    }
}
