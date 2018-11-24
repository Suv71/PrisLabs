using BLL.Interfaces;
using Hotel.Commands;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.ViewModels.Persons
{
    public class AddPersonViewModel : BaseViewModel
    {
        private readonly PersonsTabViewModel _personsTabViewModel;
        private readonly IPersonService _personService;

        public Person Person { get; set; }
        public Action CloseAction { get; set; }
        public SimpleCommand AddPersonCommand { get; set; }

        public AddPersonViewModel(PersonsTabViewModel personsTabViewModel, IPersonService personService)
        {
            _personsTabViewModel = personsTabViewModel;
            _personService = personService;

            Person = new Person();

            AddPersonCommand = new SimpleCommand(c => AddPerson());
        }

        private void AddPerson()
        {
            try
            {
                _personsTabViewModel.PersonService.Add(Person);
                _personsTabViewModel.Persons.Add(Person);

                CloseAction();
            }
            catch (InvalidOperationException e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
