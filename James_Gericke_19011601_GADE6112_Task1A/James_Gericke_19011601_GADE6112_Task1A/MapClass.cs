using System;

namespace James_Gericke_19011601_GADE6112_Task1A
{
	[Serializable]
	class userMapClass
	{
		public Random rnd = new Random();
		private ItemClass[] items;
		private userTileClass[,] map;
		private HeroClass hero;
		private EnemyClass[] userEnemies;
		private int width;
		private int height;

		public userMapClass(int minimumWidth, int maximumWidth, int minumumHeight, int maximumHeight, int numberOfEnemies, int numberOfGold)
		{
			
			
			this.width = rnd.Next(minimumWidth, maximumWidth + 1);
			this.height = rnd.Next(minumumHeight, maximumHeight + 1);

			
			
			this.map = new userTileClass[height, width];


			int max_num_enemies = ((width - 2) * (height - 2)) - 1;
			if (numberOfEnemies > max_num_enemies)


			{
				numberOfEnemies = max_num_enemies;
			}


			this.userEnemies = new EnemyClass[numberOfEnemies];

			createAnEmptyMap();
			this.hero = (HeroClass)create(userTileClass.tileType.Hero);
			map[hero.getY(), hero.getX()] = hero;


			for (int i = 0; i < userEnemies.Length; ++i)
			{
				userEnemies[i] = (EnemyClass)create(userTileClass.tileType.Enemy);
				map[userEnemies[i].getY(), userEnemies[i].getX()] = userEnemies[i];
			}



			int maximumAmountOfGold = ((width - 2) * (height - 2)) - 1 - userEnemies.Length;
			if (numberOfGold > maximumAmountOfGold)
			{
				numberOfGold = maximumAmountOfGold;
			}


			this.items = new ItemClass[numberOfGold];

			
			for (int i = 0; i < items.Length; ++i)

			{
				items[i] = (GoldClass)create(userTileClass.tileType.Gold);
				map[items[i].getY(), items[i].getX()] = items[i];
			}

			updateVision();

		}

		private void createAnEmptyMap()


		{
			for (int i = 0; i < height; ++i)
			{
				for (int j = 0; j < width; ++j)
				{
					if (i == 0 || i == (height - 1))
					{
						map[i, j] = new userObstacleClass(i, j);
					}
					else if (j == 0 || j == (width - 1))
					{
						map[i, j] = new userObstacleClass(i, j);
					}
					else
					{
						map[i, j] = new emptyUserTileClass(i, j);
					}
				}
			}
		}

		private userTileClass create(userTileClass.tileType type)
		{
			int[] spawnLocation = fetchSpawnPosition();

			if (type == userTileClass.tileType.Hero)
			{
				return new HeroClass(spawnLocation[1], spawnLocation[0], 10);
			}

			else if (type == userTileClass.tileType.Enemy)

			{
				return enemyGen(spawnLocation[1], spawnLocation[0]);
			}

			else if (type == userTileClass.tileType.Gold)

			{
				return new GoldClass(spawnLocation[1], spawnLocation[0]);
			}

			else

			{
				return new emptyUserTileClass(spawnLocation[1], spawnLocation[0]);
			}

		}

		public EnemyClass enemyGen(int y, int x)
		{
			if (rnd.Next(1, 3) == 1)
			{
				return new MagesClass(y, x, userTileClass.tileType.Enemy, 5, 5);
			}
			else
			{
				return new GoblinClass(y, x);
			}
		}


		private void updateVision()


		{
			hero.setUserVision(returnVision(hero.getX(), hero.getY()));

			for (int i = 0; i < userEnemies.Length; ++i)
			{

				userEnemies[i].setUserVision(returnVision(userEnemies[i].getX(), userEnemies[i].getY()));
			}
		}

		public void focusedUpdatedVision()


		{
			updateVision();
		}

		public void MapRemoval(userTileClass character)


		{
			if (character.getTileType() == userTileClass.tileType.Enemy)
			{
				EnemyClass[] new_list = new EnemyClass[userEnemies.Length - 1];
				int index = 0;

				for (int i = 0; i < userEnemies.Length; ++i)
				{
					if (userEnemies[i].died())
					{
						map[userEnemies[i].getY(), userEnemies[i].getX()] = new emptyUserTileClass(userEnemies[i].getY(), userEnemies[i].getX());
					}
					else
					{
						new_list[index] = userEnemies[i];
						++index;
					}
				}

				userEnemies = new_list;
				updateVision();
			}
		}


