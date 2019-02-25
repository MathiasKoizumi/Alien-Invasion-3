using System;
using System.Drawing;
using System.Reflection;

namespace GravityLivesOn1._0
{
	internal class Ding
	{
		public int image;

		public double størrelse = 45.0;

		public int masse;

		public float particles;

		public Color farve;

		public float positionX;

		public float positionY;

		public float positionZ;

		public float hastighedX = 5f;

		public float hastighedY = 5f;

		public float hastighedZ = 5f;

		public int alder;

		public int vinkel;

		public Random rand = new Random();

		public Ding(int speed, int massen, int color, int size, Form1 form1)
		{
			størrelse = size;
			hastighedX = rand.Next(speed);
			hastighedY = rand.Next(speed);
			hastighedZ = rand.Next(speed);
			positionX = rand.Next(300, 1200);
			positionY = rand.Next(100, 400);
			positionZ = rand.Next(100, 500);
			image = rand.Next(10);
			Assembly.GetExecutingAssembly();
			masse = massen;
			particles = (float)((double)massen * størrelse + (double)masse * størrelse);
			alder = 0;
			vinkel = rand.Next(1, 360);
			farve = Color.FromArgb(rand.Next(color), rand.Next(color), rand.Next(color), rand.Next(color));
		}

		public Ding()
		{
		}
	}
}
