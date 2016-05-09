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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.stagenamelabel.Location = new System.Drawing.Point(0, 73);
            this.stagenamelabel.Name = "stagenamelabel";
            this.stagenamelabel.Size = new System.Drawing.Size(131, 20);
            this.stagenamelabel.TabIndex = 0;
            this.stagenamelabel.Text = "Stage/File Name:";
            // 
            // stagenamebox
            // 
            this.stagenamebox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.stagenamebox.Location = new System.Drawing.Point(137, 70);
            this.stagenamebox.Name = "stagenamebox";
            this.stagenamebox.Size = new System.Drawing.Size(191, 26);
            this.stagenamebox.TabIndex = 1;
            this.stagenamebox.TextChanged += new System.EventHandler(this.stagenamebox_TextChanged);
            // 
            // levelnumberbox
            // 
            this.levelnumberbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.levelnumberbox.Location = new System.Drawing.Point(137, 112);
            this.levelnumberbox.Name = "levelnumberbox";
            this.levelnumberbox.Size = new System.Drawing.Size(25, 26);
            this.levelnumberbox.TabIndex = 2;
            // 
            // stagelevellabel
            // 
            this.stagelevellabel.AutoSize = true;
            this.stagelevellabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.stagelevellabel.Location = new System.Drawing.Point(21, 115);
            this.stagelevellabel.Name = "stagelevellabel";
            this.stagelevellabel.Size = new System.Drawing.Size(110, 20);
            this.stagelevellabel.TabIndex = 3;
            this.stagelevellabel.Text = "Level Number:";
            // 
            // StageBuilderTitle
            // 
            this.StageBuilderTitle.AutoSize = true;
            this.StageBuilderTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StageBuilderTitle.Location = new System.Drawing.Point(398, 9);
            this.StageBuilderTitle.Name = "StageBuilderTitle";
            this.StageBuilderTitle.Size = new System.Drawing.Size(278, 25);
            this.StageBuilderTitle.TabIndex = 4;
            this.StageBuilderTitle.Text = "Stage Builder Application";
            // 
            // stagebuildertextbox
            // 
            this.stagebuildertextbox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stagebuildertextbox.Location = new System.Drawing.Point(248, 182);
            this.stagebuildertextbox.Multiline = true;
            this.stagebuildertextbox.Name = "stagebuildertextbox";
            this.stagebuildertextbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.stagebuildertextbox.Size = new System.Drawing.Size(697, 356);
            this.stagebuildertextbox.TabIndex = 5;
            this.stagebuildertextbox.WordWrap = false;
            // 
            // stagebuilderlabel
            // 
            this.stagebuilderlabel.AutoSize = true;
            this.stagebuilderlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stagebuilderlabel.Location = new System.Drawing.Point(244, 159);
            this.stagebuilderlabel.Name = "stagebuilderlabel";
            this.stagebuilderlabel.Size = new System.Drawing.Size(192, 20);
            this.stagebuilderlabel.TabIndex = 6;
            this.stagebuilderlabel.Text = "Stage Builder Text Box";
            // 
            // keyLabel
            // 
            this.keyLabel.AutoSize = true;
            this.keyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyLabel.Location = new System.Drawing.Point(8, 159);
            this.keyLabel.Name = "keyLabel";
            this.keyLabel.Size = new System.Drawing.Size(38, 20);
            this.keyLabel.TabIndex = 7;
            this.keyLabel.Text = "Key";
            // 
            // keyBox
            // 
            this.keyBox.Font = new System.Drawing.Font("Courier New", 10F);
            this.keyBox.Location = new System.Drawing.Point(12, 182);
            this.keyBox.Multiline = true;
            this.keyBox.Name = "keyBox";
            this.keyBox.ReadOnly = true;
            this.keyBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.keyBox.Size = new System.Drawing.Size(201, 356);
            this.keyBox.TabIndex = 8;
            this.keyBox.Text = resources.GetString("keyBox.Text");
            // 
            // compilebutton
            // 
            this.compilebutton.Location = new System.Drawing.Point(696, 552);
            this.compilebutton.Margin = new System.Windows.Forms.Padding(2);
            this.compilebutton.Name = "compilebutton";
            this.compilebutton.Size = new System.Drawing.Size(124, 38);
            this.compilebutton.TabIndex = 9;
            this.compilebutton.Text = "Compile in Text File";
            this.compilebutton.UseVisualStyleBackColor = true;
            this.compilebutton.Click += new System.EventHandler(this.compilebutton_Click);
            // 
            // fileExistsButton
            // 
            this.fileExistsButton.Location = new System.Drawing.Point(353, 552);
            this.fileExistsButton.Margin = new System.Windows.Forms.Padding(2);
            this.fileExistsButton.Name = "fileExistsButton";
            this.fileExistsButton.Size = new System.Drawing.Size(124, 38);
            this.fileExistsButton.TabIndex = 13;
            this.fileExistsButton.Text = "Load in File (if it exists)";
            this.fileExistsButton.UseVisualStyleBackColor = true;
            this.fileExistsButton.Click += new System.EventHandler(this.fileExistsButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 601);
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

