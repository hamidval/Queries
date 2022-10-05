using Domain.Enums;
using Domain.Dtos;
using System;
using System.Collections.Generic;
using Domain.Dtos;

namespace Queries.ImageQueries.Contracts
{
    public interface IImageQuery
    {
        public List<S3ImageDto> GetImage(int id);

        public List<S3ImageDto> GetImageByUserId(string userId);
    }
}
