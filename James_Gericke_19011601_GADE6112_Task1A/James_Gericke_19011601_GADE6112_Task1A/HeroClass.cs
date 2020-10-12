using System;

namespace James_Gericke_19011601_GADE6112_Task1A
{
	[Serializable]
	class HeroClass : CharacterClass
	{

		public HeroClass(int x, int y, int hp) : base(x, y, userTileClass.tileType.Hero)
		{
			this.setHp(hp);
			this.setMaxHp(hp);
			this.overallUserFinalDamage(2);
			this.type = userTileClass.tileType.Hero;
		}

		public override string ToString()
		{
			string infoDisplay = "";
			infoDisplay += "Player Hp: " + userHp.ToString() + "\n";
			infoDisplay += "X Postion: " + x.ToString() + "\t";
			infoDisplay += "Y Postion: " + y.ToString() + "\t" + "\n";
			infoDisplay += "Damage: 2 " + userDamage.ToString() + "\n";
			infoDisplay += "Amount of gold: " + this.fetchFinalGoldAmount();
			return infoDisplay;

		}

		public override Movement returnMove(Movement move)
		{
			{
				if (this.userCharacterVision[(int)move] is emptyUserTileClass || this.userCharacterVision[(int)move] is GoldClass)
				{
					return move;
				}
				else
				{
					return Movement.NoMovement;
				}
			}
		}


	}
}
