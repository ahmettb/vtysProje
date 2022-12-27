using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restorant
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Calisanlar calisan = new Calisanlar();
            calisan.MdiParent = this;
            calisan.FormBorderStyle = FormBorderStyle.None;
            calisan.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            SiparisForm sip = new SiparisForm();
            sip.MdiParent = this;
            sip.FormBorderStyle = FormBorderStyle.None;
            sip.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {

            Yemekler sip = new Yemekler();
            sip.MdiParent = this;
            sip.FormBorderStyle = FormBorderStyle.None;
            sip.Show();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button11_Click_1(object sender, EventArgs e)
        {

            KayitliMusteri sip = new KayitliMusteri();
            sip.MdiParent = this;
            sip.FormBorderStyle = FormBorderStyle.None;
            sip.Show();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {

            GelirGider form = new GelirGider();
            form.MdiParent = this;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Show();
        }
    }
}
