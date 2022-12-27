using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Data;
using System.Data.SqlClient;
namespace restorant
{
    public partial class SiparisForm : Form
    {

        public void comboBoxAdd(ComboBox combo,string tabloAdi)
        {
            

            Connection.conn.Open();
            NpgsqlCommand komut = new NpgsqlCommand();
            komut.CommandText = "SELECT *FROM PUBLIC.\"" + tabloAdi + "\" ";
           komut.Connection=Connection.conn;
            komut.CommandType = CommandType.Text;
                
                NpgsqlDataReader reader = komut.ExecuteReader();


            while (reader.Read())
            {
                if (combo == comboBox3) combo.Items.Add(reader[1].ToString() + " " + reader[2].ToString());
                if(combo==comboBox2) combo.Items.Add(reader[0].ToString());
            }
            Connection.conn.Close();

        }

        public SiparisForm()
        {
          
            InitializeComponent();
            ComboBox combo=new ComboBox();
          //  combo = comboBox1;
           // comboBoxAdd(combo, "Yemekler");
            combo = comboBox2;
            comboBoxAdd(combo, "Masalar");
            combo = comboBox3;
            comboBoxAdd(combo, "Garsonlarimiz");



            Connection.conn.Open();
            NpgsqlCommand komut = new NpgsqlCommand();
            komut.CommandText = "SELECT *FROM PUBLIC.\"Yemekler\" ORDER BY \"yemekId\"";
            komut.Connection = Connection.conn;
            komut.CommandType = CommandType.Text;

            NpgsqlDataReader reader = komut.ExecuteReader();


            while (reader.Read())
            {

                 comboBox1.Items.Add(reader[1].ToString());
            }
            Connection.conn.Close();





            /* Connection.conn.Open();
             NpgsqlCommand komut = new NpgsqlCommand("SELECT *FROM PUBLIC.\"Yemekler\"", Connection.conn);
             NpgsqlDataReader reader = komut.ExecuteReader();


             while (reader.Read())
             {
                 comboBox1.Items.Add(reader["yemekAd"].ToString());
             }
             Connection.conn.Close();
             Connection.conn.Open();


             komut.CommandText = "SELECT *FROM PUBLIC.\"Masalar\"";
             komut.CommandType = CommandType.Text;
             komut.Connection=Connection.conn;
             reader = komut.ExecuteReader();
             while(reader.Read())
             {
                 comboBox2.Items.Add("MASA "+reader[0].ToString());
             }
             Connection.conn.Close();
             Connection.conn.Open();
             komut.CommandText= "SELECT *FROM PUBLIC.\"Garsonlarimiz\"";
             komut.CommandType = CommandType.Text;
             komut.Connection = Connection.conn;*/


        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SiparisForm_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            NpgsqlCommand komut = new NpgsqlCommand();
            Connection.conn.Open();
            komut.CommandType = CommandType.Text;
            komut.Connection = Connection.conn;
            komut.CommandText = "select*from public.\"Fatura\"";
            NpgsqlDataReader read = komut.ExecuteReader();
            bool kontrol = false;
            while (read.Read())
            {
                if (read[1].ToString() == comboBox2.Text)
                { kontrol = true;
                    break;

                }

            }

            read.Close();
            if (kontrol == true)
            {
                komut.CommandText = "select public.\"Fatura\".\"faturaNo\",public.\"Fatura\".\"masaNo\", public.\"MasaSiparis\".\"yemekAdet\",public.\"MasaSiparis\".\"siparisTutar\",public.\"Yemekler\".\"yemekAd\"" +
                "from public.\"Fatura\" inner join public.\"MasaSiparis\" on public.\"Fatura\".\"faturaNo\"=public.\"MasaSiparis\".\"faturaNo\"" +
           " inner join public.\"Yemekler\" on public.\"MasaSiparis\".\"yemekId\"=public.\"Yemekler\".\"yemekId\" where public.\"Fatura\".\"masaNo\"="+int.Parse(comboBox2.Text);
                NpgsqlDataAdapter data = new NpgsqlDataAdapter(komut);
                DataSet dt = new DataSet();
                data.Fill(dt);
                dataGridView1.DataSource = dt.Tables[0];
             //   Connection.conn.Close();
               
                
                //Connection.conn.Open();

                NpgsqlCommand komut2 = new NpgsqlCommand();
                komut2.Connection= Connection.conn;
                komut2.CommandType = CommandType.Text;

                komut2.CommandText = "select distinct *from public.\"GorevliGarson\" inner join public.\"Garsonlarimiz\" on public.\"GorevliGarson\".\"calisanNo\"= public.\"Garsonlarimiz\".\"calisanNo\" where public.\"GorevliGarson\".\"sorumluMasıD\"=" + int.Parse(comboBox2.Text);
                NpgsqlDataReader read2 = komut2.ExecuteReader();
                while (read2.Read())
                {
                    textBox1.Text = read[3].ToString();
                    textBox2.Text = read[4].ToString();

                }
                read2.Close();
               // Connection.conn.Close();

              


            }
            else
            {
                dataGridView1.DataSource=null;
            }
           // Connection.conn.Open();


            NpgsqlCommand komut3 = new NpgsqlCommand();
            komut3.Connection = Connection.conn;
            komut3.CommandType = CommandType.Text;
            komut3.CommandText = "select*from public.\"GuncelMusteri\"where \"oturduguMasa\"=" + int.Parse(comboBox2.Text);

            NpgsqlDataReader read3 = komut3.ExecuteReader();
            while (read3.Read())
            {
                textBox9.Text = read3[1].ToString();
                textBox8.Text = read3[2].ToString();

            }
            read3.Close();
          //  Connection.conn.Close();




            Connection.conn.Close();



        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
          /*  int yemekId = comboBox1.SelectedIndex;
            int yemekAdet = int.Parse(textBox6.Text);
            NpgsqlCommand komut = new NpgsqlCommand();
            komut.Connection = Connection.conn;
            Connection.conn.Open();

            komut.CommandText = "select *from \"TutarHesapla\"(@p1,@p2)";
            komut.Parameters.AddWithValue("@p1", yemekId+1);
            komut.Parameters.AddWithValue("@p2", yemekAdet);
            komut.CommandType = CommandType.Text;

            NpgsqlDataReader reader = komut.ExecuteReader();
            label10.Text = reader["TutarHesapla"].ToString();

            Connection.conn.Close();*/




                    




        }

