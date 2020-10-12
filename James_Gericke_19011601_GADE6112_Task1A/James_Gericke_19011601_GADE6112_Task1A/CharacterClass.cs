using System;

namespace James_Gericke_19011601_GADE6112_Task1A
{
	[Serializable]
	abstract class CharacterClass : userTileClass
	{
		private int goldAmount = 0;
		public enum Movement
		{
			MoveUp,
			MoveDown,
			MoveLeft,
			MoveRight,
			NoMovement
		}


																				protected int userHitPoints;
		public int userHp
		{
			get
			{
				return userHitPoints;
			}
			set
			{
				userHitPoints = value;
			}
		}


																				protected int maxHitPoints;
		public int maxUserHp
		{
			get
			{
				return maxHitPoints;
			}
			set
			{
				maxHitPoints = value;
			}
		}



																				protected int publicUserDamage;
		public int userDamage
		{
			get
			{
				return publicUserDamage;
			}
			set
			{
				publicUserDamage = value;
			}
		}



																				protected userTileClass[] userCharacterVision;
		public userTileClass[] overallUserCharacterVision
		{
			get
			{
				return userCharacterVision;
			}
			set
			{
				userCharacterVision = value;
			}
		}



		public CharacterClass(int temphp, int tempmaxHP, int tempdamage, userTileClass[] tempcharacterVision, int x, int y, tileType typetemp) : base(x, y, typetemp)
		{

			this.userHp = temphp;
			this.maxUserHp = tempmaxHP;
			this.userDamage = tempdamage;
			overallUserCharacterVision = tempcharacterVision;

		}



		public CharacterClass(int Xtemp, int Ytemp, tileType typetemp) : base(Xtemp, Ytemp, typetemp)
		{
			// leave for collection 
		}

		public virtual void Attack(CharacterClass target)
		{
			target.setHp(target.getHp() - this.userDamage);
		}




		public bool died()
		{
			if (userHitPoints <= 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}




		public virtual bool overallUserCheckRange(CharacterClass target)
		{
			
			if (DistanceTo(target) > 1)
			{
				return true;
			}

			else

			{
				return false;
			}

		}




		private int DistanceTo(CharacterClass target)
		{
			return (Math.Abs(base.x - target.x) + Math.Abs(base.y - target.y));
		}



		public void Move(Movement move)
		{

			if (move == Movement.MoveUp) { --this.y; }

			else if (move == Movement.MoveDown) { ++this.y; }

			else if (move == Movement.MoveLeft) { --this.x; }

			else if (move == Movement.MoveRight) { ++this.x; }
			
		}




		public abstract override string ToString();

		private int distanceTo(CharacterClass target)
		{
			int x = Math.Abs(target.getX() - this.x);
			int y = Math.Abs(target.getY() - this.y);

			return x + y;
		}




		public void setHp(int hp)
		{
			this.userHp = hp;
			if (hp <= 0)
			{
				hp = 0;
			}
		}



		public int getHp()
		{
			return this.userHp;
		}



		public void setMaxHp(int max_hp)
		{
			this.maxHitPoints = max_hp;
		}



		public int getMaxHp()
		{
			return this.maxHitPoints;
		}



		public void overallUserFinalDamage(int damage)
		{
			this.userDamage = damage;
		}


		public int userDamageFound()
		{
			return this.userDamage;
		}



		public void setUserVision(userTileClass[] characterVision)
		{
			this.userCharacterVision = characterVision;
		}



		public userTileClass[] userFindVision()
		{
			return this.userCharacterVision;
		}


		public abstract Movement returnMove(Movement move = 0);



		public void userPickup(ItemClass i)
		{
			if (i is GoldClass)
			{
				goldAmount += ((GoldClass)i).fetchFinalGoldAmount();
			}
		}



		public int fetchFinalGoldAmount()
		{
			return goldAmount;
		}
		protected Boolean user_locked_vision = false;  




		public void userLockedVision()
		{
			this.user_locked_vision = true;
		}




		public void userUnlockedVision()
		{
			this.user_locked_vision = false;
		}




		public Boolean isUserVisionLocked()
		{
			return this.user_locked_vision;
		}
		






	}
}


