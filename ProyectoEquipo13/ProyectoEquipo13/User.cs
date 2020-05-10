using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEquipo13
{
    public class User
    {
        private string userName;
        private string email;
        private string password;

        public string UserName { get => userName; set => userName = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }

        public User() { }

        public User(string userName, string email, string password)
        {
            this.UserName = userName;
            this.Email = email;
            this.Password = password;
        }

        //1.- Definir el delegate
        public delegate void VerifiedEmailEventHandler(object source, EventArgs args);
        //2.- Definir el evento basado en el delegate anterior
        public event VerifiedEmailEventHandler EmailVerified;
        //3.- Disparar el evento
        protected virtual void OnEmailVerified()
        {
            EmailVerified(this, new EventArgs());
        }

        public void OnEmailSent(object source, EventArgs args)
        {

            Console.Write("¿Quiere revisar su correo? (si)(no)\n");
            while (true)
            {
                string option = Console.ReadLine();
                if (option == "si")
                {
                    EmailVerified(source, args);
                    break;
                }
                else if (option == "no") { break; }
                else { Console.WriteLine("La opción que selecciono no es válida seleccione (si) o (no)"); }
            }
        }
    }
}
