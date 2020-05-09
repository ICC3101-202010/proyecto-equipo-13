using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEquipo13
{
    public class Person
    {
        private string name;
        private DateTime birthday;
        private char genre; //M o F
        private string link; //Link que deriva a IMDB

        protected string Name { get => name; set => name = value; }
        protected DateTime Birthday { get => birthday; set => birthday = value; }
        protected char Genre { get => genre; set => genre = value; }
        protected string Link { get => link; set => link = value; }

        public Person(string name, DateTime birthday, char genre, string link)
        {
            this.Name = name;
            this.Birthday = birthday;
            this.Genre = genre;
            this.Link = link;
        }
    }
}
