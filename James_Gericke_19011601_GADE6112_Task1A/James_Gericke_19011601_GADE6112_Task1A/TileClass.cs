using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace James_Gericke_19011601_GADE6112_Task1A
{
	[Serializable]
	abstract class userTileClass


	{

		public enum tileType
		{
			Hero,
			Weapon,
			Gold,
			Enemy
		}


		protected int x;
		protected int y;
		
		public int X



		{
			get { return x; }
			set { x = value; }

		}


		public int Y



		{
			get { return y; }
			set { y = value; }

		}


		private tileType Type;

		public tileType type


		{
			get { return Type; }
			set { Type = value; }
		}

		public userTileClass(int Xtemp, int Ytemp, tileType typetemp)



		{
			this.x = Xtemp;
			this.y = Ytemp;
			type = typetemp;
		}

		protected userTileClass(int x, int y)



		{
			X = x;
			Y = y;
		}

		public tileType getTileType()



		{
			return type;
		}

		public void setTileType(tileType type)



		{
			this.type = type;
		}

		public int getX()



		{
			return x;
		}

		public void setX(int x)



		{
			this.x = x;
		}

		public int getY()


		{
			return y;
		}

		public void setY(int y)


		{
			this.y = y;
		}
	}
}