using System;
using GraphQL;
using GraphQL.Types;
using apiproj.Database;
using apiproj.GraphQL.Types;
using apiproj.Models;

namespace apiproj.GraphQL
{
    public class MutationObject : ObjectGraphType<object>
    {
        public MutationObject(ISqlRepository repository)
       {
            Name = "Mutations";
            Description = "The base mutation for all the entities in our object graph.";

           FieldAsync<MovieObject, SqlMovie>(
                "addReview",
                "Add review to a movie.",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>>
                    {
                        Name = "id",
                        Description = "The unique GUID of the movie."
                    },
                    new QueryArgument<NonNullGraphType<ReviewInputObject>>
                  {
                     Name = "review",
                        Description = "Review for the movie."
                    }),
                context =>
                {
                    var id = context.GetArgument<Guid>("id");
                    var review = context.GetArgument<SqlReview>("review");
                    return repository.AddReviewToMovieAsync(id, review);
                });
        }
    }
}