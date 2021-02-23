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

        public static string RentalAdded = "Araba kiralama işlemi başarıyla gerçekleşti";
        public static string RentalDeleted = "Araba kiralama işlemi iptal edildi";
        public static string RentalUpdated = "Araba kiralama işlemi güncellendi";
        public static string FailedRentalAddOrUpdate = "Bu araba henüz teslim edilmediği için kiralama işlemi yapamazsınız";
        public static string RentalReturned = "Kiraladığınız araç teslim edildi.";

        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerUpdated = "Müşteri güncellendi";

        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdated = "Kullanıcı güncellendi";


    }
}
