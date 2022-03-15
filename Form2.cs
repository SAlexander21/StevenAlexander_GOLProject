using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StevenAlexander_GOLProject
{
    public partial class Form2 : Form
    {

        //Variable used for storing user input.
        public static string seed;
        public static int seedInt;

        public Form2()
        {
            InitializeComponent();
        }

        //Cancels input
        private void Cancel_Button_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        //OK button
        private void OK_Button_Click(object sender, EventArgs e)
        {

            seed = textBox1.Text;

            if (int.TryParse(seed, out seedInt))
            {

                

            }
            else
            {

                BadInputWindow badInput = new BadInputWindow();
                badInput.Show();

            }
        }
    }
}
