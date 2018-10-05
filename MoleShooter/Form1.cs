//#define my_Debug

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoleShooter.Properties;
using System.Media;

namespace MoleShooter
{
    public partial class shooter : Form
    {
#if my_Debug
        int _cursX = 0;
        int _cursY = 0;
#endif  
        int FrameRate= 15;
        int splatRate = 3;
        int _gameframe = 0;
        bool splat = false;
        int _splatTime = 0;

        CMole _mole;
        CSign _sign;
        CScoreboard _scoreboard;
        CSplat _splat;

        int hits =0;
        int misses =0 ;
        int totalshots =0;
        double accuracy=0;


        Random rnd = new Random();

        public shooter()
        {
            InitializeComponent();

            Bitmap b = new Bitmap(Resources.Site);
            this.Cursor = CustomCursor.CreateCursor(b, b.Height / 2, b.Width / 2);


            _mole = new CMole() { Left=70,Top=320 };
            _sign = new CSign() { Left = this.Width-Resources.Sign.Width-100, Top = (this.Height / 2) / 2 };
            _scoreboard = new CScoreboard { Left = 20, Top = 30 };
            _splat = new CSplat();
        }

        private void TimerGameLoop_Tick(object sender, EventArgs e)
        {   
            //Chnage Mole Position after the Duration
            if (_gameframe == FrameRate)
            {
                MoleUpdate();
                _gameframe = 0;
            }

            if(splat == true)
            {
                if(_splatTime >= splatRate)
                {
                    splat = false;
                    _splatTime = 0;
                    MoleUpdate();
                    _gameframe = 0;
                }
                _splatTime++;
            }
            _gameframe++;
            this.Refresh();
        }

        //Creates Mole in Random Location
        private void MoleUpdate()
        {
            _mole.Update(
            rnd.Next(Resources.Mole.Width,this.Width - Resources.Mole.Width),
            rnd.Next(this.Height/2+100,this.Height- Resources.Mole.Height*2)
            );
        }
        protected override void OnPaint(PaintEventArgs e)
        {
           
            Graphics dc = e.Graphics;

            if( splat== true)
            {
                _splat.DrawImage(dc);
            }
            else
            {
                _mole.DrawImage(dc);
            }
            
            _scoreboard.DrawImage(dc);

            // For Maintaining Sign for Windows Size

            if (this.WindowState == FormWindowState.Maximized)
            {
                _sign.Left = this.Width - Resources.Sign.Width - 100;
                _sign.Top = (this.Height/4);
                _sign.DrawImage(dc);

            }
            else
            {
                _sign.Left = this.Width - Resources.Sign.Width - 100;
                _sign.Top = (this.Height / 4);
                _sign.DrawImage(dc);
            }

#if my_Debug
            TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.EndEllipsis;
            Font _font = new System.Drawing.Font("Stencil", 12, FontStyle.Regular);
            TextRenderer.DrawText(dc, "X=" + _cursX.ToString() + ":Y=" + _cursY.ToString(), _font,
                  new Rectangle(30, 20, 120, 30), Color.White , flags);
#endif

            //Put Scores on Screen

            TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.EndEllipsis;
            Font _font = new System.Drawing.Font("Stencil", 10, FontStyle.Regular);
            TextRenderer.DrawText(dc, "Hits :" + hits.ToString(),_font,new Rectangle(30, 50, Resources.Scoreboard.Width, Resources.Scoreboard.Height), Color.Black, flags);
            TextRenderer.DrawText(dc, "Misses :" + misses.ToString(), _font, new Rectangle(30, 80, Resources.Scoreboard.Width, Resources.Scoreboard.Height), Color.Black, flags);
            TextRenderer.DrawText(dc, "Total Shots :" + totalshots.ToString(), _font, new Rectangle(30, 110, Resources.Scoreboard.Width, Resources.Scoreboard.Height), Color.Black, flags);
            TextRenderer.DrawText(dc, "Accuracy :" + accuracy.ToString("F0") + "%", _font, new Rectangle(30, 140, Resources.Scoreboard.Width, Resources.Scoreboard.Height), Color.Black, flags);
            if (FrameRate == 15)
            {
                TextRenderer.DrawText(dc, "Skill Level : Noob", _font, new Rectangle(30, 170, Resources.Scoreboard.Width, Resources.Scoreboard.Height), Color.Black, flags);
            }
            else if (FrameRate == 12)
            {
                TextRenderer.DrawText(dc, "Skill Level : Decent", _font, new Rectangle(30, 170, Resources.Scoreboard.Width, Resources.Scoreboard.Height), Color.Black, flags);
            }
            else if (FrameRate == 10)
            {
                TextRenderer.DrawText(dc, "Skill Level : Pro", _font, new Rectangle(30, 170, Resources.Scoreboard.Width, Resources.Scoreboard.Height), Color.Black, flags);
            }
            else if (FrameRate == 8)
            {
                TextRenderer.DrawText(dc, "Skill Level : Ace", _font, new Rectangle(30, 170, Resources.Scoreboard.Width, Resources.Scoreboard.Height), Color.Black, flags);
            }
            else if (FrameRate == 5)
            {
                TextRenderer.DrawText(dc, "Skill Level : legend", _font, new Rectangle(30, 170, Resources.Scoreboard.Width, Resources.Scoreboard.Height), Color.Black, flags);
            }


            base.OnPaint(e);
        }

