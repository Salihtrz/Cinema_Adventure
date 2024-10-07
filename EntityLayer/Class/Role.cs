using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Class
{
	public class Role
	{
        [Key]
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? RoleDescription { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsUser { get; set; }
        public bool IsMovieReadAccess { get; set; }
        public bool IsMovieWriteAccess { get; set; }
        public bool IsCategoryReadAccess { get; set; }
        public bool IsCategoryWriteAccess { get;set; }
        public bool IsNewsReadAccess { get; set; }
        public bool IsNewsWriteAccess { get; set; }
        public bool IsCastReadAccess { get; set; }
        public bool IsCastWriteAccess { get; set; }
        public bool IsReviewsReadAccess { get; set; }
        public bool IsReviewsWriteAccess { get; set; }
        public bool IsReview_NewsReadAccess { get; set; }
        public bool IsReview_NewsWriteAccess { get; set; }
    }
}
