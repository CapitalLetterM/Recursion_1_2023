using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recursion_5_2023
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonPow_Click(object sender, EventArgs e)
        {
            if(numericUpDownX.Value == 0 && numericUpDownN.Value <= 0)
            {
                textBoxResult.Text = "Помилка";
            }
            else
            {
                if(numericUpDownN.Value < 0)
                {
                    textBoxResult.Text = power(Convert.ToDouble(numericUpDownX.Value), 1, 0, -Convert.ToInt32(numericUpDownN.Value), true);
                }
                else
                {
                    textBoxResult.Text = power(Convert.ToDouble(numericUpDownX.Value), 1, 0, Convert.ToInt32(numericUpDownN.Value), false);
                }
                
            }
        }

        public string power(double value, double result, int currentPowerValue, int targetPowerValue, bool negative)
        {
            result *= value;
            currentPowerValue++;
            if (result < -10000 || result > 10000)
            {
                return "Помилка, результат повинен бути в межах [-10000; 10000]";
            }
            if(currentPowerValue != targetPowerValue)
            {
                return power(value, result, currentPowerValue, targetPowerValue, negative);
            }
            else
            {
                if(negative == true)
                {
                    return "1 / " + result + " = " + (1 / result);
                }
                else
                {
                    return result.ToString();
                }
            }
        }
    }
}
