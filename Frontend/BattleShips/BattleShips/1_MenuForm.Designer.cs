namespace BattleShips
{
    partial class MenuForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            btnChoi = new Button();
            BtnLuat = new Button();
            btnThoat = new Button();
            SuspendLayout();
            // 
            // btnChoi
            // 
            btnChoi.BackColor = Color.Transparent;
            btnChoi.FlatAppearance.BorderSize = 0;
            btnChoi.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnChoi.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnChoi.FlatStyle = FlatStyle.Flat;
            btnChoi.Font = new Font("Algerian", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChoi.Location = new Point(102, 105);
            btnChoi.Name = "btnChoi";
            btnChoi.Size = new Size(123, 48);
            btnChoi.TabIndex = 0;
            btnChoi.Text = "Play";
            btnChoi.UseVisualStyleBackColor = false;
            btnChoi.Click += button1_Click;
            // 
            // BtnLuat
            // 
            BtnLuat.BackColor = Color.Transparent;
            BtnLuat.FlatAppearance.BorderSize = 0;
            BtnLuat.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnLuat.FlatAppearance.MouseOverBackColor = Color.Transparent;
            BtnLuat.FlatStyle = FlatStyle.Flat;
            BtnLuat.Font = new Font("Algerian", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnLuat.Location = new Point(102, 179);
            BtnLuat.Name = "BtnLuat";
            BtnLuat.Size = new Size(123, 48);
            BtnLuat.TabIndex = 1;
            BtnLuat.Text = "Guide ";
            BtnLuat.UseVisualStyleBackColor = false;
            BtnLuat.Click += BtnLuat_Click;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.Transparent;
            btnThoat.FlatAppearance.BorderSize = 0;
            btnThoat.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnThoat.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.Font = new Font("Algerian", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThoat.Location = new Point(102, 253);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(123, 48);
            btnThoat.TabIndex = 2;
            btnThoat.Text = "Exit";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += button3_Click;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(btnThoat);
            Controls.Add(BtnLuat);
            Controls.Add(btnChoi);
            Name = "MenuForm";
            Text = "Menu";
            ResumeLayout(false);
        }

        #endregion

        private Button btnChoi;
        private Button BtnLuat;
        private Button btnThoat;
    }
}
