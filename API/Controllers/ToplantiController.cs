using ClassLibrary2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    public class ToplantiController:ApiController
    {
        proje1Entities _ent = new proje1Entities();
        ToplantiIslemleri ti = new ToplantiIslemleri();

        [HttpGet]
        public List<ToplantiTip> ToplantilariListele()
        {
            return ti.ToplantilariListele();
        }

        [HttpGet]
        public List<ToplantiTip> ToplantiSilId(int id)
        {

            return ti.ToplantiSilId(id);
        }

        [HttpPost]
        public List<ToplantiTip> ToplantiEkle(Toplanti veri)
        {
            try
            {
                _ent.Toplanti.Add(veri);
                _ent.SaveChanges();
                return ToplantilariListele();
            }
            catch(Exception)
            {
                return null;
            }

        }

        [HttpPost]
        public bool ToplantiGuncelle(Toplanti yeni)
        {
            try
            {
                Toplanti eski = _ent.Toplanti.Find(yeni.ToplantiID);
                eski.ToplantiKonusu = yeni.ToplantiKonusu;
                eski.Tarih = yeni.Tarih;
                eski.BaslangicSaati = yeni.BaslangicSaati;
                eski.BitisSaati = yeni.BitisSaati;
                eski.Katilimcilar = yeni.Katilimcilar;
                eski.KullaniciID = yeni.KullaniciID;
                _ent.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }

        }


    }
}