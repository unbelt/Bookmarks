﻿namespace Bookmarks.Web.Infrastructure.Mappings
{
    using AutoMapper;

    public interface IHaveCustomMapping
    {
        void CreateMappings(IConfiguration configuration);
    }
}