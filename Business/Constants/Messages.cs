using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added ="Ekleme işlemi başarılı";
        public static string Deleted = "Silme işlemi başarılı";
        public static string Updated = "Güncelleme işlemi başarılı";
        public static string MaintenanceTime="Sistem Bakımda";
        public static string CarsListed = "Araçlar listelendi";
        public static string BrandsListed = "Araç marka bilgileri listelendi";
        public static string ColorsListed = "Araç renk bilgileri listelendi.";
        public static string Error = "Beklenmedik bir hata oluştu";
        public static string ColorNameInvalid = "Renk bilgisi en az iki karakter olmalıdır";
        public static string BrandNameInvalid = "Marka bilgisi en az 2 karakter olmalıdır gözünü sevem";
        public static string DescriptionInvalid = "Açıklama 2 karakterden büyük olmalıdır";
        public static string DailyPriceInvalid = "Araç günlük kirası 0'dan büyük olmalıdır.";
        public static string IdError = "Girdiğiniz ID bilgisi sistemde bulunamadı";
    }
}
