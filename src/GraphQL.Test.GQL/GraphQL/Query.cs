using System.Linq;
using GraphQL.Test.GQL.Data;
using GraphQL.Test.GQL.Models;
using HotChocolate;
using HotChocolate.Data;

namespace GraphQL.Test.GQL.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<User> GetUser([ScopedService] AppDbContext context)
        {
            return context.Users;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<DataLeak> GetDataLeak([ScopedService] AppDbContext context)
        {
            return context.DataLeaks;
        }
    }
}