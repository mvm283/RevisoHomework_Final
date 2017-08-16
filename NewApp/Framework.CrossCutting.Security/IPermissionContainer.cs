using System;
using System.Text;
using System.Threading.Tasks;

namespace Framework.CrossCutting.Security
{
    public interface IPermissionContainer
    {
        bool HasPermission(string role, Permission permission);
        void Register(IPermissionExposer exposer);
    }
}
