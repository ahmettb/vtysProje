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
    public partial class Yemekler : Form
    {
        public Yemekler()
        {
            InitializeComponent();

            NpgsqlCommand komut = new NpgsqlCommand();
            Connection.conn.Open();
            komut.CommandType = CommandType.Text;
            komut.Connection = Connection.conn;
            komut.CommandText = "select*from public.\"YemekKategori\"";
            NpgsqlDataReader read=komut.ExecuteReader();
            while(read.Read())
            {
                comboBox1.Items.Add(read[1].ToString());
                comboBox2.Items.Add(read[1].ToString());

            }
            read.Close();
            Connection.conn.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            NpgsqlCommand komut = new NpgsqlCommand();
            Connection.conn.Open();
            komut.CommandType = CommandType.Text;
            komut.Connection = Connection.conn;
            komut.CommandText = "select  count(public.\"Yemekler\".\"yemekAd\"),  public.\"YemekKategori\".\"kategoriAd\" from public.\"Yemekler\" inner join public.\"YemekKategori\" on public.\"Yemekler\".\"yemekKategori\"=public.\"YemekKategori\".\"kategoriId\"" +
            "group by  public.\"YemekKategori\".\"kategoriAd\" order by  public.\"YemekKategori\".\"kategoriAd\"";
            NpgsqlDataAdapter data = new NpgsqlDataAdapter(komut);
            DataSet dt = new DataSet();
            data.Fill(dt);
            Connection.conn.Close();
            dataGridView1.DataSource = dt.Tables[0];
            Connection.conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlCommand komut = new NpgsqlCommand();
            Connection.conn.Open();
            komut.CommandType = CommandType.Text;
            komut.Connection = Connection.conn;
            komut.CommandText = "select  public.\"Yemekler\".\"yemekId\",public.\"Yemekler\".\"yemekAd\",  public.\"YemekKategori\".\"kategoriAd\" from public.\"Yemekler\" inner join public.\"YemekKategori\" on public.\"Yemekler\".\"yemekKategori\"=public.\"YemekKategori\".\"kategoriId\"" +
            "order by  public.\"YemekKategori\".\"kategoriAd\"";
            NpgsqlDataAdapter data = new NpgsqlDataAdapter(komut);
            DataSet dt = new DataSet();
            data.Fill(dt);
            Connection.conn.Close();
            dataGridView1.DataSource= dt.Tables[0];
            Connection.conn.Close();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            NpgsqlCommand komut = new NpgsqlCommand();
            Connection.conn.Open();
            komut.CommandType = CommandType.Text;
            komut.Connection = Connection.conn;
            komut.CommandText= "select public.\"Yemekler\".\"yemekId\", public.\"Yemekler\".\"yemekAd\",  public.\"YemekKategori\".\"kategoriAd\" from public.\"Yemekler\" inner join public.\"YemekKategori\" on public.\"Yemekler\".\"yemekKategori\"=public.\"YemekKategori\".\"kategoriId\"" +
            " where public.\"YemekKategori\".\"kategoriAd\"=@p1 order by  public.\"YemekKategori\".\"kategoriAd\"";
            komut.Parameters.AddWithValue("@p1", comboBox1.Text);
            NpgsqlDataAdapter data = new NpgsqlDataAdapter(komut);
            DataSet dt = new DataSet();
            data.Fill(dt);
            Connection.conn.Close();
            dataGridView1.DataSource = dt.Tables[0];
            Connection.conn.Close();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            NpgsqlCommand komut = new NpgsqlCommand();
            Connection.conn.Open();
            komut.CommandType = CommandType.Text;
            komut.Connection = Connection.conn;
            komut.CommandText = "select public.\"Ascilarimiz\".\"ad\",public.\"Ascilarimiz\".\"soyad\",public.\"YemekKategori\".\"kategoriAd\" from public.\"Ascilarimiz\" inner join public.\"YemekKategori\" on public.\"Ascilarimiz\".\"yemekKategori\"=public.\"YemekKategori\".\"kategoriId\"" +
"order by public.\"YemekKategori\".\"kategoriAd\"";
            NpgsqlDataAdapter data = new NpgsqlDataAdapter(komut);
            DataSet dt = new DataSet();
            data.Fill(dt);
            Connection.conn.Close();
            dataGridView1.DataSource = dt.Tables[0];
            Connection.conn.Close();


        }

        private void button6_Click(object sender, EventArgs e)
        {
            NpgsqlCommand komut = new NpgsqlCommand();
            Connection.conn.Open();
            komut.CommandType = CommandType.Text;
            komut.Connection = Connection.conn;
            komut.CommandText = "insert into public.\"Yemekler\" (\"yemekAd\",\"yemekFiyati\",\"yemekKategori\")values(@p1,@p2,@p3) ";
            komut.Parameters.AddWithValue("@p1",textBox1.Text);
            komut.Parameters.AddWithValue("@p2", decimal.Parse(textBox2.Text));
            komut.Parameters.AddWithValue("@p3", comboBox2.SelectedIndex+1);
            komut.ExecuteNonQuery();
            Connection.conn.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            NpgsqlCommand komut = new NpgsqlCommand();
            Connection.conn.Open();
            komut.CommandType = CommandType.Text;
            komut.Connection = Connection.conn;
            komut.CommandText = "DELETE FROM public.\"Yemekler\" WHERE \"yemekId\"="+int.Parse(textBox3.Text);
            komut.ExecuteNonQuery();
            Connection.conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Yemekler_Load(object sender, EventArgs e)
        {

        }
    }
    }

