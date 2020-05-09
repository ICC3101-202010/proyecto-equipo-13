using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEquipo13
{
    public class Album
    {
        private string Name;
        private DateTime Year;
        //private jpg Image;
        private Artist Artist;

        public string Name1 { get => Name; set => Name = value; }
        public DateTime Year1 { get => Year; set => Year = value; }

        public Artist Artist1 { get => Artist; set => Artist = value; }
    }
}
