using System;
using System.Drawing;
using System.Windows.Forms;

namespace James_Gericke_19011601_GADE6112_Task1A
{
	public partial class PlayGame : Form
	{
		private Form1 caller;
		private GameEngineClass ge;
		private int width;
		private int height;

		public PlayGame(int min_width, int max_width, int min_height, int max_height, int num_enemies, bool loadGame, int gold)
		{
			InitializeComponent();
			if (!loadGame)
			{
				ge = new GameEngineClass(min_width, max_width, min_height, max_height, num_enemies, gold);
				width = ge.getWidth();
				height = ge.getHeight();
			}
			else
			{
				ge = new GameEngineClass();
				ge.setMap(GameEngineClass.loadGame());
				width = ge.getWidth();
				height = ge.getHeight();
			}
			redraw();

		}
		public void setCaller(Form1 caller)
		{
			this.caller = caller;
		}

		private void actionStatus(String action, Boolean success, String meta)
		{
			if (success)
			{
				if (action.Substring(0, 6) == "attack")
				{
					lblActionStatus.ForeColor = Color.Green;
					lblActionStatus.Text = "Action successful!";
					lblActionStatus.Text += '\n' + meta;
				}
				redraw();
			}
			else
			{
				lblActionStatus.ForeColor = Color.Red;
				lblActionStatus.Text = "You cannot " + action;
			}
		}

		private void redraw()
		{
			updateMap();
			updatePlayerStats(ge.getHeroStats());
			updateEnemiesRemaining(ge.getEnemiesRemaining());


		}

		private void updateMap()
		{
			userTileClass[,] view = ge.getMapView();
			string textview = "";

			for (int i = 0; i < height; ++i)
			{
				for (int j = 0; j < width; ++j)
				{
					textview += this.getRepresentation(view[i, j]) + (j == (width - 1) ? "" : " ");
				}
				textview += '\n';
			}

			lblMapView.Text = textview;
		}

		private void updatePlayerStats(String info)
		{
			lblHeroStats.Text = info;
		}

		private void updateEnemiesRemaining(String info)
		{
			lblEnemiesRemaining.Text = info;
		}

		private char getRepresentation(userTileClass type)
		{
			if (type is emptyUserTileClass)
			{
				return '.';
			}
			else if (type is HeroClass)
			{
				if (ge.getMap().provideHero().died())
				{
					return '.';
				}
				else
				{
					return 'H';
				}
			}
			else if (type is GoblinClass)
			{
				return 'G';
			}
			else if (type is MagesClass)
			{
				return 'M';
			}
			else if (type is GoldClass)
			{
				return '$';
			}
			else
			{
				return 'X';
			}
		}

		private void PlayGame_Load(object sender, EventArgs e)
		{


		}

		private void btnUp_Click_1(object sender, EventArgs e)
		{
			actionStatus("move up", ge.movementOfPlayer(CharacterClass.Movement.MoveUp), "");
		}

		private void btnLeft_Click_1(object sender, EventArgs e)
		{
			actionStatus("move left", ge.movementOfPlayer(CharacterClass.Movement.MoveLeft), "");
		}

		private void btnDown_Click_1(object sender, EventArgs e)
		{
			actionStatus("move down", ge.movementOfPlayer(CharacterClass.Movement.MoveDown), "");
		}

		private void btnRight_Click_1(object sender, EventArgs e)
		{
			actionStatus("move right", ge.movementOfPlayer(CharacterClass.Movement.MoveRight), "");
		}

		private void btnAttackUp_Click(object sender, EventArgs e)
		{
			String response = ge.attackEnemy(CharacterClass.Movement.MoveUp);
			Boolean success = false;
			if (response[0] == '1')
			{
				success = true;
			}
			actionStatus("attack up", success, response.Substring(1));
		}

		private void btnAttackLeft_Click(object sender, EventArgs e)
		{
			String response = ge.attackEnemy(CharacterClass.Movement.MoveLeft);
			Boolean success = false;
			if (response[0] == '1')
			{
				success = true;
			}
			actionStatus("attack left", success, response.Substring(1));
		}

		private void btnAttackDown_Click(object sender, EventArgs e)
		{
			String response = ge.attackEnemy(CharacterClass.Movement.MoveDown);
			Boolean success = false;
			if (response[0] == '1')
			{
				success = true;
			}
			actionStatus("attack down", success, response.Substring(1));
		}

		private void btnAttackRight_Click(object sender, EventArgs e)
		{
			String response = ge.attackEnemy(CharacterClass.Movement.MoveRight);
			Boolean success = false;
			if (response[0] == '1')
			{
				success = true;
			}
			actionStatus("attack right", success, response.Substring(1));
		}

		private void btnSaveGame_Click(object sender, EventArgs e)
		{
			ge.saveGame();
		}
	}

}
