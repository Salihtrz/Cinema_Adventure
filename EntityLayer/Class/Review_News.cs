using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Class
{
	public class Review_News
	{
		[Key]
		public int Review_NewsId { get; set; }
		public int? UserID { get; set; }
        public int? NewsId { get; set; }
        public string? ReviewTitle { get; set; }
		public string? ReviewContent { get; set; }
		public DateTime? SendingDate { get; set; }
		public User? users { get; set; }
        public bool? State { get; set; }
        public bool? Visibility { get; set; }
    }
}
