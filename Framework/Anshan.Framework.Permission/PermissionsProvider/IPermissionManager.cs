using System.Threading.Tasks;

namespace Anshan.Framework.Permission.PermissionsProvider
{
    public interface IPermissionManager
    {
        Task<bool> HasPermission(string userId, string permission);
    }
}