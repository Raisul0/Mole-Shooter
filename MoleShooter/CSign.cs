using MoleShooter.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace MoleShooter
{
    class CSign:CImageBase
    {
        Rectangle _starthitspot;
        Rectangle _stopthitspot;
        Rectangle _resethitspot;
        Rectangle _quithitspot;

        public CSign()
            :base(Resources.Sign)
        {
            _starthitspot.X = Left + 70;
            _starthitspot.Y = Top + 42;
            _starthitspot.Width = 52;
            _starthitspot.Height = 16;

            _stopthitspot.X = Left + 70;
            _stopthitspot.Y = Top + 63;
            _stopthitspot.Width = 52;
            _stopthitspot.Height = 16;

            _resethitspot.X = Left + 70;
            _resethitspot.Y = Top + 85;
            _resethitspot.Width = 52;
            _resethitspot.Height = 16;

            _quithitspot.X = Left + 70;
            _quithitspot.Y = Top + 113;
            _quithitspot.Width = 52;
            _quithitspot.Height = 16;
        }

        public bool Hit(int x, int y)
        {
            Rectangle c = new Rectangle(x, y, 1, 1); //Checks weather the cursor hits the mole or not

            if (_starthitspot.Contains(c))
            {
                return true;
            }

            return false;
        }
    }
}
