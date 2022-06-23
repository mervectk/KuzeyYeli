using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuzeyYeli.ORM
{
    class Tools

        //connectionstring projenin her alanından erişim için kuzeyyeli.orm sağ tıkla tools classı ekledik
        //sınıf public olmasına gerek yok..
    {
        //propfull tab tab yaptık!!

        //1.adım app config dosyasına bağlantı tanımlamadan önce!!
        //private SqlConnection baglanti=new SqlConnection("Data Source=DESKTOP-U079LL1;Initial Catalog=KuzeyYeli;Integrated Security=True");

        //2.adım appcofig düzenledik ve add references systam.configuration ekledik

        private static SqlConnection baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["KuzeyYeli"].ConnectionString);

        //static verirsek tools dan instance almadan baglantıya erişim sağladık(tools.sqlconnection ile bağlantı sağlayacagız)
        public static SqlConnection Baglanti
        {
            get { return baglanti; }
            set { baglanti = value; }
        }

        public static bool ExecuteNonQuery(SqlCommand komut)
        {
            //insert,delete işlemleri için urunlerde tanımladığımız baglantı aç-kapa işlemlerini
            //tools  metot şeklinde oluşturduk ve metot çağırarak işlemlerde aç-kapa yaptık!!

            // //return olunca alt satırlar normalde çalışmaz.Ancak try-catch-finally içerisinde
            //finally blok çalışır...Sonucu içerisinde tutup sonra return tekrar döner!!

            try
            {
                if (komut.Connection.State != ConnectionState.Open)
                    komut.Connection.Open();
                return komut.ExecuteNonQuery() > 0;

            }
            catch (Exception)
            {
                return false;

            }
            finally
            {
                if (komut.Connection.State != ConnectionState.Closed)
                    komut.Connection.Close();

            }

        }

        public static DataTable Listele(string procedureName)//select metotu
        {
            //Urunler,Kategori vb tablolar için select işlemi yaparken ayrı ayrı yazmamak için metot tanımladık!!
            SqlDataAdapter adaptor = new SqlDataAdapter(procedureName, Tools.Baglanti);
            adaptor.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adaptor.Fill(dt);
            return dt;

        }

    }
}
