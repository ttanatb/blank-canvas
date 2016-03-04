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
            this.key = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.compilebutton = new System.Windows.Forms.Button();
            this.FileExistCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // stagenamelabel
            // 
            this.stagenamelabel.AutoSize = true;
            this.stagenamelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.stagenamelabel.Location = new System.Drawing.Point(-1, 50);
            this.stagenamelabel.Name = "stagenamelabel";
            this.stagenamelabel.Size = new System.Drawing.Size(131, 20);
            this.stagenamelabel.TabIndex = 0;
            this.stagenamelabel.Text = "Stage/File Name:";
            // 
            // stagenamebox
            // 
            this.stagenamebox.Location = new System.Drawing.Point(144, 53);
            this.stagenamebox.Name = "stagenamebox";
            this.stagenamebox.Size = new System.Drawing.Size(191, 20);
            this.stagenamebox.TabIndex = 1;
            // 
            // levelnumberbox
            // 
            this.levelnumberbox.Location = new System.Drawing.Point(144, 86);
            this.levelnumberbox.Name = "levelnumberbox";
            this.levelnumberbox.Size = new System.Drawing.Size(55, 20);
            this.levelnumberbox.TabIndex = 2;
            // 
            // stagelevellabel
            // 
            this.stagelevellabel.AutoSize = true;
            this.stagelevellabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.stagelevellabel.Location = new System.Drawing.Point(31, 84);
            this.stagelevellabel.Name = "stagelevellabel";
            this.stagelevellabel.Size = new System.Drawing.Size(97, 20);
            this.stagelevellabel.TabIndex = 3;
            this.stagelevellabel.Text = "Stage Level:";
            // 
            // StageBuilderTitle
            // 
            this.StageBuilderTitle.AutoSize = true;
            this.StageBuilderTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StageBuilderTitle.Location = new System.Drawing.Point(351, 9);
            this.StageBuilderTitle.Name = "StageBuilderTitle";
            this.StageBuilderTitle.Size = new System.Drawing.Size(278, 25);
            this.StageBuilderTitle.TabIndex = 4;
            this.StageBuilderTitle.Text = "Stage Builder Application";
            // 
            // stagebuildertextbox
            // 
            this.stagebuildertextbox.Location = new System.Drawing.Point(395, 185);
            this.stagebuildertextbox.Multiline = true;
            this.stagebuildertextbox.Name = "stagebuildertextbox";
            this.stagebuildertextbox.Size = new System.Drawing.Size(501, 312);
            this.stagebuildertextbox.TabIndex = 5;
            // 
            // stagebuilderlabel
            // 
            this.stagebuilderlabel.AutoSize = true;
            this.stagebuilderlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stagebuilderlabel.Location = new System.Drawing.Point(559, 149);
            this.stagebuilderlabel.Name = "stagebuilderlabel";
            this.stagebuilderlabel.Size = new System.Drawing.Size(192, 20);
            this.stagebuilderlabel.TabIndex = 6;
            this.stagebuilderlabel.Text = "Stage Builder Text Box";
            // 
            // key
            // 
            this.key.AutoSize = true;
            this.key.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.key.Location = new System.Drawing.Point(161, 149);
            this.key.Name = "key";
            this.key.Size = new System.Drawing.Size(38, 20);
            this.key.TabIndex = 7;
            this.key.Text = "Key";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(76, 182);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(236, 315);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // compilebutton
            // 
            this.compilebutton.Location = new System.Drawing.Point(772, 502);
            this.compilebutton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.compilebutton.Name = "compilebutton";
            this.compilebutton.Size = new System.Drawing.Size(124, 38);
            this.compilebutton.TabIndex = 9;
            this.compilebutton.Text = "Compile in Text File";
            this.compilebutton.UseVisualStyleBackColor = true;
            this.compilebutton.Click += new System.EventHandler(this.compilebutton_Click);
            // 
            // FileExistCheckBox
            // 
            this.FileExistCheckBox.AutoSize = true;
            this.FileExistCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.FileExistCheckBox.Location = new System.Drawing.Point(395, 513);
            this.FileExistCheckBox.Name = "FileExistCheckBox";
            this.FileExistCheckBox.Size = new System.Drawing.Size(168, 19);
            this.FileExistCheckBox.TabIndex = 10;
            this.FileExistCheckBox.Text = "File for level already exists";
            this.FileExistCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 571);
            this.Controls.Add(this.FileExistCheckBox);
            this.Controls.Add(this.compilebutton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.key);
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
        private System.Windows.Forms.Label key;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button compilebutton;
        private System.Windows.Forms.CheckBox FileExistCheckBox;
    }
}

