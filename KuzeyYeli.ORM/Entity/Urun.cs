using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuzeyYeli.ORM.Entity
{
    public class Urun

    {
        //KuzeyYeli.ORM oluşturmak için--solution sağ tıkla--add project-class library(.net framework)ekle
        //Entity dosyasına sag tıkla add new item class ekle
        //tablo adları entity içinde tekil olur!!
        //class public yaptık!!
        //property için prop tab tab yap
        public int UrunId{ get; set; }
        public string UrunAdi { get; set; }
        public decimal Fiyat { get; set; } //db money tipine karşılık gelir
        public short Stok { get; set; } //db smallint tipine karşılık gelir
        public int KategoriID { get; set; }
        public int TedarikciID { get; set; }
        public string BirimdekiMiktar { get; set; }
        public short YeniSatis{ get; set; }
        public short EnAzYenidenSatisMiktari { get; set; }
        public bool Sonlandi { get; set; } //db de bit


    }
}
