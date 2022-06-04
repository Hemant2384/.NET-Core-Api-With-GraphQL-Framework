using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using apiproj.Models;

namespace apiproj.Database
{
    public class SqlRepository : ISqlRepository
    {
        private readonly SqlContext _context;

        public SqlRepository(SqlContext context)
        {
            _context = context;
        }

        public Task<SqlMovie> GetMovieByIdAsync(Guid id)
        {
            return _context.SqlMovie.Where(m => m.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

          public async Task<SqlMovie> AddReviewToMovieAsync(Guid id, SqlReview review)
        {
            var movie = await _context.SqlMovie.Where(m => m.Id == id).FirstOrDefaultAsync();
            movie.AddReview(review);
            await _context.SaveChangesAsync();
            return movie;
        }

        //public Task<SqlMovie> AddReviewToMovieAsync(Guid id, SqlReview review)
        //{
        //    throw new NotImplementedException();
        //}
    }
}