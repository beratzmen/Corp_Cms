using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using static CMS.MvcUI.Models.IslemSonucuEnum;

namespace CMS.MvcUI.Models
{

    public class IslemSonucuEnum
    {
        public enum IslemSonucKodlari
        {
            [Description("BAŞARILI")]
            Basarili = 1,
            [Description("HATA")]
            Hata = 2,
            [Description("UYARI")]
            Uyari = 3,
            [Description("BİLGİLENDİRME")]
            Bilgilendirme = 4
        }
    }

    public static class ResultCodesExtensions
    {
        public static string ToDescriptionString(this IslemSonucKodlari val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
