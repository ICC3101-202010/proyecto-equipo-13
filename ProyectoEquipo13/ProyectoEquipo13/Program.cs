using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEquipo13
{
    
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            IFormatter formatter = new BinaryFormatter();
            //Stream stream = new FileStream("BaseDeDatos.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            //Files.AllMovies = (List<Movies>)formatter.Deserialize(stream);               
            //Files.AllSongs = (List<Songs>)formatter.Deserialize(stream);
            //Files.AllPlaylistsSongs = (List<Playlists>)formatter.Deserialize(stream);
            //Files.AllPlaylistsMovies = (List<Playlists>)formatter.Deserialize(stream);
            //Files.Users = (List<User>)formatter.Deserialize(stream);
            //stream.Close();

            Computer computer = new Computer();
            MailSender mailSender = new MailSender();
            User emptyuser = new User();

            Console1.InitialMessage();
            while (true)
            {
                Console.WriteLine("\n¿Qué desea realizar?");
                Console.WriteLine("(a) Iniciar/Crear Sesión, modificar cuenta\n(b) Salir del programa");
                string desition = Console.ReadLine();
                if (desition == "a")
                {
                    while (true)
                    {
                        User userlogin = Console1.Account(computer, emptyuser, mailSender);
                    }
                    while (true)
                    {
                        Console.Clear();
                        Console1.SecondMessage(computer);
                        Console.WriteLine("(a) Ver todas las películas\n(b) Ver todas las canciones \n(c) Crear Playlist\n(d)Modificar Playlist (Cambiar nombre, Agregar/Quitar elementos)\n(e) Ver Mis Playlists\n(f) BUSCADOR\n(g) Cerrar Sesión (para volvera a inicio/creación de sesión o salir del programa)");
                        string option = Console.ReadLine();
                        if (option == "a")
                        {
                            Console1.SeeMovies(computer, userlogin);
                        }
                        else if (option == "b")
                        {
                            Console1.SeeSongs(computer, userlogin);
                        }
                        else if (option == "c")
                        {
                            Console1.CreatePlaylist(computer, userlogin);
                        }
                        else if (option == "d")
                        {
                            Console1.ModifiedPlaylist(computer, userlogin);
                        }
                        else if (option == "e")
                        {
                            Console1.SeePlaylist(computer, userlogin);
                        }
                        else if (option == "f")
                        {
                            Console1.Search(computer, userlogin);
                        }
                        else if (option == "g")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nLa opción que seleccionó no es válida, por favor seleccione una que si lo sea\n");
                        }
                        
                    }
                }
                else if (desition == "b")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nLa opción que seleccionó no es válida, por favor seleccione una que si lo sea\n");
                }
            }
            

            Stream stream2 = new FileStream("BaseDeDatos.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream2, Files.AllMovies);
            formatter.Serialize(stream2, Files.AllSongs);
            formatter.Serialize(stream2, Files.AllPlaylistsMovies);
            formatter.Serialize(stream2, Files.AllPlaylistsSongs);
            formatter.Serialize(stream2, Files.Users);
            stream2.Close();
            // Reproductor

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //PlayMovie pM = new PlayMovie();
            //string t = @"Songs\Tarzan_-Son_Of_Man_Phil_Collins.mp3";
            //pM.Generico();
            //pM.URL(t);
            //Application.Run(pM);
        }
    }
}
