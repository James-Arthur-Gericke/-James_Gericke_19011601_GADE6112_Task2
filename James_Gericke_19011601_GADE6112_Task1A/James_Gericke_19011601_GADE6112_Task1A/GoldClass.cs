using System;

namespace James_Gericke_19011601_GADE6112_Task1A
{
	class GoldClass : ItemClass
	{
		private Random goldrnd = new Random();
		private int goldAmount;
		
		public int fetchFinalGoldAmount()
		{
			return goldAmount;
		}
		public GoldClass(int x, int y) : base(x, y)
		{
			this.type = userTileClass.tileType.Gold;
			goldAmount = goldrnd.Next(1, 5);
		}
	}
}