		public void findCharacterPosition(userTileClass character, CharacterClass.Movement direction)


		{
			CharacterClass c = (CharacterClass)map[character.getY(), character.getX()];
			emptyUserTileClass emp;

			switch (direction)

			{
				case CharacterClass.Movement.MoveUp:
					emp = (emptyUserTileClass)map[c.getY() - 1, c.getX()];
					map[c.getY() - 1, c.getX()] = c;
					map[c.getY(), c.getX()] = emp;
					c.Move(CharacterClass.Movement.MoveUp);
					emp.setY(emp.getY() + 1);
					break;
				case CharacterClass.Movement.MoveDown:
					emp = (emptyUserTileClass)map[c.getY() + 1, c.getX()];
					map[c.getY() + 1, c.getX()] = c;
					map[c.getY(), c.getX()] = emp;
					c.Move(CharacterClass.Movement.MoveDown);
					emp.setY(emp.getY() - 1);
					break;
				case CharacterClass.Movement.MoveLeft:
					emp = (emptyUserTileClass)map[c.getY(), c.getX() - 1];
					map[c.getY(), c.getX() - 1] = c;
					map[c.getY(), c.getX()] = emp;
					c.Move(CharacterClass.Movement.MoveLeft);
					emp.setX(emp.getX() + 1);
					break;
				case CharacterClass.Movement.MoveRight:
					emp = (emptyUserTileClass)map[c.getY(), c.getX() + 1];
					map[c.getY(), c.getX() + 1] = c;
					map[c.getY(), c.getX()] = emp;
					c.Move(CharacterClass.Movement.MoveRight);
					emp.setX(emp.getX() - 1);
					break;
			}

			this.updateVision();
		}


		private userTileClass[] returnVision(int x, int y)



		{
			userTileClass[] characterVision = new userTileClass[8];
			
			characterVision[0] = map[y - 1, x];  
			characterVision[1] = map[y + 1, x];  
			characterVision[2] = map[y, x - 1]; 
			characterVision[3] = map[y, x + 1];  
			characterVision[4] = map[y - 1, x + 1];  
			characterVision[5] = map[y + 1, x + 1];  
			characterVision[6] = map[y + 1, x - 1];  
			characterVision[7] = map[y - 1, x - 1]; 

			return characterVision;

		}


		private int[] fetchSpawnPosition()

		{
			int x_position = rnd.Next(1, width);
			int y_position = rnd.Next(1, height);

			if (map[y_position, x_position] is emptyUserTileClass)
			{
				int[] s_point = new int[2];
				s_point[0] = y_position;
				s_point[1] = x_position;

				return s_point;
			}
			else
			{
				return fetchSpawnPosition();
			}
		}

		public void givenMap(userTileClass[,] map)

		{
			this.map = map;
		}

		public userTileClass[,] provideMap()

		{
			return this.map;
		}

		public void givenHero(HeroClass hero)

		{
			this.hero = hero;
		}

		public HeroClass provideHero()

		{
			return this.hero;
		}

		public void setAmountOfEnemies(EnemyClass[] enemies)

		{
			this.userEnemies = enemies;
		}

		public EnemyClass[] fetchEnemies()

		{
			return this.userEnemies;
		}

		public void givenWidth(int width)

		{
			this.width = width;
		}
		public ItemClass[] fetchItem()

		{
			return this.items;
		}
		public void setItems(ItemClass[] newItems)

		{
			this.items = newItems;
		}
		public int fetchWidth()

		{
			return this.width;
		}

		public void givenHeight(int height)

		{
			this.height = height;
		}

		public int fetchHeight()

		{
			return this.height;
		}

		public ItemClass fetchItemOnArrival(int x, int y)


		{
			ItemClass item = null;
			for (int i = 0; i < items.Length; ++i)
			{
				if (items[i].getX() == x && items[i].getY() == y)
				{
					item = items[i];
				}

			}
			return item;
		}
	}
}
