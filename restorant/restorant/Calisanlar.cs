using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Npgsql;

namespace restorant
{
    public partial class Calisanlar : Form
    {
        int sehirId;

        public Calisanlar()
        {

       
            InitializeComponent();
            panel1.Visible = false;

            komut.Connection = Connection.conn;
            komut.CommandType=CommandType.Text;
            komut.CommandText = "Select *from public.\"CalisanTuru\" ";
            Connection.conn.Open();

            NpgsqlDataReader reader = komut.ExecuteReader();
            while(reader.Read())
            {
                comboBox2.Items.Add(reader[1].ToString());
            }
            Connection.conn.Close();
            Connection.conn.Open();

            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = Connection.conn;
cmd.CommandType = CommandType.Text;
            cmd.CommandText= "Select *from public.\"Seflerimiz\" ";
            NpgsqlDataReader reader2 = cmd.ExecuteReader();

            while (reader2.Read())
            {
                comboBox1.Items.Add(reader2[1].ToString()+" "+reader2[2].ToString());
            }

            Connection.conn.Close();

            Connection.conn.Open();


            NpgsqlCommand cmd2 = new NpgsqlCommand();
            cmd2.Connection = Connection.conn;
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "Select *from public.\"Sehirler\" ";
            NpgsqlDataReader reader4= cmd2.ExecuteReader();

            while (reader4.Read())
            {
                comboBox3.Items.Add(reader4[1].ToString() );
            }
           
            Connection.conn.Close();

          





        }

        public DataTable calisanListele(string sorgu)
        {
            komut.Connection = Connection.conn;
            komut.CommandType=CommandType.Text;
            komut.CommandText = sorgu;
            Connection.conn.Open();
            NpgsqlDataAdapter data = new NpgsqlDataAdapter(komut);
            DataSet dt = new DataSet();
            data.Fill(dt);
            Connection.conn.Close();
            return dt.Tables[0];


        }

        public NpgsqlCommand komut = new NpgsqlCommand();

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Calisanlar_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string sorgu = "select  public.\"Garsonlarimiz\".\"calisanNo\", public.\"Garsonlarimiz\".\"ad\",public.\"Garsonlarimiz\".\"soyad\",public.\"Garsonlarimiz\".\"maas\", public.\"Iletisim\".\"adres\",public.\"Iletisim\".\"telNo\", public.\"Sehirler\".\"sehirAd\", public.\"Ilceler\".\"ilceAd\"" +
                           "from public.\"Garsonlarimiz\"" +
                           "inner join public.\"CalisanTuru\" on public.\"Garsonlarimiz\".\"calisanTur\"=public.\"CalisanTuru\".\"calisanTur\"" +
                       "inner join public.\"Iletisim\" on public.\"Garsonlarimiz\".\"iletisimBilgi\"=public.\"Iletisim\".\"iletisimId\"" +
                       "inner join public.\"Sehirler\" on public.\"Iletisim\".\"sehir\"=public.\"Sehirler\".\"sehirId\"" +
                       "inner join public.\"Ilceler\" on public.\"Iletisim\".\"ilce\"=public.\"Ilceler\".\"ilceId\"";
            dataGridView1.DataSource = calisanListele(sorgu);

        
            

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
               
            
            
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString(); //[0] sütun numarası
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString(); //[0] sütun numarası
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString(); //[0] sütun numarası
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString(); //[0] sütun numarası
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString(); //[0] sütun numarası
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString(); //[0] sütun numarası
            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString(); //[0] sütun numarası
            textBox8.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString(); //[0] sütun numarası




        }

        private void button3_Click(object sender, EventArgs e)
        {

//            Connection.conn.Open();
            komut.Connection = Connection.conn;
            komut.CommandType=CommandType.Text;
            komut.CommandText = "Update  public.\"Calisanlar\" as \"calisan\" set \"calisan\".\"ad\"=@ad, \"calisan\".\"soyad\"=@soyad, \"calisan\".\"maas\"=@maas where \"calisan\".\"calisanNo\"=@calisanId ";


        }

