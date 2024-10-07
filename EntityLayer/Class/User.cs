using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Class
{
	public class User
	{
        [Key]
        public int UserID { get; set; }
        public string? UserEmail { get; set; }
        public string? Password { get; set; }
        public string? UserName { get; set; }
        public string? UserSurname { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? RoleId { get; set; }
        public Role? roles { get; set; }
        public IEnumerable<Review>? reviews { get; set; }
        public IEnumerable<Review_News>? reviews_News { get; set; }
    }
}
