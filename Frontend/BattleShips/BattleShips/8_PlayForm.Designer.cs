namespace BattleShips
{
    partial class PlayForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayForm));
            pBoxMe = new PictureBox();
            pBoxDeskMe = new PictureBox();
            pBoxDeskEnemy = new PictureBox();
            pBoxEnemy = new PictureBox();
            textBox1 = new TextBox();
            label1 = new Label();
            btnExit = new Button();
            lbMyName = new Label();
            lbEnemyName = new Label();
            meProgress = new ProgressBar();
            enemyprogress = new ProgressBar();
            afkTimer = new System.Windows.Forms.Timer(components);
            avtTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pBoxMe).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pBoxDeskMe).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pBoxDeskEnemy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pBoxEnemy).BeginInit();
            SuspendLayout();
            // 
            // pBoxMe
            // 
            pBoxMe.BackgroundImage = Properties.Resources.boat;
            pBoxMe.BackgroundImageLayout = ImageLayout.Stretch;
            pBoxMe.Location = new Point(200, 39);
            pBoxMe.Name = "pBoxMe";
            pBoxMe.Size = new Size(110, 76);
            pBoxMe.TabIndex = 0;
            pBoxMe.TabStop = false;
            // 
            // pBoxDeskMe
            // 
            pBoxDeskMe.BackgroundImage = Properties.Resources.bg;
            pBoxDeskMe.BackgroundImageLayout = ImageLayout.Stretch;
            pBoxDeskMe.Location = new Point(226, -85);
            pBoxDeskMe.Name = "pBoxDeskMe";
            pBoxDeskMe.Size = new Size(396, 396);
            pBoxDeskMe.TabIndex = 1;
            pBoxDeskMe.TabStop = false;
            pBoxDeskMe.Paint += pBoxDeskMe_Paint;
            // 
            // pBoxDeskEnemy
            // 
            pBoxDeskEnemy.BackgroundImage = (Image)resources.GetObject("pBoxDeskEnemy.BackgroundImage");
            pBoxDeskEnemy.BackgroundImageLayout = ImageLayout.Stretch;
            pBoxDeskEnemy.Location = new Point(661, 135);
            pBoxDeskEnemy.Name = "pBoxDeskEnemy";
            pBoxDeskEnemy.Size = new Size(396, 396);
            pBoxDeskEnemy.TabIndex = 2;
            pBoxDeskEnemy.TabStop = false;
            pBoxDeskEnemy.Click += pBoxDeskEnemy_Click;
            pBoxDeskEnemy.Paint += pBoxDeskEnemy_Paint;
            pBoxDeskEnemy.MouseMove += pBoxDeskEnemy_MouseMove;
            // 
            // pBoxEnemy
            // 
            pBoxEnemy.BackgroundImage = Properties.Resources.user;
            pBoxEnemy.BackgroundImageLayout = ImageLayout.Stretch;
            pBoxEnemy.Location = new Point(729, 32);
            pBoxEnemy.Name = "pBoxEnemy";
            pBoxEnemy.Size = new Size(110, 76);
            pBoxEnemy.TabIndex = 3;
            pBoxEnemy.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.White;
            textBox1.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            textBox1.Location = new Point(35, 63);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(140, 397);
            textBox1.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Algerian", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(35, 39);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 5;
            label1.Text = "Chat";
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Transparent;
            btnExit.BackgroundImage = (Image)resources.GetObject("btnExit.BackgroundImage");
            btnExit.BackgroundImageLayout = ImageLayout.Zoom;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnExit.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Location = new Point(0, 0);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(34, 30);
            btnExit.TabIndex = 6;
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // lbMyName
            // 
            lbMyName.AutoSize = true;
            lbMyName.BackColor = Color.Transparent;
            lbMyName.FlatStyle = FlatStyle.Flat;
            lbMyName.Font = new Font("Algerian", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbMyName.Location = new Point(200, 10);
            lbMyName.Name = "lbMyName";
            lbMyName.Size = new Size(62, 20);
            lbMyName.TabIndex = 7;
            lbMyName.Text = "Name";
            // 
            // lbEnemyName
            // 
            lbEnemyName.AutoSize = true;
            lbEnemyName.BackColor = Color.Transparent;
            lbEnemyName.FlatStyle = FlatStyle.Flat;
            lbEnemyName.Font = new Font("Algerian", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbEnemyName.Location = new Point(777, 9);
            lbEnemyName.Name = "lbEnemyName";
            lbEnemyName.Size = new Size(62, 20);
            lbEnemyName.TabIndex = 8;
            lbEnemyName.Text = "Name";
            // 
            // meProgress
            // 
            meProgress.Location = new Point(200, 136);
            meProgress.Name = "meProgress";
            meProgress.Size = new Size(338, 10);
            meProgress.TabIndex = 9;
            // 
            // enemyprogress
            // 
            enemyprogress.Location = new Point(684, 134);
            enemyprogress.Name = "enemyprogress";
            enemyprogress.Size = new Size(338, 12);
            enemyprogress.TabIndex = 10;
            // 
            // afkTimer
            // 
            afkTimer.Tick += afkTimer_Tick;
            // 
            // avtTimer
            // 
            avtTimer.Tick += avtTimer_Tick;
            // 
            // PlayForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1081, 549);
            Controls.Add(enemyprogress);
            Controls.Add(meProgress);
            Controls.Add(lbEnemyName);
            Controls.Add(lbMyName);
            Controls.Add(btnExit);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(pBoxEnemy);
            Controls.Add(pBoxDeskEnemy);
            Controls.Add(pBoxDeskMe);
            Controls.Add(pBoxMe);
            Name = "PlayForm";
            Load += PlayForm_Load;
            ((System.ComponentModel.ISupportInitialize)pBoxMe).EndInit();
            ((System.ComponentModel.ISupportInitialize)pBoxDeskMe).EndInit();
            ((System.ComponentModel.ISupportInitialize)pBoxDeskEnemy).EndInit();
            ((System.ComponentModel.ISupportInitialize)pBoxEnemy).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pBoxMe;
        private PictureBox pBoxDeskMe;
        private PictureBox pBoxDeskEnemy;
        private PictureBox pBoxEnemy;
        private TextBox textBox1;
        private Label label1;
        private Button btnExit;
        private Label lbMyName;
        private Label lbEnemyName;
        private ProgressBar meProgress;
        private ProgressBar enemyprogress;
        private System.Windows.Forms.Timer afkTimer;
        private System.Windows.Forms.Timer avtTimer;
        private System.Windows.Forms.PictureBox winlostPBox;
    }
}