        private void button2_Click(object sender, EventArgs e)
        {
       
           string sorgu = "select  public.\"Ascilarimiz\".\"calisanNo\", public.\"Ascilarimiz\".\"ad\",public.\"Ascilarimiz\".\"soyad\",public.\"Ascilarimiz\".\"maas\", public.\"Iletisim\".\"adres\",public.\"Iletisim\".\"telNo\" ,public.\"Sehirler\".\"sehirAd\", public.\"ilceler\".\"ilceadi\"" +
                "from public.\"Ascilarimiz\""+
                "inner join public.\"CalisanTuru\" on public.\"Ascilarimiz\".\"calisanTur\"=public.\"CalisanTuru\".\"calisanTur\"" + 
            "inner join public.\"Iletisim\" on public.\"Ascilarimiz\".\"iletisimBilgi\"=public.\"Iletisim\".\"iletisimId\""+
            "inner join public.\"Sehirler\" on public.\"Iletisim\".\"sehir\"=public.\"Sehirler\".\"sehirId\""+
            "inner join public.\"ilceler\" on public.\"Iletisim\".\"ilce\"=public.\"ilceler\".\"ilceId\"";

            dataGridView1.DataSource = calisanListele(sorgu);
   
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sorgu = "select  public.\"Seflerimiz\".\"calisanNo\", public.\"Seflerimiz\".\"ad\",public.\"Seflerimiz\".\"soyad\",public.\"Seflerimiz\".\"maas\", public.\"iletisim\".\"adres\",public.\"Iletisim\".\"telNo\", public.\"Sehirler\".\"sehirAd\", public.\"ilceler\".\"ilcedi\"" +
              "from public.\"Seflerimiz\"" +
              "inner join public.\"CalisanTuru\" on public.\"Seflerimiz\".\"calisanTur\"=public.\"CalisanTuru\".\"calisanTur\"" +
          "inner join public.\"Iletisim\" on public.\"Seflerimiz\".\"iletisimBilgi\"=public.\"Iletisim\".\"iletisimId\"" +
          "inner join public.\"Sehirler\" on public.\"Iletisim\".\"sehir\"=public.\"Sehirler\".\"sehirId\"" +
          "inner join public.\"ilceler\" on public.\"Iletisim\".\"ilce\"=public.\"ilceler\".\"ilceId\"";

            dataGridView1.DataSource = calisanListele(sorgu);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;

        }
        
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();

            Connection.conn.Open();

            NpgsqlCommand cmd3 = new NpgsqlCommand();
            cmd3.Connection = Connection.conn;
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "Select \"ilceadi\" from public.\"ilceler\" where \"sehirid\"= @sehirId";
            cmd3.Parameters.AddWithValue("@sehirId", comboBox3.SelectedIndex);
            NpgsqlDataReader read = cmd3.ExecuteReader();
            while(read.Read())
            {
                comboBox4.Items.Add(read[0].ToString());
            }
            read.Close();
                       // NpgsqlDataAdapter data = new NpgsqlDataAdapter(cmd3);
           // DataSet dt = new DataSet();
           // data.Fill(dt);
            //omboBox4.DataSource = dt.Tables[0];
            


            Connection.conn.Close();


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            decimal minMaas=decimal.Parse(textBox9.Text) ;
            decimal maxMaas = decimal.Parse(textBox10.Text) ;

            Connection.conn.Open();

            NpgsqlCommand cmd3 = new NpgsqlCommand();
            cmd3.Connection = Connection.conn;
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "Select*from \"MaasaGoreFiltreleme\"(CAST(@p1 AS NUMERIC),CAST(@p2 AS NUMERIC)) ";
            cmd3.Parameters.AddWithValue("@p1", minMaas);
            cmd3.Parameters.AddWithValue("@p2", maxMaas);

            NpgsqlDataAdapter data = new NpgsqlDataAdapter(cmd3);
            DataSet dt = new DataSet();
            data.Fill(dt);
            dataGridView1.DataSource = dt.Tables[0];



            Connection.conn.Close();

        }
    }
}

