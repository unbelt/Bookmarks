namespace Bookmarks.Web.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using AutoMapper;

    using Bookmarks.Web.Infrastructure.Mappings;

    public class AutoMapperConfig
    {
        private readonly Assembly assembly;

        public AutoMapperConfig(Assembly assembly)
        {
            this.assembly = assembly;
        }

        public void Execute()
        {
            var types = this.assembly.GetExportedTypes();

            var fromMaps = GetMaps(types, typeof(IMapFrom<>));
            var toMaps = GetMaps(types, typeof(IMapTo<>));

            CreateFromMappings(fromMaps);
            CreateToMappings(toMaps);

            LoadCustomMappings(types);
        }

        private static void LoadCustomMappings(IEnumerable<Type> types)
        {
            var maps = from t in types
                       from i in t.GetInterfaces()
                       where
                           typeof(IHaveCustomMapping).IsAssignableFrom(t) &&
                           !t.IsAbstract && !t.IsInterface
                       select (IHaveCustomMapping)Activator.CreateInstance(t);

            foreach (var map in maps)
            {
                map.CreateMappings(Mapper.Configuration);
            }
        }

        private static IEnumerable<MapType> GetMaps(IEnumerable<Type> types, Type interfaceType)
        {
            var fromMaps = from t in types
                           from i in t.GetInterfaces()
                           where
                                i.IsGenericType &&
                                i.GetGenericTypeDefinition() == interfaceType &&
                                !t.IsAbstract && !t.IsInterface
                           select new MapType
                           {
                               Source = i.GetGenericArguments()[0],
                               Destination = t
                           };

            return fromMaps;
        }

        private static void CreateFromMappings(IEnumerable<MapType> maps)
        {
            foreach (var map in maps)
            {
                Mapper.CreateMap(map.Source, map.Destination);
            }
        }

        private static void CreateToMappings(IEnumerable<MapType> maps)
        {
            foreach (var map in maps)
            {
                Mapper.CreateMap(map.Destination, map.Source);
            }
        }
    }
}