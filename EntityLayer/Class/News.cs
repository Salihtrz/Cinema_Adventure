using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Class
{
	public class News
	{
        [Key]
        public int NewsId { get; set; }
        public string? NewsTitle { get; set; }
        public string? NewsContent { get; set; }
        public string? NewsPicture { get; set; }
        public DateTime? SendingDate { get; set; }
        public IEnumerable<Review_News>? reviews_News { get; set; }
	}
}
