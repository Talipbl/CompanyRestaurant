using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string AuthorizationDenied = "Bu işlem için yetkiniz yok";
        public static string Added = "Eklendi";
        public static string Deleted = "Silindi";
        public static string Updated = "Güncellendi";
        public static string Listed = "Listelendi";
        public static string AllListed = "Tamamı Listelendi";
        public static string Error = "Hata";
        internal static string TableStatusOrderOfExplanation = "True , False";

        public static class Product
        {
            public static string Added = "Ürün eklendi";
            public static string NameInvalid = "Ürün ismi geçersiz";
            public static string Listed = "Ürün listelendi";
            public static string ProductsListed = "Ürünler listelendi";
            public static string Deleted = "Ürün silindi";
            public static string Updated = "Ürün güncellendi";
            public static string CountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir";
            public static string ProductNameExists = "Bu üründen zaten var";
        }
        
        public static class Category
        {
            public static string Added = "Kategori eklendi";
            public static string Listed = "Kategoriler listelendi";
            public static string Deleted = "Kategori silindi";
            public static string Updated = "Kategori güncellendi";
            internal static string LimitExceded = "Katori limit aşıldı";
        }
    }
}
