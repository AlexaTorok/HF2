﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Primszamosdi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap buffer;
        Graphics bufferg;
        Thread t;

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;

            t = new Thread(new ThreadStart(szal));
            t.Start();
        }
        void szal()
        {
            int h, w;

            lock (buffer)
            {
                h = buffer.Height;
                w = buffer.Width;
            }
            bufferg.Clear(Color.White);

            Console.WriteLine(buffer.Height + "," + buffer.Width);
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    if (PrimeSearcher.PrimeSearching(2 + x * y) == true)
                    {
                        lock (buffer)
                            buffer.SetPixel(x, y, Color.Black);
                    }
                }
            }
            

            this.Invoke(new Action(() => { button1.Enabled = true; }));
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            Form2 f2 = new Form2(String.Format("Szám={0}", e.X, e.Y));
            f2.ShowDialog(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buffer = new Bitmap(panel2.Width, panel2.Height);
            lock (buffer)
                bufferg = Graphics.FromImage(buffer);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (buffer == null)
                return;

            using (Graphics g = panel2.CreateGraphics())
            {
                lock (buffer)
                    g.DrawImage(buffer, 0, 0);
            }
        }
    }
}
