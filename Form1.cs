using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPDraw1
{
    public partial class Form1 : Form
    {
        protected Mode Mode;
        protected List<ShapePoint> shapes;
        protected int MouseX;
        protected int MouseY;
        public void AddShape(ShapePoint shape)
        {
            shapes.Add(shape);
            listBox1.Items.Add(shape);
            pictureBox1.Refresh();
        }
        public void DeleteShape(int number)
        {
            shapes.RemoveAt(listBox1.SelectedIndex);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            pictureBox1.Refresh();
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog()==DialogResult.OK)
            {
                button5.BackColor = colorDialog1.Color;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button5.BackColor = Color.Black;
            shapes = new List<ShapePoint>();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (listBox1.GetSelected(i))
                {
                    DeleteShape(i);
                    i--;
                }
            }
            if (listBox1.Items.Count > 0)
                listBox1.SetSelected(0, true);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Mode = Mode.DrawCircle;
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void PictureBox1_Move(object sender, EventArgs e)
        {

        }
        private void Button2_Click(object sender, EventArgs e)
        {
            Mode = Mode.DrawLine;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Mode = Mode.DrawPoint;
        }

        
        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            switch (Mode)
            {
                case Mode.DrawPoint:
                    ShapePoint dot = new DrawPoint(Color.FromArgb(button5.BackColor.R, button5.BackColor.G, button5.BackColor.B), e.X, e.Y);
                    dot.Draw(g);
                    AddShape(dot);
                    break;
                case Mode.DrawLine:
                    MouseX = e.X;
                    MouseY = e.Y;
                    break;
                case Mode.DrawCircle:
                    MouseX = e.X;
                    MouseY = e.Y;
                    break;
            }
        }
        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            switch (Mode)
            {
                case Mode.DrawLine:
                    if (e.Button == MouseButtons.Left)
                    {
                        pictureBox1.Refresh();
                        ShapePoint shape = new DrawLine(Color.FromArgb(button5.BackColor.R, button5.BackColor.G, button5.BackColor.B), MouseX, MouseY, e.X, e.Y);
                        shape.Draw(g);
                    }
                    break;
                case Mode.DrawCircle:
                    if (e.Button == MouseButtons.Left)
                    {
                        pictureBox1.Refresh();
                        ShapePoint shape = new DrawCircle(Color.FromArgb(button5.BackColor.R, button5.BackColor.G, button5.BackColor.B), MouseX, MouseY, (e.X - MouseX));
                        shape.Draw(g);
                    }
                    break;
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            switch (Mode)
            {
                case Mode.DrawLine:
                    ShapePoint line = new DrawLine(Color.FromArgb(button5.BackColor.R, button5.BackColor.G, button5.BackColor.B), MouseX, MouseY, e.X, e.Y);
                    AddShape(line);
                    break;
                case Mode.DrawCircle:
                    ShapePoint circle = new DrawCircle(Color.FromArgb(button5.BackColor.R, button5.BackColor.G, button5.BackColor.B), MouseX, MouseY, (e.X - MouseX));
                    AddShape(circle);
                    break;
            }
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < shapes.Count; i++)
            {
                shapes[i].Draw(e.Graphics);
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            AddShape(new DrawPoint(Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256)), random.Next(0, pictureBox1.Width), random.Next(0, pictureBox1.Height)));
        }
    }
}
