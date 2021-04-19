using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using Prism.Mvvm;

namespace BirthClinic.Models
{
    public class Person : BindableBase
    {
        public Person()
        {
            Relatives = new ObservableCollection<Person>();
        }

        private int _personId;
        private string _firstName;
        private string _lastName;
        private DateTime _dateOfBirth;
        private Person _father;
        private Person _mother;
        private ICollection<Person> _relatives = new ObservableCollection<Person>();
        private Roles _role;
        private string _relation;

        public int PersonId
        {
            get => _personId;
            set => SetProperty(ref _personId, value);
        }

        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set => SetProperty(ref _dateOfBirth, value);
        }

        public Person Father
        {
            get => _father;
            set => SetProperty(ref _father, value);
        }

        public Person Mother
        {
            get => _mother;
            set => SetProperty(ref _mother, value);
        }

        public ICollection<Person> Relatives
        {
            get => _relatives;
            set => SetProperty(ref _relatives, value);
        }

        public Roles Role
        {
            get => _role;
            set => SetProperty(ref _role, value);
        }

        public string Relation
        {
            get => _relation; 
            set => SetProperty(ref _relation, value);
        }

        public enum Roles
        {
            Child,
            Father,
            Mother,
            Doctor,
            Midwife,
            SocialAssistant,
            Relative,
            Secretary,
            Nurse
        }
    }

}