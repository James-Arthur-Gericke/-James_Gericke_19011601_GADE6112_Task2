using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace James_Gericke_19011601_GADE6112_Task1A
{
	[Serializable]
	class userObstacleClass : userTileClass

	{
		public userObstacleClass(int x, int y) : base(x, y)

		{
			this.x = x;
			this.y = y;
		}


	}
}
