using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_equipo_13_entrega_3
{
    [Serializable]
    public class Album
    {
        private string Name;
        private DateTime Year;
        private string Image;
        private Artist Artist;

        public string Name1 { get => Name; set => Name = value; }
        public DateTime Year1 { get => Year; set => Year = value; }
        public string Image1 { get => Image; set => Image = value; }
        public Artist Artist1 { get => Artist; set => Artist = value; }

        public Album(string name, DateTime year, Artist artist, string image)
        {
            this.Name = name;
            this.Year = year;
            this.Artist = artist;
            this.Image = image;
        }
    }
}
