using Domain.Enums;
using Domain.Dtos;
using System;
using System.Collections.Generic;
using Domain.Dtos;

namespace Queries.ResourceDetailsQueries.Contracts
{
    public interface IResourceDetailsQuery
    {
        public List<ResourceDto> GetResources(Level level, Subject subject);
        public List<ResourceFileDto> GetResourceFiles(int id);

        public List<ResourceFileDto> GetResourceFilesByResource(int id);
    }
}
