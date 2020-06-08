using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_equipo_13_entrega_3
{
    [Serializable]
    public class Artist : Person
    {
        public Artist(string name, DateTime birthday, char genre, string link) : base (name, birthday, genre, link)
        {
            this.Name = name;
            this.Birthday = birthday;
            this.Genre = genre;
            this.Link = link;
            this.Tipo = "Artista";
            this.NumReproduction = NumReproduction;
        }
    }
}
