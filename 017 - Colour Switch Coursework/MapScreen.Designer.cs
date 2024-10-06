namespace CourseWork_V1._0._1
{
    partial class MapScreen
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
            this.button1 = new System.Windows.Forms.Button();
            this.Level1Btn = new System.Windows.Forms.Button();
            this.Level2Btn = new System.Windows.Forms.Button();
            this.Level3Btn = new System.Windows.Forms.Button();
            this.Level4Btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Crimson;
            this.button1.Location = new System.Drawing.Point(1683, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(225, 70);
            this.button1.TabIndex = 0;
            this.button1.Text = "Menu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.MoveToMenu);
            // 
            // Level1Btn
            // 
            this.Level1Btn.BackColor = System.Drawing.SystemColors.Control;
            this.Level1Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Level1Btn.Location = new System.Drawing.Point(12, 115);
            this.Level1Btn.Name = "Level1Btn";
            this.Level1Btn.Size = new System.Drawing.Size(150, 150);
            this.Level1Btn.TabIndex = 1;
            this.Level1Btn.Text = "1";
            this.Level1Btn.UseVisualStyleBackColor = false;
            this.Level1Btn.Click += new System.EventHandler(this.LoadLvl1);
            // 
            // Level2Btn
            // 
            this.Level2Btn.BackColor = System.Drawing.SystemColors.Control;
            this.Level2Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Level2Btn.Location = new System.Drawing.Point(168, 115);
            this.Level2Btn.Name = "Level2Btn";
            this.Level2Btn.Size = new System.Drawing.Size(150, 150);
            this.Level2Btn.TabIndex = 2;
            this.Level2Btn.Text = "2";
            this.Level2Btn.UseVisualStyleBackColor = false;
            this.Level2Btn.Click += new System.EventHandler(this.LoadLvl2);
            // 
            // Level3Btn
            // 
            this.Level3Btn.BackColor = System.Drawing.SystemColors.Control;
            this.Level3Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Level3Btn.Location = new System.Drawing.Point(324, 115);
            this.Level3Btn.Name = "Level3Btn";
            this.Level3Btn.Size = new System.Drawing.Size(150, 150);
            this.Level3Btn.TabIndex = 3;
            this.Level3Btn.Text = "3";
            this.Level3Btn.UseVisualStyleBackColor = false;
            this.Level3Btn.Click += new System.EventHandler(this.LoadLvl3);
            // 
            // Level4Btn
            // 
            this.Level4Btn.BackColor = System.Drawing.SystemColors.Control;
            this.Level4Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Level4Btn.Location = new System.Drawing.Point(480, 115);
            this.Level4Btn.Name = "Level4Btn";
            this.Level4Btn.Size = new System.Drawing.Size(150, 150);
            this.Level4Btn.TabIndex = 4;
            this.Level4Btn.Text = "4";
            this.Level4Btn.UseVisualStyleBackColor = false;
            this.Level4Btn.Click += new System.EventHandler(this.Button3_Click);
            // 
            // MapScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.Level4Btn);
            this.Controls.Add(this.Level3Btn);
            this.Controls.Add(this.Level2Btn);
            this.Controls.Add(this.Level1Btn);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MapScreen";
            this.Text = "MapScreen";
            this.Load += new System.EventHandler(this.MapScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Level1Btn;
        private System.Windows.Forms.Button Level2Btn;
        private System.Windows.Forms.Button Level3Btn;
        private System.Windows.Forms.Button Level4Btn;
    }
}