using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp18
{
    public class MyRectangle
    {
        private Rectangle rect;
        private int thick;
        private bool isSolid;

        public MyRectangle()
        {
            rect = new Rectangle();
            thick = 1;
            isSolid = true;

        }

        public void setRect(Point start, Point finish, int thick, bool isSolid)
        {
            rect.X = Math.Min(start.X, finish.X);
            rect.Y = Math.Min(start.Y, finish.Y);

            rect.Height = Math.Abs(finish.Y - start.Y);
            rect.Width = Math.Abs(finish.X- start.X);

            this.thick= thick;
            this.isSolid = isSolid;
        }

        public Rectangle getRect()
        {
            return rect;
        }

        public int getThick()
        {
            return thick;
        }

        public bool getSolid()
        {
            return isSolid;
        }
    }
}
