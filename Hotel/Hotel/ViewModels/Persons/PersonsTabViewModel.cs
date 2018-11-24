using BLL.Interfaces;
using Hotel.Commands;
using Hotel.Views;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels.Persons
{
    public class PersonsTabViewModel : BaseViewModel
    {
        private Person _selectedPerson;

        public IPersonService PersonService;

        public ObservableCollection<Person> Persons { get; set; }

        public Person SelectedPerson
        {
            get => _selectedPerson;
            set
            {
                _selectedPerson = value;
                OnPropertyChanged("SelectedPerson");
            }
        }

        public SimpleCommand OpenAddPersonWindowCommand { get; set; }

        public SimpleCommand OpenEditPersonWindowCommand { get; set; }

        public SimpleCommand DeletePersonCommand { get; set; }

        public PersonsTabViewModel(IPersonService personService)
        {
            PersonService = personService;
            Persons = new ObservableCollection<Person>(PersonService.GetAll());
            OpenAddPersonWindowCommand = new SimpleCommand(c => OpenAddPersonWindow());
            OpenEditPersonWindowCommand = new SimpleCommand(c => OpenEditPersonWindow());
            DeletePersonCommand = new SimpleCommand(c => DeletePerson());
        }

        private void OpenAddPersonWindow()
        {
            var addPersonWindow = new AddPersonWindow();
            addPersonWindow.Show();
        }

        private void OpenEditPersonWindow()
        {
            if (SelectedPerson != null)
            {
                var editPersonWindow = new EditPersonWindow();
                editPersonWindow.Show();
            }
        }

        private void DeletePerson()
        {
            if (SelectedPerson != null)
            {
                PersonService.Delete(SelectedPerson.Id);
                Persons.Remove(SelectedPerson);
            }
        }
    }
}
