﻿using iTextSharp.text.pdf.parser;
using Proyecto_equipo_13_entrega_3.CustomsEvenArgs;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using System.Speech.Synthesis;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_equipo_13_entrega_3
{
    public partial class AppForm : Form
    {
        public delegate bool LoginEventHandler(object source, LoginEventArgs args);
        public event LoginEventHandler LoginButtonClicked;
        public event EventHandler<LoginEventArgs> UserChecked;
        public delegate bool CreateAccountEventHandler(object source, RegisterEventArgs args);
        public event CreateAccountEventHandler CreateAccountClicked;
        public string ruta, dest, name, imagen;
        public Queue<Songs> queuesongs = new Queue<Songs>();
        public Queue<Movies> queuemovies = new Queue<Movies>();
        public WMPLib.IWMPPlaylist Qpeliculas;
        public WMPLib.IWMPPlaylist Qcanciones;
        //Innovación
        List<VoiceInfo> vocesInfo = new List<VoiceInfo>();
        SpeechSynthesizer synthVoice;
        bool isStopped;
        bool speaking = true;


        //Organizacion
        List<Panel> stackPanels = new List<Panel>();
        Dictionary<string, Panel> panels = new Dictionary<string, Panel>();

        public AppForm()
        {
            InitializeComponent();
            char M = 'M';
            char F = 'F';

            //CANCIONES

            //GENERICOS
            string Type = ".mp3";
            int LenghtS = 165;
            string LyricsS = "letra";
            string ResolutionS = "192kbps";
            string MemoryS = "3,78MB";
            int numReproductionsS = 0;
            double RatingProm = 0; //CANCION Y PELICULA
            List<double> Rating = new List<double>(); //CANCION Y PELICULA
            int MinS = 0;

            //SONG 1
            Artist phill_collins = new Artist("Phil Collins", new DateTime(1951, 1, 30, 5, 5, 5), M, "https://es.wikipedia.org/wiki/Phil_Collins");
            Album Tarzan_album = new Album("Tarzan: An Original Walt Disney Records Soundtrack", DateTime.Now, phill_collins, @"\Tarzan.jpg");
            List<string> Genre_Son_of_man = new List<string>();
            Genre_Son_of_man.Add("Pop Rock");
            Genre_Son_of_man.Add("Soft Rock");
            string Music_Son_of_man = @"\Tarzan_-Son_Of_Man_Phil_Collins.mp3";
            Songs Son_of_man = new Songs("Son of man", phill_collins, phill_collins, phill_collins, LenghtS, Genre_Son_of_man, LyricsS, ResolutionS, MemoryS, numReproductionsS, Rating, RatingProm, Music_Son_of_man, Type, MinS, Tarzan_album);
            Files.AllSongs.Add(Son_of_man);


            //SONG 2
            Artist celine_dion = new Artist("Celine Dion", new DateTime(1968, 3, 30, 5, 5, 5), F, "https://es.wikipedia.org/wiki/C%C3%A9line_Dion");
            Person james_horner = new Person("James Horner", new DateTime(1953, 8, 14, 5, 5, 5), M, "https://es.wikipedia.org/wiki/James_Horner");
            Album Titanic_album = new Album("Titanic: Music From The Motion Picture ", DateTime.Now, celine_dion, @"\Titanic.jpg");
            List<string> Genre_My_heart_will_go_on = new List<string>();
            Genre_My_heart_will_go_on.Add("Pop");
            Genre_My_heart_will_go_on.Add("Balada");
            string Music_My_heart_will_go_on = @"\Celine Dion - My heart will go on [Lyrics y Subtitulos en Español].mp3";
            Songs My_heart_will_go_on = new Songs("My heart will go on", james_horner, celine_dion, james_horner, LenghtS, Genre_My_heart_will_go_on, LyricsS, ResolutionS, MemoryS, numReproductionsS, Rating, RatingProm, Music_My_heart_will_go_on, Type, MinS, Titanic_album);
            Files.AllSongs.Add(My_heart_will_go_on);

            //SONG 3
            Album Face_value_album = new Album("Face Value", new DateTime(1981, 1, 5, 5, 5, 5), phill_collins, @"\Face Value.jpg");
            List<string> Genre_In_the_air_tonight = new List<string>();
            Genre_In_the_air_tonight.Add("Soft Rock");
            Genre_In_the_air_tonight.Add("Power Ballad");
            string Music_In_the_air_tonight = @"\Phil Collins - In The Air Tonight (Official Video).mp3";
            Songs In_the_air_tonight = new Songs("In the air tonight", phill_collins, phill_collins, phill_collins, LenghtS, Genre_In_the_air_tonight, LyricsS, ResolutionS, MemoryS, numReproductionsS, Rating, RatingProm, Music_In_the_air_tonight, Type, MinS, Face_value_album);
            Files.AllSongs.Add(In_the_air_tonight);

            //SONG 4
            List<string> Genre_This_must_be_love = new List<string>();
            Genre_This_must_be_love.Add("Pop Rock");
            Genre_This_must_be_love.Add("Art Rock");
            Genre_This_must_be_love.Add("R&B");
            string Music_This_must_be_love = @"\Phil Collins This Must Be Love.mp3";
            Songs This_must_be_love = new Songs("This must be love", phill_collins, phill_collins, phill_collins, LenghtS, Genre_This_must_be_love, LyricsS, ResolutionS, MemoryS, numReproductionsS, Rating, RatingProm, Music_This_must_be_love, Type, MinS, Face_value_album);
            Files.AllSongs.Add(This_must_be_love);

            //SONG 5
            Artist randy_newman = new Artist("Randy Newman", new DateTime(1943, 11, 28, 5, 5, 5), M, "https://es.wikipedia.org/wiki/Randy_Newman");
            Album Toy_Story_album = new Album("Toy Story", new DateTime(1996, 4, 12, 5, 5, 5), randy_newman, @"\Toy Story.jpg");
            List<string> Genre_Youve_got_a_friend_in_me = new List<string>();
            string Music_Youve_got_a_friend_in_me = @"\Randy Newman - Youve Got a Friend in Me (From Toy Story 4Audio Only).mp3";
            Songs Youve_got_a_friend_in_me = new Songs("You've got a friend in me", randy_newman, randy_newman, randy_newman, LenghtS, Genre_Youve_got_a_friend_in_me, LyricsS, ResolutionS, MemoryS, numReproductionsS, Rating, RatingProm, Music_Youve_got_a_friend_in_me, Type, MinS, Toy_Story_album);
            Files.AllSongs.Add(Youve_got_a_friend_in_me);

            //SONG 6
            Artist sia = new Artist("Sia", new DateTime(1943, 11, 28, 5, 5, 5), F, "https://es.wikipedia.org/wiki/Sia");
            Album Forms_album = new Album("1000 Forms of fear", new DateTime(2014, 3, 14, 5, 5, 5), sia, @"\Forms of Fear.jpg");
            List<string> Genre_Chandelier = new List<string>();
            Genre_Chandelier.Add("Pop");
            string Music_Chandelier = @"\Sia - Chandelier (Official Video).mp3";
            Songs Chandelier = new Songs("Chandelier", sia, sia, sia, LenghtS, Genre_Chandelier, LyricsS, ResolutionS, MemoryS, numReproductionsS, Rating, RatingProm, Music_Chandelier, Type, MinS, Forms_album);
            Files.AllSongs.Add(Chandelier);

            //SONG 7
            List<string> Genre_Elastic_heart = new List<string>();
            Genre_Elastic_heart.Add("Electropop");
            string Music_Elastic_heart = @"\Sia - Elastic Heart (Traducida al Español).mp3";
            Songs Elastic_heart = new Songs("Elastic Heart", sia, sia, sia, LenghtS, Genre_Elastic_heart, LyricsS, ResolutionS, MemoryS, numReproductionsS, Rating, RatingProm, Music_Elastic_heart, Type, MinS, Forms_album);
            Files.AllSongs.Add(Elastic_heart);

            //SONG 8
            Artist diplo = new Artist("Diplo", new DateTime(1978, 11, 10, 5, 5, 5), M, "https://es.wikipedia.org/wiki/Diplo");
            Artist justin_bieber = new Artist("Justin Bieber", new DateTime(1994, 3, 1, 5, 5, 5), M, "https://es.wikipedia.org/wiki/Justin_Bieber");
            Album My_world_album = new Album("My World 2.0", new DateTime(2010, 5, 5, 5, 5, 5), justin_bieber, @"\My World.jpg");
            List<string> Genre_Where_are_u_now = new List<string>();
            Genre_Where_are_u_now.Add("Pop");
            string Music_Where_are_u_now = @"\Skrillex and Diplo - Where Are Ü Now with Justin Bieber (Official Video).mp3";
            Songs Where_are_u_now = new Songs("Where are Ü now", diplo, justin_bieber, diplo, LenghtS, Genre_Where_are_u_now, LyricsS, ResolutionS, MemoryS, numReproductionsS, Rating, RatingProm, Music_Where_are_u_now, Type, MinS, My_world_album);
            Files.AllSongs.Add(Where_are_u_now);

            //SONG 9
            Artist maroon_5 = new Artist("Maroon 5", new DateTime(1997, 1, 1, 5, 5, 5), M, "https://es.wikipedia.org/wiki/Maroon_5");
            Artist adam_levine = new Artist("Adam Levine", new DateTime(1979, 3, 18, 5, 5, 5), M, "https://es.wikipedia.org/wiki/Adam_Levine");
            Album V_album = new Album("V", new DateTime(2014, 9, 2, 5, 5, 5), maroon_5, @"\V.jpg");
            List<string> Genre_Sugar = new List<string>();
            Genre_Sugar.Add("Pop Rock");
            string Music_Sugar = @"\Maroon 5 - Sugar (lyrics).mp3";
            Songs Sugar = new Songs("Sugar", adam_levine, maroon_5, maroon_5, LenghtS, Genre_Sugar, LyricsS, ResolutionS, MemoryS, numReproductionsS, Rating, RatingProm, Music_Sugar, Type, MinS, V_album);
            Files.AllSongs.Add(Sugar);

            //SONG 10
            List<string> Genre_Maps = new List<string>();
            Genre_Maps.Add("Pop Rock");
            Genre_Maps.Add("Dance Pop");
            string Music_Maps = @"\Maroon 5 - Maps (Lyric).mp3";
            Songs Maps = new Songs("Maps", adam_levine, maroon_5, maroon_5, LenghtS, Genre_Maps, LyricsS, ResolutionS, MemoryS, numReproductionsS, Rating, RatingProm, Music_Maps, Type, MinS, V_album);
            Files.AllSongs.Add(Maps);
            
            //PELICULAS

            //GENERICOS
            int Lenght = 88;
            string Description = "descripcion";
            string Resolution = "617kbps";
            string Memory = "12,2MB";
            int numReproductions = 0;
            int Min = 0;

            //MOVIE 1
            Person kevin_lima = new Person("Kevin Lima", new DateTime(1962, 6, 12, 5, 5, 5), M, "https://www.imdb.com/name/nm0510674/?ref_=fn_al_nm_1");
            List<Person> Actors_Tarzan = new List<Person>();
            Person frank_welker = new Person("Frank Welker", new DateTime(1946, 3, 12, 5, 5, 5), M, "https://www.imdb.com/name/nm0919798/?ref_=fn_al_nm_1");
            Person danielle_keaton = new Person("Danielle Keaton", new DateTime(1986, 7, 30, 5, 5, 5), F, "https://www.imdb.com/name/nm0918210/?ref_=fn_al_nm_1");
            Actors_Tarzan.Add(frank_welker);
            Actors_Tarzan.Add(danielle_keaton);
            Person tab_murphay = new Person("Tab Murphy", new DateTime(1966, 2, 25, 5, 5, 5), F, "https://www.imdb.com/name/nm0614742/?ref_=nv_sr_srsg_0");
            List<string> Categories_Tarzan = new List<string>();
            Categories_Tarzan.Add("Animación musical");
            Categories_Tarzan.Add("Aventura");
            Categories_Tarzan.Add("Comedia");
            string Trailer_Tarzan = @"\Tarzan_-Son_Of_Man_Phil_Collins.mp4";
            string Video_Tarzan = @"\Tarzan_-Son_Of_Man_Phil_Collins.mp4";
            List<Songs> Songs_Tarzan = new List<Songs>();
            Songs_Tarzan.Add(Son_of_man);
            Movies Tarzan = new Movies("Tarzan", kevin_lima, Actors_Tarzan, tab_murphay, Lenght, Categories_Tarzan, "Walt Disney Pictures", Description, "1999", Resolution, Memory, numReproductions, Rating, RatingProm, Trailer_Tarzan, Video_Tarzan, Songs_Tarzan, Min, @"\Tarzanmovie.jpg");
            Files.AllMovies.Add(Tarzan);

            //MOVIE 2
            Person tom_hanks = new Person("Tom Hanks", new DateTime(1956, 7, 9, 5, 5, 5), M, "https://www.imdb.com/name/nm0000158/?ref_=fn_al_nm_1");
            Person josh_cooley = new Person("Josh Cooley", new DateTime(1950, 11, 23, 5, 5, 5), M, "https://www.imdb.com/name/nm2155757/?ref_=nv_sr_srsg_0");
            Person tim_allen = new Person("Tim Allen", new DateTime(1955, 9, 26, 5, 5, 5), M, "https://www.imdb.com/name/nm0000741/?ref_=fn_al_nm_1");
            Person annie_potts = new Person("Annie Potts", new DateTime(1976, 10, 3, 5, 5, 5), F, "https://www.imdb.com/name/nm0001633/?ref_=fn_al_nm_1");
            Person john_lasseter = new Person("John Lasseter", new DateTime(1957, 1, 12, 5, 5, 5), M, "https://www.imdb.com/name/nm0005124/?ref_=fn_al_nm_1");
            List<Person> Actors_Toy_story_4 = new List<Person>();
            Actors_Toy_story_4.Add(tom_hanks);
            Actors_Toy_story_4.Add(tim_allen);
            Actors_Toy_story_4.Add(annie_potts);
            List<string> Categories_Toy_story_4 = new List<string>();
            Categories_Toy_story_4.Add("Animación");
            Categories_Toy_story_4.Add("Aventura");
            Categories_Toy_story_4.Add("Comedia");
            string Video_Toy_story_4 = @"\Toy Story 4  Official Trailer.mp4";
            string Trailer_Toy_story_4 = @"\";
            List<Songs> Songs_Toy_story_4 = new List<Songs>();
            Songs_Toy_story_4.Add(Youve_got_a_friend_in_me);
            string b = @"\Toy Story 4.jpg";
            Movies Toy_story_4 = new Movies("Toy Story 4", josh_cooley, Actors_Toy_story_4, john_lasseter, Lenght, Categories_Toy_story_4, "Walt Disney Pictures", Description, "2019", Resolution, Memory, numReproductions, Rating, RatingProm, Trailer_Toy_story_4, Video_Toy_story_4, Songs_Toy_story_4, Min, b);
            Files.AllMovies.Add(Toy_story_4);

            //MOVIE 3 
            Person lee_unkrich = new Person("Lee Unkrich", new DateTime(1967, 8, 8, 5, 5, 5), M, "https://www.imdb.com/name/nm0881279/?ref_=nv_sr_srsg_0");
            Person darla_anderson = new Person("Darla Anderson", new DateTime(1970, 8, 22, 5, 5, 5), F, "https://www.imdb.com/name/nm0026565/?ref_=fn_al_nm_1");
            List<Person> Actors_Toy_story_3 = new List<Person>();
            Actors_Toy_story_3.Add(tom_hanks);
            Actors_Toy_story_3.Add(tim_allen);
            List<string> Categories_Toy_story_3 = new List<string>();
            Categories_Toy_story_3.Add("Animación");
            Categories_Toy_story_3.Add("Aventura");
            Categories_Toy_story_3.Add("Comedia");
            string Video_Toy_story_3 = @"\Toy Story 3 Trailer.mp4";
            string Trailer_Toy_story_3 = @"\";
            List<Songs> Songs_Toy_story_3 = new List<Songs>();
            Songs_Toy_story_3.Add(Youve_got_a_friend_in_me);
            Movies Toy_story_3 = new Movies("Toy Story 3", lee_unkrich, Actors_Toy_story_3, darla_anderson, Lenght, Categories_Toy_story_3, "Walt Disney Pictures", Description, "2010", Resolution, Memory, numReproductions, Rating, RatingProm, Trailer_Toy_story_3, Video_Toy_story_3, Songs_Toy_story_3, Min, @"\Toy Story 3.jpg");
            Files.AllMovies.Add(Toy_story_3);

            //MOVIE 4
            Person james_cameron = new Person("James Cameron", new DateTime(1954, 8, 16, 5, 5, 5), M, "https://www.imdb.com/name/nm0000116/?ref_=fn_al_nm_1");
            Person leonardo_dicaprio = new Person("Leonardo DiCaprio", new DateTime(1974, 11, 11, 5, 5, 5), M, "https://www.imdb.com/name/nm0000138/?ref_=fn_al_nm_1");
            Person kate_winslet = new Person("Kate Winslet", new DateTime(1975, 10, 5, 5, 5, 5), F, "https://www.imdb.com/name/nm0000701/?ref_=nv_sr_srsg_0");
            List<Person> Actors_Titanic = new List<Person>();
            Actors_Titanic.Add(leonardo_dicaprio);
            Actors_Titanic.Add(kate_winslet);
            List<string> Categories_Titanic = new List<string>();
            Categories_Titanic.Add("Romance");
            Categories_Titanic.Add("Catastrofe");
            Categories_Titanic.Add("Drama");
            string Video_Titanic = @"\Titanic 3D Re-Release Official Trailer 1.mp4";
            string Trailer_Titanic = @"\";
            List<Songs> Songs_Titanic = new List<Songs>();
            Songs_Titanic.Add(My_heart_will_go_on);
            Movies Titanic = new Movies("Titanic", james_cameron, Actors_Titanic, james_cameron, Lenght, Categories_Titanic, "20th Century Fox", Description, "1997", Resolution, Memory, numReproductions, Rating, RatingProm, Trailer_Titanic, Video_Titanic, Songs_Titanic, Min, @"\Titanicmovie.jpg");
            Files.AllMovies.Add(Titanic);

            //MOVIE 5
            Person andrew_stanton = new Person("Andrew Stanton", new DateTime(1965, 12, 3, 5, 5, 5), M, "https://www.imdb.com/name/nm0004056/?ref_=nv_sr_srsg_0");
            List<Person> Actors_Toy_story_2 = new List<Person>();
            Actors_Toy_story_2.Add(tom_hanks);
            Actors_Toy_story_2.Add(tim_allen);
            List<string> Categories_Toy_story_2 = new List<string>();
            Categories_Toy_story_2.Add("Animación");
            Categories_Toy_story_2.Add("Aventura");
            Categories_Toy_story_2.Add("Comedia");
            string Video_Toy_story_2 = @"\Toy Story 2 (1999) Trailer 1  Movieclips Classic Trailers.mp4";
            string Trailer_Toy_story_2 = @"\";
            List<Songs> Songs_Toy_story_2 = new List<Songs>();
            Songs_Toy_story_2.Add(Youve_got_a_friend_in_me);
            Movies Toy_story_2 = new Movies("Toy Story 2", john_lasseter, Actors_Toy_story_2, andrew_stanton, Lenght, Categories_Toy_story_2, "Walt Disney Pictures", Description, "1999", Resolution, Memory, numReproductions, Rating, RatingProm, Trailer_Toy_story_2, Video_Toy_story_2, Songs_Toy_story_2, Min, @"\Toy Story 2.jpg");
            Files.AllMovies.Add(Toy_story_2);

            //MOVIE 6
            List<Person> Actors_Toy_story = new List<Person>();
            Actors_Toy_story.Add(tom_hanks);
            Actors_Toy_story.Add(tim_allen);
            List<string> Categories_Toy_story = new List<string>();
            Categories_Toy_story.Add("Animación");
            Categories_Toy_story.Add("Aventura");
            Categories_Toy_story.Add("Comedia");
            string Video_Toy_story = @"\Toy Story 1 HD Trailer.mp4";
            string Trailer_Toy_story = @"\";
            List<Songs> Songs_Toy_story = new List<Songs>();
            Songs_Toy_story.Add(Youve_got_a_friend_in_me);
            Movies Toy_story = new Movies("Toy Story", john_lasseter, Actors_Toy_story, andrew_stanton, Lenght, Categories_Toy_story, "Pixar", Description, "1995", Resolution, Memory, numReproductions, Rating, RatingProm, Trailer_Toy_story, Video_Toy_story, Songs_Toy_story, Min, @"\Toy Storymovie.jpg");
            Files.AllMovies.Add(Toy_story);

            //MOVIE 7
            Person martin_scorsese = new Person("Martin Scorsese", new DateTime(1942, 11, 17, 5, 5, 5), M, "https://www.imdb.com/name/nm0000217/?ref_=nv_sr_srsg_0");
            Person terence_winter = new Person("Terence Winter", new DateTime(1960, 10, 2, 5, 5, 5), M, "https://www.imdb.com/name/nm1010540/?ref_=nv_sr_srsg_0");
            Person margot_robbie = new Person("Margot Robbie", new DateTime(1990, 7, 2, 5, 5, 5), F, "https://www.imdb.com/name/nm3053338/?ref_=fn_al_nm_1");
            Person matthew_mcconaughey = new Person("Matthew McConaughey", new DateTime(1969, 11, 4, 5, 5, 5), M, "https://www.imdb.com/name/nm0000190/?ref_=nv_sr_srsg_0");
            List<Person> Actors_The_wolf_of_wall_street = new List<Person>();
            Actors_The_wolf_of_wall_street.Add(leonardo_dicaprio);
            Actors_The_wolf_of_wall_street.Add(margot_robbie);
            Actors_The_wolf_of_wall_street.Add(matthew_mcconaughey);
            List<string> Categories_The_wolf_of_wall_street = new List<string>();
            Categories_The_wolf_of_wall_street.Add("Biografía");
            Categories_The_wolf_of_wall_street.Add("Comedia");
            string Video_The_wolf_of_wall_street = @"\The Wolf of Wall Street Official Trailer.mp4";
            string Trailer_The_wolf_of_wall_street = @"\";
            List<Songs> Songs_The_wolf_of_wall_street = new List<Songs>();
            Movies The_wolf_of_wall_street = new Movies("The Wolf of Wall street", martin_scorsese, Actors_The_wolf_of_wall_street, terence_winter, Lenght, Categories_The_wolf_of_wall_street, "Paramount Pictures", Description, "2013", Resolution, Memory, numReproductions, Rating, RatingProm, Trailer_The_wolf_of_wall_street, Video_The_wolf_of_wall_street, Songs_The_wolf_of_wall_street, Min, @"\The Wolf of Wall Street.jpg");
            Files.AllMovies.Add(The_wolf_of_wall_street);

            //MOVIE 8
            Person christopher_nolan = new Person("Christopher Nolan", new DateTime(1970, 7, 30, 5, 5, 5), M, "https://www.imdb.com/name/nm0634240/?ref_=nv_sr_srsg_0");
            Person anne_hathaway = new Person("Anne Hathaway", new DateTime(1982, 11, 12, 5, 5, 5), F, "https://www.imdb.com/name/nm0004266/?ref_=nv_sr_srsg_0");
            List<Person> Actors_Interestellar = new List<Person>();
            Actors_Interestellar.Add(anne_hathaway);
            Actors_Interestellar.Add(matthew_mcconaughey);
            List<string> Categories_Interestellar = new List<string>();
            Categories_Interestellar.Add("Ciencia Ficción");
            string Video_Interestellar = @"\Interstellar - Trailer - Official Warner Bros. UK.mp4";
            string Trailer_Interestellar = @"\";
            List<Songs> Songs_Interestellar = new List<Songs>();
            Movies Interestellar = new Movies("Interestellar", christopher_nolan, Actors_Interestellar, christopher_nolan, Lenght, Categories_Interestellar, "Paramount Pictures", Description, "2014", Resolution, Memory, numReproductions, Rating, RatingProm, Trailer_Interestellar, Video_Interestellar, Songs_Interestellar, Min, @"\Interestellar.jpg");
            Files.AllMovies.Add(Interestellar);

            //MOVIE 9
            Person steven_rogers = new Person("Steven Rogers", new DateTime(1953, 4, 3, 5, 5, 5), M, "https://www.imdb.com/name/nm0737216/?ref_=fn_al_nm_1");
            Person allison_janney = new Person("Allison Janney", new DateTime(1959, 11, 19, 5, 5, 5), F, "https://www.imdb.com/name/nm0005049/?ref_=nv_sr_srsg_0");
            List<Person> Actors_I_tonya = new List<Person>();
            Actors_I_tonya.Add(margot_robbie);
            Actors_I_tonya.Add(allison_janney);
            List<string> Categories_I_tonya = new List<string>();
            Categories_I_tonya.Add("Drama");
            Categories_I_tonya.Add("Bibliográfica");
            string Video_I_tonya = @"\I, Tonya Trailer #1 (2017) _ Movieclips Trailers.mp4";
            string Trailer_I_tonya = @"\";
            List<Songs> Songs_I_tonya = new List<Songs>();
            Movies I_tonya = new Movies("I, Tonya", margot_robbie, Actors_I_tonya, steven_rogers, Lenght, Categories_I_tonya, "LuckyChap", Description, "2017", Resolution, Memory, numReproductions, Rating, RatingProm, Trailer_I_tonya, Video_I_tonya, Songs_I_tonya, Min, @"\I, Tonya.jpg");
            Files.AllMovies.Add(I_tonya);

            //MOVIE 10
            Person robert_deniro = new Person("Robert De Niro", new DateTime(1943, 8, 17, 5, 5, 5), M, "https://www.imdb.com/name/nm0000134/?ref_=nv_sr_srsg_0");
            Person al_pacino = new Person("Al Pacino", new DateTime(1940, 4, 25, 5, 5, 5), M, "https://www.imdb.com/name/nm0000199/?ref_=nv_sr_srsg_0");
            Person joe_pesci = new Person("Joe Pesci", new DateTime(1943, 2, 9, 5, 5, 5), M, "https://www.imdb.com/name/nm0000582/?ref_=fn_al_nm_1");
            Person steven_zaillian = new Person("Steven Zaillian", new DateTime(1953, 1, 30, 5, 5, 5), M, "https://www.imdb.com/name/nm0001873/?ref_=nv_sr_srsg_0");
            List<Person> Actors_The_irishman = new List<Person>();
            Actors_The_irishman.Add(robert_deniro);
            Actors_The_irishman.Add(al_pacino);
            Actors_The_irishman.Add(joe_pesci);
            List<string> Categories_The_irishman = new List<string>();
            Categories_The_irishman.Add("Drama");
            Categories_The_irishman.Add("Bibliográfica");
            string Video_The_irishman = @"\The Irishman  Official Trailer  Netflix.mp4";
            string Trailer_The_irishman = @"\";
            List<Songs> Songs_The_irishman = new List<Songs>();
            Movies The_irishman = new Movies("The Irishman", martin_scorsese, Actors_The_irishman, steven_zaillian, Lenght, Categories_The_irishman, "TriBeCa", Description, "2019", Resolution, Memory, numReproductions, Rating, RatingProm, Trailer_The_irishman, Video_The_irishman, Songs_The_irishman, Min, @"\The Irishman.jpg");
            Files.AllMovies.Add(The_irishman);

            this.WindowState = FormWindowState.Maximized;
            IniciarSerializacion();
            Qpeliculas = axWindowsMediaPlayer1.playlistCollection.newPlaylist("Queue de Películas");
            Qcanciones = axWindowsMediaPlayer1.playlistCollection.newPlaylist("Queue de Canciones");
            panels.Add("WelcomePanel", WelcomeMenu);
            panels.Add("LoginPanel", LoginView);
            panels.Add("UserPanel", UserPanel);
            panels.Add("CreateAccountPanel", CreateAccountView);
            panels.Add("ModificarCuentaPanel", ModificarCuentaPanel);
            panels.Add("ReproductionPanel", ReproductionPanel);
            panels.Add("AdminPanel", AdminPanel);
            panels.Add("InovationPanel", InnovationPanel);
            //InnovationPanel
            synthVoice = new SpeechSynthesizer();

            foreach (InstalledVoice voice in synthVoice.GetInstalledVoices())
            {
                vocesInfo.Add(voice.VoiceInfo);
                cbVoces.Items.Add(voice.VoiceInfo.Name);

            }
            cbVoces.SelectedIndex = 0;

            synthVoice.Dispose();

            foreach (User user in Files.Users)
            {
                if (user.LOGIN == true)
                {
                    stackPanels.Add(panels["UserPanel"]);
                    setNameUser(user.UserName);
                    ShowLastPanel();
                }
            }
            if (stackPanels.Count()==0)
            {
                stackPanels.Add(panels["WelcomePanel"]);
                ShowLastPanel();
            }
        }

        private void IniciarSerializacion()
        {
            VerMisPlaylits.Visible = false;
            ShowSong.Visible = false;
            ShowMovie.Visible = false;
            ShowUserPanel.Visible = false;
            ShowPersonPanel.Visible = false;
            ShowMoviesPanel.Visible = false;
            BuscadorPanel.Visible = false;
            ResultsBuscador.Visible = false;
            FollowersPanel.Visible = false;
            CrearPlaylist.Visible = false;
            ShowSongsPanel.Visible = false;
            pictureBox1.Visible = true;
            pictureBox1.BringToFront();

            IFormatter formatter = new BinaryFormatter();

            string urlAllMovies = Directory.GetCurrentDirectory() + "\\AllMovies.bin";
            string urlAllSongs = Directory.GetCurrentDirectory() + "\\AllSongs.bin";
            string urlAllPlaylistsSongs = Directory.GetCurrentDirectory() + "\\AllPlaylistsSongs.bin";
            string urlAllPlaylistsMovies = Directory.GetCurrentDirectory() + "\\AllPlaylistsMovies.bin";
            string urlUsers = Directory.GetCurrentDirectory() + "\\Users.bin";
            string urlAllPersons = Directory.GetCurrentDirectory() + "\\AllPersons.bin";

            if (File.Exists(urlAllMovies) && File.Exists(urlAllSongs) && File.Exists(urlAllPlaylistsSongs) && File.Exists(urlAllPlaylistsMovies) && File.Exists(urlUsers))
            {
                Stream stream1 = new FileStream("AllMovies.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                Stream stream2 = new FileStream("AllSongs.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                Stream stream3 = new FileStream("AllPlaylistsSongs.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                Stream stream4 = new FileStream("AllPlaylistsMovies.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                Stream stream5 = new FileStream("Users.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                Stream stream6 = new FileStream("AllPersons.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                //try que Desterializa; catch mostrar mensaje; finally cierra archivo
                try
                {
                    List<Movies> des = (List<Movies>)formatter.Deserialize(stream1);
                    if (des.Count != 0)
                    {
                        Files.AllMovies = des;
                    }
                }
                catch
                {
                }
                try
                {
                    List<Songs> des2 = (List<Songs>)formatter.Deserialize(stream2);
                    if (des2.Count != 0)
                    {
                        Files.AllSongs = des2;
                    }
                }
                catch
                {
                }
                try
                {
                    Files.AllPlaylistsSongs = (List<Playlists>)formatter.Deserialize(stream3);
                }
                catch
                {
                }
                try
                {
                    Files.AllPlaylistsMovies = (List<Playlists>)formatter.Deserialize(stream4);
                }
                catch
                {
                }
                try
                {
                    Files.Users = (List<User>)formatter.Deserialize(stream5);
                    foreach (User i in Files.Users)
                    {
                        List<string> data = new List<string>()
                        { i.UserName, i.Email, i.Password, Convert.ToString(DateTime.Now), i.Type};
                        Files.AllUsers.Add(Files.AllUsers.Count + 1, data);
                    }
                }
                catch
                {
                }
                try
                {
                    List<Person> des = (List<Person>)formatter.Deserialize(stream6);
                    if (des.Count != 0)
                    {
                        List<Person> Final = ((from s in des select s).Distinct()).ToList();
                        Files.AllPersons = Final;
                    }
                }
                catch
                {
                }
                finally
                {
                    stream1.Close();
                    stream2.Close();
                    stream3.Close();
                    stream4.Close();
                    stream5.Close();
                    stream6.Close();
                }
            }
        }

        private void Serializacion()
        {
            List<Person> Final = ((from s in Files.AllPersons select s).Distinct()).ToList();
            Files.AllPersons = Final;

            IFormatter formatter = new BinaryFormatter();

            Stream stream7 = new FileStream("AllMovies.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            Stream stream8 = new FileStream("AllSongs.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            Stream stream9 = new FileStream("AllPlaylistsSongs.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            Stream stream10 = new FileStream("AllPlaylistsMovies.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            Stream stream11 = new FileStream("Users.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            Stream stream12 = new FileStream("AllPersons.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream7, Files.AllMovies);
            formatter.Serialize(stream8, Files.AllSongs);
            formatter.Serialize(stream9, Files.AllPlaylistsSongs);
            formatter.Serialize(stream10, Files.AllPlaylistsMovies);
            formatter.Serialize(stream11, Files.Users);
            formatter.Serialize(stream12, Files.AllPersons);
            stream7.Close();
            stream8.Close();
            stream9.Close();
            stream10.Close();
            stream11.Close();
            stream12.Close();
        }

        private void AppForm_Load(object sender, EventArgs e)
        {

        }

        private void IniciarSesión_Click(object sender, EventArgs e)
        {
            stackPanels.Add(panels["LoginPanel"]);
            ShowLastPanel();
            Serializacion();
        }

        private void CrearCuenta_Click(object sender, EventArgs e)
        {
            InputPrivacidadCreateAccountView.SelectedIndex = -1;
            InputTipoUsuarioCreateAccountView.SelectedIndex = -1;
            InputPasswordCreateAccountView.ResetText();
            InputEmailCreateAccountView.ResetText();
            InputUserNameCreateAccountView.ResetText();
            stackPanels.Add(panels["CreateAccountPanel"]);
            ShowLastPanel();
            Serializacion();
        }

        private void WelcomeMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ShowLastPanel()
        {
            foreach (Panel panel in panels.Values)
            {
                if (panel != stackPanels.Last())
                {
                    panel.Visible = false;
                }
                else
                {
                    panel.Dock = DockStyle.Fill;
                    panel.Visible = true;
                }
            }
        }

        public void setNameUser(string username)
        {
            ReadUserName.Text = username;
        }

        private void OnUserChecked(string username)
        {
            if (UserChecked != null)
            {
                UserChecked(this, new LoginEventArgs() { UsernameText = username });
                InputUsuarioLoginView.ResetText();
                InputContraseñaLoginView.ResetText();
                setNameUser(username);
                foreach (User user in Files.Users)
                {
                    if (user.UserName == username)
                    {
                        user.LOGIN = true;
                        Serializacion();
                    }
                }
                stackPanels.Add(panels["UserPanel"]);
                ShowLastPanel();
            }
        }

        private void UserPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoginButtonLoginView_Click(object sender, EventArgs e)
        {
            string username = InputUsuarioLoginView.Text;
            string pass = InputContraseñaLoginView.Text;
            if (username =="Admin" && pass == "Admin")
            {
                stackPanels.Add(panels["AdminPanel"]);
                AddSongPanel.SendToBack();
                AddMoviePanel.SendToBack();
                ShowLastPanel();
            }
            else
            {
                OnLoginButtonClicked(username, pass);
            }
            VerMisPlaylits.Visible = false;
            ShowSong.Visible = false;
            ShowMovie.Visible = false;
            ShowUserPanel.Visible = false;
            ShowPersonPanel.Visible = false;
            ShowMoviesPanel.Visible = false;
            BuscadorPanel.Visible = false;
            ResultsBuscador.Visible = false;
            FollowersPanel.Visible = false;
            CrearPlaylist.Visible = false;
            ShowSongsPanel.Visible = false;
            pictureBox1.Visible = true;
            pictureBox1.BringToFront();
            Serializacion();
        }

        private void OnLoginButtonClicked(string username, string pass)
        {
            bool result = LoginButtonClicked(this, new LoginEventArgs() { UsernameText = username, PasswordText = pass });
            if (!result)
            {
                loginViewInvalidCredentialsAlert.Text = "Credenciales inválidas";
                loginViewInvalidCredentialsAlert.Visible = true;
            }
            else
            {
                loginViewInvalidCredentialsAlert.ResetText();
                loginViewInvalidCredentialsAlert.Visible = false;
                foreach (User user in Files.Users)
                {
                    if (user.UserName == username)
                    {
                        user.LOGIN = true;
                        Serializacion();
                    }
                }
                OnUserChecked(username);
            }
        }

        private void CreateAccountView_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            string username = InputUserNameCreateAccountView.Text;
            string email = InputEmailCreateAccountView.Text;
            string pass = InputPasswordCreateAccountView.Text;
            string type = InputTipoUsuarioCreateAccountView.Text;
            string privacy = InputPrivacidadCreateAccountView.Text;
            OnCreateAccountClicked(username, email, pass,type, privacy);
            VerMisPlaylits.Visible = false;
            ShowSong.Visible = false;
            ShowMovie.Visible = false;
            ShowUserPanel.Visible = false;
            ShowPersonPanel.Visible = false;
            ShowMoviesPanel.Visible = false;
            BuscadorPanel.Visible = false;
            ResultsBuscador.Visible = false;
            FollowersPanel.Visible = false;
            CrearPlaylist.Visible = false;
            ShowSongsPanel.Visible = false;
            pictureBox1.Visible = true;
            pictureBox1.BringToFront();
            Serializacion();
        }

        private void OnCreateAccountClicked(string username, string email, string pass, string type, string privacy)
        {
            if ((type =="") || (type=="Premium" && privacy == "") || (username=="") || pass=="" || email =="")
            {
                CheckRegistration.Text = "Agregue los valores que faltan";
                CheckRegistration.Visible = true;
            }
            else
            {
                string typeprivacy = null;
                if (type == "Premium")
                {
                    if (privacy == "Público")
                    {
                        typeprivacy = "PremiumT";
                    }
                    else
                    {
                        typeprivacy = "PremiumF";
                    }
                }
                else if (type == "Free")
                {
                    typeprivacy = "Free";
                }
                bool result = CreateAccountClicked(this, new RegisterEventArgs() { Username = username, Password = pass, Email = email, TypePrivacy= typeprivacy });
                if (!result)
                {
                    CheckRegistration.Text = "Usuario y/o email ya existen";
                    CheckRegistration.Visible = true;
                }
                else
                {
                    CheckRegistration.ResetText();
                    CheckRegistration.Visible = false;
                    Serializacion();
                    OnUserChecked(username);
                }
            }
        }

        private void CerrarSesiónButton_Click(object sender, EventArgs e)
        {
            stackPanels.Add(panels["WelcomePanel"]);
            foreach (User user in Files.Users)
            {
                if (user.LOGIN==true)
                {
                    user.LOGIN = false;
                }
            }
            Serializacion();
            setNameUser("");
            ShowLastPanel();
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
            }
        }

        private void ModificarCuentaButton_Click(object sender, EventArgs e)
        {
            stackPanels.Add(panels["ModificarCuentaPanel"]);
            ShowLastPanel();
            ChangeUserPanel.Visible = false;
            ChangePasswordPanel.Visible = false;
            ChangeFreePanel.Visible = false;
            ChangeFreePanel.Visible = false;
            YaEsPremiumPanel.Visible = false;
            ModCorrPanel.Visible = false;
            Serializacion();
        }

        private void BackToUserMenuButton_Click(object sender, EventArgs e)
        {
            stackPanels.Add(panels["UserPanel"]);
            ShowLastPanel();
            VerMisPlaylits.Visible = false;
            ShowSong.Visible = false;
            ShowMovie.Visible = false;
            ShowUserPanel.Visible = false;
            ShowPersonPanel.Visible = false;
            ShowMoviesPanel.Visible = false;
            BuscadorPanel.Visible = false;
            ResultsBuscador.Visible = false;
            FollowersPanel.Visible = false;
            CrearPlaylist.Visible = false;
            ShowSongsPanel.Visible = false;
            pictureBox1.Visible = true;
            pictureBox1.BringToFront();
            Serializacion();
        }

        private void AceptarCambioNombreUsuarioButton_Click(object sender, EventArgs e)
        {
            string oldUser = ReadUserName.Text;
            string newUser = NuevoNombreUsuarioTextBox.Text;
            List<string> UserValues = Files.GetData(oldUser);
            UserValues[0] = newUser;
            foreach (User usuario in Files.Users)
            {
                if (usuario.UserName == oldUser)
                {
                    usuario.UserName = newUser;
                }
            }
            ReadUserName.Text = newUser;
            ChangeUserPanel.Visible = false;
            ModCorrPanel.Visible = true;
            Serializacion();
        }

        private void CambiarUsuarioButton_Click(object sender, EventArgs e)
        {
            ChangePasswordPanel.Visible = false;
            ChangeFreePanel.Visible = false;
            YaEsPremiumPanel.Visible = false;
            ModCorrPanel.Visible = false;
            NuevoNombreUsuarioTextBox.ResetText();
            ChangeUserPanel.Visible = true;
            Serializacion();
        }

        private void CambiarContraseñaButton_Click(object sender, EventArgs e)
        {
            ChangeUserPanel.Visible = false;
            ChangeFreePanel.Visible = false;
            YaEsPremiumPanel.Visible = false;
            ModCorrPanel.Visible = false;
            CheckOldPassword.ResetText();
            InputNewPassword.ResetText();
            InputOldPassword.ResetText();
            ChangePasswordPanel.Visible = true;
            Serializacion();
        }

        private void AceptarNuevaContraseñaButton_Click(object sender, EventArgs e)
        {
            string oldUser = ReadUserName.Text;
            string oldPass = InputOldPassword.Text;
            string newPass = InputNewPassword.Text;
            List<string> UserValues = Files.GetData(oldUser);
            foreach (User usuario in Files.Users)
            {
                if (usuario.UserName == oldUser)
                {
                    if (oldPass == usuario.Password)
                    {
                        usuario.Password = newPass;
                        UserValues[2] = newPass;
                        ChangePasswordPanel.Visible = false;
                        ModCorrPanel.Visible = true;
                    }
                    else
                    {
                        CheckOldPassword.Text = "Contraseña Actual Incorrecta";
                    }
                    Serializacion();
                }
            }
        }

        private void ChangeFreePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AceptarCambioCuentaButton_Click(object sender, EventArgs e)
        {
            if (PrivacidadFreeNuevaComboBox.Text == "")
            {
                CheckPrivacyInformation.Text = "Seleccione Privacidad";
            }
            else
            {
                string oldUser = ReadUserName.Text;
                string privacy = PrivacidadFreeNuevaComboBox.Text;
                List<string> UserValues = Files.GetData(oldUser);
                foreach (User usuario in Files.Users)
                {
                    if (usuario.UserName == oldUser)
                    {
                       if (privacy == "Público")
                       {
                            UserValues[4] = "PremiumT";
                            usuario.Type = "Premium";
                            usuario.Privacy1 = true;
                            ChangeFreePanel.Visible = false;
                       }
                       else if (privacy == "Privado")
                       {
                            UserValues[4] = "PremiumF";
                            usuario.Type = "Premium";
                            usuario.Privacy1 = false;
                            ChangeFreePanel.Visible = false;
                       }
                       Serializacion();
                       ModCorrPanel.Visible = true;
                    }
                }
            }
        }

        private void CambioTipoCuentaButton_Click(object sender, EventArgs e)
        {
            YaEsPremiumPanel.Visible = false;
            ChangeUserPanel.Visible = false;
            ChangePasswordPanel.Visible = false;
            ModCorrPanel.Visible = false;
            PrivacidadFreeNuevaComboBox.SelectedIndex = -1;
            CheckPrivacyInformation.ResetText();
            string oldUser = ReadUserName.Text;
            List<string> UserValues = Files.GetData(oldUser);
            if (UserValues[4].Contains("Premium"))
            {
                YaEsPremiumPanel.Visible = true;
            }
            else
            { 
                ChangeFreePanel.Visible = true;
            }
            Serializacion();
        }

        private void VolverButtonLoginView_Click(object sender, EventArgs e)
        {
            stackPanels.Add(panels["WelcomePanel"]);
            InputContraseñaLoginView.ResetText();
            InputUsuarioLoginView.ResetText();
            loginViewInvalidCredentialsAlert.ResetText();
            ShowLastPanel();
            Serializacion();
        }

        private void FemeninoSexoBuscadorPanel_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void MasculinoSexoBuscadorPanel_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void VolverRegisterPanel_Click(object sender, EventArgs e)
        {
            stackPanels.Add(panels["WelcomePanel"]);
            InputPrivacidadCreateAccountView.SelectedIndex = -1;
            InputPasswordCreateAccountView.ResetText();
            InputEmailCreateAccountView.ResetText();
            InputUserNameCreateAccountView.ResetText();
            InputTipoUsuarioCreateAccountView.SelectedIndex = -1;
            CheckRegistration.ResetText();
            ShowLastPanel();
            Serializacion();
        }

        private void FillDataGridViewSongS(List<Songs> songs)
        {
            DataGriedSongS.Rows.Clear();
            DataGriedSongS.Columns.Clear();
            DataGridViewImageColumn dgvImagen = new DataGridViewImageColumn();
            dgvImagen.HeaderText = "Canción";
            dgvImagen.ImageLayout = DataGridViewImageCellLayout.Stretch;
            DataGridViewTextBoxColumn nombre = new DataGridViewTextBoxColumn();
            nombre.HeaderText = "Información";
            DataGridViewButtonColumn buttons = new DataGridViewButtonColumn();
            buttons.Text = "Seleccionar";
            buttons.UseColumnTextForButtonValue = true;
            buttons.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            buttons.FlatStyle = FlatStyle.Standard;
            buttons.CellTemplate.Style.BackColor = Color.Black;
            buttons.CellTemplate.Style.ForeColor = Color.White;


            DataGriedSongS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGriedSongS.RowTemplate.Height = 200;
            DataGriedSongS.AllowUserToAddRows = false;

            DataGriedSongS.Columns.Add(dgvImagen);
            DataGriedSongS.Columns.Add(nombre);
            DataGriedSongS.Columns.Add(buttons);

            DataGriedSongS.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            DataGriedSongS.Columns[0].Width = 200;
            DataGriedSongS.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            foreach (Songs song in songs)
            {
                var carpeta = Directory.GetCurrentDirectory();
                var D = carpeta + song.Album1.Image1;
                DataGriedSongS.Rows.Add(new object[] { System.Drawing.Image.FromFile(D), "Título: " + song.Title1 + "\r\nCantante: " + song.Artist1.Name + "\r\nDuración: " + song.Lenght1.ToString() + " min. \r\nRating: " + song.RatingProm1.ToString() });
            }
            ShowSongsPanel.Controls.Add(DataGriedSongS);
        }

        private void VerTodasLasCancionesButton_Click(object sender, EventArgs e)
        {
            InfoMovieTextBox.Text = "";
            InfoSongsTextBox.Text = "";
            ShowSongsPanel.Visible = true;
            ShowSongsPanel.BringToFront();
            FillDataGridViewSongS(Files.AllSongs);
            Serializacion();
        }

        private void FillDataGridViewMovieS(List<Movies> movies)
        {
            DataGriedMovieS.Rows.Clear();
            DataGriedMovieS.Columns.Clear();
            DataGridViewImageColumn dgvImagen = new DataGridViewImageColumn();
            dgvImagen.HeaderText = "Película";
            dgvImagen.ImageLayout = DataGridViewImageCellLayout.Stretch;
            DataGridViewTextBoxColumn nombre = new DataGridViewTextBoxColumn();
            nombre.HeaderText = "Información";
            DataGridViewButtonColumn buttons = new DataGridViewButtonColumn();
            buttons.HeaderText = @"";
            buttons.Text = "Seleccionar";
            buttons.UseColumnTextForButtonValue = true;
            buttons.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            buttons.FlatStyle = FlatStyle.Standard;
            buttons.CellTemplate.Style.BackColor = Color.Black;
            buttons.CellTemplate.Style.ForeColor = Color.White;


            DataGriedMovieS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGriedMovieS.RowTemplate.Height = 200;
            DataGriedMovieS.AllowUserToAddRows = false;

            DataGriedMovieS.Columns.Add(dgvImagen);
            DataGriedMovieS.Columns.Add(nombre);
            DataGriedMovieS.Columns.Add(buttons);


            DataGriedMovieS.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            DataGriedMovieS.Columns[0].Width = 200;
            DataGriedMovieS.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            foreach (Movies movie in movies)
            {
                var carpeta = Directory.GetCurrentDirectory();
                var H = carpeta + movie.MovieDirection;
                DataGriedMovieS.Rows.Add(new object[] { System.Drawing.Image.FromFile(H), "Título: " + movie.Title1 + "\r\nDirector: " + movie.Director1.Name + "\r\nDuración: " + movie.Lenght1.ToString() + " min. \r\nRating: " + movie.RatingProm1.ToString() });
            }
            ShowMoviesPanel.Controls.Add(DataGriedMovieS);
        }

        private void VerTodasLasPeliculasButton_Click(object sender, EventArgs e)
        {
            InfoMovieTextBox.Text = "";
            InfoSongsTextBox.Text = "";
            ShowMoviesPanel.Visible = true;
            ShowMoviesPanel.BringToFront();
            FillDataGridViewMovieS(Files.AllMovies);
            Serializacion();
        }

        private void RellenarInfoMovies(string name)
        {
            foreach (Movies movie in Files.AllMovies)
            {
                if (movie.Title1 == name)
                {
                    InfoMovieTextBox.Text = "Título: " + movie.Title1 + "\r\nDirector: " + movie.Director1.Name + "\r\nReparto: ";
                    foreach (Person person in movie.Actors1)
                    {
                        InfoMovieTextBox.Text += person.Name + ", ";
                    }
                    InfoMovieTextBox.Text = InfoMovieTextBox.Text.Substring(0, InfoMovieTextBox.Text.Length - 2);
                    InfoMovieTextBox.Text += "\r\nEscritor: " + movie.Writer1.Name + "\r\nDuración: " + movie.Lenght1.ToString() + " min. \r\nRating: " + movie.RatingProm1.ToString() + "\r\nNúmero de Reproducciones: " + movie.NumReproductions.ToString() + "\r\nCategorías: ";
                    foreach (string cat in movie.Categories1)
                    {
                        InfoMovieTextBox.Text += cat + ", ";
                    }
                    InfoMovieTextBox.Text = InfoMovieTextBox.Text.Substring(0, InfoMovieTextBox.Text.Length - 2);
                    InfoMovieTextBox.Text += "\r\nEstudio: " + movie.Studio1 + "\r\nAño: " + movie.Year1;
                    var carpeta = Directory.GetCurrentDirectory();
                    var H = carpeta + movie.MovieDirection;
                    ShowImagenShowMovie.BackgroundImageLayout = ImageLayout.Stretch;
                    ShowImagenShowMovie.BackgroundImage = Image.FromFile(H);
                }
            }
        }

        private void RellenarInfoSongs(string name)
        {
            foreach (Songs song in Files.AllSongs)
            {
                if (song.Title1 == name)
                {
                    InfoSongsTextBox.Text = "Título: " + song.Title1 + "\r\nArtista: " + song.Artist1.Name + "\r\nÁlbum: " + song.Album1.Name1 + "\r\nGéneros: ";
                    foreach (string gen in song.Genre1)
                    {
                        InfoSongsTextBox.Text += gen + ", ";
                    }
                    InfoSongsTextBox.Text = InfoSongsTextBox.Text.Substring(0, InfoSongsTextBox.Text.Length - 2);
                    InfoSongsTextBox.Text += "\r\nCompositor: " + song.Composer1.Name + "\r\nEscritor: " + song.Writer1.Name + "\r\nDuración: " + song.Lenght1.ToString() + "\r\nRating: " + song.RatingProm1.ToString() + "\r\nNúmero de Reproducciones: " + song.NumReproductions.ToString();
                    var carpeta = Directory.GetCurrentDirectory();
                    var H = carpeta + song.Album1.Image1;
                    ShowImageShowSong.BackgroundImageLayout = ImageLayout.Stretch;
                    ShowImageShowSong.BackgroundImage = Image.FromFile(H);
                    PersonInformation.Text = null;
                    PersonInformation.Text += "Nombre: " + song.Artist1.Name + "\r\nFecha Nacimiento: " + song.Artist1.Birthday.ToString("dd / MM / yyyy");
                    if (song.Artist1.Genre == 'M') { PersonInformation.Text += "\r\nGénero: Masculino"; }
                    else if (song.Artist1.Genre == 'F') { PersonInformation.Text += "\r\nGénero: Femenino"; }
                    int num = song.Artist1.NumReproduction;
                    string num2 = num.ToString();
                    PersonInformation.Text += "\r\nNúmero de Reproducciones: " + num2;
                    linklabelPerson.Text = song.Artist1.Link;
                }
            }
        }

        private void DataGriedMovieS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGriedMovieS.Rows.Count != 0)
            {
                string datosTO = DataGriedMovieS.Rows[DataGriedMovieS.CurrentRow.Index].Cells[1].Value.ToString();
                string datosT = datosTO.Replace("Título: ", string.Empty);
                string datos = datosT.Replace("Director: ", string.Empty);
                string[] stringSeparators = new string[] { "\r\n" };
                string[] lines = datos.Split(stringSeparators, StringSplitOptions.None);
                if (e.ColumnIndex == 2)
                {
                    //MessageBox.Show("Reproduciendo: " + lines[0] + " del director " + lines[1]);
                    InfoMovieTextBox.Text = null;
                    RellenarInfoMovies(lines[0]);
                    ShowMovie.Visible = true;
                    ShowMovie.BringToFront();
                    Serializacion();
                }
            }
        }

        private void DataGriedSongS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(DataGriedSongS.Rows.Count != 0)
            {
                string datosTO = DataGriedSongS.Rows[DataGriedSongS.CurrentRow.Index].Cells[1].Value.ToString();
                string datosT = datosTO.Replace("Título: ", string.Empty);
                string datos = datosT.Replace("Cantante: ", string.Empty);
                string[] stringSeparators = new string[] { "\r\n" };
                string[] lines = datos.Split(stringSeparators, StringSplitOptions.None);
                if (e.ColumnIndex == 2)
                {
                    //MessageBox.Show("Reproduciendo: " + lines[0] + " de " + lines[1]);
                    InfoSongsTextBox.Text = null;
                    RellenarInfoSongs(lines[0]);
                    ShowSong.Visible = true;
                    ShowSong.BringToFront();
                    Serializacion();
                }
            }
        }

        public void SacarRuta(string s)
        {
            string carpeta = Directory.GetCurrentDirectory();
            foreach (Movies j in Files.AllMovies)
            {
                if (s == j.Title1)
                {
                    this.ruta = carpeta + j.Video1;
                    this.name = j.Title1;
                }
            }
            foreach (Songs j in Files.AllSongs)
            {
                if (s == j.Title1)
                {
                    this.ruta = carpeta + j.Music1;
                    this.name = j.Title1;
                }
            }
        }

        private void ReproducirShowMovie_Click(object sender, EventArgs e)
        {
            string titulo = null;
            titulo = InfoMovieTextBox.Lines[0];
            string Titulo = titulo.Replace("Título: ", string.Empty);
            RellenarInfoMovies(Titulo);
            Reproducir(Titulo);
            Serializacion();
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            stackPanels.Add(panels["UserPanel"]);
            ShowLastPanel();
            Serializacion();
        }

        private void ReproducirButtonShowsSong_Click(object sender, EventArgs e)
        {
            string titulo = null;
            titulo = InfoSongsTextBox.Lines[0];
            string Titulo = titulo.Replace("Título: ", string.Empty);
            RellenarInfoSongs(Titulo);
            Reproducir(Titulo);
            Serializacion();
        }

        private void axWindowsMediaPlayer1_Enter_1(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel62_Paint(object sender, PaintEventArgs e)
        {

        }

        private User GetUser()
        {
            string nombre = ReadUserName.Text;
            foreach (User user in Files.Users)
            {
                if (user.UserName == nombre)
                {
                    return user;
                }
            }
            return null;

        }

        private void CrearPlaylistButton_Click(object sender, EventArgs e)
        {
            InfoMovieTextBox.Text = "";
            InfoSongsTextBox.Text = "";
            label46.Visible = false;
            TipoPlaylist2.Visible = false;
            label48.Visible = false;
            Criterio.Visible = false;
            label47.Visible = false;
            NombrePlaylist.Visible = false;
            label49.Visible = false;
            NombreCriterio.Visible = false;
            AceptarPlaylist.Visible = false;
            TipoPlaylist2.Visible = false;
            label46.Visible = false;
            TipoPlaylist.SelectedIndex = -1;
            TipoPlaylist2.SelectedIndex = -1;
            Criterio.SelectedIndex = -1;
            NombreCriterio.ResetText();
            NombrePlaylist.ResetText();
            label46.Visible = false;
            TipoPlaylist2.Visible = false;
            label48.Visible = false;
            Criterio.Visible = false;
            label47.Visible = false;
            NombrePlaylist.Visible = false;
            label49.Visible = false;
            NombreCriterio.Visible = false;
            AceptarPlaylist.Visible = false;
            TipoPlaylist2.Visible = false;
            label46.Visible = false;
            TipoPlaylist.SelectedIndex = -1;
            TipoPlaylist2.SelectedIndex = -1;
            Criterio.SelectedIndex = -1;
            NombreCriterio.ResetText();
            NombrePlaylist.ResetText();

            Computer computer = new Computer();
            User user = GetUser();
            if (user.Type == "Premium")
            {
                CrearPlaylist.Visible = true;
                CrearPlaylist.BringToFront();
                string tipo = TipoPlaylist.Text;
                if(tipo == "SmartPlaylist")
                {
                    label46.Visible = true;
                    TipoPlaylist2.Visible = true;
                    string tipo2 = TipoPlaylist2.Text;
                    if (tipo2 == "Canción")
                    {
                        string name = NombrePlaylist.Text;
                        Criterio.Items.Add("Género");
                        Criterio.Items.Add("Artista");

                    }
                    else if (tipo2 == "Película")
                    {
                        Criterio.Items.Add("Director");
                        Criterio.Items.Add("Estudio");
                        Criterio.Items.Add("Actor");
                        Criterio.Items.Add("Categoría");

                    }
                }
            }
            else if (user.Type == "Free")
            {
                MessageBox.Show("Opción válida solo para usuarios Premium");
            }
            Serializacion();
        }

        private void AceptarPlaylist_Click(object sender, EventArgs e)
        {
            Computer computer = new Computer();
            User user = GetUser();
            string nombre = NombrePlaylist.Text;
            string tipo = TipoPlaylist.Text;
            string tipo2 = TipoPlaylist2.Text;
            string criterio = Criterio.Text;
            string namecriterio = NombreCriterio.Text.ToUpper();
            bool option = true;
            foreach (Playlists pla in user.MyPlaylist1)
            {
                if (pla.Name ==nombre && pla.Type == tipo2)
                {
                    option = false;
                }
            }
            if (nombre == "Me gusta")
            {
                option = false;
            }
            if (option)
            {
                if (tipo == "Normal")
                {
                    if (user.Privacy1 == true)
                    {
                        user.MyPlaylist1.Add(computer.CreatePlaylist(tipo2, nombre));
                        if (tipo2 == "Canción")
                        {
                            Files.AllPlaylistsSongs.Add(computer.CreatePlaylist(tipo2, nombre));

                        }
                        else if (tipo2 == "Película")
                        {
                            Files.AllPlaylistsMovies.Add(computer.CreatePlaylist(tipo2, nombre));

                        }
                    }
                    else if (user.Privacy1 == false)
                    {
                        user.MyPlaylist1.Add(computer.CreatePlaylist(tipo2, nombre));
                    }
                }
                else if (tipo == "SmartPlaylist")
                {
                    var a = computer.CreateSmartPlaylist(tipo2, criterio, namecriterio, nombre);
                    if (user.Privacy1 == true)
                    {
                        if (tipo2 == "Canción")
                        {
                            if (criterio == "Género")
                            {
                                foreach (Songs songs in Files.AllSongs)
                                {
                                    foreach (string genero in songs.Genre1)
                                    {
                                        if (genero.ToUpper().Contains(namecriterio))
                                        {
                                            a.Playlistsong.Add(songs);
                                        }
                                    }
                                }
                            }
                            else if (criterio == "Artista")
                            {
                                foreach (Songs songs in Files.AllSongs)
                                {
                                    if (songs.Artist1.Name.ToUpper().Contains(namecriterio))
                                    {
                                        a.Playlistsong.Add(songs);
                                    }
                                }
                            }
                            Files.AllPlaylistsSongs.Add(a);
                        }
                        else if (tipo2 == "Película")
                        {
                            if (criterio == "Director")
                            {
                                foreach (Movies movies in Files.AllMovies)
                                {
                                    if (movies.Director1.Name.ToUpper().Contains(namecriterio))
                                    {
                                        a.Playlistmovie.Add(movies);
                                    }
                                }
                            }
                            else if (criterio == "Estudio")
                            {
                                foreach (Movies movies in Files.AllMovies)
                                {
                                    if (movies.Studio1.ToUpper().Contains(namecriterio))
                                    {
                                        a.Playlistmovie.Add(movies);
                                    }
                                }
                            }
                            else if (criterio == "Categoría")
                            {
                                foreach (Movies movies in Files.AllMovies)
                                {
                                    foreach (string cate in movies.Categories1)
                                    {
                                        if (cate.ToUpper().Contains(namecriterio.ToUpper()))
                                        {
                                            a.Playlistmovie.Add(movies);
                                        }
                                    }
                                }
                            }
                            else if (criterio == "Actor")
                            {
                                foreach (Movies movies in Files.AllMovies)
                                {
                                    foreach (Person actor in movies.Actors1)
                                    {
                                        if (actor.Name.ToUpper().Contains(namecriterio))
                                        {
                                            a.Playlistmovie.Add(movies);
                                        }
                                    }
                                }
                            }
                            Files.AllPlaylistsMovies.Add(a);
                        }
                        user.MyPlaylist1.Add(a);
                    }
                    else if (user.Privacy1 == false)
                    {
                        if (tipo2 == "Canción")
                        {
                            if (criterio == "Género")
                            {
                                foreach (Songs songs in Files.AllSongs)
                                {
                                    foreach (string genero in songs.Genre1)
                                    {
                                        if (genero.ToUpper().Contains(namecriterio))
                                        {
                                            a.Playlistsong.Add(songs);
                                        }
                                    }
                                }
                            }
                            else if (criterio == "Artista")
                            {
                                foreach (Songs songs in Files.AllSongs)
                                {
                                    if (songs.Artist1.Name.ToUpper().Contains(namecriterio))
                                    {
                                        a.Playlistsong.Add(songs);
                                    }
                                }
                            }
                        }
                        else if (tipo2 == "Película")
                        {
                            if (criterio == "Director")
                            {
                                foreach (Movies movies in Files.AllMovies)
                                {
                                    if (movies.Director1.Name.ToUpper().Contains(namecriterio))
                                    {
                                        a.Playlistmovie.Add(movies);
                                    }
                                }
                            }
                            else if (criterio == "Estudio")
                            {
                                foreach (Movies movies in Files.AllMovies)
                                {
                                    if (movies.Studio1.ToUpper().Contains(namecriterio))
                                    {
                                        a.Playlistmovie.Add(movies);
                                    }
                                }
                            }
                            else if (criterio == "Categoría")
                            {
                                foreach (Movies movies in Files.AllMovies)
                                {
                                    foreach (string cate in movies.Categories1)
                                    {
                                        if (cate.ToUpper().Contains(namecriterio))
                                        {
                                            a.Playlistmovie.Add(movies);
                                        }
                                    }
                                }
                            }
                            else if (criterio == "Actor")
                            {
                                foreach (Movies movies in Files.AllMovies)
                                {
                                    foreach (Person actor in movies.Actors1)
                                    {
                                        if (actor.Name.ToUpper().Contains(namecriterio))
                                        {
                                            a.Playlistmovie.Add(movies);
                                        }
                                    }
                                }
                            }
                        }
                        user.MyPlaylist1.Add(a);
                    }
                }
                MessageBox.Show("Playlist creada con éxito");
            }
            else
            {
                MessageBox.Show("La playlist no se ha podido crear, debido a que existe una del mismo tipo y mismo nombre");
            }
            List<Playlists> Final = ((from s in user.MyPlaylist1 select s).Distinct()).ToList();
            user.MyPlaylist1 = Final;
            foreach (Playlists p in user.MyPlaylist1)
            {
                if (p.Type == "Película")
                {
                    List<Movies> Final5 = ((from s in p.Playlistmovie select s).Distinct()).ToList();
                    p.Playlistmovie = Final5;
                }
                else if (p.Type == "Canción")
                {
                    List<Songs> Final6 = ((from s in p.Playlistsong select s).Distinct()).ToList();
                    p.Playlistsong = Final6;
                }
            }
            List<Playlists> Final1 = ((from s in Files.AllPlaylistsMovies select s).Distinct()).ToList();
            Files.AllPlaylistsMovies = Final1;
            List<Playlists> Final2 = ((from s in Files.AllPlaylistsSongs select s).Distinct()).ToList();
            Files.AllPlaylistsSongs = Final2;
            CrearPlaylist.Visible = false;
            VerMIsPlaylistsButton_Click(sender, e);
            VerMisPlaylits.Visible = true;
            VerMisPlaylits.BringToFront();
            Serializacion();
        }

        private void NombrePlaylist_TextChanged(object sender, EventArgs e)
        {
            if (TipoPlaylist.Text == "SmartPlaylist")
            {
                label48.Visible = true;
                Criterio.Visible = true;
            }
            else
            {
                AceptarPlaylist.Visible = true;
            }
        }

        private void label48_Click(object sender, EventArgs e)
        {

        }

        private void TipoPlaylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoPlaylist2.Visible = true;
            label46.Visible = true;
        }

        private void TipoPlaylist2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label47.Visible = true;
            NombrePlaylist.Visible = true;
            string tipo2 = TipoPlaylist2.Text;
            Criterio.Items.Clear();
            if (tipo2 == "Canción")
            {
                Criterio.Items.Add("Género");
                Criterio.Items.Add("Artista");

            }
            else if (tipo2 == "Película")
            {
                Criterio.Items.Add("Director");
                Criterio.Items.Add("Estudio");
                Criterio.Items.Add("Actor");
                Criterio.Items.Add("Categoría");

            }
        }

        private void Criterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TipoPlaylist.Text == "SmartPlaylist")
            {
                label49.Visible = true;
                NombreCriterio.Visible = true;
            }
            else
            {
                AceptarPlaylist.Visible = true;
            }
        }

        private void NombreCriterio_TextChanged(object sender, EventArgs e)
        {
            AceptarPlaylist.Visible = true;
        }

        private void FillDataGridBuscadorSongS(List<Songs> songs)
        {
            dataGridBuscadorSongs.Rows.Clear();
            dataGridBuscadorSongs.Columns.Clear();
            DataGridViewImageColumn dgvImagen = new DataGridViewImageColumn();
            dgvImagen.HeaderText = "Canción";
            dgvImagen.ImageLayout = DataGridViewImageCellLayout.Stretch;
            DataGridViewTextBoxColumn nombre = new DataGridViewTextBoxColumn();
            nombre.HeaderText = "Información";
            DataGridViewButtonColumn buttons = new DataGridViewButtonColumn();
            buttons.Text = "Seleccionar";
            buttons.UseColumnTextForButtonValue = true;
            buttons.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            buttons.FlatStyle = FlatStyle.Standard;
            buttons.CellTemplate.Style.BackColor = Color.Black;
            buttons.CellTemplate.Style.ForeColor = Color.White;


            dataGridBuscadorSongs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridBuscadorSongs.RowTemplate.Height = 100;
            dataGridBuscadorSongs.AllowUserToAddRows = false;

            dataGridBuscadorSongs.Columns.Add(dgvImagen);
            dataGridBuscadorSongs.Columns.Add(nombre);
            dataGridBuscadorSongs.Columns.Add(buttons);

            dataGridBuscadorSongs.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridBuscadorSongs.Columns[0].Width = 100;
            dataGridBuscadorSongs.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            foreach (Songs song in songs)
            {
                var carpeta = Directory.GetCurrentDirectory();
                var D = carpeta + song.Album1.Image1;
                dataGridBuscadorSongs.Rows.Add(new object[] { System.Drawing.Image.FromFile(D), "Título: " + song.Title1 + "\r\nCantante: " + song.Artist1.Name + "\r\nDuración: " + song.Lenght1.ToString() + " min. \r\nRating: " + song.RatingProm1.ToString() });
            }
            panel2.Controls.Add(dataGridBuscadorSongs);
        }

        private void FillDataGridBuscadorMovieS(List<Movies> movies)
        {
            dataGridBuscadorMovies.Rows.Clear();
            dataGridBuscadorMovies.Columns.Clear();
            DataGridViewImageColumn dgvImagen = new DataGridViewImageColumn();
            dgvImagen.HeaderText = "Película";
            dgvImagen.ImageLayout = DataGridViewImageCellLayout.Stretch;
            DataGridViewTextBoxColumn nombre = new DataGridViewTextBoxColumn();
            nombre.HeaderText = "Información";
            DataGridViewButtonColumn buttons = new DataGridViewButtonColumn();
            buttons.HeaderText = @"";
            buttons.Text = "Seleccionar";
            buttons.UseColumnTextForButtonValue = true;
            buttons.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            buttons.FlatStyle = FlatStyle.Standard;
            buttons.CellTemplate.Style.BackColor = Color.Black;
            buttons.CellTemplate.Style.ForeColor = Color.White;

            dataGridBuscadorMovies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridBuscadorMovies.RowTemplate.Height = 100;
            dataGridBuscadorMovies.AllowUserToAddRows = false;

            dataGridBuscadorMovies.Columns.Add(dgvImagen);
            dataGridBuscadorMovies.Columns.Add(nombre);
            dataGridBuscadorMovies.Columns.Add(buttons);


            dataGridBuscadorMovies.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridBuscadorMovies.Columns[0].Width = 100;
            dataGridBuscadorMovies.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            foreach (Movies movie in movies)
            {
                var carpeta = Directory.GetCurrentDirectory();
                var H = carpeta + movie.MovieDirection;
                dataGridBuscadorMovies.Rows.Add(new object[] { System.Drawing.Image.FromFile(H), "Título: " + movie.Title1 + "\r\nDirector: " + movie.Director1.Name + "\r\nDuración: " + movie.Lenght1.ToString() + " min. \r\nRating: " + movie.RatingProm1.ToString() });
            }
            panel1.Controls.Add(dataGridBuscadorMovies);
        }

        private void dataGridBuscadorMovies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridBuscadorMovies.Rows.Count!=0)
            {
                string datosTO = dataGridBuscadorMovies.Rows[dataGridBuscadorMovies.CurrentRow.Index].Cells[1].Value.ToString();
                string datosT = datosTO.Replace("Título: ", string.Empty);
                string datos = datosT.Replace("Director: ", string.Empty);
                string[] stringSeparators = new string[] { "\r\n" };
                string[] lines = datos.Split(stringSeparators, StringSplitOptions.None);
                if (e.ColumnIndex == 2)
                {
                    //MessageBox.Show("Reproduciendo: " + lines[0] + " de " + lines[1]);
                    InfoMovieTextBox.Text = null;
                    RellenarInfoMovies(lines[0]);
                    ShowMovie.Visible = true;
                    ShowMovie.BringToFront();
                    Serializacion();
                }
            }
        }

        private void dataGridBuscadorSongs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridBuscadorSongs.Rows.Count != 0)
            {
                string datosTO = dataGridBuscadorSongs.Rows[dataGridBuscadorSongs.CurrentRow.Index].Cells[1].Value.ToString();
                string datosT = datosTO.Replace("Título: ", string.Empty);
                string datos = datosT.Replace("Cantante: ", string.Empty);
                string[] stringSeparators = new string[] { "\r\n" };
                string[] lines = datos.Split(stringSeparators, StringSplitOptions.None);
                if (e.ColumnIndex == 2)
                {
                    //MessageBox.Show("Reproduciendo: " + lines[0] + " del director " + lines[1]);
                    InfoSongsTextBox.Text = null;
                    RellenarInfoSongs(lines[0]);
                    ShowSong.Visible = true;
                    ShowSong.BringToFront();
                    Serializacion();
                }
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            int Edad1 = 0;
            int Edad2 = 0;
            string año1 = Año1BuscadorPanel.Text;
            string año2 = Año2BuscadorPanel.Text;
            string Cat1 = CatGen1BuscadorPanel.Text;
            string Cat2 = CatGen2BuscadorPanel.Text;
            int NumRep1 = 0;
            int NumRep2 = 0;
            string titulo1 = Titulo1BuscadorTextBox.Text;
            string titulo2 = Titulo2BuscadorTextBox.Text;
            string persona1 = Persona1BuscadorPanel.Text;
            string persona2 = Persona2BuscadorPanel.Text;
            double rating1 = 0;
            double rating2 = 0;
            string album1 = Album1BuscadorPanel.Text;
            string album2 = Album2BuscadorPanel.Text;
            bool fem = FemeninoSexoBuscadorPanel.Checked;
            bool masc =MasculinoSexoBuscadorPanel.Checked;
            try
            {
                Edad1 = Convert.ToInt32(Edad1BuscadorPanelTextBox.Text);
            }
            catch
            {
                Edad1 = 0;
            }
            try
            {
                Edad2 = Convert.ToInt32(Edad2BuscadorPanelTextBox.Text);
            }
            catch
            {
                Edad2 = 0;
            }
            try
            {
                NumRep1 = Convert.ToInt32(NumRep1BuscadorPanel.Text);
            }
            catch
            {
                NumRep1 = 0;
            }
            try
            {
                NumRep2 = Convert.ToInt32(NumRep2BuscadorPanel.Text);
            }
            catch
            {
                NumRep2 = 0;
            }
            try
            {
                rating1 = Convert.ToInt32(Rating1BuscadorPanel.Text);
            }
            catch
            {
                rating1 = 0;
            }
            try
            {
                rating2 = Convert.ToInt32(Rating2BuscadorPanel.Text);
            }
            catch
            {
                rating2 = 0;
            }
            if (PelículasBuscadorUserCheckBox.Checked)
            {
                List<Movies> movies = Search.SearchingMovies(titulo1,titulo2,persona1,persona2,Cat1,Cat2,NumRep1,NumRep2,rating1,rating2,año1,año2);
                FillDataGridBuscadorMovieS(movies);
                dataGridBuscadorMovies.Visible = true;
                dataGridBuscadorMovies.BringToFront();
            }
            if (CancionesBuscadorUserCheckBox.Checked)
            {
                List<Songs> songs = Search.SearchingSongs(titulo1,titulo2,persona1,persona2,Cat1,Cat2,NumRep1,NumRep2,rating1,rating2,album1,album2);
                FillDataGridBuscadorSongS(songs);
                dataGridBuscadorSongs.Visible = true;
                dataGridBuscadorSongs.BringToFront();
            }
            if (PersonasCheckBoxBuscadorPanel.Checked)
            {
                (List<Person> personas, List<User> usuarios) = Search.SearchingPerson(titulo1,titulo2,persona1,persona2,masc,fem,Edad1,Edad2);
                FilldataGriedBuscadorFollowers(personas, usuarios);
                dataGriedBuscadorFollowers.Visible = true;
                dataGriedBuscadorFollowers.BringToFront();
            }
            BuscadorPanel.Visible = false;
            ResultsBuscador.Visible = true;
            ResultsBuscador.BringToFront();

            PersonasCheckBoxBuscadorPanel.Checked = false;
            CancionesBuscadorUserCheckBox.Checked = false;
            PelículasBuscadorUserCheckBox.Checked = false;
            Edad1BuscadorPanelTextBox.ResetText();
            Edad2BuscadorPanelTextBox.ResetText();
            NumRep1BuscadorPanel.ResetText();
            NumRep2BuscadorPanel.ResetText();
            Rating1BuscadorPanel.ResetText();
            Rating2BuscadorPanel.ResetText();
            Año1BuscadorPanel.ResetText();
            Año2BuscadorPanel.ResetText();
            CatGen1BuscadorPanel.ResetText();
            CatGen2BuscadorPanel.ResetText();
            Titulo1BuscadorTextBox.ResetText();
            Titulo2BuscadorTextBox.ResetText();
            Persona1BuscadorPanel.ResetText();
            Persona2BuscadorPanel.ResetText();
            Album1BuscadorPanel.ResetText();
            Album2BuscadorPanel.ResetText();
            FemeninoSexoBuscadorPanel.Checked = false; 
            MasculinoSexoBuscadorPanel.Checked=false;
            Serializacion();
        }

        private void Buscador_Click(object sender, EventArgs e)
        {
            InfoMovieTextBox.Text = "";
            InfoSongsTextBox.Text = "";
            BuscadorPanel.Visible = true;
            BuscadorPanel.BringToFront();
            Serializacion();
        }

        private void FillDataGridMisPlaylist()
        {
            User user = GetUser();
            dataGridVerPlaylist.Rows.Clear();
            dataGridVerPlaylist.Columns.Clear();
            DataGridViewTextBoxColumn nombre = new DataGridViewTextBoxColumn();
            nombre.HeaderText = "Nombre Playlist";
            DataGridViewTextBoxColumn tipo = new DataGridViewTextBoxColumn();
            tipo.HeaderText = "Tipo";
            DataGridViewButtonColumn buttons = new DataGridViewButtonColumn();
            buttons.HeaderText = @"";
            buttons.Text = "Ver";
            buttons.UseColumnTextForButtonValue = true;
            buttons.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            buttons.FlatStyle = FlatStyle.Standard;
            buttons.CellTemplate.Style.BackColor = Color.Black;
            buttons.CellTemplate.Style.ForeColor = Color.White;
            DataGridViewButtonColumn buttons2 = new DataGridViewButtonColumn();
            buttons2.HeaderText = @"";
            buttons2.Text = "Modificar";
            buttons2.UseColumnTextForButtonValue = true;
            buttons2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            buttons2.FlatStyle = FlatStyle.Standard;
            buttons2.CellTemplate.Style.BackColor = Color.Black;
            buttons2.CellTemplate.Style.ForeColor = Color.White;
            DataGridViewButtonColumn buttons3 = new DataGridViewButtonColumn();
            buttons3.HeaderText = @"";
            buttons3.Text = "Reproducir Playlist";
            buttons3.UseColumnTextForButtonValue = true;
            buttons3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            buttons3.FlatStyle = FlatStyle.Standard;
            buttons3.CellTemplate.Style.BackColor = Color.Black;
            buttons3.CellTemplate.Style.ForeColor = Color.White;


            dataGridVerPlaylist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridVerPlaylist.RowTemplate.Height = 100;
            dataGridVerPlaylist.AllowUserToAddRows = false;

            dataGridVerPlaylist.Columns.Add(nombre);
            dataGridVerPlaylist.Columns.Add(tipo);
            dataGridVerPlaylist.Columns.Add(buttons);
            dataGridVerPlaylist.Columns.Add(buttons2);
            dataGridVerPlaylist.Columns.Add(buttons3);

            dataGridVerPlaylist.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            for(int i = 0; i<user.MyPlaylist1.Count();i++)
            { 
                dataGridVerPlaylist.Rows.Add(user.MyPlaylist1[i].Name, user.MyPlaylist1[i].Type);
            }
            VerMisPlaylits.Controls.Add(dataGridVerPlaylist);
        }

        private void FillDataGridAgregarPlaylist()
        {
            User user = GetUser();
            dataGridAgregarAPlaylist.Rows.Clear();
            dataGridAgregarAPlaylist.Columns.Clear();
            DataGridViewTextBoxColumn nombre = new DataGridViewTextBoxColumn();
            nombre.HeaderText = "Nombre Playlist";
            DataGridViewTextBoxColumn tipo = new DataGridViewTextBoxColumn();
            tipo.HeaderText = "Tipo";
            DataGridViewButtonColumn buttons = new DataGridViewButtonColumn();
            buttons.HeaderText = @"";
            buttons.Text = "Seleccionar";
            buttons.UseColumnTextForButtonValue = true;
            buttons.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            buttons.FlatStyle = FlatStyle.Standard;
            buttons.CellTemplate.Style.BackColor = Color.Black;
            buttons.CellTemplate.Style.ForeColor = Color.White;

            dataGridAgregarAPlaylist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridAgregarAPlaylist.RowTemplate.Height = 100;
            dataGridAgregarAPlaylist.AllowUserToAddRows = false;

            dataGridAgregarAPlaylist.Columns.Add(nombre);
            dataGridAgregarAPlaylist.Columns.Add(tipo);
            dataGridAgregarAPlaylist.Columns.Add(buttons);

            dataGridAgregarAPlaylist.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            for (int i = 0; i < user.MyPlaylist1.Count(); i++)
            {
                dataGridAgregarAPlaylist.Rows.Add(user.MyPlaylist1[i].Name, user.MyPlaylist1[i].Type);
            }
            VerMisPlaylits.Controls.Add(dataGridAgregarAPlaylist);
        }

        private void VerMIsPlaylistsButton_Click(object sender, EventArgs e)
        {
            InfoMovieTextBox.Text = "";
            InfoSongsTextBox.Text = "";
            VerMisPlaylits.Visible = true;
            VerMisPlaylits.BringToFront();
            FillDataGridMisPlaylist();
            dataGridVerPlaylist.Visible = true;
            dataGridVerPlaylist.BringToFront();
            Serializacion();
        }

        private void CambiarNombrePlaylist_Click(object sender, EventArgs e)
        {
            string name = dataGridVerPlaylist.Rows[dataGridVerPlaylist.CurrentRow.Index].Cells[0].Value.ToString();
            if (name=="Me gusta")
            {
                MessageBox.Show("No se puede cambiar el nombre de esta Playlist");
            }
            else
            {
                label50.Visible = true;
                NuevoNombrePlaylist.Visible = true;
                Aceptarcambiodenombre.Visible = true;
                label50.BringToFront();
                NuevoNombrePlaylist.BringToFront();
                Aceptarcambiodenombre.BringToFront();
            }
            Serializacion();
        }

        private void Aceptarcambiodenombre_Click(object sender, EventArgs e)
        {
            User user = GetUser();
            string name = dataGridVerPlaylist.Rows[dataGridVerPlaylist.CurrentRow.Index].Cells[0].Value.ToString();
            string nuevo = NuevoNombrePlaylist.Text; 
            string tipo = dataGridVerPlaylist.Rows[dataGridVerPlaylist.CurrentRow.Index].Cells[1].Value.ToString();

            int contador = 0;
            foreach (Playlists p2 in user.MyPlaylist1)
            {
                if (nuevo == p2.Name)
                {
                    contador += 1;
                }
            }
            foreach (Playlists p in user.MyPlaylist1)
            {
                if (p.Name == name && contador == 0)
                {
                    p.Name = nuevo;
                    MessageBox.Show("Nombre cambiado con éxito");
                    break;
                }
            }
            if (contador != 0)
            {
                MessageBox.Show("La playlist no se puede crear porque ese nombre ya existe");
            }
            VerMisPlaylits.Visible = false;
            NuevoNombrePlaylist.Text = "";
            Serializacion();
        }

        public void ChooseFolder()
        { 
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.dest = folderBrowserDialog1.SelectedPath;
                try
                {
                    Copy();
                }
                catch(Exception EX) 
                { 
                }
            }
        }

        private void FilldataGriedFollowers(List<Person> persons, List<User> users)
        {
            dataGridFollowers.Rows.Clear();
            dataGridFollowers.Columns.Clear();
            DataGridViewTextBoxColumn nombre = new DataGridViewTextBoxColumn();
            nombre.HeaderText = "Nombre";
            DataGridViewTextBoxColumn tipo = new DataGridViewTextBoxColumn();
            nombre.HeaderText = "Tipo";
            DataGridViewButtonColumn buttons = new DataGridViewButtonColumn();
            buttons.HeaderText = @"";
            buttons.Text = "Seleccionar";
            buttons.UseColumnTextForButtonValue = true;
            buttons.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            buttons.FlatStyle = FlatStyle.Standard;
            buttons.CellTemplate.Style.BackColor = Color.Black;
            buttons.CellTemplate.Style.ForeColor = Color.White;


            dataGridFollowers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridFollowers.RowTemplate.Height = 100;
            dataGridFollowers.AllowUserToAddRows = false;

            dataGridFollowers.Columns.Add(nombre);
            dataGridFollowers.Columns.Add(tipo);
            dataGridFollowers.Columns.Add(buttons);

            if (persons != null)
            {
                foreach (Person p in persons)
                {
                    dataGridFollowers.Rows.Add(new object[] { p.Name, "Persona" });
                }
            }
            if (users != null)
            {
                foreach (User u in users)
                {
                    if (u.UserName != "Admin" && u.Privacy1 == true)
                    {
                        dataGridFollowers.Rows.Add(new object[] { u.UserName, "Usuario" });
                    }
                }
            }
            FollowersPanel.Controls.Add(dataGridFollowers);
        }

        private void FollowsButton_Click(object sender, EventArgs e)
        {
            User user = GetUser();
            FilldataGriedFollowers(user.FollowsP, user.FollowsU);
            FollowersPanel.Visible = true;
            FollowersPanel.BringToFront();
            Serializacion();
        }

        private void linklabelPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { 
            Process.Start(linklabelPerson.Text);
        }

        private void dataGridFollowers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridFollowers.Rows.Count != 0)
            {
                string datosTO = dataGridFollowers.Rows[dataGridFollowers.CurrentRow.Index].Cells[0].Value.ToString();
                string datosTO2 = dataGridFollowers.Rows[dataGridFollowers.CurrentRow.Index].Cells[1].Value.ToString();
                string[] stringSeparators = new string[] { "\r\n" };
                string[] lines = datosTO.Split(stringSeparators, StringSplitOptions.None);
                string[] lines2 = datosTO2.Split(stringSeparators, StringSplitOptions.None);
                if (e.ColumnIndex == 2)
                {
                    //MessageBox.Show("Seleccionaste a: " + lines[0] + " y es de tipo: "+lines2[0]);
                    if (lines2[0] == "Usuario")
                    {
                        //MessageBox.Show(lines2[0] + " " + lines[0]); Usuario keko
                        foreach (User u in Files.Users)
                        {
                            if (u.UserName == lines[0])
                            {
                                foreach (Playlists p in u.MyPlaylist1)
                                {
                                    FilldataGridVerPlaylistUsuarioExterno(lines[0]);
                                    dataGridVerPlaylistUsuarioExterno.BringToFront();
                                    ShowUserPanel.Visible = true;
                                    ShowUserPanel.BringToFront();
                                    NombreUsuarioTextBox.Text = lines[0];
                                }
                            }
                        }
                        Serializacion();
                    }
                    else if (lines2[0] == "Persona")
                    {
                        PersonInformation.Text = null;
                        foreach (Person p in Files.AllPersons)
                        {
                            if (p.Name == lines[0])
                            {
                                PersonInformation.Text += "Nombre: " + p.Name + "\r\nFecha Nacimiento: " + p.Birthday.ToString("dd / MM / yyyy");
                                if (p.Genre == 'M') { PersonInformation.Text += "\r\nGénero: Masculino"; }
                                else if (p.Genre == 'F') { PersonInformation.Text += "\r\nGénero: Femenino"; }
                                if (p.Tipo == "Artista") { PersonInformation.Text += "\r\nNúmero de Reproducciones: " + p.NumReproduction.ToString(); }
                                linklabelPerson.Text = p.Link;
                            }
                        }
                        FilldataGriedPanelPersona(lines[0]);
                        dataGriedPanelPersona.BringToFront();
                        ShowPersonPanel.Visible = true;
                        ShowPersonPanel.BringToFront();
                        Serializacion();
                    }
                }
            }
        }

        private void FilldataGridVerPlaylistUsuarioExterno(string username)
        {
            foreach (User u in Files.Users)
            {
                if (username == u.UserName)
                {
                    dataGridVerPlaylistUsuarioExterno.Rows.Clear();
                    dataGridVerPlaylistUsuarioExterno.Columns.Clear();
                    DataGridViewTextBoxColumn nombre = new DataGridViewTextBoxColumn();
                    nombre.HeaderText = "Nombre";
                    DataGridViewTextBoxColumn tipo = new DataGridViewTextBoxColumn();
                    nombre.HeaderText = "Tipo";
                    DataGridViewButtonColumn buttons = new DataGridViewButtonColumn();
                    buttons.HeaderText = @"";
                    buttons.Text = "Ver Playlist";
                    buttons.UseColumnTextForButtonValue = true;
                    buttons.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    buttons.FlatStyle = FlatStyle.Standard;
                    buttons.CellTemplate.Style.BackColor = Color.Black;
                    buttons.CellTemplate.Style.ForeColor = Color.White;

                    DataGridViewButtonColumn buttons2 = new DataGridViewButtonColumn();
                    buttons2.HeaderText = @"";
                    buttons2.Text = "Reproducir Playlist";
                    buttons2.UseColumnTextForButtonValue = true;
                    buttons2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    buttons2.FlatStyle = FlatStyle.Standard;
                    buttons2.CellTemplate.Style.BackColor = Color.Black;
                    buttons2.CellTemplate.Style.ForeColor = Color.White;

                    dataGridVerPlaylistUsuarioExterno.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridVerPlaylistUsuarioExterno.RowTemplate.Height = 100;
                    dataGridVerPlaylistUsuarioExterno.AllowUserToAddRows = false;

                    dataGridVerPlaylistUsuarioExterno.Columns.Add(nombre);
                    dataGridVerPlaylistUsuarioExterno.Columns.Add(tipo);
                    dataGridVerPlaylistUsuarioExterno.Columns.Add(buttons);
                    dataGridVerPlaylistUsuarioExterno.Columns.Add(buttons2);

                    foreach (Playlists p in u.MyPlaylist1)
                    {
                        dataGridVerPlaylistUsuarioExterno.Rows.Add(new object[] { p.Name, p.Type });
                    }
                    panel5.Controls.Add(dataGridVerPlaylistUsuarioExterno);
                }
            }
        }

        private void dataGridVerPlaylistUsuarioExterno_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string datosTO = dataGridVerPlaylistUsuarioExterno.Rows[dataGridVerPlaylistUsuarioExterno.CurrentRow.Index].Cells[0].Value.ToString();
            string datosTO2 = dataGridVerPlaylistUsuarioExterno.Rows[dataGridVerPlaylistUsuarioExterno.CurrentRow.Index].Cells[1].Value.ToString();
            string[] stringSeparators = new string[] { "\r\n" };
            string[] lines = datosTO.Split(stringSeparators, StringSplitOptions.None);
            string[] lines2 = datosTO2.Split(stringSeparators, StringSplitOptions.None);
            if (e.ColumnIndex == 2)
            {
                //MessageBox.Show("Seleccionaste a: " + lines[0]+ " y es de tipo " + lines2[0]  ); //lines[0]=NombrePlaylist
                foreach (User u in Files.Users)
                {
                    if (u.UserName == NombreUsuarioTextBox.Text)
                    {
                        foreach (Playlists p in u.MyPlaylist1)
                        {
                            if (p.Name == lines[0] && lines2[0] == "Canción")
                            {
                                FillDataGridViewSongS(p.Playlistsong);
                                ShowSongsPanel.Visible = true;
                                ShowSongsPanel.BringToFront();
                                dataGridVerPlaylistUsuarioExterno.SendToBack();
                            }
                            else if (p.Name == lines[0] && lines2[0] == "Película")
                            {
                                FillDataGridViewMovieS(p.Playlistmovie);
                                ShowMoviesPanel.Visible = true;
                                ShowMoviesPanel.BringToFront();
                                dataGridVerPlaylistUsuarioExterno.SendToBack();
                            }
                        }
                    }
                }
                Serializacion();
            }
            else if (e.ColumnIndex == 3)
            {
                VerMisPlaylits.Visible = false;
                ShowSong.Visible = false;
                ShowMovie.Visible = false;
                ShowUserPanel.Visible = false;
                ShowPersonPanel.Visible = false;
                ShowMoviesPanel.Visible = false;
                BuscadorPanel.Visible = false;
                ResultsBuscador.Visible = false;
                FollowersPanel.Visible = false;
                CrearPlaylist.Visible = false;
                ShowSongsPanel.Visible = false;
                pictureBox1.Visible = true;
                pictureBox1.BringToFront();
                dataGridVerPlaylistUsuarioExterno.SendToBack();
                Playlists p = null;
                foreach (User u in Files.Users)
                {
                    if (u.UserName == NombreUsuarioTextBox.Text)
                    {
                        foreach (Playlists playlist in u.MyPlaylist1)
                        {
                            if (playlist.Name == lines[0] && playlist.Type==lines2[0])
                            {
                                p = playlist;
                            }
                        }

                    }
                }
                Serializacion();
                ReproducirPlaylist(p);
            }
        }

        private void dataGriedBuscadorFollowers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string datosTO = dataGriedBuscadorFollowers.Rows[dataGriedBuscadorFollowers.CurrentRow.Index].Cells[0].Value.ToString();
            string datosTO2 = dataGriedBuscadorFollowers.Rows[dataGriedBuscadorFollowers.CurrentRow.Index].Cells[1].Value.ToString();
            string[] stringSeparators = new string[] { "\r\n" };
            string[] lines = datosTO.Split(stringSeparators, StringSplitOptions.None);
            string[] lines2 = datosTO2.Split(stringSeparators, StringSplitOptions.None);
            if (e.ColumnIndex == 2)
            {
                //MessageBox.Show(lines[0]);
                if (lines2[0] == "Usuario")
                {
                    //MessageBox.Show(lines[0]);
                    NombreUsuarioTextBox.Text = lines[0];
                    FilldataGridVerPlaylistUsuarioExterno(lines[0]);
                    dataGridVerPlaylistUsuarioExterno.BringToFront();
                    ShowUserPanel.Visible = true;
                    ShowUserPanel.BringToFront();
                    Serializacion();
                }
                else if (lines2[0] == "Persona")
                {
                    PersonInformation.Text = null;
                    foreach (Person p in Files.AllPersons)
                    {
                        if (p.Name == lines[0])
                        {
                            PersonInformation.Text += "Nombre: " + p.Name + "\r\nFecha Nacimiento: " + p.Birthday.ToString("dd / MM / yyyy");
                            if (p.Genre == 'M') { PersonInformation.Text += "\r\nGénero: Masculino"; }
                            else if (p.Genre == 'F') { PersonInformation.Text += "\r\nGénero: Femenino"; }
                            if (p.Tipo == "Artista") { PersonInformation.Text += "\r\nNúmero de Reproducciones: " + p.NumReproduction.ToString(); }
                            linklabelPerson.Text = p.Link;
                        }
                    }
                    dataGriedPanelPersona.BringToFront();
                    FilldataGriedPanelPersona(lines[0]);
                    ShowPersonPanel.Visible = true;
                    ShowPersonPanel.BringToFront();
                    Serializacion();
                }
            }
        }

        private void FilldataGriedBuscadorFollowers(List<Person> persons, List<User> users)
        {
            dataGriedBuscadorFollowers.Rows.Clear();
            dataGriedBuscadorFollowers.Columns.Clear();
            DataGridViewTextBoxColumn nombre = new DataGridViewTextBoxColumn();
            nombre.HeaderText = "Nombre";
            DataGridViewTextBoxColumn tipo = new DataGridViewTextBoxColumn();
            nombre.HeaderText = "Tipo";
            DataGridViewButtonColumn buttons = new DataGridViewButtonColumn();
            buttons.HeaderText = @"";
            buttons.Text = "Seleccionar";
            buttons.UseColumnTextForButtonValue = true;
            buttons.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            buttons.FlatStyle = FlatStyle.Standard;
            buttons.CellTemplate.Style.BackColor = Color.Black;
            buttons.CellTemplate.Style.ForeColor = Color.White;


            dataGriedBuscadorFollowers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGriedBuscadorFollowers.RowTemplate.Height = 100;
            dataGriedBuscadorFollowers.AllowUserToAddRows = false;

            dataGriedBuscadorFollowers.Columns.Add(nombre);
            dataGriedBuscadorFollowers.Columns.Add(tipo);
            dataGriedBuscadorFollowers.Columns.Add(buttons);

            if (persons != null)
            {
                foreach (Person p in persons)
                {
                    dataGriedBuscadorFollowers.Rows.Add(new object[] { p.Name, "Persona" });
                }
            }
            if (users != null)
            {
                foreach (User u in users)
                {
                    if (u.UserName != "Admin" && u.Privacy1 == true)
                    {
                        dataGriedBuscadorFollowers.Rows.Add(new object[] { u.UserName, "Usuario" });
                    }
                }
            }
            panel3.Controls.Add(dataGriedBuscadorFollowers);
        }

        private void FilldataGriedPanelPersona(string name)
        {
            dataGriedPanelPersona.Rows.Clear();
            dataGriedPanelPersona.Columns.Clear();
            List<Songs> songs = new List<Songs>(); 
            List<Movies> movies = new List<Movies>();
            foreach (Movies m in Files.AllMovies)
            {
                foreach (Person p in m.Actors1)
                {
                    if (p.Name == name)
                    {
                        movies.Add(m);
                    }
                }
                if (name== m.Writer1.Name)
                {
                    movies.Add(m);
                }
                if (name== m.Director1.Name)
                {
                    movies.Add(m);
                }
            }
            List<Movies> Final = ((from s in movies select s).Distinct()).ToList();
            movies = Final;
            foreach (Songs s in Files.AllSongs)
            {
                if (name== s.Composer1.Name)
                {
                    songs.Add(s);
                }
                if (name== s.Artist1.Name)
                {
                    songs.Add(s);
                }
                if (name== s.Writer1.Name)
                {
                    songs.Add(s);
                }
            }
            List<Songs> Final2 = ((from s in songs select s).Distinct()).ToList();
            songs = Final2;
            DataGridViewImageColumn dgvImagen = new DataGridViewImageColumn();
            dgvImagen.HeaderText = "Película/Canción";
            dgvImagen.ImageLayout = DataGridViewImageCellLayout.Stretch;
            DataGridViewTextBoxColumn nombre = new DataGridViewTextBoxColumn();
            nombre.HeaderText = "Información";
            DataGridViewButtonColumn buttons = new DataGridViewButtonColumn();
            buttons.HeaderText = @"";
            buttons.Text = "Seleccionar";
            buttons.UseColumnTextForButtonValue = true;
            buttons.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            buttons.FlatStyle = FlatStyle.Standard;
            buttons.CellTemplate.Style.BackColor = Color.Black;
            buttons.CellTemplate.Style.ForeColor = Color.White;

            dataGriedPanelPersona.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGriedPanelPersona.RowTemplate.Height = 100;
            dataGriedPanelPersona.AllowUserToAddRows = false;

            dataGriedPanelPersona.Columns.Add(dgvImagen);
            dataGriedPanelPersona.Columns.Add(nombre);
            dataGriedPanelPersona.Columns.Add(buttons);


            dataGriedPanelPersona.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGriedPanelPersona.Columns[0].Width = 100;
            dataGriedPanelPersona.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            foreach (Movies movie in movies)
            {
                var carpeta = Directory.GetCurrentDirectory();
                var H = carpeta + movie.MovieDirection;
                dataGriedPanelPersona.Rows.Add(new object[] { System.Drawing.Image.FromFile(H), "Título: " + movie.Title1 + "\r\nDirector: " + movie.Director1.Name + "\r\nDuración: " + movie.Lenght1.ToString() + " min. \r\nRating: " + movie.RatingProm1.ToString() });
            }
            foreach (Songs song in songs)
            {
                var carpeta = Directory.GetCurrentDirectory();
                var D = carpeta + song.Album1.Image1;
                dataGriedPanelPersona.Rows.Add(new object[] { System.Drawing.Image.FromFile(D), "Título: " + song.Title1 + "\r\nCantante: " + song.Artist1.Name + "\r\nDuración: " + song.Lenght1.ToString() + " min. \r\nRating: " + song.RatingProm1.ToString() });
            }
            panel4.Controls.Add(dataGriedPanelPersona);
        }

        private void DescargarButtonShowSong_Click(object sender, EventArgs e)
        {
            string titulo = null;
            titulo = InfoSongsTextBox.Lines[0];
            string Titulo = titulo.Replace("Título: ", string.Empty);
            SacarRuta(Titulo);
            ChooseFolder();
        }

        private void CambiarImagenShowSong_Click(object sender, EventArgs e)
        {
            Songs s = null;
            string titulo = InfoSongsTextBox.Lines[0];
            string Titulo = titulo.Replace("Título: ", string.Empty);
            string salida = "";
            foreach (Songs song in Files.AllSongs)
            {
                if (song.Title1 == Titulo)
                {
                    s = song;
                }
            }
            if (openFileDialogCambiarImagen.ShowDialog() == DialogResult.OK)
            {
                salida = openFileDialogCambiarImagen.FileName;
            }
            string carpeta = Directory.GetCurrentDirectory();
            string filePath = carpeta + s.Album1.Image1;
            string newName = @"\" + DateTime.Now.ToString();
            newName = newName.Replace("-", "");
            newName = newName.Replace(" ", "");
            newName = newName.Replace(":", "");
            try
            {
                File.Copy(salida, carpeta + newName, true);
                s.Album1.Image1 = newName;
                RellenarInfoMovies(Titulo);
            }
            catch
            {
                MessageBox.Show("No se pudo cambiar la imagen");
            }
            finally
            {
                RellenarInfoSongs(Titulo);
            }
            Serializacion();
        }

        private void CalificarButtonShowSong_Click(object sender, EventArgs e)
        {
            string titulo = null;
            titulo = InfoSongsTextBox.Lines[0];
            string Titulo = titulo.Replace("Título: ", string.Empty);
            double cal = Convert.ToDouble(calificacionsong.Value);
            foreach(Songs song in Files.AllSongs)
            {
                if (song.Title1 == Titulo)
                {
                    song.Rating1.Add(cal);
                    song.RatingProm1 = song.Rating1.Average();
                    MessageBox.Show("Se ha calificado correctamente la canción");
                }
            }
            RellenarInfoSongs(Titulo);
            calificacionsong.Value = 0;
            Serializacion();
        }

        private void MeGustaButtonShowSong_Click(object sender, EventArgs e)
        {
            User user = GetUser();
            string titulo = null;
            titulo = InfoSongsTextBox.Lines[0];
            string Titulo = titulo.Replace("Título: ", string.Empty);
            int contador = 0;
            foreach (Playlists pla in user.MyPlaylist1)
            {
                if (pla.Type == "Canción" && pla.Name=="Me gusta")
                {
                    foreach (Songs s in pla.Playlistsong)
                    {
                        if (s.Title1 == Titulo)
                        {
                            contador += 1;
                        }
                    }
                }
            }
            foreach (Songs song in Files.AllSongs)
            {
                if (song.Title1 == Titulo)
                {
                    foreach (Playlists p in user.MyPlaylist1)
                    {
                        if (p.Name=="Me gusta" && p.Type == "Canción" && contador==0)
                        {
                            p.Playlistsong.Add(song);
                            MessageBox.Show("La canción se ha agregado correctamente a sus me gusta");
                            return;
                        }
                    }
                }
            }
            MessageBox.Show("La canción ya se encuentra en sus Me gusta");
            Serializacion();
        }

        private void CalificarShowMovie_Click(object sender, EventArgs e)
        {
            double cal = Convert.ToDouble(CalificationMovie.Value);
            string titulo = null;
            titulo = InfoMovieTextBox.Lines[0];
            string Titulo = titulo.Replace("Título: ", string.Empty);
            foreach (Movies movie in Files.AllMovies)
            {
                if (movie.Title1 == Titulo)
                {
                    movie.Rating1.Add(cal);
                    movie.RatingProm1 = movie.Rating1.Average();
                    MessageBox.Show("Su película se ha calificado correctamente");
                    CalificationMovie.Value = 0;
                }
            }
            RellenarInfoMovies(Titulo);
            Serializacion();
        }

        private void MeGustaShowMovie_Click(object sender, EventArgs e)
        {
            User user = GetUser();
            string titulo = null;
            titulo = InfoMovieTextBox.Lines[0];
            string Titulo = titulo.Replace("Título: ", string.Empty);
            int contador = 0;
            foreach (Playlists pla in user.MyPlaylist1)
            {
                if (pla.Type == "Película" && pla.Name == "Me gusta")
                {
                    foreach (Movies m in pla.Playlistmovie)
                    {
                        if (m.Title1 == Titulo)
                        {
                            contador += 1;
                        }
                    }
                }
            }
            foreach (Movies movie in Files.AllMovies)
            {
                if (movie.Title1 == Titulo)
                {
                    foreach (Playlists p in user.MyPlaylist1)
                    {
                        if (p.Name == "Me gusta" && p.Type == "Película" && contador == 0)
                        {
                            p.Playlistmovie.Add(movie);
                            MessageBox.Show("La canción se ha agregado correctamente a sus me gusta");
                            return;
                        }
                    }
                }
            }
            MessageBox.Show("La película ya se encuentra en sus Me gusta");
            Serializacion();
        }

        private void AddPlaylistShowSong_Click(object sender, EventArgs e)
        {
            VerMisPlaylits.Visible = true;
            VerMisPlaylits.BringToFront();
            FillDataGridAgregarPlaylist();
            dataGridAgregarAPlaylist.Visible = true;
            dataGridAgregarAPlaylist.BringToFront();
            Serializacion();
        }

        private void AddPlaylistShowMovie_Click(object sender, EventArgs e)
        {
            VerMisPlaylits.Visible = true;
            VerMisPlaylits.BringToFront();
            FillDataGridAgregarPlaylist();
            dataGridAgregarAPlaylist.Visible = true;
            dataGridAgregarAPlaylist.BringToFront();
            Serializacion();
        }

        private void GoAddMoviePanel_Click(object sender, EventArgs e)
        {
            AddMoviePanel.BringToFront();
            Serializacion();
        }

        private void GoAddSongPanel_Click(object sender, EventArgs e)
        {
            AddSongPanel.BringToFront();
            Serializacion();
        }

        private void CambiarImagenShowMovie_Click(object sender, EventArgs e)
        {
            Movies m = null;
            string titulo = InfoMovieTextBox.Lines[0];
            string Titulo = titulo.Replace("Título: ", string.Empty);
            string salida = "";
            foreach (Movies movie in Files.AllMovies)
            {
                if (movie.Title1 == Titulo)
                {
                    m = movie;
                }
            }
            if (openFileDialogCambiarImagen.ShowDialog() == DialogResult.OK)
            {
                salida = openFileDialogCambiarImagen.FileName;
            }
            string carpeta = Directory.GetCurrentDirectory();
            string filePath = carpeta + m.MovieDirection;
            string newName = @"\"+DateTime.Now.ToString();
            newName = newName.Replace("-", "");
            newName = newName.Replace(" ", "");
            newName = newName.Replace(":", "");
            try
            {
                File.Copy(salida, carpeta + newName, true);
                m.MovieDirection = newName;
            RellenarInfoMovies(Titulo);
            }
            catch
            {
                MessageBox.Show("No se pudo cambiar la imagen");
            }
            finally
            {
                RellenarInfoMovies(Titulo);
            }
            Serializacion();
        }

        private void dataGriedPanelPersona_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string datosTO = dataGriedPanelPersona.Rows[dataGriedPanelPersona.CurrentRow.Index].Cells[1].Value.ToString();
            string datosT = datosTO.Replace("Título: ", string.Empty);
            string[] stringSeparators = new string[] { "\r\n" };
            string[] lines = datosT.Split(stringSeparators, StringSplitOptions.None);
            if (e.ColumnIndex == 2)
            {
                //MessageBox.Show("Seleccionaste: "+ lines[0]);
                foreach (Movies m in Files.AllMovies)
                {
                    if (m.Title1 == lines[0])
                    {
                        InfoMovieTextBox.Text = null;
                        RellenarInfoMovies(lines[0]);
                        ShowMovie.Visible = true;
                        ShowMovie.BringToFront();
                    }
                }
                foreach (Songs s in Files.AllSongs)
                {
                    if (s.Title1 == lines[0])
                    {
                        InfoSongsTextBox.Text = null;
                        RellenarInfoSongs(lines[0]);
                        ShowSong.Visible = true;
                        ShowSong.BringToFront();
                    }
                }
                Serializacion();
            }
        }

        public void Copy()
        {
            string destFileName = (this.name) + " (Spotflix)" + ".mp3";
            var destFile = System.IO.Path.Combine(dest, destFileName);
            System.IO.File.Copy(ruta, destFile, true);
        }

        public void AgregarCancion()
        {
            string carpeta = Directory.GetCurrentDirectory();
            char sexo_compositor;
            if (comboBoxSexoC.SelectedIndex == 1)
            {
                sexo_compositor = 'F';
            }
            else
            {
                sexo_compositor = 'M';
            }
            Person compositor = new Person(textBoxNameC.Text, dateTimePickerC.Value, sexo_compositor, textBoxLinkC.Text);
            char sexo_escritor;
            if (comboBoxSexoE.SelectedIndex == 1)
            {
                sexo_escritor = 'F';
            }
            else
            {
                sexo_escritor = 'M';
            }
            Person escritor = new Person(textBoxNameE.Text, dateTimePickerEC.Value, sexo_escritor, textBoxLinkE.Text);
            char sexo_artista;
            if (comboBoxSexoA.SelectedIndex == 1)
            {
                sexo_artista = 'F';
            }
            else
            {
                sexo_artista = 'G';
            }
            Artist artista = new Artist(textBoxNameA.Text, dateTimePickerA.Value, sexo_artista, textBoxLinkA.Text);
            Album album = new Album(textBoxTituloA.Text, new DateTime(Decimal.ToInt32(numericUpDownAnoAlbum.Value), 1, 1), artista, imagen);
            string titulo = textBoxTitulo.Text;
            List<string> generos = new List<string>();
            string genero1 = textBoxGenero1.Text;
            string genero2 = textBoxGenero2.Text;
            generos.Add(genero1);
            generos.Add(genero2);
            string letra = "";
            string resolucion = textBoxResolucionC.Text;
            string memoria = textBoxMemoriaC.Text;
            string tipo = ".mp3";
            string nombre;
            string musica = "";
            if (openFileDialogCancion.ShowDialog() == DialogResult.OK)
            {
                string destFileName = titulo + tipo;
                nombre = destFileName;
                var destFile = System.IO.Path.Combine(carpeta, destFileName);
                string salida = openFileDialogCancion.FileName;
                System.IO.File.Copy(salida, destFile, true);
                musica = @"\" + nombre;
            }
            int reproducciones = 0;
            int min = 0;
            int largo = 0;
            try
            {
                largo = Int32.Parse(textBoxLargo.Text);
            }
            catch { }
            double ratingprom = 0;
            List<double> rating = new List<double>();
            Songs cancion = new Songs(titulo, compositor, artista, escritor, largo, generos, letra, resolucion, memoria, reproducciones, rating, ratingprom, musica, tipo, min, album);
            Files.AllSongs.Add(cancion);
            MessageBox.Show("La canción se ha agregado correctamente");
            foreach (SmartPlaylist playlist in Files.AllPlaylistsSongs)
            {
                if (playlist.NameCriterio.ToUpper().Contains(genero1.ToUpper()) || playlist.NameCriterio.ToUpper().Contains(genero2.ToUpper()))
                {
                    playlist.Playlistsong.Add(cancion);
                }
                else if (playlist.NameCriterio.ToUpper().Contains(artista.Name.ToUpper()))
                {
                    playlist.Playlistsong.Add(cancion);
                }
            }
            Serializacion();
        }

        private void buttonVolverAgregarPelicula_Click(object sender, EventArgs e)
        {
            AddMoviePanel.SendToBack();
            Serializacion();
        }

        private void buttonAgregarPelicula_Click(object sender, EventArgs e)
        {
            AgregarPelicula();
            Serializacion();
        }

        private void buttonVolverAgregarCanciones_Click(object sender, EventArgs e)
        {
            AddSongPanel.SendToBack();
            Serializacion();
        }

        private void buttonAgregarCancion_Click(object sender, EventArgs e)
        {
            AgregarCancion();
            Serializacion();
        }

        private void buttonImagenC_Click(object sender, EventArgs e)
        {
            AgregarImagenCancion();
            Serializacion();
        }

        private void buttonImagenP_Click(object sender, EventArgs e)
        {
            AgregarImagenPelicula();
            Serializacion();
        }

        private void ModificarPlaylistButton_Click(object sender, EventArgs e)
        {

        }

        private void AgregarElemntoPlaylist_Click(object sender, EventArgs e)
        {
            User user = GetUser();
            string name = dataGridVerPlaylist.Rows[dataGridVerPlaylist.CurrentRow.Index].Cells[0].Value.ToString();
            string type = dataGridVerPlaylist.Rows[dataGridVerPlaylist.CurrentRow.Index].Cells[1].Value.ToString();
            if(type == "Canción")
            {
                InfoMovieTextBox.Text = "";
                InfoSongsTextBox.Text = "";
                ShowSongsPanel.Visible = true;
                ShowSongsPanel.BringToFront();
                FillDataGridViewSongS(Files.AllSongs);
            }
            else if(type == "Película")
            {
                InfoMovieTextBox.Text = "";
                InfoSongsTextBox.Text = "";
                ShowMoviesPanel.Visible = true;
                ShowMoviesPanel.BringToFront();
                FillDataGridViewMovieS(Files.AllMovies);
            }
            Serializacion();
        }

        private void FillDataGridEliminarS(List<Songs> songs)
        {
            dataGridEliminar.Rows.Clear();
            dataGridEliminar.Columns.Clear();
            DataGridViewImageColumn dgvImagen = new DataGridViewImageColumn();
            dgvImagen.HeaderText = "Canción";
            dgvImagen.ImageLayout = DataGridViewImageCellLayout.Stretch;
            DataGridViewTextBoxColumn nombre = new DataGridViewTextBoxColumn();
            nombre.HeaderText = "Información";
            DataGridViewButtonColumn buttons = new DataGridViewButtonColumn();
            buttons.Text = "Seleccionar";
            buttons.UseColumnTextForButtonValue = true;
            buttons.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            buttons.FlatStyle = FlatStyle.Standard;
            buttons.CellTemplate.Style.BackColor = Color.Black;
            buttons.CellTemplate.Style.ForeColor = Color.White;


            dataGridEliminar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridEliminar.RowTemplate.Height = 200;
            dataGridEliminar.AllowUserToAddRows = false;

            dataGridEliminar.Columns.Add(dgvImagen);
            dataGridEliminar.Columns.Add(nombre);
            dataGridEliminar.Columns.Add(buttons);

            dataGridEliminar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridEliminar.Columns[0].Width = 200;
            dataGridEliminar.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            foreach (Songs song in songs)
            {
                var carpeta = Directory.GetCurrentDirectory();
                var D = carpeta + song.Album1.Image1;
                dataGridEliminar.Rows.Add(new object[] { System.Drawing.Image.FromFile(D), "Título: " + song.Title1 + "\r\nCantante: " + song.Artist1.Name + "\r\nDuración: " + song.Lenght1.ToString() + " min. \r\nRating: " + song.RatingProm1.ToString() });
            }
            VerMisPlaylits.Controls.Add(dataGridEliminar);
        }

        private void FillDataGridEliminarM(List<Movies> movies)
        {
            dataGridEliminar.Rows.Clear();
            dataGridEliminar.Columns.Clear();
            DataGridViewImageColumn dgvImagen = new DataGridViewImageColumn();
            dgvImagen.HeaderText = "Película";
            dgvImagen.ImageLayout = DataGridViewImageCellLayout.Stretch;
            DataGridViewTextBoxColumn nombre = new DataGridViewTextBoxColumn();
            nombre.HeaderText = "Información";
            DataGridViewButtonColumn buttons = new DataGridViewButtonColumn();
            buttons.HeaderText = @"";
            buttons.Text = "Seleccionar";
            buttons.UseColumnTextForButtonValue = true;
            buttons.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            buttons.FlatStyle = FlatStyle.Standard;
            buttons.CellTemplate.Style.BackColor = Color.Black;
            buttons.CellTemplate.Style.ForeColor = Color.White;


            dataGridEliminar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridEliminar.RowTemplate.Height = 200;
            dataGridEliminar.AllowUserToAddRows = false;

            dataGridEliminar.Columns.Add(dgvImagen);
            dataGridEliminar.Columns.Add(nombre);
            dataGridEliminar.Columns.Add(buttons);


            dataGridEliminar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridEliminar.Columns[0].Width = 200;
            dataGridEliminar.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            foreach (Movies movie in movies)
            {
                var carpeta = Directory.GetCurrentDirectory();
                var H = carpeta + movie.MovieDirection;
                dataGridEliminar.Rows.Add(new object[] { System.Drawing.Image.FromFile(H), "Título: " + movie.Title1 + "\r\nDirector: " + movie.Director1.Name + "\r\nDuración: " + movie.Lenght1.ToString() + " min. \r\nRating: " + movie.RatingProm1.ToString() });
            }
            VerMisPlaylits.Controls.Add(dataGridEliminar);
        }

        private void EliminardePlaylist_Click(object sender, EventArgs e)
        {
            User user = GetUser();
            string name = dataGridVerPlaylist.Rows[dataGridVerPlaylist.CurrentRow.Index].Cells[0].Value.ToString();
            string type = dataGridVerPlaylist.Rows[dataGridVerPlaylist.CurrentRow.Index].Cells[1].Value.ToString();

            if (type == "Canción")
            {
                for (int i = 0; i < user.MyPlaylist1.Count(); i++)
                {
                    if(name == user.MyPlaylist1[i].Name)
                    {
                        FillDataGridEliminarS(user.MyPlaylist1[i].Playlistsong);
                    }
                    
                }
                    
            }
            if (type == "Película")
            {
                VerMisPlaylits.Visible = true;
                VerMisPlaylits.BringToFront();
                dataGridEliminar.Visible = true;
                dataGridEliminar.BringToFront();
                for (int i = 0; i < user.MyPlaylist1.Count(); i++)
                {
                    if (name == user.MyPlaylist1[i].Name)
                    {
                        FillDataGridEliminarM(user.MyPlaylist1[i].Playlistmovie);
                    }

                }
            }
            dataGridEliminar.Visible = true;
            dataGridEliminar.BringToFront();
            tableLayoutPanel89.SendToBack();
            Serializacion();
        }

        private void AddToFollowersButton_Click(object sender, EventArgs e)
        {
            User user = GetUser();
            string titulo = PersonInformation.Lines[0];
            string Titulo = titulo.Replace("Nombre: ", string.Empty);
            int contador = 0;
            foreach (Person person in user.FollowsP)
            {
                if (person.Name == Titulo)
                {
                    contador += 1;
                }
            }
            if (contador == 0)
            {
                foreach (Person p in Files.AllPersons)
                {
                    if (p.Name == Titulo)
                    {
                        user.FollowsP.Add(p);
                        MessageBox.Show("Se ha agregado correctamente a sus Seguidores");
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("La persona ya se encuentra en sus seguidores");
            }
            List<Person> Final = ((from s in user.FollowsP select s).Distinct()).ToList();
            user.FollowsP = Final;
            Serializacion();
        }

        private void FollowUserButton_Click(object sender, EventArgs e)
        {
            User user = GetUser();
            string Titulo = NombreUsuarioTextBox.Text;
            int contador = 0;
            foreach (User person in user.FollowsU)
            {
                if (person.UserName == Titulo)
                {
                    contador += 1;
                }
            }
            if (contador == 0)
            {
                foreach (User p in Files.Users)
                {
                    if (p.UserName == Titulo)
                    {
                        user.FollowsU.Add(p);
                        MessageBox.Show("Se ha agregado correctamente a sus Seguidores");
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("El Usuario ya se encuentra en sus seguidores");
            }
            List<User> Final = ((from s in user.FollowsU select s).Distinct()).ToList();
            user.FollowsU = Final;
            Serializacion();
        }

        public void AgregarPelicula()
        {
            string carpeta = Directory.GetCurrentDirectory();
            string movieDirection2 = imagen;
            string Title = textBoxTituloP.Text;
            char s_d;
            if (comboBoxSexoD.SelectedIndex == 1)
            {
                s_d = 'F';
            }
            else
            {
                s_d = 'M';
            }
            Person Director = new Person(textBoxNameD.Text, dateTimePickerD.Value, s_d, textBoxLinkD.Text);
            char a1;
            if (comboBoxSexoActor1.SelectedIndex == 1)
            {
                a1 = 'F';
            }
            else
            {
                a1 = 'M';
            }
            char a2;
            if (comboBoxSexoActor2.SelectedIndex == 1)
            {
                a2 = 'F';
            }
            else
            {
                a2 = 'M';
            }
            Person actor1 = new Person(textBoxNameActor1.Text, dateTimePickerActor1.Value, a1, textBoxLinkActor1.Text);
            Person actor2 = new Person(textBoxNameActor2.Text, dateTimePickerActor2.Value, a2, textBoxLinkActor2.Text); ;
            List<Person> Actors = new List<Person>();
            Actors.Add(actor1);
            Actors.Add(actor2);
            char w;
            if (comboBoxSexoEP.SelectedIndex == 1)
            {
                w = 'F';
            }
            else
            {
                w = 'M';
            }
            Person Writer = new Person(textBoxEscritoP.Text, dateTimePickerEP.Value, w, textBoxLinkEscritorP.Text);
            int Lenght = 0;
            try
            {
                Lenght = Int32.Parse(textBoxLargoP.Text);
            }
            catch { }
            List<string> Categories = new List<string>();
            string c1 = textBoxCategoria1.Text;
            string c2 = textBoxCategoria2.Text;
            Categories.Add(c1);
            Categories.Add(c2);
            string Studio = textBoxEstudio.Text;
            string Description = "";
            string Year = numericUpDownAnoP.Value.ToString();
            string Resolution = textBoxResolucionP.Text;
            string Memory = textBoxMemoriaP.Text;
            int numReproductions = 0;
            List<double> Rating = new List<double>();
            double RatingProm = 0;
            int Min = 0;
            string Trailer = "";
            string nombre;
            string Video = "";
            if (openFileDialogPelicula.ShowDialog() == DialogResult.OK)
            {
                string destFileName = Title + ".mp4";
                nombre = destFileName;
                var destFile = System.IO.Path.Combine(carpeta, destFileName);
                string salida = openFileDialogPelicula.FileName;
                System.IO.File.Copy(salida, destFile, true);
                Video = @"\" + nombre;
            }
            List<Songs> SongsMovie = new List<Songs>();
            Movies pelicula = new Movies(Title, Director, Actors, Writer, Lenght, Categories, Studio, Description, Year, Resolution, Memory, numReproductions, Rating, RatingProm, Trailer, Video, SongsMovie, Min, movieDirection2);
            Files.AllMovies.Add(pelicula);
            MessageBox.Show("Se ha agregado correctamente");
            foreach (SmartPlaylist playlist in Files.AllPlaylistsMovies)
            {
                if (playlist.NameCriterio.ToUpper().Contains(Studio.ToUpper()))
                {
                    playlist.Playlistmovie.Add(pelicula);
                }
                else if (playlist.NameCriterio.ToUpper().Contains(Director.Name.ToUpper()))
                {
                    playlist.Playlistmovie.Add(pelicula);
                }
                else if (playlist.NameCriterio.ToUpper().Contains(actor1.Name.ToUpper()) || playlist.NameCriterio.ToUpper().Contains(actor2.Name.ToUpper()))
                {
                    playlist.Playlistmovie.Add(pelicula);
                }
                else if (playlist.NameCriterio.ToUpper().Contains(c1.ToUpper()) || playlist.NameCriterio.ToUpper().Contains(c2.ToUpper()))
                {
                    playlist.Playlistmovie.Add(pelicula);
                }
            }
            Serializacion();
        }

        public void AgregarImagenCancion()
        {
            string carpeta = Directory.GetCurrentDirectory();
            if (openFileDialogImagenAlbum.ShowDialog() == DialogResult.OK)
            {
                string destFileName = textBoxTituloA.Text + ".jpg";
                var destFile = System.IO.Path.Combine(carpeta, destFileName);
                string salida = openFileDialogImagenAlbum.FileName;
                System.IO.File.Copy(salida, destFile, true);
                imagen = @"\" + destFileName;
            }
            Serializacion();
        }

        public void AgregarImagenPelicula()
        {
            string carpeta = Directory.GetCurrentDirectory();
            if (openFileDialogImagenPelicula.ShowDialog() == DialogResult.OK)
            {
                string destFileName = textBoxTituloP.Text + ".jpg";
                var destFile = System.IO.Path.Combine(carpeta, destFileName);
                string salida = openFileDialogImagenPelicula.FileName;
                System.IO.File.Copy(salida, destFile, true);
                imagen = @"\" + destFileName;
            }
            Serializacion();
        }

        public void QueueSongs(string titulo)
        {
            WMPLib.IWMPMedia media;
            foreach (Songs s in Files.AllSongs)
            {
                if (s.Title1 == titulo)
                {
                    queuesongs.Enqueue(s);
                    SacarRuta(s.Title1);
                    media = axWindowsMediaPlayer1.newMedia(this.ruta);
                    Qcanciones.appendItem(media);
                }
            }

            Serializacion();
        }

        public void QueueMovies(string titulo)
        {
            WMPLib.IWMPMedia media;
            foreach (Movies s in Files.AllMovies)
            {
                if (s.Title1 == titulo)
                {
                    queuemovies.Enqueue(s);
                    SacarRuta(s.Title1);
                    media = axWindowsMediaPlayer1.newMedia(this.ruta);
                    Qpeliculas.appendItem(media);
                }
            }
            Serializacion();
        }

        public void ReproducirPlaylist(Playlists plist)
        {
            WMPLib.IWMPPlaylist playlist = axWindowsMediaPlayer1.playlistCollection.newPlaylist(plist.Name);
            WMPLib.IWMPMedia media;
            if (plist.Playlistsong.Count != 0)
            {
                foreach (Songs s in plist.Playlistsong)
                {
                    SacarRuta(s.Title1);
                    media = axWindowsMediaPlayer1.newMedia(this.ruta);
                    playlist.appendItem(media);
                }
                axWindowsMediaPlayer1.currentPlaylist = playlist;
                try
                {
                    axWindowsMediaPlayer1.Ctlcontrols.playItem(axWindowsMediaPlayer1.currentPlaylist.Item[0]);
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                    NameSong.Text = axWindowsMediaPlayer1.currentMedia.name.ToString();
                    Serializacion();
                }
                catch
                {
                    MessageBox.Show("La playlist no se puede reproducir, puede ser que no tenga elementos dentro de ella");
                }
            }
            else if (plist.Playlistmovie.Count != 0)
            {
                foreach (Movies m in plist.Playlistmovie)
                {
                    SacarRuta(m.Title1);
                    media = axWindowsMediaPlayer1.newMedia(this.ruta);
                    playlist.appendItem(media);
                }
                axWindowsMediaPlayer1.currentPlaylist = playlist;
                try
                {
                    axWindowsMediaPlayer1.Ctlcontrols.playItem(axWindowsMediaPlayer1.currentPlaylist.Item[0]);
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                    NameSong.Text = axWindowsMediaPlayer1.currentMedia.name.ToString();
                    Serializacion();
                }
                catch
                {
                    MessageBox.Show("La playlist no se puede reproducir, puede ser que no tenga elementos dentro de ella");
                }
            }
            else if (plist.Playlistmovie.Count == 0)
            {
                MessageBox.Show("La playlist no se puede reproducir, puede ser que no tenga elementos dentro de ella");
            }
            else if (plist.Playlistsong.Count == 0)
            {
                MessageBox.Show("La playlist no se puede reproducir, puede ser que no tenga elementos dentro de ella");
            }
        }

        private void backbutton_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.previous();
            string s = axWindowsMediaPlayer1.URL;
            if (s != "")
            {
                NameSong.Text = axWindowsMediaPlayer1.currentMedia.name.ToString();
            }
            Serializacion();
        }

        private void playpausebutton_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
            }
            else
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
            Serializacion();
        }

        private void nextbutton_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.next();
            string s = axWindowsMediaPlayer1.URL;
            if (s != "")
            {
                NameSong.Text = axWindowsMediaPlayer1.currentMedia.name.ToString();
            }
            Serializacion();
        }

        private void dataGridAgregarAPlaylist_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            User user = GetUser();
            string playlist = dataGridAgregarAPlaylist.Rows[dataGridAgregarAPlaylist.CurrentRow.Index].Cells[0].Value.ToString();
            string type = dataGridAgregarAPlaylist.Rows[dataGridAgregarAPlaylist.CurrentRow.Index].Cells[1].Value.ToString();
            string cancion = InfoSongsTextBox.Text;
            string pelicula = InfoMovieTextBox.Text;
            string datosp = pelicula.Replace("Título: ", string.Empty);
            string datosc = cancion.Replace("Título: ", string.Empty);
            string[] stringSeparators = new string[] { "\r\n" };
            string[] linesp = datosp.Split(stringSeparators, StringSplitOptions.None); 
            string[] linesc = datosc.Split(stringSeparators, StringSplitOptions.None);
            int contador = 0;
            foreach (Playlists p in user.MyPlaylist1)
            {
                if (p.Name==playlist && p.Type == type)
                {
                    foreach (Songs s in p.Playlistsong)
                    {
                        if (s.Title1 == linesc[0])
                        {
                            contador += 1;
                        }
                    }
                }
            }
            int contador2 = 0;
            foreach (Playlists p in user.MyPlaylist1)
            {
                if (p.Name == playlist && p.Type == type)
                {
                    foreach (Movies m in p.Playlistmovie)
                    {
                        if (m.Title1 == linesp[0])
                        {
                            contador2 += 1;
                        }
                    }
                }
            }
            if (dataGridAgregarAPlaylist.CurrentCell.ColumnIndex == 2)
            {
                if (datosc.Contains("Artista") == true)
                {
                    if (type == "Canción")
                    {
                        foreach (Songs songs in Files.AllSongs)
                        {
                            if (songs.Title1 == linesc[0])
                            {
                                foreach (Playlists playlists in user.MyPlaylist1)
                                {
                                    if (playlists.Name == playlist && contador ==0 && playlists.Type=="Canción")
                                    {
                                        playlists.Playlistsong.Add(songs);
                                        MessageBox.Show("Canción agragada con éxito");
                                        return;
                                    }
                                }
                                if (type == "Canción")
                                {
                                    MessageBox.Show("La canción ya se encuentra en la Playlist");
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se puede agregar objetos de este tipo a esta Playlist");
                    }
                }
                else if (datosp.Contains("Director") == true)
                {
                    if (type == "Película")
                    {
                        foreach (Movies movies in Files.AllMovies)
                        {
                            if (movies.Title1 == linesp[0])
                            {
                                foreach (Playlists playlists in user.MyPlaylist1)
                                {
                                    if (playlists.Name == playlist && contador2==0 && playlists.Type=="Película")
                                    {
                                        playlists.Playlistmovie.Add(movies);
                                        MessageBox.Show("Película agragada con éxito");
                                        return;
                                    }
                                }
                                if (type == "Película")
                                {
                                    MessageBox.Show("La película ya se encuentra en la Playlist");
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se puede agregar objetos de este tipo a esta Playlist");
                    }
                }
                Serializacion();
            }
        }

        private void dataGridVerPlaylist_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            User user = GetUser();
            string name = dataGridVerPlaylist.Rows[dataGridVerPlaylist.CurrentRow.Index].Cells[0].Value.ToString();
            string type = dataGridVerPlaylist.Rows[dataGridVerPlaylist.CurrentRow.Index].Cells[1].Value.ToString();
            if (dataGridVerPlaylist.CurrentCell.ColumnIndex == 2)
            {
                for (int i = 0; i < user.MyPlaylist1.Count(); i++)
                {
                    if (name == user.MyPlaylist1[i].Name && type == "Canción" && user.MyPlaylist1[i].Type =="Canción")
                    {
                        ShowSongsPanel.Visible = true;
                        ShowSongsPanel.BringToFront();
                        FillDataGridViewSongS(user.MyPlaylist1[i].Playlistsong);
                        //MessageBox.Show(user.MyPlaylist1[i].Name + " " + user.MyPlaylist1[i].Type);
                    }
                    if (name == user.MyPlaylist1[i].Name && type == "Película" && user.MyPlaylist1[i].Type == "Película")
                    {
                        ShowMoviesPanel.Visible = true;
                        ShowMoviesPanel.BringToFront();
                        FillDataGridViewMovieS(user.MyPlaylist1[i].Playlistmovie);
                    }
                }
                Serializacion();
            }
            else if (dataGridVerPlaylist.CurrentCell.ColumnIndex == 3)
            {
                dataGridVerPlaylist.Visible = false;
                dataGridAgregarAPlaylist.Visible = false;
                dataGridEliminar.Visible = false;
                CambiarNombrePlaylist.Visible = true;
                EliminardePlaylist.Visible = true;
                CambiarNombrePlaylist.BringToFront();
                EliminardePlaylist.BringToFront();
                tableLayoutPanel89.BringToFront();
                Aceptarcambiodenombre.Visible = false;
                NuevoNombrePlaylist.Visible = false;
                label50.Visible = false;
                Serializacion();
            }
            else if (dataGridVerPlaylist.CurrentCell.ColumnIndex == 4)
            {
                VerMisPlaylits.Visible = false;
                ShowSong.Visible = false;
                ShowMovie.Visible = false;
                ShowUserPanel.Visible = false;
                ShowPersonPanel.Visible = false;
                ShowMoviesPanel.Visible = false;
                BuscadorPanel.Visible = false;
                ResultsBuscador.Visible = false;
                FollowersPanel.Visible = false;
                CrearPlaylist.Visible = false;
                ShowSongsPanel.Visible = false;
                pictureBox1.Visible = true;
                pictureBox1.BringToFront();
                Playlists p = null;
                foreach (Playlists playlist in user.MyPlaylist1)
                {
                    if (playlist.Name == name && playlist.Type == type)
                    {
                        p = playlist;
                    }
                }
                ReproducirPlaylist(p);
                Serializacion();
            }
            //dataGridVerPlaylist.Visible = false;
            Serializacion();
        }

        private void dataGridEliminar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridEliminar.Rows.Count != 0)
            {
                User user = GetUser();
                string nameP = dataGridVerPlaylist.Rows[dataGridVerPlaylist.CurrentRow.Index].Cells[0].Value.ToString();
                string typeP = dataGridVerPlaylist.Rows[dataGridVerPlaylist.CurrentRow.Index].Cells[1].Value.ToString();
                string infoCP = dataGridEliminar.Rows[dataGridEliminar.CurrentRow.Index].Cells[1].Value.ToString();
                string datosc = infoCP.Replace("Título: ", string.Empty);
                string[] stringSeparators = new string[] { "\r\n" };
                string[] linescp = datosc.Split(stringSeparators, StringSplitOptions.None);

                if (dataGridEliminar.CurrentCell.ColumnIndex == 2)
                {
                    if (typeP == "Canción")
                    {
                        for (int i = 0; i < user.MyPlaylist1.Count(); i++)
                        {
                            foreach (Songs songs in user.MyPlaylist1[i].Playlistsong)
                            {
                                if (songs.Title1 == linescp[0])
                                {
                                    user.MyPlaylist1[i].Playlistsong.Remove(songs);
                                    MessageBox.Show("Canción eliminada");
                                    break;
                                }
                            }
                        }
                    }
                    else if (typeP == "Película")
                    {
                        for (int i = 0; i < user.MyPlaylist1.Count(); i++)
                        {
                            foreach (Movies movies in user.MyPlaylist1[i].Playlistmovie)
                            {
                                if (movies.Title1 == linescp[0])
                                {
                                    user.MyPlaylist1[i].Playlistmovie.Remove(movies);
                                    MessageBox.Show("Película eliminada");
                                    break;
                                }
                            }
                        }
                    }
                    Serializacion();
                }
            }
        }

        private void AddToQueueMovies_Click(object sender, EventArgs e)
        {
            string titulo = InfoMovieTextBox.Lines[0];
            string Titulo = titulo.Replace("Título: ", string.Empty);
            QueueMovies(Titulo);
            MessageBox.Show("Se agregó al Queue");
        }

        private void AddToQueueSongs_Click(object sender, EventArgs e)
        {
            string titulo = InfoSongsTextBox.Lines[0];
            string Titulo = titulo.Replace("Título: ", string.Empty);
            QueueSongs(Titulo);
            MessageBox.Show("Se agregó al Queue");
        }

        private void StartQueueSongs_Click(object sender, EventArgs e)
        {
            ReproducirQueueSongs();
        }

        private void StartQueueMovies_Click(object sender, EventArgs e)
        {
            ReproducirQueueMovies();
        }

        private void GoToReproductionPanel_Click(object sender, EventArgs e)
        {
            stackPanels.Add(panels["ReproductionPanel"]);
            ShowLastPanel();
        }

        private void axWindowsMediaPlayer1_CurrentItemChange(object sender, AxWMPLib._WMPOCXEvents_CurrentItemChangeEvent e)
        {
            string name = axWindowsMediaPlayer1.currentMedia.name.ToString();
            string nameartist = "";
            foreach (Songs song in Files.AllSongs)
            {
                if ((name.ToUpper() == song.Title1.ToUpper()) || (name.ToUpper().Contains(song.Title1.ToUpper()) && name.ToUpper().Contains(song.Artist1.Name.ToUpper())) || (@"\"+name+".mp3" ==song.Music1))
                {
                    song.NumReproductions += 1;
                    song.Artist1.NumReproduction += 1;
                    nameartist = song.Artist1.Name;
                    foreach (Person person in Files.AllPersons)
                    {
                        if (nameartist == person.Name)
                        {
                            person.NumReproduction += 1;
                        }
                    }
                    RellenarInfoSongs(song.Title1);
                }
            }
            foreach (Movies movie in Files.AllMovies)
            {
                if ((name.ToUpper() == movie.Title1.ToUpper()) || (name.ToUpper().Contains(movie.Title1.ToUpper())) || (@"\" + name + ".mp3" == movie.Video1))
                {
                    movie.NumReproductions += 1;
                    RellenarInfoMovies(movie.Title1);
                }
            }
            NameSong.Text = axWindowsMediaPlayer1.currentMedia.name.ToString();
            Serializacion();
        }

        private void AbrirArchivo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "PDF files|*.pdf", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(ofd.FileName);
                        StringBuilder sb = new StringBuilder();
                        for (int i = 1; i <= reader.NumberOfPages; i++)
                        {
                            sb.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                        }
                        richTextBox1.Text = sb.ToString();
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void VolverfrominovationPanel_Click(object sender, EventArgs e)
        {
            stackPanels.Add(panels["UserPanel"]);
            ShowLastPanel();
        }

        private void Hablar_Click(object sender, EventArgs e)
        {
            if (speaking)
            {
                string voice = cbVoces.Text;
                string theText = richTextBox1.Text;
                double Volume = tbVolumen.Value;
                double Rate = tbRate.Value;

                if (theText == "")
                {
                    MessageBox.Show("Escriba algo, o abra un archivo");
                    return;
                }

                synthVoice = new SpeechSynthesizer();
                synthVoice.SetOutputToDefaultAudioDevice();
                synthVoice.SelectVoice(voice);

                synthVoice.Rate = (int)Rate;
                synthVoice.Volume = (int)Volume;

                synthVoice.SpeakAsync(theText);

                isStopped = false;
                speaking = false;
            }
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            if (synthVoice != null)
            {
                if (isStopped == false)
                {
                    try
                    {
                        if (synthVoice.State == SynthesizerState.Speaking)
                        {
                            synthVoice.Pause();
                        }
                        else if (synthVoice.State == SynthesizerState.Paused)
                        {
                            synthVoice.Resume();
                        }
                    }
                    catch { }
                }
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            if (synthVoice != null)
            {
                try
                {
                    synthVoice.Dispose();
                    isStopped = true;
                }
                catch { }
                finally
                {
                    speaking = true;
                }
            }
        }

        private void innovacion_Click(object sender, EventArgs e)
        {
            stackPanels.Add(panels["InovationPanel"]);
            ShowLastPanel();
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
            }
        }

        public void ReproducirQueueMovies()
        {
            axWindowsMediaPlayer1.currentPlaylist = Qpeliculas;
            try
            {
                axWindowsMediaPlayer1.Ctlcontrols.playItem(axWindowsMediaPlayer1.currentPlaylist.Item[0]);
                NameSong.Text = axWindowsMediaPlayer1.currentMedia.name.ToString();
            }
            catch { }
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        public void ReproducirQueueSongs()
        {
            axWindowsMediaPlayer1.currentPlaylist = Qcanciones;
            try
            {
                axWindowsMediaPlayer1.Ctlcontrols.playItem(axWindowsMediaPlayer1.currentPlaylist.Item[0]);
                NameSong.Text = axWindowsMediaPlayer1.currentMedia.name.ToString();
            }
            catch { }
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        public void Reproducir(string titulo)
        {
            SacarRuta(titulo);
            stackPanels.Add(panels["ReproductionPanel"]);
            ShowLastPanel();
            axWindowsMediaPlayer1.URL = this.ruta;
            axWindowsMediaPlayer1.Ctlcontrols.playItem(axWindowsMediaPlayer1.currentPlaylist.Item[0]);
            axWindowsMediaPlayer1.Ctlcontrols.play();
            //string nameartist ="";
            //if (NameSong.Text == axWindowsMediaPlayer1.currentMedia.name.ToString())
            //{
            //    string carpeta = Directory.GetCurrentDirectory();
            //    foreach (Movies j in Files.AllMovies)
            //    {
            //        if (titulo == j.Title1)
            //        {
            //            j.NumReproductions += 1;
            //            RellenarInfoMovies(j.Title1);
            //        }
            //    }
            //    foreach (Songs j in Files.AllSongs)
            //    {
            //        if (titulo == j.Title1)
            //        {
            //            j.NumReproductions += 1;
            //            j.Artist1.NumReproduction += 1;
            //            nameartist = j.Artist1.Name;
            //            foreach (Person person in Files.AllPersons)
            //            {
            //                if (nameartist == person.Name)
            //                {
            //                    person.NumReproduction += 1;
            //                }
            //            }
            //            RellenarInfoSongs(j.Title1);
            //        }
            //    }
            //}
            Serializacion();
        }
    }
}
