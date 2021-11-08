using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notro_Player
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
            axWindowsMediaPlayer1.AllowDrop = true;
            ////axWindowsMediaPlayer1.DragEnter += new DragEventHandler(Form1_DragEnter);
            ////axWindowsMediaPlayer1.DragDrop += new DragEventHandler(Form1_DragDrop);
        }

        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            file = (string[])e.Data.GetData(DataFormats.FileDrop);
            path = (string[])e.Data.GetData(DataFormats.FileDrop);
            play();
        }
        string[] path, file;
        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1;
            openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                file = openFileDialog1.SafeFileNames;
                path = openFileDialog1.FileNames;
                play();
            }

        }

        private void play()
        {
            try
            {
                axWindowsMediaPlayer1.URL = path[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
