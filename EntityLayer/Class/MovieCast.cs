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
    public class MovieCast
    {
        [Key]
        public int MovieCastId { get; set; }
        public int? MovieId { get; set; }
        public int? CastId { get; set; }
        public Movie? movies { get; set; }
        public Cast? casts { get; set; }

    }
}