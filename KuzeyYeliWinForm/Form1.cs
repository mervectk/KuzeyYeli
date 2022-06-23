using KuzeyYeli.ORM.Entity;
using KuzeyYeli.ORM.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuzeyYeliWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //kuzeyyeli.orm referanslardan ekledik!!
            dataGridView1.DataSource = Urunler.Listele();
        }

        private void btn_Ekle_Click(object sender, EventArgs e)
        {
           //numericupdown maksimumlarını arttır!!
            
            Urun entity = new Urun();
            entity.UrunAdi = txtUrunAdi.Text;
            entity.Fiyat = nupFiyat.Value;
            entity.Stok = (short)nupStok.Value;
            //Şayet urunlerin ekle metotu false dönerse
            if (!Urunler.Ekle(entity))                
                MessageBox.Show("Ürün Eklenemedi");
           
            else
                MessageBox.Show("Ürün Eklendi");
            dataGridView1.DataSource = Urunler.Listele();
        }

        private void btn_Sil_Click(object sender, EventArgs e)
        {
            //datagriedview  özelliklerinden selection mode=fullrowselect seç ki tüm satırlar seçilsin
            if (dataGridView1.SelectedRows.Count == 0) return;
            Urun silinecek = new Urun(); //silinecek entity oluşturduk!!
            silinecek.UrunId = (int)dataGridView1.CurrentRow.Cells["UrunID"].Value;//cast ettik
            if (!Urunler.Sil(silinecek))
                MessageBox.Show("Ürün silinemedi");
            else
                MessageBox.Show("Ürün Silindi");
            dataGridView1.DataSource = Urunler.Listele();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            txtUrunAdi.Text = row.Cells["UrunAdi"].Value.ToString();
            txtUrunAdi.Tag = row.Cells["UrunId"].Value;
            nupFiyat.Value = (decimal)row.Cells["Fiyat"].Value;
            nupStok.Value = Convert.ToDecimal(row.Cells["Stok"].Value);
        }

        private void btn_Guncelle_Click(object sender, EventArgs e)
        {
            Urun update = new Urun();
            update.UrunId = (int)txtUrunAdi.Tag; //urun adı yazan urunun ıd sine bakacak.Aynı adlı farklı ıd li ürünlerde güncelleme yapabilmemizi saglar
            update.UrunAdi = txtUrunAdi.Text;
            update.Fiyat = nupFiyat.Value;
            update.Stok = (short)nupStok.Value;
            if (!Urunler.Guncelle(update))
                MessageBox.Show("Ürün güncelleme başarısız");
            else
                MessageBox.Show("Ürün güncelleme yapıldı");
            dataGridView1.DataSource = Urunler.Listele();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
