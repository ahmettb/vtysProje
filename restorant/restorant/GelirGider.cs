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
    public partial class GelirGider : Form
    {
        public GelirGider()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection.conn.Open();
            NpgsqlCommand komut = new NpgsqlCommand();
            komut.CommandText = "SELECT *FROM PUBLIC.\"Analiz\"";
            komut.Connection=Connection.conn;
            komut.CommandType = CommandType.Text;   
            NpgsqlDataAdapter data = new NpgsqlDataAdapter(komut);
            DataSet dt = new DataSet();
            data.Fill(dt);
            dataGridView1.DataSource = dt.Tables[0];
            Connection.conn.Close();

        }
    }
}
