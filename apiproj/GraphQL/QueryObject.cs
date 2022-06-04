using System;
using GraphQL;
using GraphQL.Types;
using apiproj.Database;
using apiproj.GraphQL.Types;
using apiproj.Models;

namespace apiproj.GraphQL
{
    public class QueryObject : ObjectGraphType<object>
    {
        public QueryObject(ISqlRepository repository)
        {
            Name = "Queries";
            Description = "The base query for all the entities in our object graph.";

            FieldAsync<MovieObject, SqlMovie>(
                "movie",
                "Gets a movie by its unique identifier.",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>>
                    {
                        Name = "id",
                        Description = "The unique GUID of the movie."
                    }),
              context => repository.GetMovieByIdAsync(context.GetArgument("id", Guid.Empty)));
        }
    }
}