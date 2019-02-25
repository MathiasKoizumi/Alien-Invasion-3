using IrrKlang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using WMPLib;

namespace GravityLivesOn1._0
{
	public class Form1 : Form
	{
		private ISoundEngine engine;

		private Image a = null;

		private Image image1;

		private Image image2;

		private Image image3;

		private Image image4;

		private Image image5;

		private Image image6;

		private Image image7;

		private Image image8;

		private Image image9;

		private Image image10;

		private Image exp;

		private Random rand;

		private Ding[] objekter;

		private Graphics g;

		private Bitmap bitmap;

		private IContainer components;

		private Panel panel1;

		private NumericUpDown numericUpDown1;

		private Label label1;

		private Button button1;

		private CheckBox checkBox1;

		private CheckBox checkBox2;

		private NumericUpDown numericUpDown2;

		private NumericUpDown antalObjekter;

		private Label label2;

		private CheckBox checkBox4;

		private NumericUpDown numericUpDown4;

		private NumericUpDown sizeDrops;

		private Label label3;

		private CheckBox checkBox5;

		private Label label4;

		private NumericUpDown spredningStørrelse;

		private Button button2;

		private NumericUpDown rounds;

		private Label label5;

		private NumericUpDown speed;

		private Panel panel2;

		private Label label8;

		private Label label7;

		private Label label9;

		private NumericUpDown numericUpDown3;

		private Label label6;

