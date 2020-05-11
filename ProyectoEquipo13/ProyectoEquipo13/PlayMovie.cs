using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ProyectoEquipo13
{
    public partial class PlayMovie : Form
    {
        public string generic;

        public string ruta;

        public PlayMovie()
        {
            InitializeComponent();
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
        }
        public string Combine(string uri1, string uri2)
        {
            uri2 = uri2.TrimStart('/');
            return string.Format("{0}{1}", uri1, uri2);
        }

        public string SearchForFile(string searchPath, Func<string, bool> searchPredicate)
        {
            try
            {
                foreach (string fileName in Directory.EnumerateFiles(searchPath))
                {
                    if (searchPredicate(fileName))
                    {
                        return fileName;
                    }
                }

                foreach (string dirName in Directory.EnumerateDirectories(searchPath))
                {
                    var childResult = SearchForFile(dirName, searchPredicate);
                    if (childResult != null)
                    {
                        return childResult;
                    }
                }
                return null;
            }
            catch (UnauthorizedAccessException)
            {
                return null;
            }
        }
        public void Generico()
        {
            string filePath = SearchForFile(@"C:\", x => Path.GetFileName(x) == "git.txt");
            string j = filePath.TrimEnd('/');
            j = j.TrimEnd('t');
            j = j.TrimEnd('x');
            j = j.TrimEnd('t');
            j = j.TrimEnd('.');
            j = j.TrimEnd('t');
            j = j.TrimEnd('i');
            j = j.TrimEnd('g');
            j = j.TrimEnd('/');
            generic = j;
        }
        public void URL(string t)
        {
            string r = this.Combine(this.generic, t);
            this.ruta = r;
        }

        private void Upload_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.ruta;
        }

        private void Play_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = textBox1.Text;
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }
    }
}
