using System.Linq;
using GraphQL.Test.GQL.Data;
using GraphQL.Test.GQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace GraphQL.Test.GQL.GraphQL.Users
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Description("Represents users that belong to a company that is being searched for data breaches.");
            descriptor.Field(u => u.Name).Description("Represents the full name of the user.");
            descriptor.Field(u => u.LicenseKey).Ignore();
            descriptor
                .Field(u => u.DataLeaks)
                .ResolveWith<Resolvers>(x => x.GetDataLeaks(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("This is the list of data leaks the user has been exposed to.");
        }

        private class Resolvers
        {
            public IQueryable<DataLeak> GetDataLeaks(User user, [ScopedService] AppDbContext context)
            {
                return context.DataLeaks.Where(dl => dl.UserId == user.Id);
            }
        }
    }
}