		private WindowsMediaPlayer wplayer = (WindowsMediaPlayer)Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("6BF52A52-394A-11D3-B153-00C04F79FAA6")));

		public static string AssemblyDirectory
		{
			get
			{
				string codeBase = Assembly.GetExecutingAssembly().CodeBase;
				UriBuilder uriBuilder = new UriBuilder(codeBase);
				string path = Uri.UnescapeDataString(uriBuilder.Path);
				return Path.GetDirectoryName(path);
			}
		}

		public Form1()
		{
			InitializeComponent();
			rand = new Random();
			designObjekter((int)antalObjekter.Value, (int)speed.Value);
			g = panel1.CreateGraphics();
			bitmap = new Bitmap(panel1.Width, panel1.Height, PixelFormat.Format32bppArgb);
			engine = new ISoundEngine();
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				graphics.Clear(Color.Beige);
			}
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		private void DrawPaintMe()
		{
			Bitmap image = new Bitmap(panel1.Width, panel1.Height);
			Graphics graphics = Graphics.FromImage(image);
			graphics = Graphics.FromImage(image);
			graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphics.DrawImage(bitmap, 0, 0);
			for (int i = 0; i < objekter.Length; i++)
			{
				if (objekter[i].image == 0)
				{
					a = image1;
				}
				if (objekter[i].image == 1)
				{
					a = image2;
				}
				if (objekter[i].image == 2)
				{
					a = image3;
				}
				if (objekter[i].image == 3)
				{
					a = image4;
				}
				if (objekter[i].image == 4)
				{
					a = image5;
				}
				if (objekter[i].image == 5)
				{
					a = image6;
				}
				if (objekter[i].image == 6)
				{
					a = image7;
				}
				if (objekter[i].image == 7)
				{
					a = image8;
				}
				if (objekter[i].image == 8)
				{
					a = image9;
				}
				if (objekter[i].image == 9)
				{
					a = image10;
				}
				graphics.DrawImage(a, (int)objekter[i].positionX, (int)objekter[i].positionY, (int)objekter[i].størrelse, (int)objekter[i].størrelse);
				if (rand.Next((int)numericUpDown3.Value) == 0)
				{
					graphics.DrawString(Speakup(), new Font("Times New Roman", 18f), Brushes.Black, new PointF((int)objekter[i].positionX + 25, (int)objekter[i].positionY - 15));
					engine.Play2D(effect());
					wplayer.URL = "bang.wav";
					wplayer.controls.play();
					graphics.DrawImage(explosion(), (int)objekter[i].positionX, (int)objekter[i].positionY, (int)objekter[i].størrelse + 50, (int)objekter[i].størrelse + 50);
					List<Ding> list = new List<Ding>(objekter);
					list.RemoveAt(i);
					objekter = list.ToArray();
					label8.Text = objekter.Length.ToString();
					label8.Refresh();
					if (objekter.Length == 0)
					{
						graphics.DrawString("The End....", new Font("Times New Roman", 46f), Brushes.Black, new PointF(1000f, 500f));
					}
				}
			}
			graphics.Save();
			g.DrawImage(image, 0, 0);
			animate();
		}

		private string effect()
		{
			string result = "";
			switch (rand.Next(11))
			{
			case 0:
				return "hey.wav";
			case 1:
				return "cyborg.wav";
			case 2:
				return "zap.wav";
			case 3:
				return "laugh.wav";
			case 4:
				return "lazer.wav";
			case 5:
				return "rocket.wav";
			case 6:
				return "bang.wav";
			case 7:
				return "explo.wav";
			case 8:
				return "zap.wav";
			case 9:
				return "zap2.wav";
			case 10:
				return "zaps.wav";
			default:
				return result;
			}
		}

		private Image explosion()
		{
			Image result = null;
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			Stream manifestResourceStream = executingAssembly.GetManifestResourceStream("Alien0.png");
			switch (rand.Next(6))
			{
			case 0:
				manifestResourceStream = executingAssembly.GetManifestResourceStream("exp2.png");
				return Image.FromStream(manifestResourceStream);
			case 1:
				manifestResourceStream = executingAssembly.GetManifestResourceStream("exp2.png");
				return Image.FromStream(manifestResourceStream);
			case 2:
				manifestResourceStream = executingAssembly.GetManifestResourceStream("exp3.png");
				return Image.FromStream(manifestResourceStream);
			case 3:
				manifestResourceStream = executingAssembly.GetManifestResourceStream("exp4.png");
				return Image.FromStream(manifestResourceStream);
			case 4:
				manifestResourceStream = executingAssembly.GetManifestResourceStream("exp5.png");
				return Image.FromStream(manifestResourceStream);
			case 5:
				manifestResourceStream = executingAssembly.GetManifestResourceStream("exp6.png");
				return Image.FromStream(manifestResourceStream);
			default:
				return result;
			}
		}

		private string Speakup()
		{
			string result = "";
			switch (rand.Next(10))
			{
			case 0:
				return "Yo";
			case 1:
				return "See ya";
			case 2:
				return "Im good";
			case 3:
				return "Dummy";
			case 4:
				return "Bad joke";
			case 5:
				return "Dont call me that";
			case 6:
				return "Im alive...yes";
			case 7:
				return "Dont mess with me..";
			case 8:
				return "Im better now";
			case 9:
				return "Please marry me";
			default:
				return result;
			}
		}

		private void animate()
		{
			for (int i = 0; i < objekter.Length; i++)
			{
				objekter[i].positionX = objekter[i].positionX + objekter[i].hastighedX + (float)rand.Next(-objekter[i].masse, objekter[i].masse);
				objekter[i].positionY = objekter[i].positionY + objekter[i].hastighedY + (float)rand.Next(-objekter[i].masse, objekter[i].masse);
				objekter[i].positionZ = objekter[i].positionZ + objekter[i].hastighedZ + (float)rand.Next(-objekter[i].masse, objekter[i].masse);
				switch (rand.Next(2))
				{
				case 1:
					objekter[i].hastighedX = 0f - (float)rand.Next((int)speed.Value);
					objekter[i].hastighedY = 0f - (float)rand.Next((int)speed.Value);
					objekter[i].hastighedZ = 0f - (float)rand.Next((int)speed.Value);
					break;
				case 0:
					objekter[i].hastighedX = rand.Next((int)speed.Value);
					objekter[i].hastighedY = rand.Next((int)speed.Value);
					objekter[i].hastighedZ = rand.Next((int)speed.Value);
					break;
				}
				switch (rand.Next(2))
				{
				case 1:
					if (objekter[i].størrelse > (double)(int)spredningStørrelse.Value)
					{
						objekter[i].størrelse = objekter[i].størrelse - (double)rand.Next((int)spredningStørrelse.Value);
					}
					break;
				case 0:
					objekter[i].størrelse = objekter[i].størrelse + (double)rand.Next((int)spredningStørrelse.Value);
					break;
				}
				objekter[i].masse = (int)numericUpDown1.Value;
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			for (int i = 0; (decimal)i < rounds.Value; i++)
			{
				DrawPaintMe();
			}
		}

		private void designObjekter(int number, int speed)
		{
			objekter = new Ding[number];
			for (int i = 0; i < number; i++)
			{
				Ding ding = new Ding(rand.Next(speed), rand.Next((int)numericUpDown1.Value), rand.Next(255), (int)sizeDrops.Value, this);
				objekter[i] = ding;
			}
		}

		private void antalObjekter_ValueChanged(object sender, EventArgs e)
		{
			designObjekter((int)antalObjekter.Value, (int)speed.Value);
		}

		private void sizeDrops_ValueChanged(object sender, EventArgs e)
		{
			designObjekter((int)antalObjekter.Value, (int)speed.Value);
		}

		private void spredningStørrelse_ValueChanged(object sender, EventArgs e)
		{
			designObjekter((int)antalObjekter.Value, (int)speed.Value);
		}

		private void numericUpDown3_ValueChanged(object sender, EventArgs e)
		{
			designObjekter((int)antalObjekter.Value, (int)speed.Value);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Close();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			panel1 = new System.Windows.Forms.Panel();
			label8 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			label9 = new System.Windows.Forms.Label();
			numericUpDown3 = new System.Windows.Forms.NumericUpDown();
			button2 = new System.Windows.Forms.Button();
			label3 = new System.Windows.Forms.Label();
			numericUpDown4 = new System.Windows.Forms.NumericUpDown();
			label6 = new System.Windows.Forms.Label();
			sizeDrops = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			checkBox4 = new System.Windows.Forms.CheckBox();
			speed = new System.Windows.Forms.NumericUpDown();
			antalObjekter = new System.Windows.Forms.NumericUpDown();
			numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			spredningStørrelse = new System.Windows.Forms.NumericUpDown();
			label5 = new System.Windows.Forms.Label();
			numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			label1 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			rounds = new System.Windows.Forms.NumericUpDown();
			checkBox2 = new System.Windows.Forms.CheckBox();
			button1 = new System.Windows.Forms.Button();
			checkBox5 = new System.Windows.Forms.CheckBox();
			checkBox1 = new System.Windows.Forms.CheckBox();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
			((System.ComponentModel.ISupportInitialize)sizeDrops).BeginInit();
			((System.ComponentModel.ISupportInitialize)speed).BeginInit();
			((System.ComponentModel.ISupportInitialize)antalObjekter).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
			((System.ComponentModel.ISupportInitialize)spredningStørrelse).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
			((System.ComponentModel.ISupportInitialize)rounds).BeginInit();
			SuspendLayout();
			panel1.AutoSize = true;
			panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			panel1.Controls.Add(label8);
			panel1.Controls.Add(label7);
			panel1.Controls.Add(panel2);
			panel1.Location = new System.Drawing.Point(2, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(1920, 1080);
			panel1.TabIndex = 0;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(124, 39);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(0, 13);
			label8.TabIndex = 24;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(32, 39);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(86, 13);
			label7.TabIndex = 23;
			label7.Text = "Number of aliens";
			panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel2.Controls.Add(label9);
			panel2.Controls.Add(numericUpDown3);
			panel2.Controls.Add(button2);
			panel2.Controls.Add(label3);
			panel2.Controls.Add(numericUpDown4);
			panel2.Controls.Add(label6);
			panel2.Controls.Add(sizeDrops);
			panel2.Controls.Add(label2);
			panel2.Controls.Add(checkBox4);
			panel2.Controls.Add(speed);
			panel2.Controls.Add(antalObjekter);
			panel2.Controls.Add(numericUpDown1);
			panel2.Controls.Add(spredningStørrelse);
			panel2.Controls.Add(label5);
			panel2.Controls.Add(numericUpDown2);
			panel2.Controls.Add(label1);
			panel2.Controls.Add(label4);
			panel2.Controls.Add(rounds);
			panel2.Controls.Add(checkBox2);
			panel2.Controls.Add(button1);
			panel2.Controls.Add(checkBox5);
			panel2.Controls.Add(checkBox1);
			panel2.Location = new System.Drawing.Point(93, 557);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(1309, 117);
			panel2.TabIndex = 22;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(570, 63);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(59, 13);
			label9.TabIndex = 23;
			label9.Text = "War speed";
			numericUpDown3.Location = new System.Drawing.Point(516, 60);
			numericUpDown3.Maximum = new decimal(new int[4]
			{
				1000,
				0,
				0,
				0
			});
			numericUpDown3.Name = "numericUpDown3";
			numericUpDown3.Size = new System.Drawing.Size(48, 20);
			numericUpDown3.TabIndex = 22;
			numericUpDown3.Value = new decimal(new int[4]
			{
				100,
				0,
				0,
				0
			});
			button2.AutoSize = true;
			button2.Location = new System.Drawing.Point(364, 17);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(118, 44);
			button2.TabIndex = 17;
			button2.Text = "Start";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(button2_Click);
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(962, 49);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(64, 13);
			label3.TabIndex = 13;
			label3.Text = "Size objects";
			numericUpDown4.AutoSize = true;
			numericUpDown4.Location = new System.Drawing.Point(823, 47);
			numericUpDown4.Name = "numericUpDown4";
			numericUpDown4.Size = new System.Drawing.Size(57, 20);
			numericUpDown4.TabIndex = 11;
			numericUpDown4.ValueChanged += new System.EventHandler(numericUpDown4_ValueChanged);
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(585, 27);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(38, 13);
			label6.TabIndex = 21;
			label6.Text = "Speed";
			sizeDrops.AutoSize = true;
			sizeDrops.Location = new System.Drawing.Point(915, 47);
			sizeDrops.Maximum = new decimal(new int[4]
			{
				1000,
				0,
				0,
				0
			});
			sizeDrops.Name = "sizeDrops";
			sizeDrops.Size = new System.Drawing.Size(41, 20);
			sizeDrops.TabIndex = 12;
			sizeDrops.Value = new decimal(new int[4]
			{
				25,
				0,
				0,
				0
			});
			sizeDrops.ValueChanged += new System.EventHandler(sizeDrops_ValueChanged);
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(1048, 27);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(81, 13);
			label2.TabIndex = 8;
			label2.Text = "Number objects";
			checkBox4.AutoSize = true;
			checkBox4.Location = new System.Drawing.Point(762, 48);
			checkBox4.Name = "checkBox4";
			checkBox4.Size = new System.Drawing.Size(55, 17);
			checkBox4.TabIndex = 10;
			checkBox4.Text = "Shield";
			checkBox4.UseVisualStyleBackColor = true;
			checkBox4.CheckedChanged += new System.EventHandler(checkBox4_CheckedChanged);
			speed.AutoSize = true;
			speed.Location = new System.Drawing.Point(516, 23);
			speed.Maximum = new decimal(new int[4]
			{
				1000,
				0,
				0,
				0
			});
			speed.Name = "speed";
			speed.Size = new System.Drawing.Size(63, 20);
			speed.TabIndex = 20;
			speed.Value = new decimal(new int[4]
			{
				50,
				0,
				0,
				0
			});
			speed.ValueChanged += new System.EventHandler(numericUpDown3_ValueChanged);
			antalObjekter.AutoSize = true;
			antalObjekter.Location = new System.Drawing.Point(1135, 25);
			antalObjekter.Maximum = new decimal(new int[4]
			{
				100000,
				0,
				0,
				0
			});
			antalObjekter.Name = "antalObjekter";
			antalObjekter.Size = new System.Drawing.Size(59, 20);
			antalObjekter.TabIndex = 7;
			antalObjekter.Value = new decimal(new int[4]
			{
				50,
				0,
				0,
				0
			});
			antalObjekter.ValueChanged += new System.EventHandler(antalObjekter_ValueChanged);
			numericUpDown1.AutoSize = true;
			numericUpDown1.Location = new System.Drawing.Point(23, 41);
			numericUpDown1.Name = "numericUpDown1";
			numericUpDown1.Size = new System.Drawing.Size(44, 20);
			numericUpDown1.TabIndex = 1;
			spredningStørrelse.AutoSize = true;
			spredningStørrelse.Location = new System.Drawing.Point(1135, 60);
			spredningStørrelse.Name = "spredningStørrelse";
			spredningStørrelse.Size = new System.Drawing.Size(47, 20);
			spredningStørrelse.TabIndex = 14;
			spredningStørrelse.Value = new decimal(new int[4]
			{
				1,
				0,
				0,
				0
			});
			spredningStørrelse.ValueChanged += new System.EventHandler(spredningStørrelse_ValueChanged);
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(82, 70);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(44, 13);
			label5.TabIndex = 19;
			label5.Text = "Rounds";
			numericUpDown2.AutoSize = true;
			numericUpDown2.Location = new System.Drawing.Point(288, 44);
			numericUpDown2.Name = "numericUpDown2";
			numericUpDown2.Size = new System.Drawing.Size(61, 20);
			numericUpDown2.TabIndex = 6;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(73, 43);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(40, 13);
			label1.TabIndex = 2;
			label1.Text = "Gravity";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(1048, 62);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(68, 13);
			label4.TabIndex = 15;
			label4.Text = "Size diversity";
			rounds.AutoSize = true;
			rounds.Location = new System.Drawing.Point(23, 68);
			rounds.Maximum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				0
			});
			rounds.Name = "rounds";
			rounds.Size = new System.Drawing.Size(53, 20);
			rounds.TabIndex = 18;
			rounds.Value = new decimal(new int[4]
			{
				20,
				0,
				0,
				0
			});
			checkBox2.AutoSize = true;
			checkBox2.Location = new System.Drawing.Point(194, 47);
			checkBox2.Name = "checkBox2";
			checkBox2.Size = new System.Drawing.Size(88, 17);
			checkBox2.TabIndex = 5;
			checkBox2.Text = "Particle mass";
			checkBox2.UseVisualStyleBackColor = true;
			button1.AutoSize = true;
			button1.Location = new System.Drawing.Point(194, 81);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(109, 23);
			button1.TabIndex = 3;
			button1.Text = "Create Magneto";
			button1.UseVisualStyleBackColor = true;
			checkBox5.AutoSize = true;
			checkBox5.Location = new System.Drawing.Point(1189, 62);
			checkBox5.Name = "checkBox5";
			checkBox5.Size = new System.Drawing.Size(68, 17);
			checkBox5.TabIndex = 16;
			checkBox5.Text = "Pico size";
			checkBox5.UseVisualStyleBackColor = true;
			checkBox1.AutoSize = true;
			checkBox1.Location = new System.Drawing.Point(194, 23);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(96, 17);
			checkBox1.TabIndex = 4;
			checkBox1.Text = "Affect particles";
			checkBox1.UseVisualStyleBackColor = true;
			checkBox1.CheckedChanged += new System.EventHandler(checkBox1_CheckedChanged);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoSize = true;
			base.ClientSize = new System.Drawing.Size(1425, 768);
			base.Controls.Add(panel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Name = "Form1";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Alien Invasion";
			base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			base.Load += new System.EventHandler(Form1_Load);
			panel1.ResumeLayout(performLayout: false);
			panel1.PerformLayout();
			panel2.ResumeLayout(performLayout: false);
			panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
			((System.ComponentModel.ISupportInitialize)sizeDrops).EndInit();
			((System.ComponentModel.ISupportInitialize)speed).EndInit();
			((System.ComponentModel.ISupportInitialize)antalObjekter).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
			((System.ComponentModel.ISupportInitialize)spredningStørrelse).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
			((System.ComponentModel.ISupportInitialize)rounds).EndInit();
			ResumeLayout(performLayout: false);
			PerformLayout();
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void numericUpDown4_ValueChanged(object sender, EventArgs e)
		{
		}

		private void checkBox4_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			Stream manifestResourceStream = executingAssembly.GetManifestResourceStream("Alien0.png");
			image2 = Image.FromStream(manifestResourceStream);
			manifestResourceStream = executingAssembly.GetManifestResourceStream("Alien_Invasion.1.png");
			image3 = Image.FromStream(manifestResourceStream);
			manifestResourceStream = executingAssembly.GetManifestResourceStream("Alien_Invasion.2.png");
			image4 = Image.FromStream(manifestResourceStream);
			manifestResourceStream = executingAssembly.GetManifestResourceStream("Alien_Invasion.3.png");
			image5 = Image.FromStream(manifestResourceStream);
			manifestResourceStream = executingAssembly.GetManifestResourceStream("Alien_Invasion.4.png");
			image6 = Image.FromStream(manifestResourceStream);
			manifestResourceStream = executingAssembly.GetManifestResourceStream("Alien_Invasion.5.png");
			image7 = Image.FromStream(manifestResourceStream);
			manifestResourceStream = executingAssembly.GetManifestResourceStream("Alien_Invasion.6.png");
			image8 = Image.FromStream(manifestResourceStream);
			manifestResourceStream = executingAssembly.GetManifestResourceStream("Alien_Invasion.7.png");
			image9 = Image.FromStream(manifestResourceStream);
			manifestResourceStream = executingAssembly.GetManifestResourceStream("Alien_Invasion.8.png");
			image10 = Image.FromStream(manifestResourceStream);
			manifestResourceStream = executingAssembly.GetManifestResourceStream("Alien_Invasion.9.png");
			exp = Image.FromStream(manifestResourceStream);
		}
	}
}
