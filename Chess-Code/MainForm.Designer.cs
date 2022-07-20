namespace Chess
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.OpeningPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.buttonRestart = new System.Windows.Forms.Button();
            this.undoButton = new System.Windows.Forms.Button();
            this.ToMainMenu = new System.Windows.Forms.Button();
            this.soundOnOff = new System.Windows.Forms.Button();
            this.OpeningPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpeningPanel
            // 
            this.OpeningPanel.BackColor = System.Drawing.Color.Transparent;
            this.OpeningPanel.Controls.Add(this.label1);
            this.OpeningPanel.Controls.Add(this.button6);
            this.OpeningPanel.Controls.Add(this.button5);
            this.OpeningPanel.Location = new System.Drawing.Point(150, 127);
            this.OpeningPanel.Name = "OpeningPanel";
            this.OpeningPanel.Size = new System.Drawing.Size(358, 266);
            this.OpeningPanel.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 27.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.GhostWhite;
            this.label1.Location = new System.Drawing.Point(45, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 135);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome to Chess!\r\n\r\nPlease select option";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(110, 151);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(122, 39);
            this.button6.TabIndex = 1;
            this.button6.Text = "Human";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(110, 196);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(122, 39);
            this.button5.TabIndex = 0;
            this.button5.Text = "AI";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // buttonRestart
            // 
            this.buttonRestart.Location = new System.Drawing.Point(175, 463);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(87, 29);
            this.buttonRestart.TabIndex = 3;
            this.buttonRestart.Text = "Restart";
            this.buttonRestart.UseVisualStyleBackColor = true;
            this.buttonRestart.Click += new System.EventHandler(this.button4_Click);
            // 
            // undoButton
            // 
            this.undoButton.Location = new System.Drawing.Point(63, 463);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(87, 29);
            this.undoButton.TabIndex = 5;
            this.undoButton.Text = "Undo";
            this.undoButton.UseVisualStyleBackColor = true;
            this.undoButton.Visible = false;
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // ToMainMenu
            // 
            this.ToMainMenu.Location = new System.Drawing.Point(287, 463);
            this.ToMainMenu.Name = "ToMainMenu";
            this.ToMainMenu.Size = new System.Drawing.Size(101, 29);
            this.ToMainMenu.TabIndex = 6;
            this.ToMainMenu.Text = "Return to Menu";
            this.ToMainMenu.UseVisualStyleBackColor = true;
            this.ToMainMenu.Click += new System.EventHandler(this.ToMainMenu_Click);
            // 
            // soundOnOff
            // 
            this.soundOnOff.Image = global::Chess.Properties.Resources._32px_Speaker_Icon_svg;
            this.soundOnOff.Location = new System.Drawing.Point(419, 444);
            this.soundOnOff.Name = "soundOnOff";
            this.soundOnOff.Size = new System.Drawing.Size(48, 48);
            this.soundOnOff.TabIndex = 7;
            this.soundOnOff.Text = "\r\n";
            this.soundOnOff.UseVisualStyleBackColor = true;
            this.soundOnOff.Click += new System.EventHandler(this.soundOnOff_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(653, 525);
            this.Controls.Add(this.soundOnOff);
            this.Controls.Add(this.ToMainMenu);
            this.Controls.Add(this.undoButton);
            this.Controls.Add(this.OpeningPanel);
            this.Controls.Add(this.buttonRestart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Chess";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.OpeningPanel.ResumeLayout(false);
            this.OpeningPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel OpeningPanel;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button buttonRestart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button undoButton;
        private System.Windows.Forms.Button ToMainMenu;
        private System.Windows.Forms.Button soundOnOff;
    }
}