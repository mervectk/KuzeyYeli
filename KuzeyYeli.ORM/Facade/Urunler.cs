using KuzeyYeli.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuzeyYeli.ORM.Facade
{
    public class Urunler

    //public yaptık
    //sadece metot çalıştırmak için class oluşturuyorsak static yapmak en doğrusudur!!
    {
        //select işlemi
        public static DataTable Listele()
        {
           return Tools.Listele("UrunListele");
            //URUNLISTELE=STORED PROCEDURE
            

        }
        //insert işlemi
        public static bool Ekle(Urun entity)
            
        {
            SqlCommand komut = new SqlCommand("UrunEkle", Tools.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@urunAdi", entity.UrunAdi);
            komut.Parameters.AddWithValue("@fiyat", entity.Fiyat);
            komut.Parameters.AddWithValue("@stok", entity.Stok);
            //return olunca alt satırlar normalde çalışmaz.Ancak try-catch-finally içerisinde
            //finally blok çalışır...Sonucu içerisinde tutup sonra return tekrar döner!!
            return Tools.ExecuteNonQuery(komut);

         

        }
        //delete işlemi
        public static bool Sil(Urun entity)
        {
            SqlCommand komut = new SqlCommand("UrunSil", Tools.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@urunId", entity.UrunId);
           
            //return olunca alt satırlar normalde çalışmaz.Ancak try-catch-finally içerisinde
            //finally blok çalışır...Sonucu içerisinde tutup sonra return tekrar döner!!
            return Tools.ExecuteNonQuery(komut);
        }
        //update işlemi
        public static bool Guncelle(Urun entity)
        {
            SqlCommand komut = new SqlCommand("UrunGuncelle", Tools.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@a", entity.UrunAdi);
            komut.Parameters.AddWithValue("@f", entity.Fiyat);
            komut.Parameters.AddWithValue("@s", entity.Stok);
            komut.Parameters.AddWithValue("@id", entity.UrunId);

            //return olunca alt satırlar normalde çalışmaz.Ancak try-catch-finally içerisinde
            //finally blok çalışır...Sonucu içerisinde tutup sonra return tekrar döner!!
            return Tools.ExecuteNonQuery(komut);
        }
           
    }
}
