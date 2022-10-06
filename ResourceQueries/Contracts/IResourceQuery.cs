using Domain.Enums;
using Domain.Dtos;
using System;
using System.Collections.Generic;
using Domaim.Dtos;

namespace Queries.ResourceQueries.Contracts
{
    public interface IResourceQuery
    {
        public List<ResourceDto> GetResources(string userId, ResourceStatus? status = null);
        public List<ResourceDto> GetResources(int id, ResourceStatus? status = null);
        public List<ResourceDto> GetResources(Level level, Subject subject);
        public List<ResourceHtmlDto> GetHtmlResources(int id);



    }
}
