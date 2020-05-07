using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEquipo13
{
    public class Artist : Person
    {
        private int numReproduction;

        public Artist(string name, DateTime birthday, char genre) : base (name, birthday, genre)
        {
            this.Name = name;
            this.Birthday = birthday;
            this.Genre = genre;
        }

        //Implementar acción que sume numRepdroduction a Artist... no se bien dd puede ir... tal vez una interfaz en vez de que vaya a Movies o Song o algo
    }
}
