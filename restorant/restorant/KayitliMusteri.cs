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
    public partial class KayitliMusteri : Form
    {
        public KayitliMusteri()
        {
            InitializeComponent();
        }

        private void KayitliMusteri_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            NpgsqlCommand komut = new NpgsqlCommand();
            komut.CommandType = CommandType.Text;
            komut.Connection = Connection.conn;
            Connection.conn.Open();
            komut.CommandText = "Select \"musteri\".\"kayitNo\",\"musteri\".\"musteriAd\",\"musteri\".\"musteriSoyad\",\"musteri\".\"kayitTarih\",\"sehir\".\"sehirAd\",\"ilce\".\"ilceadi\",\"iletisim\".\"adres\"" +
                                "from public.\"KayitliMusteri\" as \"musteri\" inner join public.\"Iletisim\" as \"iletisim\"" +
                           "on \"musteri\".\"iletisimBilgi\" = \"iletisim\".\"iletisimId\"" +
                         "inner join public.\"Sehirler\" as \"sehir\"" +
                      "on \"iletisim\".\"sehir\"= \"sehir\".\"sehirId\"" +
                      "inner join public.\"ilceler\" as \"ilce\"" +
                       " on \"iletisim\".\"ilce\"=\"ilce\".\"ilceId\"";
                NpgsqlDataAdapter data = new NpgsqlDataAdapter(komut);
            DataSet dt = new DataSet();
            data.Fill(dt);
            dataGridView1.DataSource = dt.Tables[0];
            Connection.conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection.conn.Open();
            NpgsqlCommand komut = new NpgsqlCommand();
            komut.CommandText = "DELETE FROM PUBLIC.\"KayitliMusteri\" WHERE \"kayitNo\"=" + int.Parse(textBox7.Text);
            komut.CommandType = CommandType.Text;
            komut.Connection=Connection.conn;
            komut.ExecuteNonQuery();
            Connection.conn.Close();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            int sehirId = 0;
            int ilceId = 0;


            Connection.conn.Open();
            NpgsqlCommand komut = new NpgsqlCommand();
            komut.CommandText = "SELECT*FROM PUBLIC.\"Sehirler\" WHERE \"sehirAd\"=@p1";
            komut.Parameters.AddWithValue("@p1",textBox4.Text);
            komut.CommandType = CommandType.Text;
            komut.Connection = Connection.conn;
            NpgsqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                sehirId = int.Parse(read[0].ToString());
            }
            read.Close();
            komut.CommandText = "SELECT*FROM PUBLIC.\"ilceler\" WHERE \"ilceadi\"=@p2";
            komut.Parameters.AddWithValue("@p2", textBox5.Text);

            read = komut.ExecuteReader(); 
            while(read.Read())
            {
                ilceId = int.Parse(read[0].ToString());
            }
            read.Close();
            komut.CommandText = "INSERT INTO PUBLIC.\"Iletisim\"(\"sehir\",\"ilce\",\"adres\",\"telNo\") VALUES(@p6,@p7,@p3,@p4)";
            komut.Parameters.AddWithValue("@p6",sehirId);
            komut.Parameters.AddWithValue("@p7",ilceId);
            komut.Parameters.AddWithValue("@p3",textBox6.Text);
            komut.Parameters.AddWithValue("@p4",textBox3.Text);
            komut.ExecuteNonQuery();

            komut.CommandText = "SELECT *FROM PUBLIC.\"Iletisim\" WHERE \"telNo\"=" + textBox3.Text;
            read=komut.ExecuteReader();
            int iletisimId = 0;
            while (read.Read())
            {
                 iletisimId = int.Parse(read[0].ToString());

            }
            read.Close();
            komut.CommandText = "INSERT INTO  PUBLIC.\"KayitliMusteri\" (\"musteriAd\",\"musteriSoyad\",\"iletisimBilgi\") VALUES(@p1,@p2,@p3)";
            komut.Parameters.AddWithValue("@p1",textBox1.Text);
            komut.Parameters.AddWithValue("@p2",textBox2.Text);
            komut.Parameters.AddWithValue("@p3",iletisimId);
            komut.ExecuteNonQuery();

            Connection.conn.Close();




        }
    }
}
