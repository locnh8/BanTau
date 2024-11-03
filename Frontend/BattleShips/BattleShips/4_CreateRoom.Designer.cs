namespace BattleShips
{
    partial class CreateRoom
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
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            btnBack = new Button();
            dataGridView1 = new DataGridView();
            RoomID = new DataGridViewTextBoxColumn();
            PlayerCount = new DataGridViewTextBoxColumn();
            Join = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.BackgroundImage = Properties.Resources.button;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Algerian", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(276, 73);
            button1.Name = "button1";
            button1.Size = new Size(252, 53);
            button1.TabIndex = 0;
            button1.Text = "Create a room";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.BackgroundImage = Properties.Resources.button;
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Algerian", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(496, 142);
            button2.Name = "button2";
            button2.Size = new Size(129, 37);
            button2.TabIndex = 1;
            button2.Text = "Confirm";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Algerian", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Image = Properties.Resources.button;
            label1.Location = new Point(187, 149);
            label1.Name = "label1";
            label1.Size = new Size(98, 22);
            label1.TabIndex = 2;
            label1.Text = "ROom ID:";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Algerian", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(291, 148);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(199, 31);
            textBox1.TabIndex = 3;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Transparent;
            btnBack.BackgroundImage = Properties.Resources.button;
            btnBack.BackgroundImageLayout = ImageLayout.Stretch;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnBack.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Algerian", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.Location = new Point(1, 3);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 33);
            btnBack.TabIndex = 4;
            btnBack.Text = "BACK";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { RoomID, PlayerCount, Join });
            dataGridView1.Location = new Point(187, 226);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(427, 188);
            dataGridView1.TabIndex = 5;
            // 
            // RoomID
            // 
            RoomID.HeaderText = "RoomID";
            RoomID.MinimumWidth = 6;
            RoomID.Name = "RoomID";
            RoomID.ReadOnly = true;
            RoomID.Resizable = DataGridViewTriState.True;
            RoomID.Width = 125;
            // 
            // PlayerCount
            // 
            PlayerCount.HeaderText = "PlayerCount";
            PlayerCount.MinimumWidth = 6;
            PlayerCount.Name = "PlayerCount";
            PlayerCount.ReadOnly = true;
            PlayerCount.Width = 125;
            // 
            // Join
            // 
            Join.HeaderText = "Join";
            Join.MinimumWidth = 6;
            Join.Name = "Join";
            Join.Resizable = DataGridViewTriState.True;
            Join.SortMode = DataGridViewColumnSortMode.Automatic;
            Join.Width = 125;
            // 
            // CreateRoom
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bantau;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(btnBack);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "CreateRoom";
            Text = "Create Room";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Label label1;
        private TextBox textBox1;
        private Button btnBack;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn RoomID;
        private DataGridViewTextBoxColumn PlayerCount;
        private DataGridViewButtonColumn Join;
    }
}