using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class ToplantiIslemleri //diğer katmanlardan da erişmek için public olarak tanımlıyoruz.
    {
        proje1Entities _ent = new proje1Entities();//yeni bir nesne oluşturuyoruz.

        public List<ToplantiTip> ToplantilariListele()
        {

           return _ent.Toplanti.Select(p => new ToplantiTip() {
                ToplantiID = p.ToplantiID,
                ToplantiKonusu=p.ToplantiKonusu,
                Tarih=p.Tarih,
                BaslangicSaati=p.BaslangicSaati,
                BitisSaati=p.BitisSaati,
                Katilimcilar=p.Katilimcilar

            }).ToList();
        }

        public List<ToplantiTip> ToplantiSilId(int id)
        {
            Toplanti silinecek = _ent.Toplanti.Find(id);//silinecek toplantıyı bulur.
            _ent.Toplanti.Remove(silinecek);//toplantıyı siler.
            _ent.SaveChanges();//değişiklikleri kaydeder.

            return ToplantilariListele();
        }

    }

    public class ToplantiTip
    {
        public int ToplantiID { get; set; }
        public string ToplantiKonusu { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
        public Nullable<System.TimeSpan> BaslangicSaati { get; set; }
        public Nullable<System.TimeSpan> BitisSaati { get; set; }
        public string Katilimcilar { get; set; }
        public Nullable<int> KullaniciID { get; set; }
    }
}
