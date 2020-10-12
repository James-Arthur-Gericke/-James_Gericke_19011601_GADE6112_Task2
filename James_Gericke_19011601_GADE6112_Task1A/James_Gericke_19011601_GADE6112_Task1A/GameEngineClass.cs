using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace James_Gericke_19011601_GADE6112_Task1A
{
	[Serializable]
		class GameEngineClass
		{
			private userMapClass map;
		private string statusOfAttack;

		public GameEngineClass(int min_width, int max_width, int min_height, int max_height, int num_enemies, int gold)
			{
				map = new userMapClass(min_width, max_width, min_height, max_height, num_enemies, gold);
			}
			public GameEngineClass()
			{ }
			public userTileClass[,] getMapView()
			{
				return map.provideMap();
			}

			public int getWidth()
			{
				return map.fetchWidth();
			}

			public int getHeight()
			{
				return map.fetchHeight();
			}

			public string getHeroStats()
			{
				return map.provideMap().ToString();
			}

			public string getEnemiesRemaining()
			{
				string info = "";

				for (int i = 0; i < map.fetchEnemies().Length; ++i)
				{
					if (i <= 5)
					{
						info += map.fetchEnemies()[i].ToString() + "\n\n";
					}
				}

				if (map.fetchEnemies().Length > 6)
				{
					info += "+" + (map.fetchEnemies().Length - 6) + " more enem" + ((map.fetchEnemies().Length - 6) > 1 ? "ies" : "y");
				}

				return info;
			}

		public void itemRemoval(int ypos, int xpos)
		{
			ItemClass[] itemsNew = new ItemClass[map.fetchItem().Length - 1];
			int index = 0;
			for (int i = 0; i < map.fetchItem().Length; ++i)
			{
				if (map.fetchItem()[i].getX() != xpos && map.fetchItem()[i].getY() != ypos)
				{
					itemsNew[index] = map.fetchItem()[i];
					index++;
				}
			}
			map.setItems(itemsNew);
		}

		public Boolean movementOfPlayer(CharacterClass.Movement move)
		{

			if (map.provideHero().returnMove(move) == CharacterClass.Movement.NoMovement)
			{
				return false;
			}
			else
			{
				int heroX = map.provideHero().getX();
				int heroY = map.provideHero().getY();
				if (move == CharacterClass.Movement.MoveUp)
				{
					if (map.provideMap()[heroY - 1, heroX] is GoldClass)
					{
						map.provideHero().userPickup((GoldClass)map.provideMap()[heroY - 1, heroX]);
						map.provideMap()[heroY - 1, heroX] = new emptyUserTileClass(heroY - 1, heroX);

						map.focusedUpdatedVision();
					}
				}
				else if (move == CharacterClass.Movement.MoveDown)
				{
					if (map.provideMap()[heroY + 1, heroX] is GoldClass)
					{
						map.provideHero().userPickup((GoldClass)map.provideMap()[heroY + 1, heroX]);
						map.provideMap()[heroY + 1, heroX] = new emptyUserTileClass(heroY + 1, heroX);

						map.focusedUpdatedVision();
					}
				}
				else if (move == CharacterClass.Movement.MoveLeft)
				{
					if (map.provideMap()[heroY, heroX - 1] is GoldClass)
					{
						map.provideHero().userPickup((GoldClass)map.provideMap()[heroY, heroX - 1]);
						map.provideMap()[heroY, heroX - 1] = new emptyUserTileClass(heroY, heroX - 1);

						map.focusedUpdatedVision();
					}
				}
				else if (move == CharacterClass.Movement.MoveRight)
				{
					if (map.provideMap()[heroY, heroX + 1] is GoldClass)
					{
						map.provideHero().userPickup((GoldClass)map.provideMap()[heroY, heroX + 1]);
						map.provideMap()[heroY, heroX + 1] = new emptyUserTileClass(heroY, heroX + 1);

						map.focusedUpdatedVision();
					}
				}
				map.findCharacterPosition(map.provideHero(), move);
				movementOfEnemies();
				enemyAttackedUser();
				return true;

			}
		}

		private void movementOfEnemies()
		{
			EnemyClass[] enemies = map.fetchEnemies();

			for (int i = 0; i < enemies.Length; ++i)
			{
				CharacterClass.Movement move = enemies[i].returnMove(CharacterClass.Movement.NoMovement);
				map.findCharacterPosition(enemies[i], move);
			}

		}

		public String attackEnemy(CharacterClass.Movement move)
		{
			HeroClass h = map.provideHero();
			userTileClass target = new emptyUserTileClass(0, 0);

			switch (move)
			{
				case CharacterClass.Movement.MoveUp:
					target = map.provideMap()[h.getY() - 1, h.getX()];
					break;
				case CharacterClass.Movement.MoveDown:
					target = map.provideMap()[h.getY() + 1, h.getX()];
					break;
				case CharacterClass.Movement.MoveLeft:
					target = map.provideMap()[h.getY(), h.getX() - 1];
					break;
				case CharacterClass.Movement.MoveRight:
					target = map.provideMap()[h.getY(), h.getX() + 1];
					break;
			}

			if (target is EnemyClass)
			{

				h.Attack((CharacterClass)target);
				CharacterClass c_target = (CharacterClass)target;

				if (c_target.died())
				{
					map.MapRemoval(c_target);
				}

				movementOfEnemies();

				if (!c_target.died())
				{
					return "1" + c_target.ToString();
				}
				else
				{
					return "The enemy has died";
				}

			}
			else
			{
				return "0";
			}


		}
		public void enemyAttackedUser()
		{
			EnemyClass[] copyOfEnemies = new EnemyClass[map.fetchEnemies().Length];
			Array.Copy(map.fetchEnemies(), 0, copyOfEnemies, 0, map.fetchEnemies().Length);
			string statusOfAttack;
			for (int i = 0; i < copyOfEnemies.Length; ++i)
			{
				if (!copyOfEnemies[i].died())
				{
					copyOfEnemies[i].userLockedVision();

					for (int j = 0; j < copyOfEnemies[i].userFindVision().Length; ++j)
					{
						if (copyOfEnemies[i] is GoblinClass && j < 4)
						{
							statusOfAttack = userAttacksEnemy(copyOfEnemies[i], CharacterClass.Movement.NoMovement, copyOfEnemies[i].userFindVision()[j]);

						}
						else if (copyOfEnemies[i] is MagesClass)
						{
							statusOfAttack = userAttacksEnemy(copyOfEnemies[i], CharacterClass.Movement.NoMovement, copyOfEnemies[i].userFindVision()[j]);

						}
					}

					copyOfEnemies[i].userUnlockedVision();
					map.findCharacterPosition(copyOfEnemies[i], CharacterClass.Movement.NoMovement);
				}
			}


		}


		public string userAttacksEnemy(CharacterClass h, CharacterClass.Movement dir, userTileClass t)
		{
			userTileClass target = new emptyUserTileClass(0, 0);

			switch (dir)
			{
				case CharacterClass.Movement.MoveUp:
					target = map.provideMap()[h.getY() - 1, h.getX()];
					break;
				case CharacterClass.Movement.MoveDown:
					target = map.provideMap()[h.getY() + 1, h.getX()];
					break;
				case CharacterClass.Movement.MoveLeft:
					target = map.provideMap()[h.getY(), h.getX() - 1];
					break;
				case CharacterClass.Movement.MoveRight:
					target = map.provideMap()[h.getY(), h.getX() + 1];
					break;
				default:
					target = t;
					break;
			}


			if ((h is HeroClass && target is EnemyClass && !h.died()) || (h is GoblinClass && target is HeroClass) || (h is MagesClass && target is CharacterClass))
			{

				h.Attack((CharacterClass)target);
				CharacterClass c_target = (CharacterClass)target;

				if (c_target.died())
				{
					map.MapRemoval(c_target);
				}


				if (h is HeroClass)
				{


					enemyAttackedUser();
					if (!c_target.died())
					{
						return "1" + c_target.ToString();
					}
					else
					{
						return "The enemy is dead";
					}
				}
				else
				{
					return "";
				}

			}
			else
			{
				return "0";
			}


		}
		public Boolean saveGame()
		{
			try
			{
				FileStream file = new FileStream("file.saved", FileMode.Create, FileAccess.ReadWrite);
				BinaryFormatter bf = new BinaryFormatter();
				bf.Serialize(file, map);

				file.Close();

				return true;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return false;
			}

		}

		static public userMapClass loadGame()
		{
			try
			{
				FileStream file = new FileStream("file.saved", FileMode.Open, FileAccess.Read);
				BinaryFormatter bf = new BinaryFormatter();
				userMapClass m = (userMapClass)bf.Deserialize(file);

				file.Close();

				return m;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return null;
			}
		}
		public void setMap(userMapClass loadMap)
		{
			this.map = loadMap;
		}
		public userMapClass getMap()
		{
			return map;
		}
	}
}

