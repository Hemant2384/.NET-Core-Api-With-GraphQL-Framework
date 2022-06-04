using GraphQL.Types;
using apiproj.Models;

namespace apiproj.GraphQL.Types
{
    public sealed class ReviewObject : ObjectGraphType<SqlReview>
    {
        public ReviewObject()
        {
            Name = nameof(SqlReview);
            Description = "A review of the movie";

            Field(r => r.Reviewer).Description("Name of the reviewer");
            Field(r => r.Stars).Description("Star rating out of five");
        }
    }
}