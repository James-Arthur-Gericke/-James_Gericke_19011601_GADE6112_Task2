using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace James_Gericke_19011601_GADE6112_Task1A
{	[Serializable]
	abstract class ItemClass : userTileClass
	{
		protected ItemClass(int x, int y) : base(x, y)
		{

		}

		public override string ToString()
		{
			return base.ToString();
		}
	}
}
