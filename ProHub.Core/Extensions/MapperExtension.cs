using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using X.PagedList;

namespace ProHub.Core.Extensions
{
    public static class MapperExtension
    {
        public static IPagedList<TDestination> ToMapPagedList<TSource, TDestination>(
            this IPagedList<TSource> list, IMapper mapper)
        {
            IEnumerable<TDestination> sourceList = mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(list);
            IPagedList<TDestination> pagedResult = new StaticPagedList<TDestination>(sourceList, list.GetMetaData());
            return pagedResult;
        }
    }
}
