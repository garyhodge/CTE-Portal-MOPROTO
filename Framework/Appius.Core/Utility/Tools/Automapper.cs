using System;
using System.Collections.Generic;

using AutoMapper;

namespace Appius.Core.Utility.Tools
{
    public static class AutoMapper
    {
        private static void CreateMap<TSource, TDestination>()
        {
            var typeMap = Mapper.FindTypeMapFor<TSource, TDestination>();

            if (typeMap == null)
            {
                Mapper.CreateMap<TSource, TDestination>();
            }
        }

        /// <summary>
        /// check if a map already exists
        /// then map a source entity to a destination type
        /// </summary>
        public static TDestination Map<TSource, TDestination>(TSource obj)
        {
            CreateMap<TSource, TDestination>();
            return Mapper.Map<TSource, TDestination>(obj);
        }


        /// <summary>
        /// check if a map already exists
        /// then map a list source entity to a list of destination type
        /// </summary>
        public static IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> obj)
        {
            CreateMap<TSource, TDestination>();
            return Mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(obj);
        }
    }
}
