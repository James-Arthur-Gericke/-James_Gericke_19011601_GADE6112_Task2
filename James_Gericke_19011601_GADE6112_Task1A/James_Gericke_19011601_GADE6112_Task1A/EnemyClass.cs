using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace James_Gericke_19011601_GADE6112_Task1A
{
	[Serializable]
	abstract class EnemyClass : CharacterClass



	{
		protected Random random = new Random();
		public EnemyClass(int x, int y, userTileClass.tileType type, int damage, int hp) : base(x, y, type)
		{
			overallUserFinalDamage(damage);
			setHp(hp);
			setMaxHp(hp);
			this.type = userTileClass.tileType.Enemy;
		}


		public override string ToString()


		{
			string userInfoDisplay = "";
			userInfoDisplay += "Enemies that are in the game\n\n";
			userInfoDisplay += "X postion: "+x.ToString() + "\t";
			userInfoDisplay += "Y postion: " + y.ToString() + "\t" + "\n";
			userInfoDisplay += "Damage dealt: " + userDamage.ToString();
			return userInfoDisplay;
			
		}

		
	}
}
