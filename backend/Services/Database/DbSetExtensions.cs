using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BrainShark.Api.Services.Database
{
    public class DbSetQuery
    {
        public List<string> Includes { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }


    public static class DbSetExtensions
    {
        public static IQueryable<T> Query<T>(this DbSet<T> self, DbSetQuery query = null) where T : class
        {
            IQueryable<T> result = self;

            if (query == null)
                return result;

            if (query.Includes != null && query.Includes.Any())
            {
                foreach (var include in query.Includes)
                    result = result.Include<T>(include);
            }

            if (query.Skip > 0)
                result = result.Skip(query.Skip);

            if (query.Take > 0)
                result = result.Take(query.Take);

            return result;
        }


        public static IQueryable<T> Query<T>(this IQueryable<T> self, DbSetQuery query) where T : class
        {
            IQueryable<T> result = self;

            if (query == null)
                return result;

            if (query.Includes != null && query.Includes.Any())
            {
                foreach (var include in query.Includes)
                    result = result.Include<T>(include);
            }

            if (query.Skip > 0)
                result = result.Skip(query.Skip);

            if (query.Take > 0)
                result = result.Take(query.Take);

            return result;
        }

    }
}
