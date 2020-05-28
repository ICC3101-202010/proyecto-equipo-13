using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_equipo_13_entrega_3.CustomsEvenArgs
{
    public class ChangePasswordEventArgs : EventArgs
    {
        public string Email { get; set; }
        public string Username { get; set; }
    }
}
