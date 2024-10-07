using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityLayer.Class
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public string? MovieName { get; set; }
        public string? MovieContent { get; set; }
        public string? MoviePicture { get; set; }
        public string? ReleaseCountry { get; set; }
        public string? VideoLink { get; set; }
        public int? MovieRunTime { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public IEnumerable<Review>? Reviews { get; set; }
        public IEnumerable<MovieCast>? MovieCasts { get; set; }
        public IEnumerable<MovieCategory>? MovieCategories { get; set; }
    }
}
