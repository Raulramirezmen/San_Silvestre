using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace SanSil.BLL.User.Interface
{
    public interface IUserManager
    {
        List<Models.User> GetUsers();
        Models.User GetUser(int id);

        Dictionary<string, string> GetRoleDir();
        int SaveUser(Models.User user);
        void RemoveUser(int id);
        DAL.User GetUpdateUser(WindowsIdentity windowsIdentity);
    }
}
