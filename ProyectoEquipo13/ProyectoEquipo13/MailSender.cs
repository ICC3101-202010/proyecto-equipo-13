using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProyectoEquipo13
{
    class MailSender
    {
        public void OnRegistered(object source, RegisterEventArgs e)
        {
            Thread.Sleep(2000);
            Console.WriteLine($"\nCorreo enviado a {e.Email}: \n Gracias por registrarte, {e.Username}!\n Por favor, para poder verificar tu correo, has click en: {e.VerificationLink}\n");
            Thread.Sleep(2000);
        }

        public void OnPasswordChanged(object source, ChangePasswordEventArgs e)
        {
            Thread.Sleep(2000);
            Console.WriteLine($"\nCorreo enviado a {e.Email}:  \n {e.Username}, te notificamos que la contrasena de tu cuenta Netfy ha sido cambiada. \n");
            Thread.Sleep(2000);
        }

        public void OnUserNameChanged(object source, ChangeUserNameEventArgs e)
        {
            Thread.Sleep(2000);
            Console.WriteLine($"\nCorreo enviado a {e.Email}:  \n Te notificamos que el nombre de usuario de tu cuenta Netfy ha sido cambiada a {e.Username}. \n");
            Thread.Sleep(2000);
        }

        //1.- Definir el delegate
        public delegate void SentEmailEventHandler(object source, EventArgs args);
        //2.- Definir el evento basado en el delegate anterior
        public event SentEmailEventHandler EmailSent;
        //3.- Disparar el evento
        protected virtual void OnEmailSent()
        {
            EmailSent(this, new EventArgs());
        }
    }
}
