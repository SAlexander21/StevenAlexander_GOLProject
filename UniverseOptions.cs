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
    public partial class UniverseOptions : Form
    {
        public UniverseOptions()
        {
            InitializeComponent();
        }

        //Entered X value
        public static int entX;
        //Entered Y value
        public static int entY;
        //Entered tick speed
        public static int entTick;

        private void Ok_Button_Click(object sender, EventArgs e)
        {

            if ((XBox.Value < 3 || XBox.Value > 75) && (YBox.Value < 3 || YBox.Value > 75) && (Timing.Value < 50 || Timing.Value > 2000))
            {

                BadInputWindow badInput = new BadInputWindow();
                badInput.Show();

            }
            else
            {

                entX = (int)XBox.Value;
                entY = (int)YBox.Value;
                entTick = (int)Timing.Value;

            }
        }
    }
}
