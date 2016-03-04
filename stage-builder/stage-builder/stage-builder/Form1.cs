using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace stage_builder
{
    public partial class Form1 : Form
    {
        // Attributes for Stage Builder Application
        string stageName; // Used for file name and stage name
        string fileName; // create a text file name variable
        string lvlStr; // used for level string - Before Parsing
        double level; // Used for level number
        string stageTxt;



        public Form1()
        {
            InitializeComponent();
        }




        private void compilebutton_Click(object sender, EventArgs e)
        {
            stageName = (stagenamebox.Text); // assign the stage name variable
            fileName = (stageName + ".txt"); // assign a text file name variable
            lvlStr = levelnumberbox.Text; // assign the lvlStr variable
            double.TryParse(lvlStr, out level); // parsing the lvlStr variable into a double variable
            stageTxt = stagebuildertextbox.Text; //assigns the stage text into a string variable

            // File Writer
            try
            {
                StreamWriter output = new StreamWriter(fileName,true); // creates file and appends to an existing file (if done more than once)
                output.WriteLine(stageName);
                output.WriteLine(level);
                output.WriteLine(stageTxt); // Writes in the text of the stage

                output.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }


        }
    }
}
