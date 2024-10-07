using DataAccessLayer.Abstraction;
using DataAccessLayer.Context;
using EntityLayer.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Managers
{
    public class ContactManager : IContactManager<Contact>
    {
        CinemaDb CinemaDb = new CinemaDb();
        public void addContact(Contact contact)
        {
            CinemaDb.Contacts.Add(contact);
            CinemaDb.SaveChanges();
        }

        public List<Contact> getAll()
        {
            return CinemaDb.Set<Contact>().ToList();
        }

        public Contact getContact()
        {
            return CinemaDb.Set<Contact>().FirstOrDefault();
        }

        public void removeContact(Contact contact)
        {
            CinemaDb.Remove(contact);
            CinemaDb.SaveChanges();
        }

        public void updateContact(Contact contact)
        {
            CinemaDb.Update(contact);
            CinemaDb.SaveChanges();
        }
    }
}
