using System;

namespace James_Gericke_19011601_GADE6112_Task1A
{

	[Serializable]
	class emptyUserTileClass : userTileClass



	{
		public emptyUserTileClass(int x, int y) : base(x, y)
		{
			this.x = x;
			this.y = y;
		}
	}
}
