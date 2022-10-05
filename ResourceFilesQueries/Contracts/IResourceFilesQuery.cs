using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Queries.ResourceFilesQueries.Contracts
{
    public interface IResourceFilesQuery
    {
        public List<ResourceFileDto> GetResourceFiles(int resourceId);
    }
}
