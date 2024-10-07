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
	public class Cast
	{
		[Key]
		public int CastId { get; set; }
        public string? CastName { get; set; }
        public string? CastSurname { get; set; }
		public string? CastPicture { get; set; }
    }
}
