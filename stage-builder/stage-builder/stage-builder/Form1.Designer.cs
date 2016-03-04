﻿namespace stage_builder
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
            this.SuspendLayout();
            // 
            // stagenamelabel
            // 
            this.stagenamelabel.AutoSize = true;
            this.stagenamelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.stagenamelabel.Location = new System.Drawing.Point(-1, 61);
            this.stagenamelabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.stagenamelabel.Name = "stagenamelabel";
            this.stagenamelabel.Size = new System.Drawing.Size(164, 25);
            this.stagenamelabel.TabIndex = 0;
            this.stagenamelabel.Text = "Stage/File Name:";
            // 
            // stagenamebox
            // 
            this.stagenamebox.Location = new System.Drawing.Point(192, 65);
            this.stagenamebox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.stagenamebox.Name = "stagenamebox";
            this.stagenamebox.Size = new System.Drawing.Size(253, 22);
            this.stagenamebox.TabIndex = 1;
            // 
            // levelnumberbox
            // 
            this.levelnumberbox.Location = new System.Drawing.Point(192, 106);
            this.levelnumberbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.levelnumberbox.Name = "levelnumberbox";
            this.levelnumberbox.Size = new System.Drawing.Size(72, 22);
            this.levelnumberbox.TabIndex = 2;
            // 
            // stagelevellabel
            // 
            this.stagelevellabel.AutoSize = true;
            this.stagelevellabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.stagelevellabel.Location = new System.Drawing.Point(41, 103);
            this.stagelevellabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.stagelevellabel.Name = "stagelevellabel";
            this.stagelevellabel.Size = new System.Drawing.Size(122, 25);
            this.stagelevellabel.TabIndex = 3;
            this.stagelevellabel.Text = "Stage Level:";
            // 
            // StageBuilderTitle
            // 
            this.StageBuilderTitle.AutoSize = true;
            this.StageBuilderTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StageBuilderTitle.Location = new System.Drawing.Point(468, 11);
            this.StageBuilderTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StageBuilderTitle.Name = "StageBuilderTitle";
            this.StageBuilderTitle.Size = new System.Drawing.Size(341, 31);
            this.StageBuilderTitle.TabIndex = 4;
            this.StageBuilderTitle.Text = "Stage Builder Application";
            // 
            // stagebuildertextbox
            // 
            this.stagebuildertextbox.Location = new System.Drawing.Point(527, 228);
            this.stagebuildertextbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.stagebuildertextbox.Multiline = true;
            this.stagebuildertextbox.Name = "stagebuildertextbox";
            this.stagebuildertextbox.Size = new System.Drawing.Size(667, 383);
            this.stagebuildertextbox.TabIndex = 5;
            // 
            // stagebuilderlabel
            // 
            this.stagebuilderlabel.AutoSize = true;
            this.stagebuilderlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stagebuilderlabel.Location = new System.Drawing.Point(745, 183);
            this.stagebuilderlabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.stagebuilderlabel.Name = "stagebuilderlabel";
            this.stagebuilderlabel.Size = new System.Drawing.Size(234, 25);
            this.stagebuilderlabel.TabIndex = 6;
            this.stagebuilderlabel.Text = "Stage Builder Text Box";
            // 
            // key
            // 
            this.key.AutoSize = true;
            this.key.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.key.Location = new System.Drawing.Point(215, 183);
            this.key.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.key.Name = "key";
            this.key.Size = new System.Drawing.Size(50, 25);
            this.key.TabIndex = 7;
            this.key.Text = "Key";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(101, 224);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(313, 387);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // compilebutton
            // 
            this.compilebutton.Location = new System.Drawing.Point(793, 618);
            this.compilebutton.Name = "compilebutton";
            this.compilebutton.Size = new System.Drawing.Size(165, 47);
            this.compilebutton.TabIndex = 9;
            this.compilebutton.Text = "Compile in Text File";
            this.compilebutton.UseVisualStyleBackColor = true;
            this.compilebutton.Click += new System.EventHandler(this.compilebutton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 703);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
    }
}

