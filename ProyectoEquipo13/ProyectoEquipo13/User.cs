using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEquipo13
{
    public class User
    {
        private string type;
        protected int UserID;
        protected string user;
        protected string Email;
        protected string Password;
        protected bool Privacy;

        public bool CreateAccount(string email, string password, int userid)
        {
            for (int i = 0; i < Files.AllUsers.Count ; i++)
            {
                if ((Files.AllUsers[i].Email==email ) || (Files.AllUsers[i].UserID == userid))
                {
                    Console.WriteLine("La cuenta no se puede crear, debido a que ya existe, o el mail usado ya esta usado");
                    return false;
                }
                else if (Files.AllUsers[i].Email != email || Files.AllUsers[i].UserID != userid)
                {
                    Console.WriteLine("La cuenta ha sido creada correctamente");
                    return true;
                }
            }

            Console.WriteLine("La opción que seleccionó no es válida");
            return false;
        }
    }
}
