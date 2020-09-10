using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace mhrs_randevu_otomasyonu
{
    class connection
    {
        public static string con
        {
            get { return @"Server=localhost;Database=proje;Uid=root;Pwd=''"; }
        }
    }
}
