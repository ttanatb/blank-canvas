namespace stage_builder
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
            this.stagenamelabel = new System.Windows.Forms.Label();
            this.stagenamebox = new System.Windows.Forms.TextBox();
            this.levelnumberbox = new System.Windows.Forms.TextBox();
            this.stagelevellabel = new System.Windows.Forms.Label();
            this.StageBuilderTitle = new System.Windows.Forms.Label();
            this.stagebuildertextbox = new System.Windows.Forms.TextBox();
            this.stagebuilderlabel = new System.Windows.Forms.Label();
            this.keyLabel = new System.Windows.Forms.Label();
            this.keyBox = new System.Windows.Forms.TextBox();
            this.compilebutton = new System.Windows.Forms.Button();
            this.fileExistsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // stagenamelabel
            // 
            this.stagenamelabel.AutoSize = true;
            this.stagenamelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.stagenamelabel.Location = new System.Drawing.Point(0, 62);
            this.stagenamelabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.stagenamelabel.Name = "stagenamelabel";
            this.stagenamelabel.Size = new System.Drawing.Size(164, 25);
            this.stagenamelabel.TabIndex = 0;
            this.stagenamelabel.Text = "Stage/File Name:";
            // 
            // stagenamebox
            // 
            this.stagenamebox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.stagenamebox.Location = new System.Drawing.Point(183, 62);
            this.stagenamebox.Margin = new System.Windows.Forms.Padding(4);
            this.stagenamebox.Name = "stagenamebox";
            this.stagenamebox.Size = new System.Drawing.Size(253, 30);
            this.stagenamebox.TabIndex = 1;
            this.stagenamebox.TextChanged += new System.EventHandler(this.stagenamebox_TextChanged);
            // 
            // levelnumberbox
            // 
            this.levelnumberbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.levelnumberbox.Location = new System.Drawing.Point(183, 102);
            this.levelnumberbox.Margin = new System.Windows.Forms.Padding(4);
            this.levelnumberbox.Name = "levelnumberbox";
            this.levelnumberbox.Size = new System.Drawing.Size(32, 30);
            this.levelnumberbox.TabIndex = 2;
            // 
            // stagelevellabel
            // 
            this.stagelevellabel.AutoSize = true;
            this.stagelevellabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.stagelevellabel.Location = new System.Drawing.Point(25, 105);
            this.stagelevellabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.stagelevellabel.Name = "stagelevellabel";
            this.stagelevellabel.Size = new System.Drawing.Size(139, 25);
            this.stagelevellabel.TabIndex = 3;
            this.stagelevellabel.Text = "Level Number:";
            // 
            // StageBuilderTitle
            // 
            this.StageBuilderTitle.AutoSize = true;
            this.StageBuilderTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StageBuilderTitle.Location = new System.Drawing.Point(229, 11);
            this.StageBuilderTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StageBuilderTitle.Name = "StageBuilderTitle";
            this.StageBuilderTitle.Size = new System.Drawing.Size(341, 31);
            this.StageBuilderTitle.TabIndex = 4;
            this.StageBuilderTitle.Text = "Stage Builder Application";
            // 
            // stagebuildertextbox
            // 
            this.stagebuildertextbox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stagebuildertextbox.Location = new System.Drawing.Point(237, 186);
            this.stagebuildertextbox.Margin = new System.Windows.Forms.Padding(4);
            this.stagebuildertextbox.Multiline = true;
            this.stagebuildertextbox.Name = "stagebuildertextbox";
            this.stagebuildertextbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.stagebuildertextbox.Size = new System.Drawing.Size(544, 328);
            this.stagebuildertextbox.TabIndex = 5;
            this.stagebuildertextbox.WordWrap = false;
            // 
            // stagebuilderlabel
            // 
            this.stagebuilderlabel.AutoSize = true;
            this.stagebuilderlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stagebuilderlabel.Location = new System.Drawing.Point(377, 160);
            this.stagebuilderlabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.stagebuilderlabel.Name = "stagebuilderlabel";
            this.stagebuilderlabel.Size = new System.Drawing.Size(234, 25);
            this.stagebuilderlabel.TabIndex = 6;
            this.stagebuilderlabel.Text = "Stage Builder Text Box";
            // 
            // keyLabel
            // 
            this.keyLabel.AutoSize = true;
            this.keyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyLabel.Location = new System.Drawing.Point(95, 160);
            this.keyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.keyLabel.Name = "keyLabel";
            this.keyLabel.Size = new System.Drawing.Size(50, 25);
            this.keyLabel.TabIndex = 7;
            this.keyLabel.Text = "Key";
            // 
            // keyBox
            // 
            this.keyBox.Font = new System.Drawing.Font("Courier New", 10F);
            this.keyBox.Location = new System.Drawing.Point(17, 188);
            this.keyBox.Margin = new System.Windows.Forms.Padding(4);
            this.keyBox.Multiline = true;
            this.keyBox.Name = "keyBox";
            this.keyBox.ReadOnly = true;
            this.keyBox.Size = new System.Drawing.Size(209, 328);
            this.keyBox.TabIndex = 8;
            this.keyBox.Text = "Tiles:\r\n     Blank Tile\r\n_    Ground Tile\r\nP    Player\r\nE    Enemy\r\no    Puzzle O" +
    "rb\r\n0    End Orb\r\n|    Door\r\n\r\nFormat:\r\n/    Y-axis advance\r\n\r\n";
            // 
            // compilebutton
            // 
            this.compilebutton.Location = new System.Drawing.Point(616, 523);
            this.compilebutton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.compilebutton.Name = "compilebutton";
            this.compilebutton.Size = new System.Drawing.Size(165, 47);
            this.compilebutton.TabIndex = 9;
            this.compilebutton.Text = "Compile in Text File";
            this.compilebutton.UseVisualStyleBackColor = true;
            this.compilebutton.Click += new System.EventHandler(this.compilebutton_Click);
            // 
            // fileExistsButton
            // 
            this.fileExistsButton.Location = new System.Drawing.Point(237, 523);
            this.fileExistsButton.Name = "fileExistsButton";
            this.fileExistsButton.Size = new System.Drawing.Size(166, 47);
            this.fileExistsButton.TabIndex = 13;
            this.fileExistsButton.Text = "Load in File (if it exists)";
            this.fileExistsButton.UseVisualStyleBackColor = true;
            this.fileExistsButton.Click += new System.EventHandler(this.fileExistsButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 580);
            this.Controls.Add(this.fileExistsButton);
            this.Controls.Add(this.compilebutton);
            this.Controls.Add(this.keyBox);
            this.Controls.Add(this.keyLabel);
            this.Controls.Add(this.stagebuilderlabel);
            this.Controls.Add(this.stagebuildertextbox);
            this.Controls.Add(this.StageBuilderTitle);
            this.Controls.Add(this.stagelevellabel);
            this.Controls.Add(this.levelnumberbox);
            this.Controls.Add(this.stagenamebox);
            this.Controls.Add(this.stagenamelabel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Stage Builder - Blank ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label stagenamelabel;
        private System.Windows.Forms.TextBox levelnumberbox;
        private System.Windows.Forms.Label stagelevellabel;
        private System.Windows.Forms.TextBox stagenamebox;
        private System.Windows.Forms.Label StageBuilderTitle;
        private System.Windows.Forms.TextBox stagebuildertextbox;
        private System.Windows.Forms.Label stagebuilderlabel;
        private System.Windows.Forms.Label keyLabel;
        private System.Windows.Forms.TextBox keyBox;
        private System.Windows.Forms.Button compilebutton;
        private System.Windows.Forms.Button fileExistsButton;
    }
}

