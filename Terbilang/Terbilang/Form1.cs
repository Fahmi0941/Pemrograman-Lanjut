using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TerbilangLibrary;

namespace Terbilang
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TerbilangLbr terbilang = new TerbilangLbr();

            int nominal = int.Parse(txtNominal.Text);
            lstTerbilang.Items.Clear();
            lstTerbilang.Items.Add(terbilang.TerbilangIndonesia(nominal));
        }

      
    }
}
