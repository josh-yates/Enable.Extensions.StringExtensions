using System;
using System.Runtime.InteropServices;
using System.Security;
using Enable.Common;

namespace Enable.Extensions
{
    public static class SecureStringExtensions
    {
        public static SecureString ToSecureString(this string plainText)
        {
            Argument.IsNotNull(plainText, nameof(plainText));

            var secureString = new SecureString();

            foreach (var c in plainText)
            {
                secureString.AppendChar(c);
            }

            secureString.MakeReadOnly();

            return secureString;
        }

        public static string ToInsecureString(this SecureString secureString)
        {
            Argument.IsNotNull(secureString, nameof(secureString));

            var ptr = IntPtr.Zero;

            try
            {
                ptr = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(ptr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(ptr);
            }
        }
    }
}
