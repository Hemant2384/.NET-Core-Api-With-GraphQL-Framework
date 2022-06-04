using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace apiproj.Models
{
    public class SqlMovie
    {
        [Required]
        public IList<SqlReview> Reviews { get; set; }
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public void AddReview(SqlReview review)
        {
            Reviews.Add(review);
        }
    }
}