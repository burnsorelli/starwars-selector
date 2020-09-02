using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xwing.Methods
{
    class ControlsActive
    {
        public static void DisableControls(Panel _panel)
        {
            var _form = Styling.WholeForm.TheForm;

            foreach (Control c in _form.Controls)
            {
                c.Enabled = false;
                //DisableControls(c);
            }

            _panel.Enabled = true;

        }

        public static void EnableControls()
        {
            var _form = Styling.WholeForm.TheForm;

            foreach (Control c in _form.Controls)
            {
                c.Enabled = true;
                //DisableControls(c);
            }
        }
    }
}
