using GraphQL.Types;
using apiproj.Models;

namespace apiproj.GraphQL.Types
{
    public sealed class MovieObject : ObjectGraphType<SqlMovie>
    {
        public MovieObject()
        {
            Name = nameof(SqlMovie);
            Description = "A movie in the collection";

            Field(m => m.Id).Description("Identifier of the movie");
            Field(m => m.Name).Description("Name of the movie");
            Field(
                name: "Reviews",
                description: "Reviews of the movie",
                type: typeof(ListGraphType<ReviewObject>),
                resolve: m => m.Source.Reviews);
        }
    }
}