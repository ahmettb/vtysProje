using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Npgsql;


namespace restorant
{
    public static class Connection
    {
        public static NpgsqlConnection conn = new NpgsqlConnection("server=localHost;port=5432;Database=restoran;user Id=postgres;password=Ahmet.1212");






    }
}
