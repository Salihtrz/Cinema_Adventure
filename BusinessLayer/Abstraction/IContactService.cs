using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Class;

namespace BusinessLayer.Abstraction
{
	public interface IContactService<Contact>
	{
		void addContact (Contact contact);
		void removeContact (Contact contact);
		void updateContact (Contact contact);
		List<Contact> getAll();
		Contact getContact();

	}
}
