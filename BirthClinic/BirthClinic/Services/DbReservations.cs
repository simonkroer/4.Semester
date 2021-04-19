using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using BirthClinic.Context;
using BirthClinic.Models;

namespace BirthClinic.Services
{
    public interface IReservationService
    {
        List<Reservation> GetList();
    }
    public class DbReservationService : IReservationService
    {
        public List<Reservation> GetList()
        {
            using (var context = new BirthClinicContext())
            {
                return context.Reservations.ToList();
            }

        }

    }
}
