using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Class
{
	public class MovieCategory
	{
        [Key]
        public int MovieCategoryId { get; set; }
        public int? MovieId { get; set; }
        public int? CategoryId { get; set; }
        public Category? categorys { get; set; }
        public Movie? movies { get; set; }
    }
}
