using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEquipo13
{
    public class Person
    {
        protected string Name;
        protected DateTime Birthday;
        protected char Genre; //M o F
        //Agregar más cosas para hacer el programa interesante??? --> tipo biografía mamá papá... nose

        public Person(string name, DateTime birthday, char genre)
        {
            this.Name = name;
            this.Birthday = birthday;
            this.Genre = genre;
        }


    }
}
