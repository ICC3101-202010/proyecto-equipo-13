using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEquipo13
{
    public class Album
    {
        string Name;
        public Album(string name)
        {
            this.Name = name;

        }
        public string GetName()
        {
            return this.Name;
        }
    }
}
