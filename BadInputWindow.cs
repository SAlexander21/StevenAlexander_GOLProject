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
    public partial class BadInputWindow : Form
    {
        public BadInputWindow()
        {
            InitializeComponent();
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {

            this.Close();

        }
    }
}
