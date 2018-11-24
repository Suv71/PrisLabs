using DAL.Database;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementation.Database
{
    public class DbPersonRepository : IPersonRepository
    {
        private readonly DatabaseContext _context;

        public DbPersonRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
        }

        public void Delete(Guid personId)
        {
            var deletingPerson = _context.Persons.Single(p => p.Id == personId);
            _context.Persons.Remove(deletingPerson);
            _context.SaveChanges();
        }

        public IEnumerable<Person> GetAll()
        {
            return _context.Persons.ToList();
        }

        public void Update(Guid personId, Person person)
        {
            var updatedPerson = _context.Persons.Single(o => o.Id == personId);
            updatedPerson.FullName = person.FullName;
            updatedPerson.PassportData = person.PassportData;
            _context.SaveChanges();
        }

        public Person GetById(Guid id)
        {
            return _context.Persons.Single(t => t.Id == id);
        }
    }
}
