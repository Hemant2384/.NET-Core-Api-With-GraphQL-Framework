using System;
using System.Threading.Tasks;
using apiproj.Models;

namespace apiproj.Database
{
    public interface ISqlRepository
    {
        Task<SqlMovie> GetMovieByIdAsync(Guid id);
        Task<SqlMovie> AddReviewToMovieAsync(Guid id, SqlReview review);
    }
}
