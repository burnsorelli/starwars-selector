using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Xwing.PaintEventHandlers
{
    class DrawBorder
    {
        internal static void Draw(object sender, EventArgs e, Panel _panel, int _thickness)
        {
            Graphics graphicobj = _panel.CreateGraphics();
            Pen mypen = new Pen(Color.Black, _thickness);
            var _internalWidth = _panel.ClientSize.Width;
            var _internalHeight = _panel.ClientSize.Height;
            Rectangle myRectangle = new Rectangle(0, 0, _internalWidth, _internalHeight);
            graphicobj.DrawRectangle(mypen, myRectangle);
            graphicobj.Dispose();
            mypen.Dispose();
        }

        internal static void Draw(object sender, EventArgs e, Label _label, int _thickness)
        {
            Graphics graphicobj = _label.CreateGraphics();
            Pen mypen = new Pen(Color.Black, _thickness);
            var _internalWidth = _label.ClientSize.Width;
            var _internalHeight = _label.ClientSize.Height;
            Rectangle myRectangle = new Rectangle(0, 0, _internalWidth, _internalHeight);
            graphicobj.DrawRectangle(mypen, myRectangle);
            graphicobj.Dispose();
            mypen.Dispose();
        }

    }
}
