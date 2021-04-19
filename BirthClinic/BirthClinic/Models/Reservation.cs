using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Prism.Mvvm;

namespace BirthClinic.Models
{
    public class Reservation : BindableBase
    {

        public Reservation()
        {
            Clinicians = new ObservableCollection<Person>();
        }
        private int _reservationId;
        private Person _father;
        private Person _mother;
        private Person _child;
        private Room _room;
        private DateTime _from;
        private DateTime _to;
        private ICollection<Person> _clinicians;

        public int ReservationId
        {
            get => _reservationId;
            set => SetProperty(ref _reservationId, value);
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

        public Person Child
        {
            get => _child;
            set => SetProperty(ref _child, value);
        }

        public Room Room
        {
            get => _room;
            set => SetProperty(ref _room, value);
        }

        public DateTime From
        {
            get => _from;
            set => SetProperty(ref _from, value);
        }

        public DateTime To
        {
            get => _to;
            set => SetProperty(ref _to, value);
        }

        public ICollection<Person> Clinicians
        {
            get => _clinicians;
            set => SetProperty(ref _clinicians, value);
        }
    }
}