using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fibonahhi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Заполните поля ввода значений", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            BigInteger search = BigInteger.Parse(textBox1.Text);
            int n = Convert.ToInt32(textBox1.Text);
            List<BigInteger> f = new List<BigInteger>();
            BigInteger[] code = new BigInteger[n];

            f.Add(0);
            f.Add(1);

            listBox1.Items.Add(f[0]);
            listBox1.Items.Add(f[1]);
            int i = 1;
            while(f[i] <= n)
            {
                f.Add(f[i - 1] + f[i]);
                listBox1.Items.Add(f[i]);
                i++;
            }
            listBox1.Items.Add(f[i - 2] + f[i-1]);
            txtbxCode.Text = Convert.ToString(fibcode(f, search, n));
            listBox2.Items.Add(NUM(f, txtbxCode.Text, n));
        }
        BigInteger fibcode(IList<BigInteger> f, BigInteger search, int n)
        {
            int temp = n;
            string str = "";
            for (int i = f.Count -1; i > 0; i--)
            {
                if (f[i] <= search)
                {
                    temp = i;
                    search = search - f[i];
                    str += "1";
                    for (int j = temp - 1; j > 0; j--)
                    {
                        if (f[j] <= search)
                        {
                            str += "1";
                            search = search - f[j];
                            temp = j;
                        }
                        else str += "0";
                    }
                }
            }
            str += "1";
            BigInteger code = BigInteger.Parse(str);
            return code;
        }
        BigInteger NUM(IList<BigInteger> f, string code, int n)
        {
            BigInteger sum = 0;
            char[] arr = code.ToCharArray();
            Array.Reverse(arr);
            code = String.Concat<char>(arr);
            BigInteger x = BigInteger.Parse(code);

            var digitArray = x.ToString().Select(digit => BigInteger.Parse(digit.ToString())).ToArray();

            for (int j = 0; j < digitArray.Length; j++)
            {
                if (digitArray[j] == 1)
                {
                    sum += f[j];
                }
            }
            return sum;

        }
    }
}
