namespace Birthdays
{
    partial class TodayBirthdays
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTodayBirths = new System.Windows.Forms.TextBox();
            this.textBoxComingBirths = new System.Windows.Forms.TextBox();
            this.buttonMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto Medium", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(58, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Today";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto Medium", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(422, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 39);
            this.label2.TabIndex = 1;
            this.label2.Text = "Coming Soon";
            // 
            // textBoxTodayBirths
            // 
            this.textBoxTodayBirths.Font = new System.Drawing.Font("Roboto Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTodayBirths.Location = new System.Drawing.Point(32, 72);
            this.textBoxTodayBirths.Multiline = true;
            this.textBoxTodayBirths.Name = "textBoxTodayBirths";
            this.textBoxTodayBirths.Size = new System.Drawing.Size(194, 386);
            this.textBoxTodayBirths.TabIndex = 2;
            this.textBoxTodayBirths.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBoxComingBirths
            // 
            this.textBoxComingBirths.Font = new System.Drawing.Font("Roboto Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxComingBirths.Location = new System.Drawing.Point(340, 72);
            this.textBoxComingBirths.Multiline = true;
            this.textBoxComingBirths.Name = "textBoxComingBirths";
            this.textBoxComingBirths.Size = new System.Drawing.Size(412, 386);
            this.textBoxComingBirths.TabIndex = 3;
            this.textBoxComingBirths.TextChanged += new System.EventHandler(this.textBoxComingBirths_TextChanged);
            // 
            // buttonMenu
            // 
            this.buttonMenu.Font = new System.Drawing.Font("Roboto Medium", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMenu.Location = new System.Drawing.Point(305, 488);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(174, 62);
            this.buttonMenu.TabIndex = 4;
            this.buttonMenu.Text = "Menu";
            this.buttonMenu.UseVisualStyleBackColor = true;
            this.buttonMenu.Click += new System.EventHandler(this.buttonMenu_Click);
            // 
            // TodayBirthdays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 574);
            this.Controls.Add(this.buttonMenu);
            this.Controls.Add(this.textBoxComingBirths);
            this.Controls.Add(this.textBoxTodayBirths);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TodayBirthdays";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTodayBirths;
        private System.Windows.Forms.TextBox textBoxComingBirths;
        private System.Windows.Forms.Button buttonMenu;
    }
}