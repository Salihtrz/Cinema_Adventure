using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Class
{
	public class Contact
	{
		public int ContactId { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactAddress { get; set; }
        public string? ContactNumber { get; set; }
    }
}
