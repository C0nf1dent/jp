using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jp
{
	public partial class Form1 : Form
	{
		private Random rnd = new Random();
		private int desktopWidth = SystemInformation.VirtualScreen.Width;
		private int desktopHeight = SystemInformation.VirtualScreen.Height;
		public Form1()
		{
			InitializeComponent();
			desktopWidth -= this.Width;
			desktopHeight -= this.Height;
		}
		private bool mouseInForm()
		{
			int border = 50;
			//check for x
			if (Control.MousePosition.X < this.Location.X - border || Control.MousePosition.X > this.Location.X + this.Width + border)
			{
				return false;
			}
			//check for y
			if (Control.MousePosition.Y < this.Location.Y - 100 || Control.MousePosition.Y > this.Location.Y + this.Height + border)
			{
				return false;
			}
			return true;
		}
		private void flee(Vector2 v)
		{
			int newX = this.Location.X + (int)(v.X * 10);
			while (newX > desktopWidth)
			{
				newX = 2*desktopWidth-newX;
			}
			if (newX < 0)
			{
				newX = -2*newX;
			}
			int newY = this.Location.Y + (int)(v.Y * 10);
			while (newY > desktopHeight)
			{
				newY = 2*desktopHeight-newY;
			}
			if (newY < 0)
			{
				newY = -2*newY;
			}

			this.Location = new Point(newX, newY);
		}


		private void Form1_Load(object sender, EventArgs e)
		{
			//MessageBox.Show("Siema", "S", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}



		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			this.Location = new Point(rnd.Next(desktopWidth), rnd.Next(desktopHeight));
			Form1 form2 = new Form1();
			form2.Location = new Point(rnd.Next(desktopWidth), rnd.Next(desktopHeight));
			form2.Visible = true;
		}

		private void Form1_MouseEnter(object sender, EventArgs e)
		{
			double x = rnd.NextDouble();
			if (this.Location.X > 100)
			{
				x -= 0.5;
				if (this.Location.X > desktopWidth - 100)
				{
					x -= 0.5;
				}
			}
			double y = rnd.NextDouble();
			if (this.Location.Y > 100)
			{
				y -= 0.5;
				if (this.Location.Y > desktopHeight - 100)
				{
					y -= 0.5;
				}
			}
			while (mouseInForm())
			{
				if(this.Location.X < 50 || this.Location.X > desktopWidth - 50)
				{
					x *= -1;
					for (int _ = 0; _ < 20; _++)
					{
						this.flee(new Vector2((float)x, (float)y));
					}
				}
				if (this.Location.Y < 50 || this.Location.Y > desktopHeight - 50)
				{
					y *= -1;
					for (int _ = 0; _ < 20; _++)
					{
						this.flee(new Vector2((float)x, (float)y));
					}

				}
			for (int _ = 0; _ < rnd.Next(75,125); _++)
			{
				this.flee(new Vector2((float)x, (float)y));
			}

				this.flee(new Vector2((float)x, (float)y));
			}
		}
	}
}
