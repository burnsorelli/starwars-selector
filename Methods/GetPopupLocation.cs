using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xwing.Methods
{
    class GetPopupLocation
    {
        private static int _xLocation;
        private static int _yLocation;

        public static Tuple<int,int> GetLocation(Panel _container)
        {
            Form _wholeForm = Styling.WholeForm.TheForm;
            _xLocation = (_wholeForm.Width - _container.Width) / 2;
            _yLocation = (_wholeForm.Height - _container.Height) / 2;

            return Tuple.Create(_xLocation, _yLocation);
        }
    }
}
