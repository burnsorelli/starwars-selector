using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Xwing.EventHandlers
{
    class MouseHoverImage
    {
        private static Panel tmpPanel = new Panel();
        private static int _padding = 10;
        private static int _maxWidth = 300;
        private static int _maxHeight = 420;
        public static void image_MouseHover(object sender, EventArgs e)
        {
            // Check if there is another pic with _dual at the end
            var _widthForm = Styling.WholeForm.FormInternalWidth;
            var _form = Styling.WholeForm.TheForm;
            PictureBox tmpPictureBox = (PictureBox)sender;
            Image img = tmpPictureBox.Image;
            int imgWidth = img.Width;
            int imgHeight = img.Height;
            var mousePos = _form.PointToClient(Cursor.Position);
            int mouseX = mousePos.X;
            int mouseY = mousePos.Y;

            tmpPanel.Visible = true;
            tmpPanel.Size = new Size(_maxWidth, _maxHeight);

            if (mouseX + _padding + _maxWidth < _widthForm)
            {
                tmpPanel.Location = new Point(mouseX + _padding, 100);
            }
            else
            {
                tmpPanel.Location = new Point(mouseX - _padding - _maxWidth, 100);
            }

            PictureBox tmpPic = new PictureBox();
            tmpPic.Size = new Size(_maxWidth, _maxHeight);
            tmpPic.SizeMode = PictureBoxSizeMode.StretchImage;
            tmpPic.Location = new Point(0, 0);
            tmpPic.BackColor = Color.Black;
            tmpPic.Image = img;
            tmpPanel.Controls.Add(tmpPic);
            Styling.WholeForm.TheForm.Controls.Add(tmpPanel);
            tmpPanel.BringToFront();
        }
        public static void image_MouseLeave(object sender, EventArgs e)
        {
            tmpPanel.Controls.Clear();
            tmpPanel.Visible = false;
        }
    }
}
