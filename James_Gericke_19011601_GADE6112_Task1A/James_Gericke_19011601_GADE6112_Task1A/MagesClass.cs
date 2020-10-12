using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace James_Gericke_19011601_GADE6112_Task1A
{ [Serializable]
	class MagesClass : EnemyClass
	{

		private int userMageDamage;

		public int getUserMageDamage()
		{
			return userMageDamage;
		}
		private int magesHitPoints;
		public int getMagesHitPoints()
		{
			return magesHitPoints;
		}

		public MagesClass(int x, int y, tileType type, int damage, int hp) : base(x, y, type, damage, hp)
		{
			userMageDamage = damage;
			magesHitPoints = hp;
		}

		public override Movement returnMove(Movement move = 0)
		{
			return Movement.NoMovement;

		}
		public override bool overallUserCheckRange(CharacterClass target)
		{
			bool foundUsersEnemy = false;
			for (int i = 0; i < userCharacterVision.Length; ++i)
			{
				if (userCharacterVision[i] is EnemyClass || userCharacterVision[i] is HeroClass)
				{
					foundUsersEnemy = true;

				}
			}
			return foundUsersEnemy;

		}
	
	}
}
