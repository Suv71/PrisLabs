using Hotel.Commands;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels.Persons
{
    public class EditPersonViewModel : BaseViewModel
    {
        private readonly PersonsTabViewModel _personsTabViewModel;

        public Person EditedPerson { get; set; }
        public Action CloseAction { get; set; }
        public SimpleCommand UpdatePersonCommand { get; set; }

        public EditPersonViewModel(PersonsTabViewModel personsTabViewModel)
        {
            _personsTabViewModel = personsTabViewModel;

            EditedPerson = new Person
            {
                Id = _personsTabViewModel.SelectedPerson.Id,
                FullName = _personsTabViewModel.SelectedPerson.FullName,
                PassportData = _personsTabViewModel.SelectedPerson.PassportData,
            };

            UpdatePersonCommand = new SimpleCommand(c => UpdatePerson());
        }

        void UpdatePerson()
        {
            _personsTabViewModel.PersonService.Update(EditedPerson.Id, EditedPerson);
            var index = _personsTabViewModel.Persons.IndexOf(_personsTabViewModel.SelectedPerson);
            _personsTabViewModel.Persons[index] = EditedPerson;
            _personsTabViewModel.SelectedPerson = EditedPerson;
            CloseAction();
        }
    }
}
