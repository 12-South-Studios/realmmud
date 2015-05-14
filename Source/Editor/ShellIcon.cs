using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;

namespace Realm.Edit
{
    /// <summary>
    /// Summary description for ShellIcon.
    /// </summary>
    /// <summary>
    /// Summary description for ShellIcon. Get a small or large Icon with an easy C# function call
    /// that returns a 32x32 or 16x16 System.Drawing.Icon depending on which function you call
    /// either GetSmallIcon(string fileName) or GetLargeIcon(string fileName)
    /// </summary>
    public static class ShellIcon
    {
        public static Icon extractIconFromFile(string aFile, int aIndex, bool aLargeIcon)
        {
            var hDummy = new[] { IntPtr.Zero };
            var hIconEx = new[] { IntPtr.Zero };

            try
            {
                int readIconCount = aLargeIcon
                    ? NativeMethods.ExtractIconEx(aFile, aIndex, hIconEx, hDummy, 1)
                    : NativeMethods.ExtractIconEx(aFile, aIndex, hDummy, hIconEx, 1);

                if (readIconCount <= 0 || hIconEx[0] == IntPtr.Zero)
                    return null;
                else
                {
                    // GET FIRST EXTRACTED ICON
                    return (Icon)Icon.FromHandle(hIconEx[0]).Clone();
                }
            }
            catch (Exception ex)
            {
                /* EXTRACT ICON ERROR */

                // BUBBLE UP
                throw new EditorException("Could not extract icon", ex);
            }
            finally
            {
                // RELEASE RESOURCES
                foreach (IntPtr ptr in hIconEx.Where(ptr => ptr != IntPtr.Zero))
                    NativeMethods.DestroyIcon(ptr);

                foreach (IntPtr ptr in hDummy.Where(ptr => ptr != IntPtr.Zero))
                    NativeMethods.DestroyIcon(ptr);
            }
        }

        public static Icon GetSmallIcon(string fileName)
        {
            var shinfo = new NativeMethods.SHFILEINFO();

            //Use this to get the small Icon
            NativeMethods.SHGetFileInfo(fileName, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo),
                NativeMethods.SHGFI_ICON | NativeMethods.SHGFI_SMALLICON);

            //The icon is returned in the hIcon member of the shinfo struct
            return Icon.FromHandle(shinfo.hIcon);
        }

        public static Icon GetLargeIcon(string fileName)
        {
            var shinfo = new NativeMethods.SHFILEINFO();

            //Use this to get the large Icon
            NativeMethods.SHGetFileInfo(fileName, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo),
                NativeMethods.SHGFI_ICON | NativeMethods.SHGFI_LARGEICON);

            //The icon is returned in the hIcon member of the shinfo struct
            return Icon.FromHandle(shinfo.hIcon);
        }
    }
}