        private void shooter_MouseMove(object sender, MouseEventArgs e)
        {
#if my_Debug
            _cursX = e.X;
            _cursY = e.Y;

            this.Refresh();
#endif
        }

        private void shooter_MouseClick(object sender, MouseEventArgs e)
        {   
            
                if (e.X >= this.Width - Resources.Sign.Width - 100  && e.X <= this.Width - 100 && e.Y >= (this.Height / 4) +42  && e.Y < (this.Height /4) + 56) // Start Button Hotspot
                {
                    TimerGameLoop.Start();
                }
                else if (e.X >= this.Width - Resources.Sign.Width - 100 && e.X <= this.Width - 100 && e.Y >= (this.Height /4) + 66 && e.Y < (this.Height / 4) + 80) // Stop Button Hotspot
                {
                    TimerGameLoop.Stop();
                }
                else if (e.X >= this.Width - Resources.Sign.Width - 100 && e.X <= this.Width - 100 && e.Y >= (this.Height /4) + 90 && e.Y < (this.Height / 4) + 102) // Reset Button Hotspot
                {
                    hits = 0;
                    misses = 0;
                    totalshots = 0;
                    accuracy = 0;
                    FrameRate = 15;
                    TimerGameLoop.Stop();
                    this.Refresh();
                }
                else if (e.X >= this.Width - Resources.Sign.Width - 100 && e.X <= this.Width - 100 && e.Y >= (this.Height /4) + 110 && e.Y < (this.Height /4) + 125) // Start Button Hotspot
                {
                    TimerGameLoop.Stop();
                    this.Dispose();
                }
                else if(_mole.Hit(e.X, e.Y))
                {
                    splat = true;
                    _splat.Left = _mole.Left - Resources.Splat.Width / 4;
                    _splat.Top = _mole.Top - Resources.Splat.Height / 4;
                    hits++;
                   
                }
                else
                {
                    misses++;
                }
            totalshots = hits + misses;
            FireGun();
            if (totalshots > 0)
            {
                accuracy = ((double)hits / (double)totalshots) * 100;
            }

            if(totalshots % 20 ==0 && accuracy >= 75)
            {
                FrameRate = 5; // Difficulty Very Hard
            }else if (totalshots % 20 == 0 && accuracy >= 50)
            {
                FrameRate = 8; // Difficulty Hard
            }
            else if (totalshots % 20 == 0 && accuracy >= 35)
            {
                FrameRate = 10; // Difficulty Medium
            }
            else if (totalshots % 20 == 0 && accuracy >= 25)
            {
                FrameRate = 12; // Difficulty Easy
            }
            else  if(totalshots % 20 == 0 && accuracy < 25)
            {
                FrameRate = 15; // Difficulty Very Easy
            }


        }

        private void FireGun()
        {
            SoundPlayer simplesound = new SoundPlayer(Resources.Shotgun);
            simplesound.Play();
        }
    }
}
