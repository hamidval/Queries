using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;
using Dapper;
using System.Data.SqlClient;
using Domain.Dtos;
using Queries.ResourceQueries.Contracts;
using Domaim.Dtos;
using System.Configuration;
using Core;

namespace Queries.ResourceQueries
{

    public class ResourceQuery : IResourceQuery
    {

        private readonly string ConnectionString = DbConnectionFactory.ConnectionString;

        public ResourceQuery()
        {

        }

        public List<ResourceDto> GetResources(string userId, ResourceStatus? status = null) {

            var sql = @"SELECT * FROM dbo.Resources r WHERE r.CreatedBy = @userId";

            if (status != null) 
            {               
                sql += @" and r.ResourceStatus = @status";
            }

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var result = connection.Query<ResourceDto>(sql, new { UserId = userId, Status = status }).ToList();
                return result;
            }
        }
        public List<ResourceDto> GetResources(int id, ResourceStatus? status = null)
        {

            var sql = @"SELECT * FROM dbo.Resources r WHERE r.Id = @id";

            if (status != null)
            {
                sql += @" and r.ResourceStatus = @status";
            }

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var result = connection.Query<ResourceDto>(sql, new { Id = id, Status = status }).ToList();
                return result;
            }
        }

        public List<ResourceDto> GetResources(Level level, Subject subject) {

            var sql = @"SELECT * FROM dbo.Resources r WHERE r.Level = @level and r.subject = @subject";

            if (level == Level.None && subject == Subject.None)
            {
                sql = @"SELECT * FROM dbo.Resources r";
            }
            else if (level == Level.None)
            {
                sql = @"SELECT * FROM dbo.Resources r WHERE r.subject = @subject";
            }
            else if (subject == Subject.None)
            {
                sql = @"SELECT * FROM dbo.Resources r WHERE r.Level = @level";
            }

            sql += " and r.ResourceStatus != 1";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var result = connection.Query<ResourceDto>(sql,new { level = level, subject = subject }).ToList();
                return result;
            }

        }

        public List<ResourceHtmlDto> GetHtmlResources(int id)
        {

            var sql = @"SELECT 
                           rh.Id,
                           rh.ResourceId,
						   rh.PageNumber,
						   rh.HtmlString
                        FROM dbo.ResourceHtmls rh
                            inner join dbo.Resources r on r.Id = rh.ResourceId
                        WHERE r.ResourceStatus != 1 and rh.ResourceId = @id";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var result = connection.Query<ResourceHtmlDto>(sql, new { id = id }).ToList();
                return result;
            }

        }

    }
}
