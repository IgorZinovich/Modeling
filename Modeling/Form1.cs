using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modeling
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a;
            double b;
            try
            {
                a = Convert.ToDouble(textA.Text.Replace('.', ','));
                b = Convert.ToDouble(textB.Text.Replace('.', ','));
            }
            catch(Exception ex)
            {
                MessageBox.Show("Не верно введены параметры a и b", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if((a < 0.0 || a >= 1.0) || (b <= 0.0 || b > 1.0) || a >= b)
            {
                MessageBox.Show("Не верно введены параметры a и b", "Ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Double[] X = new Double[20];
            for (Int32 i = 0; i < 20; i++)
            {
                X[i] = Convert.ToDouble(i) * 0.05 + 0.025;
            }

            List<Double> list = new List<double>();
            Double[] Y = new Double[20];

            RandomSimpson rand = new RandomSimpson(a, b);
            double num;

            for(Int32 i = 0; i < 1000000; i++)
            {
                num = rand.Next();
                list.Add(num);
                Y[Convert.ToInt32(Math.Truncate(20 * num))] += 1.0;
            }
            for (int i = 0; i < Y.Length; i++ )
            {
                Y[i] /= list.Count;
            }

            textMX.Text = Functions.GetMedian(list).ToString("0.00000");
            textDX.Text = Functions.GetDisp(list).ToString("0.00000");
            textRMS.Text = Functions.GetRMS(list).ToString("0.00000");

            this.chart1.Series[0].Points.DataBindXY(X, Y);


        }

        
    }
}
