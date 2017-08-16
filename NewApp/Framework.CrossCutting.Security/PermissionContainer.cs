using System.Collections.Generic;
using System.Linq;

namespace Framework.CrossCutting.Security
{
    public class PermissionContainer : IPermissionContainer
    {
        Dictionary<string,List<Permission>> permissions = new Dictionary<string, List<Permission>>(); 
        public bool HasPermission(string role, Permission permission)
        {
            if (permissions.ContainsKey(role))
            {
                return permissions[role].Any(a => a.Equals(permission));
            }
            return false;
        }

        public void Register(IPermissionExposer exposer)
        {
            //TODO: add exposed permissions to permissions
            permissions = exposer.Expose();
        }
    }
}