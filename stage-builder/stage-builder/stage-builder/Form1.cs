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
        string fileName; // Create a text file name variable
        string lvlStr; // Used for level string - Before Parsing
        double level; // Used for level number
        string stageTxt; // Used for stage text
        int timesRun = 0; // number of times the file has been runbool



        public Form1()
        {
            InitializeComponent();
            fileExistsButton.Enabled = false;
            compilebutton.Enabled = false;
        }

        private void stagenamebox_TextChanged(object sender, EventArgs e)
        {
            fileExistsButton.Enabled = true;
        }


        private void fileExistsButton_Click(object sender, EventArgs e) //Loads in stage text file if it already exists
        {
            stageName = (stagenamebox.Text); // assign the stage name variable
            fileName = (stageName + ".txt"); // assign a text file name variable

            try
            {
                StreamReader input = new StreamReader(fileName);

                stagebuildertextbox.Text = System.IO.File.ReadAllText(fileName);
                input.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            compilebutton.Enabled = true;
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
                StreamWriter output = new StreamWriter(fileName); // creates file and overrides existing file (if done more than once)

                output.WriteLine(stageName); // Puts stage name at top of text file
                output.WriteLine(level); // Puts level number at top of text file
                output.WriteLine(stageTxt); // Writes in the text of the stage
                output.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            timesRun++;
        }
    }
}
