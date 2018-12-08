using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace CMS.MvcUI.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class IslemSonucModel
    {
        [JsonProperty]
        public int IslemKodu { get; set; }
        [JsonProperty]
        public string Baslik { get; set; }
        [JsonProperty]
        public string Aciklama { get; set; }
        [JsonProperty]
        public string AciklamaDetay { get; set; }
        [JsonProperty]
        public object Data { get; set; }

        public IslemSonucModel()
        {

        }

        public IslemSonucModel(int islemKodu, string baslik, string aciklama, string aciklamaDetay, object data)
        {
            this.IslemKodu = islemKodu;
            this.Baslik = baslik;
            this.Aciklama = aciklama;
            this.AciklamaDetay = aciklamaDetay;
            this.Data = data;
        }

        public IslemSonucModel(IslemSonucuEnum.IslemSonucKodlari islemSonucKodu, string aciklama = "", string aciklamaDetay = "", object data = null)
        {
            this.IslemKodu = (int)islemSonucKodu;
            this.Baslik = islemSonucKodu.ToDescriptionString();
            this.Aciklama = aciklama;
            this.AciklamaDetay = aciklamaDetay;
            this.Data = data;
        }

    }
}