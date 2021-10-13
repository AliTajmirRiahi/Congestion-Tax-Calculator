using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Anshan.Framework.Permission
{
    public class ShopInfo : IShop
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ShopInfo(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.GetUserId();
            return userId;
        }

        public string GetClientId()
        {
            var client = _httpContextAccessor.HttpContext.User
                .Claims.FirstOrDefault(c => c.Type == "client_id");
            return client?.Value;
        }

        public int GetProjectId()
        {
            var projectIdString = GetClientId().Split('-')[0];
            var isNumeric = int.TryParse(projectIdString, out var projectId);

            if (!isNumeric)
                throw new Exception("There is something error");

            return projectId;
        }

        public ShopInfoModel GetShopInfo()
        {
            var user = _httpContextAccessor.HttpContext.User;
            if (user == null)
                return null;
            return new ShopInfoModel(
                Guid.Parse(user.Claims.FirstOrDefault(x => x.Type == "Id")?.Value),
                int.Parse(user.Claims.FirstOrDefault(x => x.Type == "ShopId")?.Value),
                user.Claims.FirstOrDefault(x => x.Type == "AccessAddress")?.Value,
                user.Claims.FirstOrDefault(x => x.Type == "ThemeName")?.Value
                );
        }

        public Task<ShopInfoModel> GetShopInfoUrl()
        {
            throw new NotImplementedException();
        }
    }
}