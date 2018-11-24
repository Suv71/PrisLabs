using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPersonService
    {
        void Add(Person person);

        void Update(Guid personId, Person person);

        void Delete(Guid personId);

        IEnumerable<Person> GetAll();

        Person GetById(Guid id);
    }
}
