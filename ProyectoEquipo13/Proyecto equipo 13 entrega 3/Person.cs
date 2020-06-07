using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_equipo_13_entrega_3
{
    [Serializable]
    public class Person
    {
        private string name;
        private DateTime birthday;
        private char genre; //M o F
        private string link; //Link que deriva a IMDB
        private string tipo;
        protected int numReproduction = 0;

        public string Name { get => name; set => name = value; }
        public DateTime Birthday { get => birthday; set => birthday = value; }
        public char Genre { get => genre; set => genre = value; }
        public string Link { get => link; set => link = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public int NumReproduction { get => numReproduction; set => numReproduction = value; }

        public Person(string name, DateTime birthday, char genre, string link)
        {
            this.Name = name;
            this.Birthday = birthday;
            this.Genre = genre;
            this.Link = link;
        }
    }
}
