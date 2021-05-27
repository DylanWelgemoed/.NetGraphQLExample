using System.Linq;
using GraphQL.Test.GQL.Data;
using GraphQL.Test.GQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace GraphQL.Test.GQL.GraphQL.Users
{
    public class DataLeakType : ObjectType<DataLeak>
    {
        protected override void Configure(IObjectTypeDescriptor<DataLeak> descriptor)
        {
            descriptor.Description("Represents data leaks that could of happened and annotates more detail around the leak of a user.");
            descriptor.Field(dl => dl.BreachSource).Description("Represents the location where the breach occured.");
            descriptor.Field(dl => dl.BreachType).Description("Represents the type of data that was breached.");
            descriptor
                .Field(u => u.User)
                .ResolveWith<Resolvers>(x => x.GetUser(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("This is the user that has data that has been exposed.");
        }

        private class Resolvers
        {
            public User GetUser(DataLeak dataLeak, [ScopedService] AppDbContext context)
            {
                return context.Users.FirstOrDefault(u => u.Id == dataLeak.UserId);
            }
        }
    }
}