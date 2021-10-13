using System;
using System.Collections.Generic;
using System.Text;

namespace Anshan.Framework.Permission
{
    public class ShopInfoModel
    {
        public ShopInfoModel()
        {

        }
        public ShopInfoModel(Guid userId, int shopId, string accessAddress, string themeName)
        {
            UserId = userId;
            Id = shopId;
            AccessAddress = accessAddress;
            ThemeName = themeName;
        }

        public Guid UserId { get; private set; }
        public int Id { get; private set; }
        public string AccessAddress { get; set; }
        public string ShopName { get; set; }
        public string Title { get; set; }
        public bool IsEnable { get; set; }
        public bool IsExpired { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }
        public string Tell { get; set; }
        public string Email { get; set; }
        public string ThemeName { get; set; }
    }
}
