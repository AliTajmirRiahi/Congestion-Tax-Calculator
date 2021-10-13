using System;
using System.Threading.Tasks;

namespace Anshan.Framework.Permission
{
    public interface IShop
    {
        ShopInfoModel GetShopInfo();
        Task<ShopInfoModel> GetShopInfoUrl();
    }
}