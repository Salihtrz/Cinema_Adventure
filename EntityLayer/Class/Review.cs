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
	public class Review
	{
        [Key]
        public int ReviewId { get; set; }
        public int? UserID { get; set; }
        public int? MovieId { get; set; }
        public string? ReviewTitle { get; set; }
        public string? ReviewContent { get; set; }
        public int? VoteGiven { get; set; }
        public bool State { get; set; }
        public bool Visibility { get; set; }
        public DateTime? SendingDate { get; set; }
        public User? users { get; set; }
    }
}
