using Domain.Enums;
using Domain.Dtos;
using System;
using System.Collections.Generic;
using Domaim.Dtos;

namespace Queries.SearchQueries.Contracts
{
    public interface IResourceQuery
    {
        public List<ResourceDto> GetResources(Level level, Subject subject);

        public List<ResourceDto> GetResources(int id);

        public List<ResourceHtmlDto> GetHtmlResources(int id);

        public List<ResourceDto> GetResourcesById(string userId);


    }
}
