using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Xwing.Styling
{
    class WholeForm
    {
        public static Form TheForm;
        private static int _width_form = 800;
        private static int _height_form = 600;
        public static int FormInternalHeight;
        public static int FormInternalWidth;

        public static void GetElements()
        {
            TheForm.Size = new Size(_width_form, _height_form);
            TheForm.Text = "Star Wars X-wing Miniatures";
            
            FormInternalWidth = TheForm.ClientSize.Width;
            FormInternalHeight = TheForm.ClientSize.Height;
        }
    }
}
