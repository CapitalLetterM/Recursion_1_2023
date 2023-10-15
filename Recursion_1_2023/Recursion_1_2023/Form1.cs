using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recursion_1_2023
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxOut.Text = shuffle(textBoxIn.Text);
        }

        public string shuffle(string line)
        {
            string result = line[0].ToString();
            if(line.Length != 1)
            {
                line = line.Remove(0, 1);
                result = shuffle(line) + result;
            }
            return result;
        }
    }
}
