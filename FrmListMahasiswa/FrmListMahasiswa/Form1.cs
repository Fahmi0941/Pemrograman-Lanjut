using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmListMahasiswa
{
    public partial class Form1 : Form
    {
        public delegate void SaveUpdateEventHandler(Mahasiswa obj);
        public event SaveUpdateEventHandler OnSave;
        private Form1 frm;
        private bool Data = true;
        private Mahasiswa mhs = null;
        private IList<Mahasiswa> listOfMahasiswa = new List<Mahasiswa>();
        
        public Form1()
        {
            InitializeComponent();
            InisialisasiListView();
        }

        public void Tampil(Mahasiswa obj)
        {
            this.Data = false;
            this.mhs = obj;
            mskNpm.Text = this.mhs.Npm;
            txtNama.Text = this.mhs.Nama;

            if (this.mhs.Gender == "Laki-laki")
                rdoLakilaki.Checked = true;
            else
                rdoPerempuan.Checked = true;

            txtTempatLahir.Text = this.mhs.TempatLahir;
            dtpTanggalLahir.Value = DateTime.Parse(this.mhs.TanggalLahir);
        }
        private void InisialisasiListView()
        {
            lvwMahasiswa.View = System.Windows.Forms.View.Details;
            lvwMahasiswa.FullRowSelect = true;
            lvwMahasiswa.GridLines = true;
            lvwMahasiswa.Columns.Add("No.", 30, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Npm", 70, HorizontalAlignment.Left);
            lvwMahasiswa.Columns.Add("Nama", 180, HorizontalAlignment.Left);
            lvwMahasiswa.Columns.Add("Jenis Kelamin", 80, HorizontalAlignment.Left);
            lvwMahasiswa.Columns.Add("Tempat Lahir", 75, HorizontalAlignment.Left);
            lvwMahasiswa.Columns.Add("Tgl. Lahir", 75, HorizontalAlignment.Left);
        }

        private void InputListView(bool Data, Mahasiswa mhs)
        {
            if (Data)
            {
                int noUrut = lvwMahasiswa.Items.Count + 1;

                ListViewItem item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(mhs.Npm);
                item.SubItems.Add(mhs.Nama);
                item.SubItems.Add(mhs.Gender);
                item.SubItems.Add(mhs.TempatLahir);
                item.SubItems.Add(mhs.TanggalLahir);
                
                lvwMahasiswa.Items.Add(item);
            }
            else
            {
                int row = lvwMahasiswa.SelectedIndices[0];

                ListViewItem itemRow = lvwMahasiswa.Items[row];
                itemRow.SubItems[1].Text = mhs.Npm;
                itemRow.SubItems[2].Text = mhs.Nama;
                itemRow.SubItems[3].Text = mhs.Gender;
                itemRow.SubItems[4].Text = mhs.TempatLahir;
                itemRow.SubItems[5].Text = mhs.TanggalLahir;
            }
        }

        private void ResetForm()
        {
            mskNpm.Clear();
            txtNama.Clear();
            rdoLakilaki.Checked = true;
            txtTempatLahir.Clear();
            dtpTanggalLahir.Value = DateTime.Today;
            mskNpm.Focus();
        }

        private void Form1_OnSave(Mahasiswa obj)
        {
            listOfMahasiswa.Add(obj);
            InputListView(true, obj);
        }

       
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (!mskNpm.MaskFull)
            {
                MessageBox.Show("NPM harus diisi!!!", "Peringatan",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                mskNpm.Focus();
                return;
            }
            if (!(txtNama.Text.Length > 0))
            {
                MessageBox.Show("Nama harus diisi!!!", "Peringatan",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                txtNama.Focus();
                return;
            }
            var jenisKelamin = rdoLakilaki.Checked ? "Laki-laki" : "Perempuan";
            var result = MessageBox.Show("Apakah data ingin disimpan?", "Konfirmasi",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (Data)
                    mhs = new Mahasiswa();

                mhs.Npm = mskNpm.Text;
                mhs.Nama = txtNama.Text;
                mhs.Gender = rdoLakilaki.Checked ? "Laki-laki" : "Perempuan";
                mhs.TempatLahir = txtTempatLahir.Text;
                mhs.TanggalLahir = dtpTanggalLahir.Value.ToString("dd/MM/yyyy");
                
                    Form1_OnSave(mhs);
                    ResetForm();
                
            }
        }
        
        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (lvwMahasiswa.SelectedItems.Count > 0)
            {
                var index = lvwMahasiswa.SelectedIndices[0];
                var nama = lvwMahasiswa.Items[index].SubItems[2].Text;
                var msg = string.Format("Apakah data mahasiswa '{0}' ingin dihapus ?",
                nama);
                var result = MessageBox.Show(msg, "Konfirmasi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    listOfMahasiswa.Remove(mhs);

                    lvwMahasiswa.Items.Clear();
                    foreach (var obj in listOfMahasiswa)
                    {
                        InputListView(true, obj);
                    }
                }
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data belum dipilih", "Peringatan",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            }
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            var msg = "Apakah Anda yakin ?";
            var result = MessageBox.Show(msg, "Konfirmasi", MessageBoxButtons.YesNo,
            MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
                this.Close();
        }

        private void lvwMahasiswa_DoubleClick(object sender, EventArgs e)
        {
            var mhs = listOfMahasiswa[lvwMahasiswa.SelectedIndices[0]];
            Tampil(mhs);
        }
    }
}
