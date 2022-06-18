using PasswordGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSaveCloudClient.Core
{
    public class PasswordTool
    {
        private PasswordTool() { }

        public static bool CheckRequirements(string password)
        {
            if (password.Length < 6)
            {
                return false;
            }
            return true;
        }

        public static string GeneratePassword()
        {
            Password pwd = new(12);
            return pwd.Next();
        }
    }
}
