using MoleShooter.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace MoleShooter
{
    class CMole :CImageBase
    {
        private Rectangle _molehotspot = new Rectangle();
        public CMole()
            :base(Resources.Mole)
        {
            _molehotspot.X= Left + 20;
            _molehotspot.Y = Top - 1;
            _molehotspot.Width=30;
            _molehotspot.Height=40;
        }
        
        public void Update(int x, int y)
        {
            Left = x;
            Top = y;
            _molehotspot.X = Left + 20;
            _molehotspot.Y = Top -1;
        }

        public bool Hit(int x,int y)
        {
            Rectangle c = new Rectangle(x-2, y-2, 5, 5); //Checks weather the cursor hits the mole or not

            if (_molehotspot.Contains(c))
            {
                return true;
            }

            return false;
        }
    }
}
