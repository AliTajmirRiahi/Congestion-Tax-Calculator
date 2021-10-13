using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace Framework.CommonUtility
{
    public enum LinkListType { Pages = 0, Collections = 1, Article = 2, News = 3, Product = 4 }

    public static class CommonUtility
    {
        public static bool ValidateJSON(string s)
        {
            try
            {
                JToken.Parse(s);
                return true;
            }
            catch (JsonReaderException)
            {
                return false;
            }
        }
        public static T deepClone<T>(T obj)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
        }
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
        public static string GetLinkListUrl(LinkListType type, int Id, string Slug)
        {
            if (string.IsNullOrEmpty(Slug))
                return "/notfound";
            switch (type)
            {
                case LinkListType.Pages:
                    break;
                case LinkListType.Collections:
                    return "/collection/" + Slug;
                case LinkListType.Article:
                    return "/article/" + Slug;
                case LinkListType.News:
                    return "/news/" + Slug;
                case LinkListType.Product:
                    return "/product/" + Slug;
                default:
                    return "/notfound";
            }
            return "/notfound";
        }
    }
}
