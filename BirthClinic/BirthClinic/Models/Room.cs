using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace BirthClinic.Models
{
    public class Room : BindableBase
    {
        private int _roomId;
        private string _name;
        private RoomType _type;

        public int RoomId
        {
            get => _roomId;
            set => SetProperty(ref _roomId, value);
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public RoomType Type
        {
            get => _type;
            set => SetProperty(ref _type, value);
        }

        public enum RoomType
        {
            Maternity,
            Birth,
            Rest
        }
    }
}
