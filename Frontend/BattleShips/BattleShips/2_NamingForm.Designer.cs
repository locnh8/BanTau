namespace BattleShips
{
    partial class NamingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NamingForm));
            btnQuaylai = new Button();
            btnXacnhan = new Button();
            label1 = new Label();
            txtName = new TextBox();
            SuspendLayout();
            // 
            // btnQuaylai
            // 
            btnQuaylai.BackColor = Color.Transparent;
            btnQuaylai.FlatAppearance.BorderSize = 0;
            btnQuaylai.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnQuaylai.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnQuaylai.FlatStyle = FlatStyle.Flat;
            btnQuaylai.Font = new Font("Algerian", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnQuaylai.Location = new Point(264, 257);
            btnQuaylai.Name = "btnQuaylai";
            btnQuaylai.Size = new Size(121, 47);
            btnQuaylai.TabIndex = 0;
            btnQuaylai.Text = "Back";
            btnQuaylai.UseVisualStyleBackColor = false;
            btnQuaylai.Click += btnQuaylai_Click;
            // 
            // btnXacnhan
            // 
            btnXacnhan.BackColor = Color.Transparent;
            btnXacnhan.FlatAppearance.BorderSize = 0;
            btnXacnhan.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnXacnhan.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnXacnhan.FlatStyle = FlatStyle.Flat;
            btnXacnhan.Font = new Font("Algerian", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXacnhan.Location = new Point(467, 257);
            btnXacnhan.Name = "btnXacnhan";
            btnXacnhan.Size = new Size(121, 47);
            btnXacnhan.TabIndex = 1;
            btnXacnhan.Text = "Confirm";
            btnXacnhan.UseVisualStyleBackColor = false;
            btnXacnhan.Click += btnXacnhan_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Algerian", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(184, 154);
            label1.Name = "label1";
            label1.Size = new Size(74, 22);
            label1.TabIndex = 2;
            label1.Text = "Name:";
            // 
            // txtName
            // 
            txtName.Font = new Font("Algerian", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtName.Location = new Point(264, 151);
            txtName.Multiline = true;
            txtName.Name = "txtName";
            txtName.Size = new Size(324, 34);
            txtName.TabIndex = 3;
            // 
            // NamingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(txtName);
            Controls.Add(label1);
            Controls.Add(btnXacnhan);
            Controls.Add(btnQuaylai);
            Name = "NamingForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnQuaylai;
        private Button btnXacnhan;
        private Label label1;
        private TextBox txtName;
    }
}