        private void button3_Click(object sender, EventArgs e)
        {
            int masaId = int.Parse(comboBox2.Text);
            int faturaNo= int.Parse(comboBox2.Text);
            int yemekId = 0;
            int yemekAdet = int.Parse(textBox6.Text);
            Connection.conn.Open();
            NpgsqlCommand komut=new NpgsqlCommand();
            komut.CommandType = CommandType.Text;
            komut.Connection = Connection.conn;
            komut.CommandText = "SELECT *FROM PUBLIC.\"Yemekler\" where \"yemekAd\"=@p1" ;
            komut.Parameters.AddWithValue("@p1", comboBox1.Text);
            NpgsqlDataReader read5 = komut.ExecuteReader();
            while(read5.Read())
            {
                yemekId = int.Parse(read5[0].ToString());
            }
            read5.Close();
            komut.CommandText = "select*from public.\"Fatura\"";
            Connection.conn.Close();
            Connection.conn.Open();



            NpgsqlDataReader read = komut.ExecuteReader();
            bool kontrol = true;

            while (read.Read())
            {
                if (read[1].ToString() == masaId.ToString())
                { kontrol = false;
                    break;
                }
            }
            read.Close();
            if(kontrol)
            {
                komut.CommandText = "insert into public.\"Fatura\" (\"masaNo\")values(@masa)";
                komut.Parameters.AddWithValue("@masa", masaId);
                komut.ExecuteNonQuery();

            }
            komut.CommandText = "Select *from public.\"Fatura\" where\"masaNo\"= " + masaId;
            NpgsqlDataReader read2 = komut.ExecuteReader();
            
            
                while(read2.Read())
                {
                    faturaNo = int.Parse(read2[0].ToString());

                }
            
            read2.Close();  


            komut.CommandText = "insert into public.\"MasaSiparis\" (\"faturaNo\",\"yemekId\",\"yemekAdet\",\"masaId\")values(@a1,@a2,@a3,@a5)";
            komut.Parameters.AddWithValue("@a1", faturaNo);
            komut.Parameters.AddWithValue("@a2", yemekId);
            komut.Parameters.AddWithValue("@a3", yemekAdet);
            komut.Parameters.AddWithValue("@a5", masaId);
            komut.ExecuteNonQuery();
            komut.CommandText = "call \"SiparisTutariniKaydet\"(@t1,@t2,@t3,@t4)";
            komut.Parameters.AddWithValue("@t1",faturaNo);
            komut.Parameters.AddWithValue("@t2",masaId);
            komut.Parameters.AddWithValue("@t3",yemekId);
            komut.Parameters.AddWithValue("@t4",yemekAdet);
            komut.ExecuteNonQuery();

            Connection.conn.Close();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection.conn.Open();
            NpgsqlCommand komut = new NpgsqlCommand();
            komut.CommandType = CommandType.Text;
            komut.Connection = Connection.conn;
            komut.CommandText = "insert into public.\"GorevliGarson\"(\"calisanNo\",\"sorumluMasıD\")values(@no,@masaId)";
            komut.Parameters.AddWithValue("@no", comboBox3.SelectedIndex + 1000);
            int masaId = int.Parse(comboBox2.Text);
            komut.Parameters.AddWithValue("@masaId",masaId );
            komut.ExecuteNonQuery();

            Connection.conn.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            NpgsqlCommand komut = new NpgsqlCommand();
            komut.CommandType = CommandType.Text;
            komut.Connection= Connection.conn;
            Connection.conn.Open();
            komut.CommandText = "select \"iletisim\".\"telNo\" from public.\"KayitliMusteri\" as \"kayitli\" inner join public.\"Iletisim\" as \"iletisim\" on  \"kayitli\".\"iletisimBilgi\" = \"iletisim\".\"iletisimId\"";
            NpgsqlDataReader read;
            read=komut.ExecuteReader();
            bool kontrol = true;
            while(read.Read())
            {
                if (read[0].ToString() == textBox5.Text)
                {
                    MessageBox.Show("Müşteri Bulundu.İndirim Oranı Hesap Tutarına Yansıtılacaktır");
                    kontrol = false;
                    break;
                }
            }
            read.Close();

            komut.CommandText = "insert into public.\"GuncelMusteri\"(\"musteriAd\",\"musteriSoyad\",\"telNo\",\"oturduguMasa\")values(@p1,@p2,@p3,@p4)";
            komut.Parameters.AddWithValue("@p1",textBox3.Text);
            komut.Parameters.AddWithValue("@p2", textBox4.Text);
            komut.Parameters.AddWithValue("@p3", textBox5.Text);
            komut.Parameters.AddWithValue("@p4", int.Parse(comboBox2.Text));
            komut.ExecuteNonQuery();



            Connection.conn.Close();
            if (kontrol)
            {
                Connection.conn.Open();

                komut.CommandText = "insert into public.\"GuncelMusteri\" (\"musteriAd\" ,\"musteriSoyad\",\"telNo\") values (@p1,@p2,@p3)";
                komut.Parameters.AddWithValue("@p1", textBox3.Text);
                komut.Parameters.AddWithValue("@p2", textBox4.Text);
                komut.Parameters.AddWithValue("@p3", textBox5.Text);
                komut.ExecuteNonQuery();
                Connection.conn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int masaId = int.Parse(comboBox2.Text);
            NpgsqlCommand komut = new NpgsqlCommand();
            Connection.conn.Open();
            komut.Connection = Connection.conn;
            komut.CommandType = CommandType.Text;
            komut.CommandText = "call public.\"TutarKaydet\"(@p1) ";
            komut.Parameters.AddWithValue("@p1", masaId);
            komut.ExecuteNonQuery();
            Connection.conn.Close();



        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
