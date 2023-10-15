using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recursion_3_2023
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = fib(0, 1, numericUpDownLimit.Value, 2).ToString();
        }

        public int fib(int one, int two, decimal limit, int current)
        {
            if(current == limit)
            {
                return one + two;
            }
            else
            {
                current++;
                int temp = two;
                two = one + two;
                one = temp;
                return fib(one, two, limit, current);
            }
        }
    }
}
