﻿namespace James_Gericke_19011601_GADE6112_Task1A
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.btnStartGame = new System.Windows.Forms.Button();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.lblMinHeight = new System.Windows.Forms.Label();
            this.lblMaxHeight = new System.Windows.Forms.Label();
            this.lblMinWidth = new System.Windows.Forms.Label();
            this.lblMaxWidth = new System.Windows.Forms.Label();
            this.edtMinWidth = new System.Windows.Forms.TextBox();
            this.edtMinHeight = new System.Windows.Forms.TextBox();
            this.edtMaxWidth = new System.Windows.Forms.TextBox();
            this.edtMaxHeight = new System.Windows.Forms.TextBox();
            this.lblEnemies = new System.Windows.Forms.Label();
            this.edtEnemies = new System.Windows.Forms.TextBox();
            this.btnLoadGame = new System.Windows.Forms.Button();
            this.lblGold = new System.Windows.Forms.Label();
            this.edtGold = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStartGame
            // 
            this.btnStartGame.Location = new System.Drawing.Point(33, 356);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(576, 184);
            this.btnStartGame.TabIndex = 0;
            this.btnStartGame.Text = "StartGame";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.AutoSize = true;
            this.lblErrorMessage.Location = new System.Drawing.Point(182, 255);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(0, 18);
            this.lblErrorMessage.TabIndex = 1;
            // 
            // lblMinHeight
            // 
            this.lblMinHeight.AutoSize = true;
            this.lblMinHeight.Location = new System.Drawing.Point(48, 101);
            this.lblMinHeight.Name = "lblMinHeight";
            this.lblMinHeight.Size = new System.Drawing.Size(78, 18);
            this.lblMinHeight.TabIndex = 1;
            this.lblMinHeight.Text = "Min Height";
            this.lblMinHeight.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblMaxHeight
            // 
            this.lblMaxHeight.AutoSize = true;
            this.lblMaxHeight.Location = new System.Drawing.Point(308, 101);
            this.lblMaxHeight.Name = "lblMaxHeight";
            this.lblMaxHeight.Size = new System.Drawing.Size(82, 18);
            this.lblMaxHeight.TabIndex = 1;
            this.lblMaxHeight.Text = "Max Height";
            // 
            // lblMinWidth
            // 
            this.lblMinWidth.AutoSize = true;
            this.lblMinWidth.Location = new System.Drawing.Point(48, 47);
            this.lblMinWidth.Name = "lblMinWidth";
            this.lblMinWidth.Size = new System.Drawing.Size(74, 18);
            this.lblMinWidth.TabIndex = 1;
            this.lblMinWidth.Text = "Min Width";
            // 
            // lblMaxWidth
            // 
            this.lblMaxWidth.AutoSize = true;
            this.lblMaxWidth.Location = new System.Drawing.Point(308, 47);
            this.lblMaxWidth.Name = "lblMaxWidth";
            this.lblMaxWidth.Size = new System.Drawing.Size(78, 18);
            this.lblMaxWidth.TabIndex = 1;
            this.lblMaxWidth.Text = "Max Width";
            // 
            // edtMinWidth
            // 
            this.edtMinWidth.Location = new System.Drawing.Point(134, 42);
            this.edtMinWidth.Name = "edtMinWidth";
            this.edtMinWidth.Size = new System.Drawing.Size(112, 24);
            this.edtMinWidth.TabIndex = 2;
            // 
            // edtMinHeight
            // 
            this.edtMinHeight.Location = new System.Drawing.Point(134, 98);
            this.edtMinHeight.Name = "edtMinHeight";
            this.edtMinHeight.Size = new System.Drawing.Size(112, 24);
            this.edtMinHeight.TabIndex = 2;
            // 
            // edtMaxWidth
            // 
            this.edtMaxWidth.Location = new System.Drawing.Point(396, 42);
            this.edtMaxWidth.Name = "edtMaxWidth";
            this.edtMaxWidth.Size = new System.Drawing.Size(112, 24);
            this.edtMaxWidth.TabIndex = 2;
            // 
            // edtMaxHeight
            // 
            this.edtMaxHeight.Location = new System.Drawing.Point(396, 96);
            this.edtMaxHeight.Name = "edtMaxHeight";
            this.edtMaxHeight.Size = new System.Drawing.Size(112, 24);
            this.edtMaxHeight.TabIndex = 2;
            // 
            // lblEnemies
            // 
            this.lblEnemies.AutoSize = true;
            this.lblEnemies.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnemies.Location = new System.Drawing.Point(48, 190);
            this.lblEnemies.Name = "lblEnemies";
            this.lblEnemies.Size = new System.Drawing.Size(140, 18);
            this.lblEnemies.TabIndex = 1;
            this.lblEnemies.Text = "Number of Enemies";
            this.lblEnemies.Click += new System.EventHandler(this.label2_Click);
            // 
            // edtEnemies
            // 
            this.edtEnemies.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtEnemies.Location = new System.Drawing.Point(204, 186);
            this.edtEnemies.Name = "edtEnemies";
            this.edtEnemies.Size = new System.Drawing.Size(112, 24);
            this.edtEnemies.TabIndex = 2;
            this.edtEnemies.TextChanged += new System.EventHandler(this.edtEnemies_TextChanged);
            // 
            // btnLoadGame
            // 
            this.btnLoadGame.Location = new System.Drawing.Point(622, 12);
            this.btnLoadGame.Name = "btnLoadGame";
            this.btnLoadGame.Size = new System.Drawing.Size(341, 122);
            this.btnLoadGame.TabIndex = 3;
            this.btnLoadGame.Text = "Load previous game";
            this.btnLoadGame.UseVisualStyleBackColor = true;
            this.btnLoadGame.Click += new System.EventHandler(this.btnLoadGame_Click);
            // 
            // lblGold
            // 
            this.lblGold.AutoSize = true;
            this.lblGold.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGold.Location = new System.Drawing.Point(48, 255);
            this.lblGold.Name = "lblGold";
            this.lblGold.Size = new System.Drawing.Size(95, 18);
            this.lblGold.TabIndex = 1;
            this.lblGold.Text = "Gold Amount";
            this.lblGold.Click += new System.EventHandler(this.label2_Click);
            // 
            // edtGold
            // 
            this.edtGold.Location = new System.Drawing.Point(204, 255);
            this.edtGold.Name = "edtGold";
            this.edtGold.Size = new System.Drawing.Size(112, 24);
            this.edtGold.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 568);
            this.Controls.Add(this.btnLoadGame);
            this.Controls.Add(this.edtMaxHeight);
            this.Controls.Add(this.edtMaxWidth);
            this.Controls.Add(this.edtGold);
            this.Controls.Add(this.edtEnemies);
            this.Controls.Add(this.edtMinHeight);
            this.Controls.Add(this.edtMinWidth);
            this.Controls.Add(this.lblMaxWidth);
            this.Controls.Add(this.lblMinWidth);
            this.Controls.Add(this.lblGold);
            this.Controls.Add(this.lblEnemies);
            this.Controls.Add(this.lblMaxHeight);
            this.Controls.Add(this.lblMinHeight);
            this.Controls.Add(this.lblErrorMessage);
            this.Controls.Add(this.btnStartGame);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Game Menu";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnStartGame;
		private System.Windows.Forms.Label lblErrorMessage;
		private System.Windows.Forms.Label lblMinHeight;
		private System.Windows.Forms.Label lblMaxHeight;
		private System.Windows.Forms.Label lblMinWidth;
		private System.Windows.Forms.Label lblMaxWidth;
		private System.Windows.Forms.TextBox edtMinWidth;
		private System.Windows.Forms.TextBox edtMinHeight;
		private System.Windows.Forms.TextBox edtMaxWidth;
		private System.Windows.Forms.TextBox edtMaxHeight;
		private System.Windows.Forms.Label lblEnemies;
		private System.Windows.Forms.TextBox edtEnemies;
		private System.Windows.Forms.Button btnLoadGame;
		private System.Windows.Forms.Label lblGold;
		private System.Windows.Forms.TextBox edtGold;
	}
}

