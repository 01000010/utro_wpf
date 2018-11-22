using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Runtime.InteropServices;

namespace utro_wpf.core
{
    /// <summary>
    /// Helpers for the <see cref="SecureString"/> class
    /// </summary>
    public static class SecureStringHelpers
    {
        /// <summary>
        /// Unsecures a <see cref="SecureString"/> to plain text
        /// </summary>
        /// <param name="securePassword"></param>
        /// <returns></returns>
        public static string Unsecure(this SecureString secureString) // getting C++ vibes here
        {
            // Make sure we have a secure string
            if (secureString == null) return string.Empty;
            
            // Get a pointer for an unsecure 
            IntPtr unmagedString = IntPtr.Zero;

            try
            {
                // Unsecures the password
                unmagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmagedString);
            }
            finally
            {
                // Clean up after ourselves
                Marshal.ZeroFreeGlobalAllocUnicode(unmagedString);
            }
        }
    }
}
