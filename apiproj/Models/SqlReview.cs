using System;
using System.ComponentModel.DataAnnotations;

namespace apiproj.Models
{
    public class SqlReview
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid MovieId { get; set; }
        [Required]
        public string Reviewer { get; set; }

        [Required]
        public int Stars { get; set; }
    }
}