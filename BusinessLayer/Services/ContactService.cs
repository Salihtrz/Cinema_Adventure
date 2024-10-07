using BusinessLayer.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Class;
using DataAccessLayer.EntityFramework;

namespace BusinessLayer.Services
{
    public class ContactService : IContactService<Contact>
    {
        EFContact efcontact;
        public ContactService(EFContact efcontact) 
        {
            this.efcontact = efcontact;
        }
        public void addContact(Contact contact)
        {
            efcontact.addContact(contact);
        }

        public List<Contact> getAll()
        {
            return efcontact.getAll();
        }

        public Contact getContact()
        {
            return efcontact.getContact();
        }

        public void removeContact(Contact contact)
        {
            efcontact.removeContact(contact);
        }

        public void updateContact(Contact contact)
        {
            efcontact.updateContact(contact);
        }
    }
}
