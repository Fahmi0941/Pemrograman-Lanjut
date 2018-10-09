using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calct
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            int a = int.Parse(txtA.Text);
            int b = int.Parse(txtB.Text);
            int hitung;
            string hasil;

            if (cbOperasi.SelectedIndex == 0)
            {
                hitung = a + b;
                hasil = hitung.ToString();
                txtHasil.Text = hasil;
            }

            if (cbOperasi.SelectedIndex == 1)
            {
                hitung = a - b;
                hasil = hitung.ToString();
                txtHasil.Text = hasil;
            }

            if (cbOperasi.SelectedIndex == 2)
            {
                hitung = a * b;
                hasil = hitung.ToString();
                txtHasil.Text = hasil;
            }

            if (cbOperasi.SelectedIndex == 3)
            {
                hitung = a / b;
                hasil = hitung.ToString();
                txtHasil.Text = hasil;
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            txtA.Text = " ";
            txtB.Text = " ";
            txtHasil.Text = " ";
        }
    }
}
