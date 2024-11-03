namespace BattleShips
{
    partial class GuideForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuideForm));
            btnQuayLai = new Button();
            label2 = new Label();
            panel1 = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnQuayLai
            // 
            btnQuayLai.BackColor = Color.Transparent;
            btnQuayLai.FlatAppearance.BorderSize = 0;
            btnQuayLai.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnQuayLai.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnQuayLai.FlatStyle = FlatStyle.Flat;
            btnQuayLai.Font = new Font("Algerian", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnQuayLai.ForeColor = Color.Black;
            btnQuayLai.Location = new Point(-10, 2);
            btnQuayLai.Name = "btnQuayLai";
            btnQuayLai.Size = new Size(187, 50);
            btnQuayLai.TabIndex = 0;
            btnQuayLai.Text = "Back";
            btnQuayLai.UseVisualStyleBackColor = false;
            btnQuayLai.Click += btnQuayLai_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Algerian", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(343, 9);
            label2.Name = "label2";
            label2.Size = new Size(104, 34);
            label2.TabIndex = 2;
            label2.Text = "Guide";
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Location = new Point(34, 58);
            panel1.Name = "panel1";
            panel1.Size = new Size(721, 485);
            panel1.TabIndex = 7;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Dock = DockStyle.Fill;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Algerian", 16.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(721, 485);
            label1.TabIndex = 7;
            label1.Text = resources.GetString("label1.Text");
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GuideForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.onepiece_ship;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(801, 543);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(btnQuayLai);
            Name = "GuideForm";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnQuayLai;
        private Label label2;
        private Panel panel1;
        private Label label1;
    }
}