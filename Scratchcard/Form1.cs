using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scratchcard
{
    public partial class Form1 : Form
    {
        private Bitmap cover;
        private bool scratching = false;
        private string cover_url = "";
        private string back_url = "";
        private float penWidth = 30.0F;

        public Form1()
        {
            InitializeComponent();

            cover_url = @"images\cover.jpg";
            back_url = @"images\back.jpg";

            cover = new Bitmap(cover_url);
            pictureBox1.Image = cover;
            pictureBox1.BackgroundImage = Image.FromFile(back_url);
            pictureBox1.Size = new Size(cover.Width, cover.Height);

            pictureBox1.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);
            pictureBox1.MouseUp += new MouseEventHandler(pictureBox1_MouseUp);
            pictureBox1.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            scratching = true;
            go_paint(e);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            scratching = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (scratching)
            {
                go_paint(e);
            }
        }

        private void go_paint(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                using (Graphics g = Graphics.FromImage(cover))
                {
                    g.FillPie(Brushes.Magenta, e.Location.X - penWidth, e.Location.Y - penWidth, 2 * penWidth, 2 * penWidth, 0, 360);
                }
                cover.MakeTransparent(Color.Magenta);
            }
            else if (e.Button == MouseButtons.Right)
            {
                cover = new Bitmap(cover_url);
            }
            pictureBox1.Image = cover;
            pictureBox1.Refresh();
        }

    }
}
