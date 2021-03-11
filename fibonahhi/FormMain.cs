using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;

namespace fibonahhi
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxNum.Text == string.Empty)
            {
                MessageBox.Show("Заполните поля ввода значений", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Convert.ToInt64(textBoxNum.Text) > long.MaxValue)
            {
                MessageBox.Show("Вы ввели слишком большое число", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            long n = Convert.ToInt64(textBoxNum.Text);
            BigInteger search = n;

            List<BigInteger> f = new List<BigInteger>();

            f.Add(0);
            f.Add(1);

            listBox1.Items.Add(f[0]);
            listBox1.Items.Add(f[1]);
            int i = 1;
            while (f[i] <= n)
            {
                f.Add(f[i - 1] + f[i]);
                listBox1.Items.Add(f[i + 1]);
                i++;
            }
            txtbxCode.Text = Convert.ToString(fibcode(f, search));
            listBox2.Items.Add(NUM(f, txtbxCode.Text));
        }

        private BigInteger fibcode(IList<BigInteger> f, BigInteger search)
        {
            string str = "";
            for (int i = f.Count - 1; i > 0; i--)
            {
                if (f[i] <= search)
                {
                    search = search - f[i];
                    str += "1";
                }
                else str += "0";
            }
            str += "1";
            BigInteger code = BigInteger.Parse(str);
            return code;
        }

        private BigInteger NUM(IList<BigInteger> f, string code)
        {
            BigInteger sum = 0;
            char[] arr = code.ToCharArray();
            Array.Reverse(arr);
            code = string.Concat(arr);
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
