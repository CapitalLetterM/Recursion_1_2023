using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recursion_4_2023
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int success;
        string bigLog;

        private void buttonGo_Click(object sender, EventArgs e)
        {
            success = 0;
            bigLog = "";
            countSteps(numericUpDownSteps.Value, 0, "");

            textBoxResults.Text = "Variants: " + success + "\r\n";
            textBoxResults.Text += bigLog;
        }

        public void countSteps(decimal limit, int current, string log)
        {
            string tempLog = log;
            if (current + 1 < limit)
            {
                tempLog += "1 step + ";
                countSteps(limit, current + 1, tempLog);
            }
            else if (current + 1 == limit)
            {
                tempLog += "1 step";
                addLog(tempLog + "\r\n");
                return;
            }

            tempLog = log;
            if (current + 2 < limit)
            {
                tempLog += "2 steps + ";
                countSteps(limit, current + 2, tempLog);
            }
            else if (current + 2 == limit)
            {
                tempLog += "2 steps";
                addLog(tempLog + "\r\n");
            }
        }

        public void addLog(string log)
        {
            success++;
            bigLog += success + ". " + log;
        }
    }
}
