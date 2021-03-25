using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


// Model for form that includes validation
namespace MovieCollection.Models
{
    public class AddMovie
    {
        [Key]
        public int MovieID { get; set; }

        [Required]
        public String Category { get; set; }

        [Required]
        public String Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public String Director { get; set; }

        [Required]
        public Rating Rating { get; set; }

        public Boolean Edited { get; set; }

        public String LentTo { get; set; }

        [StringLength(25, ErrorMessage = "The Notes value cannot exceed 25 characters.")]
        public String Notes { get; set; }
    }

    public enum Rating
    {
        G,
        PG,
        PG13,
        R

    }
}