using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Constants
{
    public static class Messages<T>
    {
        private static readonly string EntityName = typeof(T).Name;

        public static string EntityAdded => $"{EntityName} başarıyla eklendi.";
        public static string EntityUpdated => $"{EntityName} başarıyla güncellendi.";
        public static string EntityDeleted => $"{EntityName} verisine soft delete yapıldı.";
        public static string EntityNotFound => $"Girdiğiniz id değerine sahip {EntityName} verisi bulunamadı.";
        public static string EntityNameDuplicated => $"Bu isme sahip bir {EntityName} zaten var, lütfen ismi değiştirin.";
        public static string EntityAlreadyDeleted => $"Girdiğiniz id değerine sahip {EntityName} zaten silinmiş.";
    }
}
