using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Queries.ResourceCreatorQueries.Contract
{
    public interface IResourceCreatorQuery
    {

        public List<ResourceCreatorDto> GetResourceCreator(string userId);
    }
}
