using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;

namespace MoleShooter
{   
    public struct IconInfo
    {
        public bool fTcon;
        public int xhotspot;
        public int yhotspot;
        public IntPtr hbmMask;
        public IntPtr hbmColor;

    }
    class CustomCursor
    {

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);

        [DllImport("user32.dll")]
        public static extern IntPtr CreateIconIndirect(ref IconInfo icon);

        public static System.Windows.Forms.Cursor CreateCursor(Bitmap bmp, int xhotspot, int yhotspot)
        {
            IntPtr ptr = bmp.GetHicon();
            IconInfo tmp = new IconInfo();
            GetIconInfo(ptr, ref tmp);
            tmp.xhotspot = xhotspot;
            tmp.yhotspot = yhotspot;
            tmp.fTcon = false;
            ptr = CreateIconIndirect(ref tmp);
            return new System.Windows.Forms.Cursor(ptr);

        }
    }
}
