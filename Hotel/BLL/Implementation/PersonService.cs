using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implementation
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public void Add(Person person)
        {
            _personRepository.Add(person);
        }

        public void Delete(Guid personId)
        {
            _personRepository.Delete(personId);
        }

        public IEnumerable<Person> GetAll()
        {
            return _personRepository.GetAll();
        }

        public void Update(Guid personId, Person person)
        {
            _personRepository.Update(personId, person);
        }

        public Person GetById(Guid id)
        {
            return _personRepository.GetById(id);
        }
    }
}
