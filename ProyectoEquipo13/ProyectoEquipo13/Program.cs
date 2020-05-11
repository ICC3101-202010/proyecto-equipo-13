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
            //IFormatter formatter = new BinaryFormatter();
            //Stream stream = new FileStream("BaseDeDatos.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            //List<Movies> AllMovies = (List<Movies>)formatter.Deserialize(stream);
            //List<Songs> AllSongs = (List<Songs>)formatter.Deserialize(stream);
            //List<Playlists> AllPlaylistsSongs = (List<Playlists>)formatter.Deserialize(stream);
            //List<Playlists> AllPlaylistsMovies = (List<Playlists>)formatter.Deserialize(stream);
            //List<User> AllUsers = (List<User>)formatter.Deserialize(stream);
            //stream.Close();

            Computer computer = new Computer();
            MailSender mailSender = new MailSender();
            User user = new User();


            //Stream stream2 = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            //formatter.Serialize(stream2, Files.AllMovies);
            //formatter.Serialize(stream2, Files.AllSongs);
            //formatter.Serialize(stream2, Files.AllPlaylistsMovies);
            //formatter.Serialize(stream2, Files.AllPlaylistsSongs);
            //formatter.Serialize(stream2, Files.AllUsers);
            //stream.Close();
            // Reproductor

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            PlayMovie pM = new PlayMovie();
            string t = @"Movies\Tarzan_-Son_Of_Man_Phil_Collins";
            pM.Generico();
            pM.URL(t);
            Application.Run(pM);
        }
    }
}
