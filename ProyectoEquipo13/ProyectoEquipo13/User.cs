using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEquipo13
{
    public class User
    {
        protected int UserID;
        protected string user;
        protected string Email;
        protected string Password;
        protected bool Privacy;

        public bool CreateAccount(Files.AllUsers() list, string email, string password, int userid)
        {
            for (int i = 0; i <list.Count ; i++)
            {
                if ((list[i].Email==email ) || (list[i].UserID == userid))
                {
                    Console.WriteLine("La cuenta no se puede crear, debido a que ya existe, o el mail usado ya esta usado");
                    return false;
                }
                else if (list[i].Email != email || list[i].UserID != userid)
                {
                    Console.WriteLine("La cuenta ha sido creada correctamente");
                    return true;
                }
                else
                {
                    Console.WriteLine("La opción que seleccionó no es válida");
                    return false;
                }
            }
        }
    }
}
