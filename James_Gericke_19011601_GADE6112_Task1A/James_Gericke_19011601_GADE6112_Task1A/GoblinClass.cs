using System;

namespace James_Gericke_19011601_GADE6112_Task1A
{
	[Serializable]
	class GoblinClass : EnemyClass
	{

		public GoblinClass(int x, int y) : base(x, y, userTileClass.tileType.Enemy, 1, 10)
		{ }

		

		public override Movement returnMove(CharacterClass.Movement move)
		{
			int[] possibleUserMovement = { 0, 1, 2, 3 };
			Boolean foundUserMovement = false;
			CharacterClass.Movement userDirection = CharacterClass.Movement.NoMovement;


			while (!foundUserMovement)



			{

				userDirection = (CharacterClass.Movement)possibleUserMovement[random.Next(0, possibleUserMovement.Length)];

				if (this.userCharacterVision[(int)userDirection] is emptyUserTileClass)
				{
					foundUserMovement = true;

				}
				else if (possibleUserMovement.Length != 1)
				{

					int[] new_possible_moves = new int[possibleUserMovement.Length - 1];
					int index = 0;



					for (int i = 0; i < possibleUserMovement.Length; ++i)
					{
						if (possibleUserMovement[i] != (int)userDirection)
						{
							new_possible_moves[index] = possibleUserMovement[i];
							++index;
						}
					}

					possibleUserMovement = new_possible_moves;
				}


				else



				{
					userDirection = CharacterClass.Movement.NoMovement;
					foundUserMovement = true;
				}

			}



			return userDirection;

		}

	}

}
